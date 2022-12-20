select salary
from Instructor

select sum(salary)
from Instructor

select count(ins_id)
from Instructor

select min(salary) as Min_val,Max(Salary) as Max_val
from Instructor

select count(*),count(st_id),count(st_fname),count(st_age)
from Student

select avg(st_age)
from student

select avg(isnull(st_age,0))
from student

select sum(st_age)/count(*)
from Student

select sum(salary),dept_id
from Instructor
group by dept_id



select sum(salary),d.dept_id,dept_name
from Instructor i inner join Department d
	on d.Dept_Id = i.Dept_Id
group by d.dept_id,Dept_Name

select count(*),st_address
from student
group by st_address

select count(*),dept_id
from student
group by dept_id

select count(*),dept_id,st_address
from student
group by dept_id,St_Address

select count(*),
from student
group by 


select sum(salary),dept_id
from Instructor
group by dept_id

select sum(salary),dept_id
from Instructor
where salary>1000
group by dept_id


select sum(salary),dept_id
from Instructor
group by dept_id

select sum(salary),dept_id
from Instructor
group by dept_id
having sum(salary)>20000

select sum(salary),dept_id
from Instructor
group by dept_id
having count(ins_id)<6

---?   having  without group
select sum(salary)
from Instructor
having count(ins_id)>100

--condition aggregate function

select sum(salary)
from Instructor
group by dept_id
----------------------------------------
--subqueries
select *
from Student
where st_age<(select avg(St_age) from Student)

select *,(select count(st_id) from student)
from Student

select dept_name
from Department
where dept_id in(select distinct dept_id
                 from Student
				 where dept_id is not null)

select distinct dept_name
from Student s inner join department d
on d.Dept_Id = s.Dept_Id

--joins + DML
--Subqueries + DML
--delete + sub
delete from Stud_Course
where st_id=10

delete from Stud_Course
where st_address='mansoura'

delete from Stud_Course
where st_id in(select st_id from student where st_address='mansoura')
--------------------------------------------------------------------
--union
union all    union    intersect   except

--batch    set of independent queries
select st_fname
from Student
union all
select ins_name
from Instructor

select st_fname as ITI_names
from Student
union all
select ins_name
from Instructor

select st_fname,st_id
from Student
union all
select ins_name,ins_id
from Instructor

select convert(varchar(20),st_id)
from Student
union all
select ins_name
from Instructor

select st_fname
from Student
union --distinct   --order by +unique
select ins_name
from Instructor

select st_fname
from Student
intersect
select ins_name
from Instructor

select st_fname,st_id
from Student
intersect
select ins_name,ins_id
from Instructor


select st_fname
from Student
except
select ins_name
from Instructor

--Aggregate functions + grouping
--subqueries
--union
--EERD
--Data types
----------------Numeric DT
bit  --boolean   false:true   0:1
tinyint  1 byte   -128:127   unsigned 0:255
smallint 2B    -32768:32767    unsigned   0:65555
int    4B
bigint 8B
----------------Decimal DT
smallmoney  --4B  .0000
money       --8B  .0000
real              .0000000
float             .000000000000000000000000000000
dec   decimal  dec(5,2)  123.65   1.3    12.432 XXXXX
----------------Text DT
char(10)   fixed length char   ahmed 10   ali 10   على  ???
varchar(10) variable length char   ahmed 5   ali 3  على  ???
nchar(10)   unicode DT   Language   على  على
nvarchar(10)
nvarchar(max) --up to 2GB
text  --old DT
----------------Date_Time
Date   MM/dd/yyyy
Time   hh:mm:12.876
Time(7) hh:mm:12.8768765
smalldatetime  MM/dd/yyyy hh:mm:00
datetime  MM/dd/yyyy hh:mm:ss.234
datetime2(7)  MM/dd/yyyy hh:mm:ss.7654562
datetimeoffset  1/1/2023  10:30  +2:00
----------------binary
binary 10001  1111100  10001111
image
----------------others
XML
SQL_variant  ------------> var     any dT
Uniqueidentifier
-------------------------------------------------

select st_fname,dept_id,st_Age
from Student
order by st_address

select st_fname,dept_id,st_Age
from Student
order by 1

select st_fname,dept_id,st_Age
from Student
order by dept_id asc,st_age desc


select st_fname,dept_id,st_Age
from Student
order by st_id asc,st_age desc

select st_fname,st_address,st_age
from student
order by st_address,st_age 

select db_name()

select suser_name()


















