/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2018/1/29 15:37:38                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Emp') and o.name = 'FK_EMP_REFERENCE_DEPTMENT')
alter table Emp
   drop constraint FK_EMP_REFERENCE_DEPTMENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Emp') and o.name = 'FK_EMP_REFERENCE_USERTYPE')
alter table Emp
   drop constraint FK_EMP_REFERENCE_USERTYPE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('OrderDinnerTable') and o.name = 'FK_ORDERDIN_REFERENCE_MENU')
alter table OrderDinnerTable
   drop constraint FK_ORDERDIN_REFERENCE_MENU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('OrderDinnerTable') and o.name = 'FK_ORDERDIN_REFERENCE_EMP')
alter table OrderDinnerTable
   drop constraint FK_ORDERDIN_REFERENCE_EMP
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Deptment')
            and   type = 'U')
   drop table Deptment
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Emp')
            and   type = 'U')
   drop table Emp
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Menu')
            and   type = 'U')
   drop table Menu
go

if exists (select 1
            from  sysobjects
           where  id = object_id('OrderDinnerTable')
            and   type = 'U')
   drop table OrderDinnerTable
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UserType')
            and   type = 'U')
   drop table UserType
go

/*==============================================================*/
/* Table: Deptment                                              */
/*==============================================================*/
create table Deptment (
   Deptno               int                  not null,
   Deptname             varchar(50)          not null,
   constraint PK_DEPTMENT primary key (Deptno)
)
go

/*==============================================================*/
/* Table: Emp                                                   */
/*==============================================================*/
create table Emp (
   Empno                int                  not null,
   Name                 character(50)        not null,
   Type                 int                  not null,
   Password             varchar(50)          not null,
   Deptno               int                  not null,
   Gender               char(4)              not null,
   constraint PK_EMP primary key (Empno)
)
go

/*==============================================================*/
/* Table: Menu                                                  */
/*==============================================================*/
create table Menu (
   DishNumber           int                  not null,
   DishName             varchar(50)          not null,
   Path                 nvarchar(100)        not null,
   Price                int                  not null,
   constraint PK_MENU primary key (DishNumber)
)
go

/*==============================================================*/
/* Table: OrderDinnerTable                                      */
/*==============================================================*/
create table OrderDinnerTable (
   Orderno              int                  not null,
   Empno                int                  not null,
   Mnumber              int                  not null,
   Name                 varchar(50)          not null,
   Deptno               int                  not null,
   DishName             varchar(50)          not null,
   Time                 datetime             not null,
   Clean                int                  not null,
   Price                int                  not null,
   constraint PK_ORDERDINNERTABLE primary key (Orderno)
)
go

/*==============================================================*/
/* Table: UserType                                              */
/*==============================================================*/
create table UserType (
   Type                 int                  not null,
   Typename             varchar(50)          not null,
   constraint PK_USERTYPE primary key (Type)
)
go

alter table Emp
   add constraint FK_EMP_REFERENCE_DEPTMENT foreign key (Deptno)
      references Deptment (Deptno)
go

alter table Emp
   add constraint FK_EMP_REFERENCE_USERTYPE foreign key (Type)
      references UserType (Type)
go

alter table OrderDinnerTable
   add constraint FK_ORDERDIN_REFERENCE_MENU foreign key (Mnumber)
      references Menu (DishNumber)
go

alter table OrderDinnerTable
   add constraint FK_ORDERDIN_REFERENCE_EMP foreign key (Orderno)
      references Emp (Empno)
go

