delete from dept where did=10

update dept set did=100
where did=20

--SQLServer Schema
--SchemaName.objectName
--logical group of objects

create schema HR

create schema sales

alter schema HR transfer Student

alter schema HR transfer Instructor

alter schema sales transfer Department

select * from student   --dbo.student

select * from HR.student

create table student
(
 eid int,
 ename varchar(20)
)

select * from Student


create table sales.student
(
 eid int,
 ename varchar(20)
)

--Security
---->create Login (mansstud)
---->user(ITI)
---->schema    student,instructor


Select *
from sales.EmployeeDepartmentHistory

--shortcut
--sysnonym
create synonym EmpDH
for  HumanResources.EmployeeDepartmentHistory

select * from EmpDH

alter schema dbo transfer hr.instructor
alter schema dbo transfer hr.student

-----------------------------------------------------
--builtin functions
--convert   --cast
select convert(varchar(50),getdate())
select cast(getdate() as varchar(50))

select convert(varchar(50),getdate(),101)
select convert(varchar(50),getdate(),102)
select convert(varchar(50),getdate(),103)
select convert(varchar(50),getdate(),104)
select convert(varchar(50),getdate(),105)

--format
select format(getdate(),'dd/MM/yyyy')
select format(getdate(),'dddd MMMM yyyy')
select format(getdate(),'ddd MMM yy')
select format(getdate(),'dddd')
select format(getdate(),'MMMM')
select format(getdate(),'hh:mm:ss')
select format(getdate(),'hh')
select format(getdate(),'hh tt')
select format(getdate(),'dd/MM/yyyy hh:mm:ss tt')

select format(getdate(),'dd')
select day(getdate())

select eomonth(getdate())

select format(eomonth(getdate()),'dd')

select format(eomonth(getdate()),'dddd')

select eomonth(getdate(),1)
select eomonth(getdate(),-2)

--string data
select upper(st_fname),lower(st_lname)
from Student

select len(st_fname),st_fname
from student

select substring(st_fname,1,3)
from Student

select substring(st_fname,3,3)
from Student

select *
from Student
where substring(st_fname,1,1)='a'

select *
from Student
where st_fname like 'a%'

select substring(st_fname,1,len(st_fname)-1)
from Student

--math
sin cos tan log

select power(salary,2)
from Instructor

select top(1) st_fname
from student
order by len(st_fname) desc

--create DB (Properties)
--SQLServer Schema
--built in functions
--DB integrity  (constraints_rules)


create table Depts
(
 did int Primary key,
 Dname varchar(20)
)

create table emps
(
 eid int identity(1,1),
 ename varchar(20),
 eadd varchar(20) default 'cairo',
 hiredate date default getdate(),
 sal int,
 overtime int,
 netsal as(isnull(sal,0)+isnull(overtime,0)) persisted,
 BD date,
 age as year(getdate())-year(BD),
 hour_rate int not null,
 gender varchar(1),
 dnum int,
 constraint c1 primary key(eid,ename),
 constraint c2 unique(sal),
 constraint c3 unique(overtime),
 constraint c4 check(sal>1000),
 constraint c5 check(overtime between 100 and 500),
 constraint c6 check(eadd in('alex','mansoura','cairo')),
 constraint c7 check(gender='f' or gender='M'),
 constraint c8 foreign key(dnum) references depts(did)
      on delete set NULL on update cascade
)

alter table emps drop constraint c4

alter table emps add constraint c9 check(hour_rate>1000)

--constraint --->new data  XXXX
--constraint --->shared tables  XXXX
--constraint ---> new data type  XXXX

alter table instructor add constraint c10 check(salary>1000) 

--Rule
create rule r1 as @x>1000

sp_bindrule r1,'instructor.salary'
sp_bindrule r1,'emps.sal'

sp_unbindrule 'instructor.salary'
sp_unbindrule 'emps.sal'

drop rule r1

-------------------------------------------------
--default
create default def1 as 5000

sp_bindefault def1,'instructor.salary'

sp_unbindefault 'instructor.salary'

drop default def1

-------------------------------------------------->
--create custom (new)   datatype 
--int      value>1000   default 5000
sp_addtype newdt,'int'   --4 bytes

create rule r1 as @x>1000

create default def1 as 5000

sp_bindrule r1,newdt

sp_bindefault def1,newdt

create table mystaff
(
 sid int,
 sname varchar(20),
 salary newdt
)
-----------------------------------------------------


















