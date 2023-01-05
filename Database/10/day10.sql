create Proc getval @col varchar(20),@t varchar(20)
as
    execute('select '+@col+' from '+@t)

getval 'st_id,st_fname','student'

getval '*','student'

execute getval '*','course'

--output   ---> runtime trigger

delete from student
	output getdate(),suser_name(),deleted.st_fname
where st_id=100


delete from student
where st_id=20

declare c1 cursor
for select st_id,st_fname from Student
	where st_address='cairo'
for read only     --update  --modification

declare @id int,@name varchar(20)
open c1
fetch c1 into @id,@name
while @@FETCH_STATUS=0
	begin
		select @id,@name
		fetch c1 into @id,@name
	end
close c1
deallocate c1


--one cell [ahmed,ali,amr,fady.........]

declare c1 cursor
for select distinct st_fname from student where st_fname is not null
for read only

declare @name varchar(20),@all_names varchar(300)=''
open c1
fetch c1 into @name     --counter=0
while @@FETCH_STATUS=0
	begin
		set @all_names=CONCAT(@all_names,',',@name)
		fetch c1 into @name   --counter++
	end
select @all_names
close c1
deallocate c1

declare c1 cursor
for select salary from instructor
for update

declare @sal int
open c1
fetch c1 into @sal
while @@FETCH_STATUS=0
	begin  
		if @sal>=3000
			update instructor    --1 row affected
				set salary=@sal*1.20
			where current of c1
		else if @sal<3000
			update instructor
				set salary=@sal*1.10
			where current of c1
		else
			delete from instructor
			where current of c1
		fetch c1 into @sal
	end
close c1
deallocate c1


declare c1 cursor
for select st_fname,lead(st_fname) over(order by st_id)
    from student
for read only

declare @name1 varchar(20),@name2 varchar(20),@count int=0
open c1
fetch c1 into @name1,@name2
while @@FETCH_STATUS=0
	begin
		if @name1='ahmed' and @name2='amr'
			set @count+=1
		fetch c1 into @name1,@name2
	end
select @count
close c1
deallocate c1
-------------------------------------------------------
backup database SD
to disk='d:\SD_db.bak'


--failover Recovery 
--------------->failover clustering
--------------->Always on
--------------->Relplication  Peer to Peer
--------------->Ship transaction Log   [jobs]
--------------->DB Mirroring

Create database Snap1
On
(
 name='iti',  --mdf
 filename='d:\s1.ss'
)
as snapshot of ITI

use ITI


select * from instructor

select * from Student

use Snap1

select * from Student


select * from instructor
