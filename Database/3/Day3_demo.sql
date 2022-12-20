Select  St_fname, Dept_name
from Student , Department

Select  St_fname, Dept_name
from Student cross join Department

Select  St_fname, Dept_name
from Student , Department
where Department.Dept_Id = Student.Dept_Id

Select  St_fname, Dept_name
from Student S , Department D
where D.Dept_Id = S.Dept_Id

Select  St_fname, Dept_name, D.Dept_Id
from Student S , Department D
where D.Dept_Id = S.Dept_Id

Select  St_fname, Dept_name
from Student S , Department D
where D.Dept_Id = S.Dept_Id and st_address='alex'
order by dept_name

Select  *
from Student S , Department D
where D.Dept_Id = S.Dept_Id

Select  st_fname,D.*
from Student S , Department D
where D.Dept_Id = S.Dept_Id 

Select  st_fname,Dept_Name
from Student S inner join Department D
on D.Dept_Id = S.Dept_Id

Select  st_fname,Dept_Name
from Student S inner join Department D
on D.Dept_Id = S.Dept_Id
where st_age<25

Select  st_fname,Dept_Name
from Student S inner join Department D
  on D.Dept_Id = S.Dept_Id and st_age<25
------------------------------------------
--outer
Select  st_fname,Dept_Name
from Student S left outer join Department D
on D.Dept_Id = S.Dept_Id


Select  st_fname,Dept_Name
from Student S right outer join Department D
on D.Dept_Id = S.Dept_Id

Select  st_fname,Dept_Name
from Student S full outer join Department D
on D.Dept_Id = S.Dept_Id

-------------------------
--self join
Select X.St_Fname as studname , Y.St_Fname as Leader
From Student X , Student Y
Where Y.St_Id = X.St_super --(Y,pk,parent.Leaders) (x,fk,child,studs)

Select X.st_fname as studentname,Y.*
From Student X , Student Y
Where Y.St_Id = X.St_super

Select distinct Y.st_fname
From Student X , Student Y
Where Y.St_Id = X.St_super
-----------------------------------------
--Join + Multi tables
Select st_fname, crs_name ,grade
from Student S, Stud_Course SC , Course C
where S.St_Id = SC.St_Id and
	  C.Crs_Id =SC.Crs_Id

Select st_fname, crs_name ,grade
from Student S inner join Stud_Course SC 
    on S.St_Id = SC.St_Id 
inner join	
Course C	
	on C.Crs_Id =SC.Crs_Id

Select st_fname, crs_name ,grade,dept_name
from Student S inner join Stud_Course SC 
    on S.St_Id = SC.St_Id 
inner join	
Course C	
	on C.Crs_Id =SC.Crs_Id
inner join
Department d
	on d.Dept_Id=s.Dept_Id

--Join + DML
--update + join
update Stud_Course
	set grade+=10

update Stud_Course
	set grade+=10
where st_id=8

update Stud_Course
	set grade+=10
from Student S , Stud_Course SC
where S.St_Id=sc.St_Id and St_Address='mansoura'

update SC
	set grade+=10
from Student S , Stud_Course SC
where S.St_Id=sc.St_Id and St_Address='mansoura'
--------------------------------------------------
--like
select *
from Student
where st_fname ='ahmed' 

select *
from Student
where st_fname like '_a%' 

_ one char
% zero Or More char

'a%h'
'%d_'
'____'
'____%'
'ahm%'
'[ahm]%'  or
'[^ahm]%' not or
'[165]%'
'[a-h]%'   --range
'[^a-h]%'   --not in range
'%[%]'      sdfsdfsdfd%
'%[_]%'      ahmed_ali
'[_]%[_]'   _ahmed_
---------------------------------------
--built functions
select getdate()

select day(getdate())
select month(getdate())
select year(getdate())

select Dept_Name , Manager_hiredate
from Department

select Dept_Name , year(Manager_hiredate)
from Department

select Dept_Name , year(getdate())-year(Manager_hiredate)
from Department

select st_fname
from Student
where st_fname is not null

select isnull(st_fname,'')
from Student

select isnull(st_fname,'stud has no name')
from Student

select isnull(st_fname,st_lname)
from Student

select coalesce(st_fname,st_lname,st_address,'No data')
from Student

select st_fname+' '+st_age
from Student

select st_fname+' '+st_Lname
from Student


select st_fname+' '+convert(varchar(20),st_age)
from Student

select isnull(st_fname,'')+' '+convert(varchar(20),isnull(st_age,0))
from Student

select concat(st_fname ,' ',st_age)
from Student

--------------------------
drop table student   --ddl   data&metadata

delete from student  --DML  data --slower --log  --rollback  --where
                     --child   parent
truncate table student --data  --faster --sometimes  --can't rollback
                       --child --reset identity

create table testing
(
 eid int Primary key identity(1,1),   --autonIncreament
 ename varchar(20)
)

insert into testing values('khalid')

select * from  testing

delete from testing

truncate table testing

drop table testing

create table testing
(
 eid int identity(100,10),   --autonIncreament
 SSN int Primary key,
 ename varchar(20)
)








