--view
--IS A select statment
--•	Simplify construction of complex queries
--•	Specify user view
--•	Limit access to data [grant revoke]
--•	Hide names of database objects [table name and columns]
--•	increase performance

--types of views
--Standard view
--partitioned view
--indexed views

create view v2(studept_name,dept_name)
as
	select st_fname,dept_name
	from student s,department d
	where	s.dept_id=d.dept_id
	and s.st_address='cairo'

select * from v2
select studept_name from v2

drop view v1

create view v3
as 
	select st_fname from student
	union
	select dept_name from department

--insert through a view if:
----All the affected columns belong to one table
----All the columns not named in the view either allow NULLs
----or have default clauses, or IDENTITY or calculated

--update if:
----All the affected columns belong to one table

--delete if:
----The view is based on only one table

sp_depends v2
sp_help v2
sp_helptext v2
sp_rename v2,v10
select * from v10

--LIMITATIONS
--CANT USE AGGREGATE FUNCTION ON VIEWS
--CAN USE COMPUTE OR COMPUTE BY
--CANT USE ORDER BY eXCEPT IF U USE IT WITH tOP



--ENCRYPTED VIEW
CREATE VIEW V1
WITH ENCRYPTION
AS
SELECT * FROM Student

SP_HELPTEXT V1

--INDEXED VIEWS
--U CAN CREATE INDEX ON VIEW AS ON TABLES

--U CAN CREATE PARTITIONED VIEWS
--PARTITIONED VIEWS COMBINE DATA FROM DIFFERENT SOURCES
--with check option
----working with inset update only
alter view v13
as
	select st_id,st_fname,st_age
	from student
	where st_age=20
	with check option

select * from v13

insert into v13 
values(111,'ali',33)

update v13
set st_age=30
where st_age=20
--------------------------------
---------------------------------
--CTE
with cte (did,cnt)as
(
select dept_id,COUNT(dept_id)
from Student
group by Dept_Id
)
select *,(select COUNT(*) from cte) from  cte
