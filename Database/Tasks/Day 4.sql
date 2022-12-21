--1.	Display (Using Union Function)
			--a.	 The name and the gender of the dependence that's gender is Female and depending on Female Employee.
			--b.	 And the male dependence that depends on Male Employee.

		select d.Dependent_name, d.Sex
		from Dependent d, Employee p 
		where d.ESSN = p.SSN and p.Sex='F'
		union
		select d.Dependent_name, d.Sex
		from Dependent d, Employee p 
		where d.ESSN = p.SSN and p.Sex='M'

--2.	For each project, list the project name and the total hours per week (for all employees) spent on that project.

		select p.Pname, sum(w.hours) as 'Total Hours'
		from Project p, Works_for w
		where p.Pnumber = w.Pno
		group by P.Pname

--3.	Display the data of the department which has the smallest employee ID over all employees' ID.
	
		select *
		from Departments d 
		where d.Dnum = (select e.Dno from Employee e where e.SSN = (select min(SSN) from Employee))

--4.	For each department, retrieve the department name and the maximum, minimum and average salary of its employees.

		select d.Dname, min(e.Salary) as 'min', max(e.Salary) as 'max', avg(e.salary) as 'avg'
		from Employee e join Departments d on e.Dno = d.Dnum
		group by d.Dname

--5.	List the full name of all managers who have no dependents.

		select e.Fname + ' ' + e.Lname as 'Full Name'
		from Departments d join Employee e on d.MGRSSN = e.SSN
		where e.SSN not in( select distinct dt.ESSN from Dependent dt)

--6.	For each department-- if its average salary is less than the average salary of all employees-- display its number
--		, name and number of its employees.
		
		select d.Dnum, d.Dname, COUNT(e.SSN) as 'Number of Employees'
		from Departments d join Employee e on e.Dno = d.Dnum
		group by d.Dnum, d.Dname
		having avg(e.Salary) < (select avg(salary) from Employee)

--7.	Retrieve a list of employees names and the projects names they are working on ordered by department number
--		and within each department, ordered alphabetically by last name, first name.

		select e.Fname + ' ' + e.Lname as 'Full Name', p.Pname
		from Project p join Works_for w on p.Pnumber = w.Pno join Employee e on e.SSN = w.ESSn 
		order by p.Dnum, e.Fname, e.Lname

--8.	Try to get the max 2 salaries using subquery

		select top 2 isnull(tmp.Salary,0) from (select salary from Employee) as tmp
		order by tmp.Salary desc

--9.	Get the full name of employees that is similar to any dependent name

		select e.Fname + ' ' + e.Lname as 'Full Name'
		from Employee e
		where e.Fname + ' ' + e.Lname = any( select d.Dependent_name from Dependent d)

--10.	Display the employee number and name if at least one of them have dependents (use exists keyword) self-study.

		select e.SSN, e.Fname + ' ' + e.Lname as 'Full Name'
		from Employee e
		where exists(select ESSN from Dependent)

--11.	In the department table insert new department called "DEPT IT" , with id 100,
--		employee with SSN = 112233 as a manager for this department. The start date for this manager is '1-11-2006'

		insert into Departments values('DEPT IT', 100, 112233, '1-11-2006')

--12.	Do what is required if you know that : Mrs.Noha Mohamed(SSN=968574)  moved to be the manager of the new department (id = 100),
--		and they give you(your SSN =102672) her position (Dept. 20 manager) 
			--a.	First try to update her record in the department table
			--b.	Update your record to be department 20 manager.
			--c.	Update the data of employee number=102660 to be in your teamwork (he will be supervised by you) (your SSN =102672)

		update Departments 
		set MGRSSN = 968574, [MGRStart Date] = GETDATE()
		where Dnum = 100

		update Departments 
		set MGRSSN = 102672, [MGRStart Date] = GETDATE()
		where Dnum = 20

		update Employee 
		set Superssn = 102672
		where SSN = 102660

--13.	Unfortunately the company ended the contract with Mr. Kamel Mohamed (SSN=223344) so try to delete his data from your database
--		in case you know that you will be temporarily in his position.
--		Hint: (Check if Mr. Kamel has dependents, works as a department manager, supervises any employees or works in any projects
--		and handle these cases).
		
		update Departments 
		set MGRSSN = 102672, [MGRStart Date] = GETDATE()
		where MGRSSN = 223344

		update Employee 
		set Superssn = 102672
		where Superssn = 223344

		update Works_for  
		set ESSn = 102672
		where ESSn = 223344

		delete from Dependent
		where ESSN = 223344

		delete from Employee
		where SSN = 223344
		
--14.	Try to update all salaries of employees who work in Project ‘Al Rabwah’ by 30%
		
		update Employee
		set Salary = 1.3*Salary
		where SSN in(
			select e.SSN 
			from Works_for w join Employee e on w.ESSn = e.SSN
				join Project p on w.Pno = p.Pnumber
			where p.Pname = 'Al Rabwah'
		)