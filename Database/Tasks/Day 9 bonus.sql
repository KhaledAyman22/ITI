go
create proc _proc_GETMONTH(@date date)
as
	begin
		declare @month varchar(20)

		select @month = DATENAME(month,@date)
		select @month
	end
-------------------------------------------------------
go
create proc _proc_GetInBetween(@x int, @y int)
as
	begin
		declare @t table (num int)
		declare @c int = @x + 1   
			while(@c<@y)
			begin
				insert into @t values(@c)
				set @c = @c + 1
			end

			select * from @t
	end
-------------------------------------------------------
go
create proc _proc_GetDep_Name(@id int)
as
	begin
		select St_Fname+' '+St_Lname as 'Full Name', Department.Dept_Name as 'Department Name'
		from Student join Department on Student.Dept_Id = Department.Dept_Id
		where Student.St_Id = @id
	end
-------------------------------------------------------
go
create proc _proc_GetMessage(@id int)
as
begin
		declare @fn varchar(50), @ln varchar(50)
		select @fn = s.St_Fname, @ln = s.St_Lname
		from Student s
		where s.St_Id = @id

		if(@fn=null and @ln=null)
			select 'First name & last name are null'
		else if(@fn=null and @ln!=null)
			select 'first name is null'
		else if(@fn!=null and @ln=null)
			select 'last name is null'
		else
			select 'First name & last name are not null'
end

-------------------------------------------------------
go
create proc _proc_GetManagerData(@id int)
as
	begin
		select d.Dept_Name as 'Department Name', Ins_Name as 'Name', d.Manager_hiredate as 'Hire Date'
		from Department d join Instructor i on d.Dept_Manager = i.Ins_Id
		where i.Ins_Id = @id
	end

-------------------------------------------------------
go
create proc _proc_GetDynamic(@string varchar(50))
as
	begin
		declare @t table (name varchar(200))

		if (@string='first name')
			insert into @t
			select isnull(s.St_Fname, 'UNKNOWN')
			from student s	
		
		else if (@string='last name') 
			insert into @t
			select isnull(s.St_Lname, 'UNKNOWN') 
			from student s	
		
		else if (@string='full name')
			insert into @t
			select isnull(s.St_Fname, 'UNKNOWN') + ' ' + isnull(s.St_Lname, 'UNKNOWN') 
			from student s	

		select * from @t
	end
-------------------------------------------------------

go
_proc_GetDynamic 'first name'
go
_proc_GetManagerData 10
go
_proc_GetMessage 1
go
_proc_GetDep_Name 10
go
_proc_GetInBetween 1, 10 
go
_proc_GETMONTH '2000.5.4'

go

------  
CREATE TRIGGER PreventAlter   
ON DATABASE   
FOR ALTER_TABLE   
AS   
   PRINT 'You must disable Trigger "safety" to drop or alter tables!'   
   ROLLBACK;


 alter table student add test int;