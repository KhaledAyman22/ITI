create rule r1 as @x in ('NY','DS','KW');
create default def1 as 'NY';
sp_addtype  loc, 'nchar(2)';
sp_bindrule r1, loc;
sp_bindefault def1, loc;

--------------------------------------------------------------

create table Department(
DeptNo nchar(2) PRIMARY KEY,
DeptName varchar(50),
Location  loc,
);

--------------------------------------------------------------

INSERT INTO Department 
values('d1','Research','NY'),
	  ('d2','Accounting','DS'),
	  ('d3','Markiting','KW');

--------------------------------------------------------------

create table Employee(
EmpNo int,
Fname varchar(50) NOT NULL,
Lname varchar(50) NOT NULL,
DeptNo nchar(2),
Salary int,
constraint c1 primary key(EmpNo),
constraint c2 unique (Salary),
constraint c3 foreign key(DeptNo) references Department(DeptNo),
);

create rule r2 as @x < 6000;

sp_bindrule r2, 'Employee.Salary';

--------------------------------------------------------------

INSERT INTO Employee 
values  (25348,	'Mathew','Smith'	,'d3',	2500),
		(10102,	'Ann'	,'Jones'	,'d3',	3000),
		(18316,	'John'	,'Barrimore','d1',	2400),
		(29346,	'James'	,'James'	,'d2',	2800),
		(9031,	'Lisa'	,'Bertoni'	,'d2',	4000),
		(2581,	'Elisa'	,'Hansel'	,'d2',	3600),
		(28559,	'Sybl'	,'Moser'	,'d1',	2900);

--------------------------------------------------------------

INSERT INTO Project values
('p1',	'Apollo' ,120000),
('p2',	'Gemini' ,95000),
('p3',	'Mercury' ,185600);

--------------------------------------------------------------

INSERT INTO Works_On values
(10102,'p1', 'Analyst',	'2006.10.1'),
(10102,'p3', 'Manager',	'2012.1.1'),
(25348,'p2', 'Clerk',	'2007.2.15'),
(18316,'p2', NULL,	'2007.6.1'),
(29346,'p2', NULL,	'2006.12.15'),
(2581, 'p3','Analyst',	'2007.10.15'),
(9031, 'p1', 'Manager',	'2007.4.15'),
(28559,'p1', NULL,	'2007.8.1'),
(28559,	'p2',	'Clerk',	'2012.2.1'),
(9031,		'p3',	'Clerk',	'2006.11.15'),
(29346,	'p1',	'Clerk',	'2007.1.4');


--------------------------------------------------------------

INSERT INTO Works_on (EmpNo)
values(11111)
--Cannot insert the value NULL into column 'ProjectNo', table 'SD.dbo.Works_on'; column does not allow nulls. INSERT fails.

--------------------------------------------------------------

update Works_on set EmpNo = 11111 where EmpNo = 10102;
--The UPDATE statement conflicted with the FOREIGN KEY constraint "FK_Works_on_Employee". The conflict occurred in database "SD", table "dbo.Employee", column 'EmpNo'.

--------------------------------------------------------------

update Employee set EmpNo = 22222 where EmpNo = 10102;
--The UPDATE statement conflicted with the REFERENCE constraint "FK_Works_on_Employee". The conflict occurred in database "SD", table "dbo.Works_on", column 'EmpNo'.

--------------------------------------------------------------

DELETE FROM Employee
where EmpNo = 10102;
--The DELETE statement conflicted with the REFERENCE constraint "FK_Works_on_Employee". The conflict occurred in database "SD", table "dbo.Works_on", column 'EmpNo'.

--------------------------------------------------------------

ALTER TABLE Employee
ADD TelephoneNumber varchar(50);

--------------------------------------------------------------

ALTER TABLE Employee
DROP COLUMN TelephoneNumber;

--------------------------------------------------------------

CREATE SCHEMA Company;

--------------------------------------------------------------

ALTER SCHEMA Company transfer Department;

--------------------------------------------------------------

CREATE SCHEMA HR;

--------------------------------------------------------------

ALTER SCHEMA HR transfer Employee;

--------------------------------------------------------------

SELECT CONSTRAINT_TYPE,CONSTRAINT_NAME
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE TABLE_NAME='Employee';

--------------------------------------------------------------

create synonym emp for HR.Employee;
create synonym dep for Company.Department;
create synonym proj for Company.Project;

--------------------------------------------------------------

Select * from Employee;
--Invalid object name 'Employee'.

Select * from [HR].Employee;
--normal

Select * from emp;
--normal

Select * from [HR].emp;
--Invalid object name 'HR.emp'.

--------------------------------------------------------------

--------------------------------------------------------------

update [Company].Department set DeptName = 'Sales'
where DeptNo = (select DeptNo from emp where fname = 'James');

--------------------------------------------------------------

update Works_On  set EnterDate = '12.12.2007'
from emp join dep on emp.Deptno = dep.deptno join
	works_on on emp.empno = works_on.empno join
	proj on proj.ProjectNo = works_on.ProjectNo
where works_on.projectno = 'p1' and dep.deptname = 'Sales';

-- 2 row affected

--------------------------------------------------------------

Delete from Works_on
from Works_on join emp on Works_on.empno = emp.empno
			  join dep on emp.deptno = dep.deptno
where dep.location = 'KW'

--------------------------------------------------------------