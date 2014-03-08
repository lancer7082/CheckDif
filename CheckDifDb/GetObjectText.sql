use CheckDifDb
go

create procedure dbo.GetObjectText(
  @objectName sysname,
  @text nvarchar(max) output
)
as
begin
  set @text = ''
  declare @t table (line nvarchar(255))

  insert into @t(line)
  exec sp_helptext @objectName
  --'[sys].[sp_add_data_file_recover_suspect_db]'

  select @text += line /*+ char(13) + char(10)*/ from @t

  --select @text
end
go

return

declare @text nvarchar(max)
exec dbo.GetObjectText @objectName = '[sys].[sp_add_data_file_recover_suspect_db]', 
  @text = @text output
select @text