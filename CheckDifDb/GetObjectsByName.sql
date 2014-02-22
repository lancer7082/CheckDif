create function dbo.GetObjectsByName(
  @name varchar(100)
)
returns table
as return (
  select top 10 o.name
  from sys.sysobjects o
  where o.type = 'P'
    and o.name like '%' + @name + '%'
)
go

select name from dbo.GetObjectsByName('add')