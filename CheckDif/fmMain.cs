using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace CheckDif
{
    public partial class fmMain : Form
    {
        #region Const
        //private const string CONN_STR_LOCAL = @"(localdb)\v11.0;Database=master;Integrated Security=true;";
        #endregion

        DbObjects dbo = null;
        FileObjects fo = null;

        private bool lSearchInProgress = false;
        private bool lFilterFilesInProgress = false;

        //Stages stage = Stages.CHOOSE_PATH;
       // private enum Stages { CHOOSE_PATH, CHOOSE_OBJECT, SHOW_DIF };
        
        public fmMain()
        {
            InitializeComponent();
            cbObjects.Text = "Test";
            cbFolder.Items.Add(@"f:\Projects\dotNet\CheckDif\CheckDifDb\");
            //cbFolder.Items.Add(@"f:\Temp\Files");
            cbConnStr.Items.Add(Settings.ConnStr);
            cbConnStr.SelectedIndex = 0;
            tbWinMergePath.Text = Settings.WinMergePath;
                //Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\WinMerge\WinMergeU.exe";

            dbo = new DbObjects(Settings.ConnStr);
            fo = new FileObjects();    
            //Settings.ConnStr = CONN_STR_LOCAL;
            //SetStage(Stages.CHOOSE_PATH);
        }

        //private void SetStage(Stages stage)
        //{
        //    cbFolder.Enabled = btnPickFolder.Enabled = (stage == Stages.CHOOSE_PATH);
        //    cbObjects.Enabled = btnSearchObjects.Enabled = (stage == Stages.CHOOSE_OBJECT);
        //    lsbFiles.Enabled = (stage == Stages.SHOW_DIF);
        //    this.stage = stage;
        //}

        //private void OnSearchComplete()
        //{
        //    tbInfo.Text += "Search end\r\n";
        //}

        //Поиск объектов в БД, содержащих строку name
        private async void SearchObjectsDb(string name)
        {
            if (lSearchInProgress) return;
            if (String.IsNullOrEmpty(name)) return;
            
            tbInfo.Text += "Search start\r\n";
            
            progressBar.Show();
            try
            {
                lSearchInProgress = true;
                Task searchTask = dbo.SearchAsync(cbObjects.Text);
                await searchTask;
            }
            finally
            {
                lSearchInProgress = false;
                progressBar.Hide();
            }

            tbInfo.Text += "Search end\r\n";

            cbObjects.Items.Clear();
            //List<string> objects = dbo.Objects;
            if (dbo.Objects != null)
            {
                foreach (String s in dbo.Objects)
                {
                    cbObjects.Items.Add(s);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (lSearchInProgress) return;

            if (String.IsNullOrEmpty(cbFolder.Text))
            {
                MessageBox.Show("Please choose folder");
                return;
            }

            if (String.IsNullOrEmpty(cbObjects.Text) || (cbObjects.Text.Length < 3))
            {
                MessageBox.Show("Text should contain 3 or more symbols");
                return;
            }

            SearchObjectsDb(cbObjects.Text);     
        }

        private void ShowFiles()
        {
            lsbFiles.Items.Clear();
            if (fo.Files != null)
            {
                foreach (FileWithObjects f in fo.Files)
                {
                    lsbFiles.Items.Add(f.FileName.PadRight(20) + " | " + String.Join(";", f.objects.ToArray()));
                }
            }
        }

        //Заполнение списка файлов
        private async void ListFiles(string path)
        {
            if (lFilterFilesInProgress) return;

            if (String.IsNullOrEmpty(path)) return;

            tbInfo.Text += "List files start\r\n";

            //List<FileWithObjects> files;
            progressBar.Show();
            try
            {
                lFilterFilesInProgress = true;
                Task<bool> searchTask = fo.ListAsync(path);
                bool result = await searchTask;
            }
            finally
            {
                lFilterFilesInProgress = false;
                progressBar.Hide();
            }

            tbInfo.Text += "List files end\r\n";

            ShowFiles();
        }

        private void cbFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListFiles(cbFolder.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Отбор файлов, содержащих объект
        private async void FilterFiles(string objectName)
        {
            if (lFilterFilesInProgress) return;

            if (String.IsNullOrEmpty(objectName)) return;

            tbInfo.Text += "Filter files start\r\n";

            List<FileWithObjects> result;
            progressBar.Show();
            try
            {
                lFilterFilesInProgress = true;
                Task<List<FileWithObjects>> searchTask = fo.FilterAsync(objectName);
                result = await searchTask;
            }
            finally
            {
                lFilterFilesInProgress = false;
                progressBar.Hide();
            }

            tbInfo.Text += "Filter files end\r\n";

            lsbFiles.Items.Clear();
            //List<FileWithObjects> files = fo.Files;
            if (result != null)
            {
                foreach (FileWithObjects f in result)
                {
                    lsbFiles.Items.Add(f.FileName);
                }
            }
        }

        private void cbObjects_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (String.IsNullOrEmpty(cbFolder.Text))
            //{
            //    MessageBox.Show("Please choose folder");
            //    return;
            //}

            if (String.IsNullOrEmpty(cbObjects.Text))
            {
                MessageBox.Show("Please choose object");
                return;
            }

            FilterFiles(cbObjects.Text);
        }

        //отображение расхождений
        private void ShowDif(string objectName, string path, string fileName)
        {
            string text = dbo.GetObjectText(objectName);
            string filePathDb = path + @"\" + objectName + ".sql.db";
            using (StreamWriter writer = new StreamWriter(filePathDb))
            {
                writer.Write(text);
                writer.Close();
            }

            String command = Settings.WinMergePath; 
                //Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\WinMerge\WinMergeU.exe";
            Process.Start(command, path + @"\" + fileName + " " + filePathDb);
        }

        private void btnShowDif_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cbFolder.Text))
            {
                MessageBox.Show("Please choose folder");
                return;
            }

            if (lsbFiles.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose file");
                return;
            }

            if (String.IsNullOrEmpty(cbObjects.Text))
            {
                MessageBox.Show("Please choose object");
                return;
            }

            ShowDif(cbObjects.Text, cbFolder.Text, lsbFiles.SelectedItem.ToString());
        }

        private void btnPickFolder_Click(object sender, EventArgs e)
        {
            dlgPickFolder.SelectedPath = cbFolder.Text;
            if (dlgPickFolder.ShowDialog() == DialogResult.OK)
            {
                string filePath = dlgPickFolder.SelectedPath;
                if (!cbFolder.Items.Contains(filePath))
                {
                    cbFolder.Items.Add(filePath);
                    cbFolder.Text = filePath;
                }
            }
        }
    }
}
