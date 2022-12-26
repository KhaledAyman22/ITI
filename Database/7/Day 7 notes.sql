--Declare var
declare @x int -- =val --
declare @x table(col1 int) -- 1D Array of ints
declare @x table(col1 int, col2 varchar(20)) -- 2D Array of ints and varchar

-- set var
set @x = 5
select @x = 5

-- uses
select @x = age from student where id = 1
update setudent set age = @x where id = 1

-- @@ for gloabal vars: servername, version, rowcount, error, identity

--@@error returns 0 or number --> error number
--@@identity returns null if no identity else th identity of the last select 

-- execute takes a query as string to run it

--if,else if, else
--{...} == begin...end


--if --not-- exists(select..from..where..)

--if u don't know what might acuse an error
--begin try ........... end try 
--begin catch select ERROR_LINE(), ERROR_MESSAGE(), ERROR_NUMBER() end catch 


--while begin end


--case 
select ins_name, case+1
					when salary >= 3000 then 'high'
					when salary < 3000 then 'low'
				else 'no data'

from Instructor

---iif choose waitfor SEARCH

--Functions
/*
create function /*[SCHEMA].*/FNAME(@id int)
returns int
as

/*SCALAR FUNCTION*/
	begin
		declare @age int

		select @age = age from Student where id = @id

		return @age
	end

/*INLINE FUNCTION*/
return(
	select * from Instructor where depid = @id
)

/*MULTI-STATMENT FUNCTION*/
returns @t table (id int, sname varchar(20)) --*--
as
	begin
		.....
		return
	end


--Functions can't manipulate real tables, it can only read
--Can't use execute *Dynamic Function* inside a function bec. of that
--System defined functions don't belong to any schema 
--delete function
drop FNAME

*/

--if truncate is executed inside a transaction it will be logged

--Transaction Props ACID
--ATOMIC CONSISTED ISOLATED DURABLE