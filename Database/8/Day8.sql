create clustered index i2
on student(st_fname)

create nonclustered index i2
on student(st_fname)

create nonclustered index i3
on student(st_address)

select *
from student
where st_id=1

select *
from tab5
where st_id=1

---> Primary key constraint ===> clustered index
---> unique constraint ==== ===>nonclustered index

create table Mydata
(
 id int Primary key,
 name varchar(20),
 sal int unique,
 overtime int unique
)


create unique index i4   ---->unique constraint + nonclustered index
on student(st_age)

create nonclustered index i4   
on student(st_age)


select * from student
where st_age=20

--Index
--Pivoting
--Temp tables
---->types of tables
---->physical table
create table exam
(
 eid int,
 numofQ int,
 Edate date
)

drop table exam

---->table variable
declare @exam table
(
 eid int,
 numofQ int,
 Edate date
)
insert into @exam values(1,7,'1/1/2023')
select * from @exam

select * from @exam
---------------------------------
--->local tables     session based table
create table #exam
(
 eid int Primary key,
 numofQ int,
 Edate date
)

--->Global tables    shared tables
create table ##exam
(
 eid int,
 numofQ int,
 Edate date
)

-------------------------------------
select * from student

Create view Vstuds
as
	Select *
	from student

--calling
select * from Vstuds

create view hr.Vcairo(sid,sname,sadd)
as
	select st_id,st_fname,st_address
	from Student
	where St_Address='cairo'

--
select * from vcairo

select sname from vcairo

drop view vcairo

alter schema hr transfer vcairo

alter schema dbo transfer hr.vcairo


create view valex
as
   select st_id,st_fname,st_address
   from Student
   where st_address='alex'

select * from valex

create view vCairo_alex
as
select * from valex
union all
select * from vcairo

--->Complex queries

alter view vjoin (sid,sname,did,dname)
with encryption
as
select st_id,st_fname,d.dept_id,dept_name
from Student s inner join Department d
	on d.Dept_Id =s.Dept_Id

select * from vjoin

select sname,dname from vjoin

Sp_helptext 'vjoin'

create view vgrades
as
select sname,dname,grade
from vjoin v inner join Stud_Course sc
	on v.sid=sc.St_Id

--DML  view
-------View   One table
alter view valex
as
   select st_id,st_fname,st_address
   from Student
   where st_address='alex'
   with check option

insert into valex
values(2000,'ahmed','alex')

insert into valex
values(2100,'ahmed','cairo')

-------view   Multi table
alter view vjoin (sid,sname,did,dname)
with encryption
as
select st_id,st_fname,d.dept_id,dept_name
from Student s inner join Department d
	on d.Dept_Id =s.Dept_Id

--Delete XXXXXX
1,ahmed,20,unix  delete

--insert   --update
insert into vjoin(sid,sname)
values(44,'ahmed')

insert into vjoin(did,dname)
values(600,'cloud')

insert into vjoin
values(44,'ahmed',600,'cloud')

update vjoin
	set sname='eman',dname='hr'
where sid=1


update vjoin
	set sname='eman'
where sid=1

-------------------------------------
create table Lastt
(
 Lid int,
 Lname varchar(20),
 Xval int
)

create table Dailyt
(
 did int,
 dname varchar(20),
 Yval int
)




