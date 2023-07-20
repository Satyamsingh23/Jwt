

create table MyLoginTable
( UserId int identity(1,1) primary key not null, DisplayName varchar(30) not null, UserName varchar(25), UserEmail varchar(30) not null, UserPassword varchar(30) not null,
  CreateDate datetime 
)

select * from MyLoginTable

Alter procedure PostLoginDetails
@DisplayName varchar(30)='null',
@UserEmail varchar(30)='null',
@UserPassword varchar(30)='null',
@CreateDate datetime = GetDate
as
begin
insert into MyLoginTable(DisplayName, UserName , UserEmail , UserPassword ,  CreateDate   )
values(@DisplayName , 'smart'+@DisplayName+'@123' , @UserEmail , @UserPassword, @CreateDate)
end


ALTER TABLE table_name
ADD column_name datatype;

