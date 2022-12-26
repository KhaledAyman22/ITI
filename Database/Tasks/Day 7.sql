create function GETMONTH(@date date)
returns varchar(20)
as
begin
		declare @month varchar(20)

		select @month = DATENAME(month,@date)
		return @month
end

select dbo.GETMONTH(GETDATE()) --
-------------------------------------------------------
create function GetInBetween(@x int, @y int)
returns @t table (num int)
as
	begin
	declare @c int = @x + 1   
		while(@c<@y)
		begin
			insert into @t values(@c)
			set @c = @c + 1
		end

		return
	end


select * from dbo.GetInBetween(1,10)
-------------------------------------------------------
create function GetDep_Name(@id int)
returns table
return(
	select St_Fname+' '+St_Lname as 'Full Name', Department.Dept_Name as 'Department Name'
	from Student join Department on Student.Dept_Id = Department.Dept_Id
	where Student.St_Id = @id
)

select * from dbo.GetDep_Name(1)
-------------------------------------------------------
create function GetMessage(@id int)
returns varchar(100)
as
begin
		declare @fn varchar(50), @ln varchar(50)
		select @fn = s.St_Fname, @ln = s.St_Lname
		from Student s
		where s.St_Id = @id

		if(@fn=null and @ln=null)
			return 'First name & last name are null'
		else if(@fn=null and @ln!=null)
			return 'first name is null'
		else if(@fn!=null and @ln=null)
			return 'last name is null'

		return 'First name & last name are not null'
end

select dbo.GetMessage(14)
-------------------------------------------------------
create function GetManagerData(@id int)
returns table
return(
	select d.Dept_Name as 'Department Name', Ins_Name as 'Name', d.Manager_hiredate as 'Hire Date'
	from Department d join Instructor i on d.Dept_Manager = i.Ins_Id
	where i.Ins_Id = @id
)

select * from dbo.GetManagerData(1)
-------------------------------------------------------
create function GetDynamic(@string varchar(50))
returns @t table (name varchar(200))
as
	begin
	
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

		return
	end

select * from dbo.GetDynamic('first name')
-------------------------------------------------------
select s.St_Id, SUBSTRING(s.St_Fname,1, LEN(s.St_Fname) - 1)
from Student s
-------------------------------------------------------
delete from Stud_Course
from Stud_Course sc join Student s on sc.St_Id = s.St_Id join Department d on s.Dept_Id = d.Dept_Id
where d.Dept_Name = 'SD'
-------------------------------------------------------
-------------------------------------------------------
-------------------------------------------------------

begin try
	begin transaction
		declare @id int = 3001
		while(@id<6000)
		begin
			INSERT INTO Student (St_Id,St_Fname,St_Lname) 
			values (@id,'Jane','Smith')
			set @id = @id + 1
		end
	commit
end try

begin catch
	select 'ERROR'
	rollback
end catch