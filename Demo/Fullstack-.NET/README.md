# Asp.Net Core MVC CRUD
"ConnectionStrings": {
    "DevConnection": "Data Source=.;Initial Catalog=ThirdTest;User ID=gia;Password=123456"
  }
Script Sql:
Create Database [ThirdTest]
CREATE TABLE [dbo].[Users](
	[UserId] [int] identity NOT NULL,
	[FullName] [varchar](250) NULL,
	[PhoneNumber] [varchar](10) NULL,
	[Position] [varchar](100) NULL
) ON [PRIMARY]
GO

Version: .Net core 2.2
