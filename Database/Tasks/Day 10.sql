--1.	Create a cursor for Employee table that increases Employee salary by 10% if Salary <3000 
--		and increases it by 20% if Salary >=3000. Use company DB
		use SD
		go
		select salary from [HR].Employee
		----------------------------------
		go
		declare c1 cursor
		for select salary from [HR].Employee
		
		declare @sal int
		
		open c1
		
		fetch c1 into @sal
		
		while @@FETCH_STATUS=0
			begin
				if @sal >= 3000
				begin
					update [HR].Employee 
					set salary	= @sal * 1.2
					where current of c1
				end

				else
				begin
					update [HR].Employee 
					set salary	= @sal * 1.1
					where current of c1
				end

				fetch c1 into @sal
			end
		close c1
		deallocate c1
		----------------------------------
		go
		select salary from [HR].Employee

--2.	Display Department name with its manager name using cursor. Use ITI DB
		use ITI
		go
		declare c1 cursor
		for select  d.Dept_Name, i.Ins_Name 
			from Department d join Instructor i on d.Dept_Manager = i.Ins_Id
		
		declare @Iname varchar(20), @Dname varchar(20)
		
		open c1
		
		fetch c1 into @Dname, @Iname
		
		while @@FETCH_STATUS=0
			begin
				select @Dname 'Department Name', @Iname 'Manager Name'

				fetch c1 into @Dname, @Iname
			end
		close c1
		deallocate c1

--3.	Try to display all students first name in one cell separated by comma. Using Cursor 

		use ITI
		go
		declare c1 cursor
		for select  s.St_Fname
			from Student s
		
		declare @name varchar(20), @full varchar(400), @first int = 1

		open c1
		
		fetch c1 into @name
		
		while @@FETCH_STATUS=0
			begin

				if @name is not null
				begin
					if @first = 1
					begin 
						set @full = @name
						set @first = 0
					end
					else
					begin
						set @full = concat(@full, ', ', @name)
					end
				end

				fetch c1 into @name
			end

			select @full
		close c1
		deallocate c1

--4.	Create full, differential Backup for SD DB.

		--on D:\\

--5.	Use import export wizard to display students data (ITI DB) in excel sheet

		--on D:\\

--6.	Try to generate script from DB ITI that describes all tables and views in this DB

		--on D:\\  ***abandoned an encripted view***

--7.	Create a sequence object that allow values from 1 to 10 without cycling in a specific column and test it.

		CREATE SEQUENCE seq
		start with 1
		increment by 1
		minvalue 1
		maxvalue 10
		no cycle;

		create table #t (id int)

		insert into #t values(next value for seq)
		,(next value for seq)
		,(next value for seq)
		,(next value for seq)
		,(next value for seq)
		,(next value for seq)
		,(next value for seq)
		,(next value for seq)
		,(next value for seq)
		,(next value for seq)

		select * from #t

		insert into #t values(next value for seq) -- 11th time