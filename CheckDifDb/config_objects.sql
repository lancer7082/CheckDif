use CheckDifDb
go

create procedure dbo.Test1(@p1 int)
as
begin
  print 'dbo.Test1'
end
go

create procedure dbo.Test2(@p1 int, @p2 int)
as
begin
  print 'dbo.Test2'
end
go

create procedure dbo.Test3
as
begin
  print 'dbo.Test3'
end
go

create procedure dbo.Test4(@p1 varchar(max))
as
begin
  print 'dbo.Test4'
end
go

create function dbo.Test5(@p1 int)
returns int
begin
  --print 'dbo.Test5'
  return 1
end
go

create function dbo.Test6(@p1 int)
returns table
as
  return (
    select a = 1, b = 2
  )
go
