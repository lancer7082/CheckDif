use master
go

--drop function dbo.GetObjectsByName
alter function dbo.GetObjectsByName(
  @name varchar(100)
)
returns table
as return (
  select top 30 name = '[sys].' + '[' + o.name + ']'
  from sys.sysobjects o
  where o.type = 'P'
    and o.name like '%' + @name + '%'
)
go

return

select * from dbo.GetObjectsByName('add')