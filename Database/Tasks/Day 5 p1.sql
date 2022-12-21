-- 1.	Retrieve number of students who have a value in their age. 

		select count(s.St_Id) as 'Students with age'
		from student s
		where s.St_Age is not null
		
-- 2.	Get all instructors Names without repetition

		select distinct i.Ins_Name
		from Instructor i

-- 3.	Display student with the following Format (use isNull function) 
--		Student ID	Student Full Name	Department name
		
		select isnull(s.St_Id,'unknown') as ID, isnull(s.St_Fname + ' ' + s.St_Lname,'unknown') as 'Student Name',
			   isnull(d.Dept_Name,'unknown') as 'Department Name'
		from Student s join Department d on s.Dept_Id = d.Dept_Id

-- 4.	Display instructor Name and Department Name 
--		Note: display all the instructors if they are attached to a department or not
		
		select isnull(i.Ins_Name,'unknown') as 'Instructor Name', isnull(d.Dept_Name,'unknown') as 'Department Name'
		from Instructor i left join Department d on i.Dept_Id = d.Dept_Id

-- 5.	Display student full name and the name of the course he is taking
--		For only courses which have a grade
		
		select isnull(s.St_Fname + ' ' + s.St_Lname,'unknown') as 'Student Name',
			   c.Crs_Name as 'Course Name'
		from Course c join Stud_Course sc on c.Crs_Id = sc.Crs_Id join
			 Student s on sc.St_Id = s.St_Id and sc.Grade is not null
			 
-- 6.	Display number of courses for each topic name

		select t.Top_Name as 'Topic Name', count(c.Crs_Id) as 'Courses Count'
		from Course c join Topic t on c.Top_Id = t.Top_Id
		group by c.Top_Id, t.Top_Name

-- 7.	Display max and min salary for instructors
		
		select max(i.Salary) as 'Max Salary', min(i.Salary) as 'Min Salary'
		from Instructor i
		where i.Salary is not null

-- 8.	Display instructors who have salaries less than the average salary of all instructors.

		select *
		from Instructor i
		where i.Salary < (select avg(Salary) from Instructor where Salary is not null)

-- 9.	Display the Department name that contains the instructor who receives the minimum salary.
		
		select d.Dept_Name
		from Department d join Instructor i on d.Dept_Id = i.Dept_Id
		where i.Salary = (select min(Salary) from Instructor where Salary is not null)
		
-- 10.	Select max two salaries in instructor table. 

		select top 2 i.Salary
		from Instructor i
		order by i.Salary desc

-- 11.	Select instructor name and his salary but if there is no salary display instructor bonus keyword.
--		“use coalesce Function”

		select i.Ins_Name, coalesce(Convert(varchar,i.Salary), 'instructor bonus') as Salary
		from Instructor i

-- 12.	Select Average Salary for instructors 

		select avg(Salary) as 'Average Salary'
		from Instructor
		where Salary is not null

-- 13.	Select Student first name and the data of his supervisor 
		
		select s.St_Fname as 'Student FName', sv.*
		from Student s join Student sv on s.St_super = sv.St_Id

-- 14.	Write a query to select the highest two salaries in Each Department for instructors who have salaries.
--		“using one of Ranking Functions”

		select tmp.Dept_Id, tmp.Salary
		from(
				select *, ROW_NUMBER() 
				over(partition by i.Dept_Id order by i.Salary desc) as r
				from Instructor i
			) as tmp
		where tmp.r <= 2
		
-- 15.	Write a query to select a random  student from each department.  “using one of Ranking Functions”

		select top 1 tmp.*
		from(
			select *, ROW_NUMBER() over(order by newid()) as r
			from Student
		) as tmp