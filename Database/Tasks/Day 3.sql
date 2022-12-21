-- 1 Display the Department id, name and id and the name of its manager.
select e.SSN, e.Fname +' '+ e.Lname as 'Full Name', d.Dnum, d.Dname
from Departments d, Employee e
where e.SSN = d.MGRSSN

-- 2 Display the name of the departments and the name of the projects under its control.
select d.Dname, p.Pname
from Project p, Departments d
where p.Dnum = d.Dnum

-- 3 Display the full data about all the dependence associated with the name of the employee they depend on him/her.
select e.Fname +' '+ e.Lname as 'Full Name', d.*
from Employee e, Dependent d
where e.SSN=d.ESSN

-- 4 Display the Id, name and location of the projects in Cairo or Alex city.
select p.Pnumber, p.Pname, p.Plocation
from Project p
where p.City in('cairo','alex')

-- 5 Display the Projects full data of the projects with a name starts with "a" letter.
select *
from Project p
where p.Pname like 'a%'

-- 6 display all the employees in department 30 whose salary from 1000 to 2000 LE monthly
select *
from Employee e
where e.Salary between 1000 and 2000 and e.Dno=30

-- 7 Retrieve the names of all employees in department 10 who works more than or equal10 hours per week on "AL Rabwah" project.
select e.Fname +' '+ e.Lname as 'Full Name'
from Works_for w inner join Employee e on w.ESSn = e.SSN
	 inner join Project p on p.Pnumber = Pno
where e.Dno = 10 and p.Pname = 'al rabwah' and w.Hours>=10

-- 8 Find the names of the employees who directly supervised with Kamel Mohamed.
select e.Fname +' '+ e.Lname as 'Full Name'
from Employee e join Employee m on e.Superssn = m.SSN 
where m.Fname = 'kamel' and m.Lname='mohamed'

-- 9 Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name.
select e.Fname +' '+ e.Lname as 'Full Name', p.Pname
from Works_for w inner join Employee e on w.ESSn = e.SSN
	 inner join Project p on p.Pnumber = Pno
order by p.Pname

-- 10 For each project located in Cairo City , find the project number, the controlling department name ,the department manager last name ,address and birthdate.
select p.Pnumber, d.Dname, e.Lname, e.Address, e.Bdate
from Project p join Departments d on p.Dnum = d.Dnum 
	 join Employee e on e.SSN = d.MGRSSN
where p.City='cairo'

-- 11 Display All Data of the managers
select distinct m.*
from Employee e join Employee m on e.Superssn=m.SSN

-- 12 Display All Employees data and the data of their dependents even if they have no dependentss
select *
from Employee e left join Dependent d on e.SSN = d.ESSN

-- 13 Insert your personal data to the employee table as a new employee in department number 30, SSN = 102672, Superssn = 112233, salary=3000.
insert into Employee 
values('Khaled', 'Ayman', 102672, 5-4-2000, '47 Al Matbaa Al Haram', 'M', 3000, 112233, 30)

-- 14 Insert another employee with personal data your friend as new employee in department number 30, SSN = 102660, but don’t enter any value for salary or supervisor number to him.
insert into Employee(Fname, Lname, SSN, Sex, Dno)
values('Youssef', 'Bahgat', 102660, 'M', 30)

-- 15 Upgrade your salary by 20 % of its last value.
update Employee
set Salary = Salary + (Salary*20/100)
where SSN = 102672