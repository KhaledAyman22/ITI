
CREATE TABLE  dbo . Datatypes (
	 dt_bit   bit,
	 dt_tinyint   tinyint,
	 dt_smallint   smallint,
	 dt_int   int,

	 dt_money   money,
	 dt_smallmoney   smallmoney,
	 dt_float   float,
	 dt_decimal   decimal (7, 4),
	 
	 dt_datetime   datetime,
	 dt_smalldatetime   smalldatetime,
	 dt_datetime2   datetime2 (7),
	 dt_datetimeoffset   datetimeoffset (7),
	 dt_date   date,
	 dt_time   time (7),
	 
	 dt_char   char (10),
	 dt_varchar   varchar (50),
	 dt_nvarchar   nvarchar (50),
	 dt_varcharmax   varchar (max),
	 
	 dt_sqlvariant   sql_variant   
)
