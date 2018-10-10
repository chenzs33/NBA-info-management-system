USE [master]
GO

/****** Object:  Database [NBAHUPUSIM]    ******/
CREATE DATABASE [NBAHUPUSIM]
ON  PRIMARY 
( NAME = N'NBAHUPUSIM', FILENAME = N'D:\Data\NBAHUPUSIM.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NBAHUPUSIM_log', FILENAME = N'D:\Data\NBAHUPUSIM_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

USE NBAHUPUSIM
GO

CREATE TABLE [dbo].[Users](
    [UserId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[UserName] [varchar](50) NOT NULL,
	[UserPwd] [varchar](50) NOT NULL,
    [CreateTime] [date] DEFAULT (getdate()) NOT NULL,
	[Status] [int]  DEFAULT ((1)) NOT NULL
)
GO

CREATE TABLE [dbo].[Association](
	[AssociationId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[AssociationName] [nvarchar](50) NOT NULL,
)
GO

CREATE TABLE [dbo].[Division](
	[DivisionId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[DivisionName] [nvarchar](50) NOT NULL,
	[AssociationId] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Association] ([AssociationId]),
)
GO


CREATE TABLE [dbo].[Team](
	[TeamId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[TeamName] [nvarchar](50) NOT NULL,
    [TeamSize] [int] NULL,
	[DivisionId] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Division] ([DivisionId])
)
GO

CREATE TABLE [dbo].[Player](
	[PlayerName] [nvarchar](50) NOT NULL,
	[PlayerEngName] [nvarchar](50) NOT NULL,
	[PlayerNo] [char](10) NOT NULL PRIMARY KEY,
	[TeamId] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Team] ([TeamId]),
	[Age] [varchar](2) NULL,
	[Birthday] [date] NULL,
	[Height] [varchar](5) NULL,
	[Weight] [varchar](5) NULL,
	[Location] [nvarchar](50) NULL,
	[Photo] [nvarchar](50) NULL
)
GO

USE [NBAHUPUSIM]
GO

--插入联盟Association表数据
Insert into Association values('西部')
Insert into Association values('东部')
GO

--插入赛区Division表数据
Insert into Division values('太平洋赛区',1)
Insert into Division values('西南赛区',1)
Insert into Division values('西北赛区',1)
Insert into Division values('东南赛区',2)
Insert into Division values('中部赛区',2)
Insert into Division values('大西洋赛区',2)
GO

--插入球队Team表数据
Insert into Team values('勇士',50,1)
Insert into Team values('湖人',50,1)
Insert into Team values('快船',50,1)
Insert into Team values('国王',50,1)
Insert into Team values('太阳',50,1)
Insert into Team values('火箭',50,2)
Insert into Team values('马刺',50,2)
Insert into Team values('鹈鹕',50,2)
Insert into Team values('灰熊',50,2)
Insert into Team values('小牛',50,2)
Insert into Team values('森林狼',50,3)
Insert into Team values('开拓者',50,3)
Insert into Team values('雷霆',50,3)
Insert into Team values('掘金',50,3)
Insert into Team values('爵士',50,3)
Insert into Team values('奇才',50,4)
Insert into Team values('热火',50,4)
Insert into Team values('黄蜂',50,4)
Insert into Team values('魔术',50,4)
Insert into Team values('老鹰',50,4)
Insert into Team values('骑士',50,5)
Insert into Team values('步行者',50,5)
Insert into Team values('雄鹿',50,5)
Insert into Team values('活塞',50,5)
Insert into Team values('公牛',50,5)
Insert into Team values('凯尔特人',50,6)
Insert into Team values('猛龙',50,6)
Insert into Team values('尼克斯',50,6)
Insert into Team values('76人',50,6)
Insert into Team values('篮网',50,6)
GO

--插入球员Player表数据
Insert into Player(PlayerName,PlayerEngName,PlayerNo,TeamId,Age,Birthday,Height,Weight,Location)
values('斯蒂芬-库里','Stephen Curry','30',1,'29','1988-03-14','191','87','控球后卫')
Insert into Player(PlayerName,PlayerEngName,PlayerNo,TeamId,Age,Birthday,Height,Weight,Location)
values('凯文-杜兰特','Kevin Durant','35',1,'30','1988-09-29','206','109','小前锋')
Insert into Player(PlayerName,PlayerEngName,PlayerNo,TeamId,Age,Birthday,Height,Weight,Location)
values('克雷-汤普森','Klay Thompson','11',1,'28','1990-02-08','201','98','得分后卫')
Insert into Player(PlayerName,PlayerEngName,PlayerNo,TeamId,Age,Birthday,Height,Weight,Location)
values('德雷蒙德-格林','Draymond Green','23',1,'28','1990-03-04','203','105','大前锋')
Insert into Player(PlayerName,PlayerEngName,PlayerNo,TeamId,Age,Birthday,Height,Weight,Location)
values('安德烈-伊戈达拉','Andre Iguodala','9',1,'34','1984-01-28','199','98','得分后卫')
Insert into Player(PlayerName,PlayerEngName,PlayerNo,TeamId,Age,Birthday,Height,Weight,Location)
values('贾维尔-麦基','	JaVale McGee','1',1,'30','1988-01-19','214','123','中锋')
Insert into Player(PlayerName,PlayerEngName,PlayerNo,TeamId,Age,Birthday,Height,Weight,Location)
values('乔丹-贝尔','Jordan Bell','2',1,'23','1995-01-07','206','102','大前锋')
Insert into Player(PlayerName,PlayerEngName,PlayerNo,TeamId,Age,Birthday,Height,Weight,Location)
values('大卫-韦斯特','David West','3',1,'38','1980-08-29','206','114','大前锋')
Insert into Player(PlayerName,PlayerEngName,PlayerNo,TeamId,Age,Birthday,Height,Weight,Location)
values('尼克-杨','Nick Young','6',1,'33','1985-06-01','201','98','小前锋')
Insert into Player(PlayerName,PlayerEngName,PlayerNo,TeamId,Age,Birthday,Height,Weight,Location)
values('扎扎-帕楚里亚','Zaza Pachulia','27',1,'34','1984-01-28','211','123','中锋')
Insert into Player(PlayerName,PlayerEngName,PlayerNo,TeamId,Age,Birthday,Height,Weight,Location)
values('沙恩-利文斯顿','Shaun Livingston','34',1,'33','1985-09-11','201','88','控球后卫')
Insert into Player(PlayerName,PlayerEngName,PlayerNo,TeamId,Age,Birthday,Height,Weight,Location)
values('帕特里克-麦考','Patrick McCaw','0',1,'23','1995-10-25','201','98','得分后卫')
Insert into Player(PlayerName,PlayerEngName,PlayerNo,TeamId,Age,Birthday,Height,Weight,Location)
values('布兰顿-英格拉姆','Brandon Ingram','14',2,'20','1997-09-02','191','87','小前锋')
Insert into Player(PlayerName,PlayerEngName,PlayerNo,TeamId,Age,Birthday,Height,Weight,Location)
values('布雷克-格里芬','Blake Griffin','32',3,'29','1989-03-16','209','114','大前锋')
Insert into Player(PlayerName,PlayerEngName,PlayerNo,TeamId,Age,Birthday,Height,Weight,Location)
values('詹姆斯-哈登','James Harden','13',6,'29','1989-08-26','196','100','得分后卫')
GO

--插入用户表数据
Insert into [Users](UserName,UserPwd) values('Zesen','123456')
GO

--用户列表的分页数据
/****** Object:  StoredProcedure [dbo].[USP_GetUsersListByPage]    Script Date: 2015/11/14 0:25:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetUsersListByPage]
	@pageIndex int ,
	@pageSize int ,
    @totalCount int  out	
AS
BEGIN
	SET NOCOUNT ON;

	declare @startIndex int ,@endIndex int 
	set @startIndex = (@pageIndex-1) * @pageSize
	set @endIndex = @pageIndex * @pageSize

    select * from ( 
		select row = ROW_NUMBER() over (order by UserId asc) ,Users.*
		from Users ) t 
     where t.row>@startIndex and t.row<=@endIndex

     select @totalCount=COUNT(*) from Users
END

GO

--根据球队号获取的球员列表的分页数据
/****** Object:  StoredProcedure [dbo].[USP_GetPlayerListByPage]    Script Date: 2018/1/1 0:00:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetPlayerListByPage]
	@pageIndex int ,
	@pageSize int ,
    @totalCount int  out,
	@TeamId int   --球队编号	
AS
BEGIN
	SET NOCOUNT ON;

	declare @startIndex int ,@endIndex int 
	set @startIndex = (@pageIndex-1) * @pageSize
	set @endIndex = @pageIndex * @pageSize

    select * from (
	     select row = ROW_NUMBER() over(order by (PlayerNo) desc), *
		 from Player		 
		 where TeamId = @TeamId) t 
	where t.row > @startIndex and t.row <= @endIndex

     select @totalCount = COUNT(*) 
	 from Player 
	 where TeamId = @TeamId
END
