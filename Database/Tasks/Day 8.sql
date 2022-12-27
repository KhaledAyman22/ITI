use ITI
-- 1.	Create a view that displays student full name, course name if the student has a grade more than 50.
	create view Std_Data as
		select CONCAT(s.St_Fname, ' ', s.St_Lname) as 'Full Name', c.Crs_Name as 'Course Name'
		from Student s join Stud_Course sc on s.St_Id = sc.St_Id join Course c on sc.Crs_Id = c.Crs_Id
		where sc.Grade > 50

	select * from Std_Data

-- 2.	Create an Encrypted view that displays manager names and the topics they teach.
	create view Instructor_Topics WITH ENCRYPTION as
	select i.Ins_Name, t.Top_Name
	from Instructor i join Department d  on i.Ins_Id = d.Dept_Manager 
					  join Ins_Course ic on i.Ins_Id = ic.Ins_Id
					  join Course	  c	 on c.Crs_Id = ic.Crs_Id
					  join Topic	  t	 on t.Top_Id = c.Top_Id

	select * from Instructor_Topics

-- 3.	Create a view that will display Instructor Name, Department Name for the ‘SD’ or ‘Java’ Department
	create view SD_JAVA_Instructors as
	select i.Ins_Name, d.Dept_Name
	from Instructor i join Department d on i.Dept_Id = d.Dept_Id
	where d.Dept_Name in ('SD', 'Java')

	select * from SD_JAVA_Instructors

-- 4.	Create a view “V1” that displays student data for student who lives in Alex or Cairo.
-- 		Note: Prevent the users to run the following query 
-- 		Update V1 set st_address=’tanta’
-- 		Where st_address=’alex’;
	create view V1 as
	select * from Student s where s.St_Address in ('Alex', 'Cairo')
	with check option 

	select * from V1

	Update V1 set st_address='tanta'
 	Where st_address='Alex';

-- 5.	Create a view that will display the project name and the number of employees work on it. “Use SD database”
	use SD
	create view Project_Employee_Data as
	select p.ProjectName, COUNT(w.EmpNo) as 'emp count'
	from Works_on w join [Company].Project p on w.[ProjectNo] = p.ProjectNo
	group by p.ProjectName

	select * from Project_Employee_Data

-- 6.	Create index on column (Hiredate) that allow u to cluster the data in table Department. What will happen?
	create index i_Hiredate on department(Manager_hiredate)
	--Commands completed successfully.

-- 7.	Create index that allow u to enter unique ages in student table. What will happen?
	create unique index i_Age on Student(St_Age)
	--The CREATE UNIQUE INDEX statement terminated because a duplicate key was found for the object name
	--'dbo.Student' and the index name 'i_Age'. The duplicate key value is (<NULL>).

-- 8.	Using Merge statement between the following two tables [User ID, Transaction Amount]

	create table #daily (id int, val int)
	create table #last (id int, val int)
	insert into #daily values (1,1000),(2,2000),(3,1000)
	insert into #last values (1,4000),(4,2000),(2,10000)
	
	merge into #last as t 
	using #daily as d 
	on t.id = d.id
	when matched then update set t.val = d.val
	when not matched then insert values(d.id, d.val);

	select * from #last

use SD
-- 1)	Create view named   “v_clerk” that will display employee#,project#,
--		the date of hiring of all the jobs of the type 'Clerk'.
	create view v_clerk as 
	select w.EmpNo, w.ProjectNo, w.EnterDate 
	from Works_on w
	where w.Job = 'Clerk'

	select * from v_clerk

-- 2)	Create view named  “v_without_budget” that will display all the projects data 
-- 	without budget
	create view v_without_budget as 
	select * from [Company].Project p where p.Budget = null

	select * from v_without_budget

-- 3)	Create view named  “v_count “ that will display the project name and the # of jobs in it
	create view v_count as 
	select p.ProjectName, count(w.Job) as 'jobs' 
	from [Company].Project p join Works_on w on p.ProjectNo = w.ProjectNo
	group by p.ProjectName

	select * from v_count

-- 4)	Create view named ” v_project_p2” that will display the emp#  for the project# ‘p2’
-- 	use the previously created view  “v_clerk”
	create view v_project_p2 as
	select count(v.EmpNo) as empCount
	from (select * from v_clerk) as v
	where v.ProjectNo = 'p2'

	select * from v_project_p2

-- 5)	modifey the view named  “v_without_budget”  to display all DATA in project p1 and p2
	alter view v_without_budget as
	select * from [Company].Project p where p.ProjectNo in ('p1','p2')

	select * from v_without_budget

-- 6)	Delete the views  “v_clerk” and “v_count”
	drop view v_clerk
	drop view v_count

-- 7)	Create view that will display the emp# and emp lastname who works on dept# is ‘d2’
	create view d2_emps as
	select EmpNo, e.Lname
	from [HR].Employee e
	where e.DeptNo = 'd2'

	select * from d2_emps

-- 8)	Display the employee  lastname that contains letter “J”
-- Use the previous view created in Q#7
	select * from (select * from d2_emps) as t
	where t.Lname like '%j%'

-- 9)	Create view named “v_dept” that will display the department# and department name.
	create view v_dept as
	select d.DeptNo, d.DeptName
	from [Company].Department d

	select * from v_dept

-- 10)	using the previous view try enter new department data where dept# is ’d4’ and dept name is ‘Development’
	insert into v_dept values('d4', 'Development')
	--(1 row affected)

-- 11)	Create view name “v_2006_check” that will display employee#, the project #where he works
--		and the date of joining the project which must be from the first of January and the last of December 2006.
	create view v_2006_check as
	select w.EmpNo, w.EnterDate,count(w.ProjectNo) as ProjectCount
	from Works_on w
	group by w.EmpNo, w.EnterDate
	having w.EnterDate between '2006.1.1' and '2006.12.31'

	select * from v_2006_check