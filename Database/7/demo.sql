Declare @x int=(select avg(st_age) from student)

select @x=90

set @x=80

select @x

declare @y int
select @y=st_age from student
where st_id=1
select @y

declare @y int
select @y=st_age from student
where st_id=-1
select @y

declare @y int
select @y=st_age from student
where st_address='cairo'
select @y

--Arrays   --table variable
Declare @t table(col1 int)  ----> 1D array of int
insert into @t
values(1),(5),(8),(9)
select * from @t

Declare @t table(col1 int)  ----> 1D array of int
insert into @t
select st_age from student where st_address='cairo'
select * from @t
select count(*) from @t

Declare @t table(col1 int,col2 varchar(20))  ----> 2D array 
insert into @t
select st_age,st_fname from student where st_address='cairo'
select * from @t
select count(*) from @t


declare @z int,@name varchar(20)
select @z=st_age,@name=st_fname from student
where st_id=3
select @z,@name

declare @did int
update student
	set st_fname='omar',@did=dept_id
where st_id=4
select @did

-----------------------------
SElect @@servername

select @@version


update student set st_age+=1
select @@rowcount

select * from student where st_age>25
select @@rowcount
select @@rowcount

select * from student where st_age>25
go
select @@error

insert into test values('khalid')
select @@identity
------------------------------------------------------
--control of flow statments
--if
declare @x int
update student	set st_age +=1
set @x=@@ROWCOUNT
if @x<0
	begin
		select 'no rows affected'
		select 'welcome to ITI'
	end
else 
	begin
		select 'multi rows affected'
	end

--begin
--end
--if exits   if not exists

if exists(select name from sys.tables where name='staff')
	select 'table is exited'
else
create table staff
(
 sid int,
 sname varchar(20)
)


if not exists( select top_id from course where top_id=1)
	delete from topic where top_id=1
else
	select 'table has relation'

begin try
	delete from topic where top_id=1
end try
begin catch
	select 'error'
	--select ERROR_LINE(),ERROR_MESSAGE(),ERROR_NUMBER()
end catch

--while
declare @x int=10
while @x<=20
	begin 
		set @x+=1
		if @x=14
			continue
		if @x=17
			break
			select @x
	end
--------------------------------
select ins_name,salary,
               case
					when salary>=3000 then 'high salary'
					when salary<3000 then 'low'
					else 'No data'
			   end as sal
from instructor

select ins_name,iif(salary>=3000,'high','low')
from instructor

update instructor
	set salary=salary*1.20

update instructor
	set salary=
			case
				when salary>3000 then salary*1.20
				else salary*1.30
			end

--choose
--waitfor
-------------------------------------------------
--windowing function
--lead lag first_value  last_value

------------------
--user defined function
---Scalar function
--prototype    Returnvalue    functionname  Parameters
--string getsname(int id)   
alter function getsname(@id int) 
returns varchar(30)
	begin
		declare @name varchar(30)
		    select @name=st_fname from Student
			where st_id=@id
		return @name
	end

--calling
select dbo.getsname(4)

select * from Company_SD.dbo.project

alter schema hr transfer getsname

alter schema dbo transfer hr.getsname

drop function getsname

------------------------------------------
create function getInst(@did int)
returns table
as
	return 
		(
		 select ins_name,salary*12 as annual
		 from instructor
		 where dept_id=@did
		)

--calling
select * from getinst(10)

select ins_name from getinst(10)

select sum(annual) from getinst(10)

--multi
create function getstuds(@format varchar(20))
returns @t table
			(
			 id int,
			 name varchar(30)
			)
as
	begin
		if @format='first'
			insert into @t
			select st_id,st_fname from Student
		else if @format='Last'
			insert into @t
			select st_id,st_Lname from Student
		else if @format='fullname'
			insert into @t
			select st_id,concat(st_fname,' ',st_lname) from Student
		return
			
	end

--calling
select * from getstuds('fullname')

select * from getstuds('first')
-----------------------------------------------
--batch   --script  transaction

--batch  set of independent queries

insert
update
delete


--ddl  --script
create table
go
drop table
go
create rule
go
sp_bindrule

--transaction
--set of dependent queries
--as single unit of work


insert
update
delete


create table parent (pid int Primary key)

create table child (cid int foreign key references parent(pid)) 

insert into parent values(1)
insert into parent values(2)
insert into parent values(3)
insert into parent values(4)
insert into parent values(5)

insert into child values(1)
insert into child values(6)
insert into child values(2)

begin transaction
	insert into child values(1)
	insert into child values(3)
	insert into child values(2)
rollback

begin try
	begin transaction
		insert into child values(1)
		insert into child values(390)
		insert into child values(2)
	commit
end try
begin catch
	rollback
end catch


select * from child
delete from child

--truncate

begin transaction
	insert
	truncate 
	update   --rollback

--transactions Properties ACID
--------------------------------------
declare @col varchar(20)='*',@t varchar(40)='instructor'
execute('select '+@col+' from '+@t)


select * from student

select 'select * from student'

execute('select * from student')






--variables
--control of flow statments
--functions
--batch   script  transaction








