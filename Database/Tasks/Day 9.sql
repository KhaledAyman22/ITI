-- 1.	Create a stored procedure without parameters to show the number of students per department name.[use ITI DB]
	use ITI
	create proc StudPerDep
	as
		select d.Dept_Name as Department, count(s.St_Id) as 'Number of students'
		from Student s join Department d on s.Dept_Id = d.Dept_Id
		group by d.Dept_Name

	StudPerDep

-- 2.	Create a stored procedure that will check for the # of employees in the project p1 
--		if they are more than 3 print message to the user “'The number of employees in the project p1 is 3 or more
--		'” if they are less display a message to the user “'The following employees work for the project p1'” 
--		in addition to the first name and last name of each one. [Company DB]

		use SD

		create proc CheckP1Emps
		as
			declare @count int
			select @count = count(w.EmpNo)
			from Works_on w
			where w.ProjectNo = 'p1'

			if @count >= 3
				begin 
					select 'The number of employees in the project p1 is 3 or more'  
				end
			else 
				begin 
					select 'The following employees work for the project p1'
				
					select e.Fname, e.Lname
					from Works_on w join [HR].Employee e on w.EmpNo = e.EmpNo
					where w.ProjectNo = 'p1'
				end

		CheckP1Emps

-- 3.	Create a stored procedure that will be used in case there is an old employee 
--		has left the project and a new one become instead of him. The procedure should take 3 parameters 
--		(old Emp. number, new Emp. number and the project number) and it will be used to update works_on table. 
--		[Company DB]
	use SD 

	create proc SwitchEmps(@old_emp_number int, @new_emp_number int , @project_number int)
	as
		update Works_on
		set EmpNo = @new_emp_number
		where EmpNo = @old_emp_number and ProjectNo = @project_number

-- 4.	add column budget in project table and insert any draft values in it then 
-- then Create an Audit table with the following structure
-- ProjectNo 	UserName 	ModifiedDate 	Budget_Old 	Budget_New 
-- p2 	Dbo 	2008-01-31	95000 	200000 
-- This table will be used to audit the update trials on the Budget column (Project table, Company DB)
-- Example:
-- If a user updated the budget column then the project number, user name that made that update,
-- the date of the modification and the value of the old and the new budget will be inserted into the Audit table
-- Note: This process will take place only if the user updated the budget column

	create table audit(
		ProjectNo nchar(10), UserName varchar(100), ModifiedDate date, Budget_Old int, Budget_New int 
	)

	create trigger t_onBudgetUpdate
	on [Company].Project
	for update
	as
		declare @pno nchar(10), @bo int, @bn int
		select @pno = ProjectNo, @bo = Budget  from deleted
		select @bn = Budget from inserted
		
		insert into audit
		values(@pno, SUSER_NAME(), GETDATE(), @bo, @bn)

	update [Company].Project set Budget = 100000 where ProjectNo = 'p1' 
	select * from audit
	select * from [Company].Project

-- 5.	Create a trigger to prevent anyone from inserting a new record in the Department table [ITI DB]
--		“Print a message for user to tell him that he can’t insert a new record in that table”

		use ITI
		create trigger PreventNewDep
		on Department
		instead of insert
		as
			select 'Invalid Operation, can’t insert a new record in Department'

		insert into Department values(80,	'EB',	'E-Business',	'Alex',	NULL,	NULL)

-- 6.	 Create a trigger that prevents the insertion Process for Employee table in March [Company DB].

		use SD

		create trigger PreventNewEmpMarch
		on [HR].Employee
		after insert
		as
			if(format(GETDATE(),'MMMM') = 'March')
			begin
				delete from [HR].Employee where EmpNo = (select EmpNo from inserted)
				select 'No insertion allowed in March'
			end

-- 7.	Create a trigger on student table after insert to add Row in Student Audit table 
--		(Server User Name , Date, Note) where note will be “[username] Insert New Row with Key=[Key Value]\
--		in table [table name]”  Server UserName	Date  Note 

		use ITI

		create table Student_Audit(
			ServerUserName varchar(100), InsertionDate date, Note varchar(200)
		)

		create trigger ArchiveStudent
		on Student
		after insert
		as
			declare @key int
			select @key = St_Id from inserted
				
			insert into Student_Audit
			values(SUSER_NAME(), GETDATE(),
			concat(SUSER_NAME(), ' ', 'Insert New Row with Key=', @key, ' ', 'in table student'))


		insert into Student values(15,'Marwa','Ahmed','Cairo',24,30,9)
		select * from Student_Audit

-- 8.	Create a trigger on student table instead of delete to add Row in Student Audit table 
--		(Server User Name, Date, Note) where note will be“ try to delete Row with Key=[Key Value]”
		
		create trigger PreventStudentDelete
		on Student
		instead of delete
		as
			declare @key int
			select @key = St_Id from deleted
				
			insert into Student_Audit
			values(SUSER_NAME(), GETDATE(),
			concat(SUSER_NAME(), ' ', 'tried to delete Row with Key=', @key, ' ', 'in table student'))


		delete from Student where St_Id = 15
		select * from Student_Audit 
	

-- 9.	Display all the data from the Employee table (HumanResources Schema) 
--		As an XML document “Use XML Raw”. “Use Adventure works DB” 
--		A)	Elements
--		B)	Attributes

		use AdventureWorks2012
		select * from HumanResources.Employee 
		for xml raw

		use AdventureWorks2012
		select * from HumanResources.Employee 
		for xml raw, ELEMENTS

-- 10.	Display Each Department Name with its instructors. “Use ITI DB”
--		A)	Use XML Auto
--		B)	Use XML Path

	use ITI
	
	select d.Dept_Name, i.*
	from Department d join Instructor i on d.Dept_Id = i.Dept_Id
	for xml auto

	select Dept_Name "Department", (select i.Ins_Id "ID", i.Ins_Degree "Degree", i.Ins_Name "Name", i.Salary "Salary" 
									from Instructor i 
									where i.Dept_Id = Department.Dept_Id
									for xml path('Instructor'),TYPE,root('Instructors')
									)
	from Department
	for xml path('Department'), root('DepartmentInstructors')

-- 11.	Use the following variable to create a new table “customers” inside the company DB.
--  Use OpenXML

		use SD

		--1)create proc processtree
			declare @docs xml ='<customers>
								   <customer FirstName="Bob" Zipcode="91126">
										  <order ID="12221">Laptop</order>
								   </customer>
								   <customer FirstName="Judy" Zipcode="23235">
										  <order ID="12221">Workstation</order>
								   </customer>
								   <customer FirstName="Howard" Zipcode="20009">
										  <order ID="3331122">Laptop</order>
								   </customer>
								   <customer FirstName="Mary" Zipcode="12345">
										  <order ID="555555">Server</order>
								   </customer>
								</customers>'

		--2)declare document handle
			declare @hdocs int

		--3)create memory tree
			Exec sp_xml_preparedocument @hdocs output, @docs

		--4)process document 'read tree from memory' OPENXML Creates Result set from XML Document
			SELECT * into  customers
			FROM OPENXML (@hdocs, '//customer')  --levels  XPATH Code
			WITH (
				FirstName varchar(20) '@FirstName',
				Zipcode varchar(20) '@Zipcode',
				orderID int 'order/@ID',
				product varchar(20) 'order'
			)

		--5)remove memory tree
			Exec sp_xml_removedocument @hdocs

			select * from customers
-- Bonus :
-- 1.	Transform all functions in lab2 to be stored procedures
-- 2.	Create a trigger that prevents users from altering any table in Company DB.