using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckDif
{
    public partial class fmMain : Form
    {
        DbObjects dbo = new DbObjects();

        private bool lSearchInProgress = false; 
        
        public fmMain()
        {
            InitializeComponent();
            cbObjects.Text = "add";
        }

        private void OnSearchComplete()
        {
            tbInfo.Text += "Search end\r\n";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (lSearchInProgress) return;
            if ((cbObjects.Text == null) || (cbObjects.Text.Length < 3))
            {
                MessageBox.Show("Text should contain 3 or more symbols");
                return;
            }

            tbInfo.Text += "Search start\r\n";
            
            lSearchInProgress = true;
            Task searchTask = dbo.SearchAsync(cbObjects.Text);
            await searchTask;
            lSearchInProgress = false;

            tbInfo.Text += "Search end\r\n";
            cbObjects.Items.Clear();
            List<String> objects = dbo.Objects();
            if (objects != null)
            {
                foreach (String s in objects)
                {
                    cbObjects.Items.Add(s);
                }
            }
        }
    }
}
