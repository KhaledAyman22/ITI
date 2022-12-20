delete from Department
where dept_id=100

update Department
set dept_id=1
where dept_id=100

update student
set dept_id=NUll
where dept_id=100

update Instructor
	set dept_id=NULL
where dept_id=100

drop table student

delete from student
where

truncate table student

----------------------
--insert based on select
insert into cairoStud(st_id,st_fname)
select id,name
from mansouraStud
-------------------------
--join +DML
--subquery +DML
delete from Stud_Course
where st_id in (select st_id from student
                where st_address='cairo')
---------------------
isnull
coalesce
Agg Functions
getdate()

select st_fname+' '+convert(varchar(2),st_age)
from student

select 'stud name= '+st_fname+' &age= '+convert(varchar(2),st_age)
from student

select isnull(st_fname,'')+' '+convert(varchar(2),isnull(st_age,0))
from student

select concat(st_fname,' ',st_age)
from student

select db_name()

select suser_name()
 

 --Agg 
 --group by
 --having
 --subquery
 --union
 --data types
 --EEDR
 --












