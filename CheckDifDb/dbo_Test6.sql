create function dbo.Test6(@p1 int)
returns table
as
  return (
    select a = 1, b = 2
  )
go