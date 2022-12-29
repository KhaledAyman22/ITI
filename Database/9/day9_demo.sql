select * from student

create Procedure Selstud
as
select * from student

--calling
Selstud 
exec Selstud 
execute Selstud 

alter Proc hr.Getstbyadd @add varchar(20)
as
   select st_id,st_fname
   from Student
   where St_Address=@add

   --calling
hr.Getstbyadd 'cairo'
Getstbyadd 'alex'

alter schema hr transfer GEtstbyadd	

drop proc hr.getstbyadd

alter schema dbo transfer hr.GEtstbyadd	

---------------------------------------


alter Proc Deltopic @tid int
as
	if not exists(select top_id from course where top_id=@tid)
		delete from topic where top_id=@tid
	else
		select 'error'

Deltopic 30

--------------------------------------
alter Proc Sumdata @x int=200,@y int=100
as
   select @x+@y

Sumdata 6,8  --calling Parameters by Position
Sumdata @y=7,@x=10  --calling parameters by name
sumdata
sumdata 1
-------------------------------------
--return values
create Proc Getstbyadd @add varchar(20)
as
   select st_id,st_fname
   from Student
   where St_Address=@add


declare @t table(x int,y varchar(20))
insert into @t
execute Getstbyadd 'cairo'
select * from @t
select count(*) from @t

insert into test
execute Getstbyadd 'cairo'

------------------------------------
--return One value
create Proc Getdata @id int
as
	declare @age int
		select @age=st_age from Student
		where st_id=@id
	return @age

declare @x int
execute @x=Getdata 3
select @x

alter Proc Getdata @id int,@age int output,@name varchar(20) output
as
		select @age=st_age,@name=st_fname from Student
		where st_id=@id
	
declare @x int,@y varchar(20)
execute Getdata 1,@x output,@y output
select @x,@y
--------------------------------------------------
alter Proc Getdata @age int output,@name varchar(20) output
as
       	select @age=st_age,@name=st_fname from Student
		where st_id=@age
	
declare @x int=1,@y varchar(20)
execute Getdata @x output,@y output
select @x,@y
--------------------------------------------
--dynamic query
create Proc Getvalues @col varchar(20),@t varchar(20)
with encryption
as
   execute('select '+@col+' from '+@t)


Getvalues 'crs_name','course'
----------------------------------------------------------
--3 types of SP
--user defined SP
getstuds   getstbyadd sumdata

--Built-in SP
SP_bindrule  sp_unbindefault sp_helptext sp_addtype  sp_rename  sp_who  sp_helpconstraint

--Trigger
--special type of SP
--can't call
--implicit code  (fire)   action  [table]  insert   update  delete   [select  truncate]
--can't Parameter


insert into student(st_id,st_fname)
values(92,'ahmed')

create trigger t1
on student
after insert
as
	select 'welcome to ITI'


insert into student(st_id,st_fname)
values(98,'ahmed')

create trigger t2
on student
for update
as
	select getdate(),suser_name()


update student set st_age+=1

create trigger t3
on student
instead of delete
as
	select 'not allowed'


	delete from Student where st_id =98


create trigger t4
on department
instead of update,delete,insert
as
	select 'not allowed to modfiy for user='+suser_name()


alter table department disable trigger t4
alter table department enable trigger t4



update Department
	set Dept_Name='could'
where dept_id=10

alter trigger t5
on course
after update
as
	if update(crs_name)
		select 'welcome to ITI'
	

update course
	set crs_duration=100
where crs_id=-1
---------------------------------------------

create trigger t10
on course
after update
as
	select * from inserted
	select * from deleted

update course
	set crs_name='node',crs_duration=500,top_id=5
where crs_id=400


create trigger t100
on course
instead of delete
as
	select 'not allowed to delete coursename= '+(select crs_name from deleted)

delete from course where crs_id=1000

----------------------------------

create trigger t300
on student
after insert
as
	if format(getdate(),'dddd')='friday'
		begin
			select 'not allowed'
		delete from student where st_id =(select st_id from inserted)
		end


create trigger t300
on student
instead of insert
as
	if format(getdate(),'dddd')='friday'
		begin
			select 'not allowed'
		end
	else
		insert into Student
		select * from inserted

----------------------------------------------------
create table history
(
_user varchar(20),
_date date,
_oldid int,
_newid int
)

create trigger t90
on topic
instead of update
as
	if update(top_id)
		begin
			declare @old int,@new int
			select @old=top_id from deleted
			select @new=top_id from inserted
			insert into history
			values(suser_name(),getdate(),@old,@new)
		end


----------------------------------


update student
	set st_fname='ahmed'
output suser_name(),getdate(),inserted.st_id,deleted.st_id into history
where st_id=7


delete from student
output getdate() 
where st_id=92

----------------------------------------------------------
--XML
-------------------------
--for XML  (raw   auto  Explicit path)
--Open XML

select *
from Student
for xml raw('stud'),elements,Root('ITIstudents')
























































