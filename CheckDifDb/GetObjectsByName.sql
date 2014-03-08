use CheckDifDb
go

--drop function dbo.GetObjectsByName
alter function dbo.GetObjectsByName(
  @name varchar(100)
)
returns table
as return (
  select top 30 
    --name = '[' + s.name + '].[' + o.name + ']'
    name = s.name + '.' + o.name
  from sys.objects o
    inner join sys.schemas s on s.schema_id = o.schema_id
  where 
    o.type in ('P', 'FN', 'IF')
    and o.name like '%' + @name + '%'
)
go

return

select * from dbo.GetObjectsByName('Test')