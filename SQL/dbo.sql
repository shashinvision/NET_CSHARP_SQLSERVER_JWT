/*
 Navicat Premium Data Transfer

 Source Server         : Docker SQL Server
 Source Server Type    : SQL Server
 Source Server Version : 16004135 (16.00.4135)
 Source Host           : localhost:1433
 Source Catalog        : IVR_PROJECT
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16004135 (16.00.4135)
 File Encoding         : 65001

 Date: 06/09/2024 20:57:03
*/


-- ----------------------------
-- Table structure for roles
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[roles]') AND type IN ('U'))
	DROP TABLE [dbo].[roles]
GO

CREATE TABLE [dbo].[roles] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [name] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[roles] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of roles
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[roles] ON
GO

INSERT INTO [dbo].[roles] ([id], [name]) VALUES (N'2', N'admin')
GO

INSERT INTO [dbo].[roles] ([id], [name]) VALUES (N'3', N'supervisor')
GO

INSERT INTO [dbo].[roles] ([id], [name]) VALUES (N'4', N'user')
GO

SET IDENTITY_INSERT [dbo].[roles] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for token_refresh
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[token_refresh]') AND type IN ('U'))
	DROP TABLE [dbo].[token_refresh]
GO

CREATE TABLE [dbo].[token_refresh] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [id_user] int  NOT NULL,
  [refresh_token] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [expire] datetime  NOT NULL
)
GO

ALTER TABLE [dbo].[token_refresh] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of token_refresh
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[token_refresh] ON
GO

INSERT INTO [dbo].[token_refresh] ([id], [id_user], [refresh_token], [expire]) VALUES (N'2', N'1', N'f4500107-7889-40ba-b3c6-7bf3853a1695', N'2024-09-05 15:47:42.000')
GO

INSERT INTO [dbo].[token_refresh] ([id], [id_user], [refresh_token], [expire]) VALUES (N'3', N'1', N'e465bd9f-46e8-48b1-ae08-6b79ceccf164', N'2024-09-05 17:05:10.000')
GO

INSERT INTO [dbo].[token_refresh] ([id], [id_user], [refresh_token], [expire]) VALUES (N'4', N'1', N'b1b90370-146f-4d2c-91b5-b0b4967e1123', N'2024-09-05 17:42:02.000')
GO

INSERT INTO [dbo].[token_refresh] ([id], [id_user], [refresh_token], [expire]) VALUES (N'5', N'1', N'86bbfe2c-5894-4dbd-87f5-874cd2ee2b04', N'2024-09-05 17:42:18.000')
GO

INSERT INTO [dbo].[token_refresh] ([id], [id_user], [refresh_token], [expire]) VALUES (N'6', N'1', N'b49c7749-40bd-4824-8b5c-b2ebe9952a0e', N'2024-09-05 17:42:20.000')
GO

INSERT INTO [dbo].[token_refresh] ([id], [id_user], [refresh_token], [expire]) VALUES (N'7', N'1', N'1d665159-3871-4f22-bc97-66e7bd7c0edc', N'2024-09-05 17:42:20.000')
GO

INSERT INTO [dbo].[token_refresh] ([id], [id_user], [refresh_token], [expire]) VALUES (N'8', N'1', N'9c08ce1d-2e0b-4a24-b1d9-e654a88588d4', N'2024-09-05 17:42:20.000')
GO

INSERT INTO [dbo].[token_refresh] ([id], [id_user], [refresh_token], [expire]) VALUES (N'9', N'1', N'7cfc86fc-7240-4a9a-896a-fdaa88b7082d', N'2024-09-05 17:44:38.000')
GO

INSERT INTO [dbo].[token_refresh] ([id], [id_user], [refresh_token], [expire]) VALUES (N'10', N'1', N'5fb6a19a-563c-4f92-bf0f-fe25a24e016b', N'2024-09-05 17:46:27.000')
GO

INSERT INTO [dbo].[token_refresh] ([id], [id_user], [refresh_token], [expire]) VALUES (N'11', N'1', N'45141cfb-5e6b-40c0-a422-b4a0a6275903', N'2024-08-05 17:48:59.000')
GO

INSERT INTO [dbo].[token_refresh] ([id], [id_user], [refresh_token], [expire]) VALUES (N'12', N'16', N'4ed21a62-d419-4166-9701-9e3ba4757cba', N'2024-07-05 17:50:23.000')
GO

INSERT INTO [dbo].[token_refresh] ([id], [id_user], [refresh_token], [expire]) VALUES (N'13', N'16', N'577a76dd-7634-4827-9560-49174899c53b', N'2024-05-05 18:10:21.000')
GO

INSERT INTO [dbo].[token_refresh] ([id], [id_user], [refresh_token], [expire]) VALUES (N'14', N'16', N'c99d48a1-d944-465e-8f8c-64afaf5b1208', N'2024-04-05 20:49:19.000')
GO

INSERT INTO [dbo].[token_refresh] ([id], [id_user], [refresh_token], [expire]) VALUES (N'15', N'16', N'61ef2024-0acb-4c82-aa67-b4c013769657', N'2024-08-05 20:49:42.000')
GO

INSERT INTO [dbo].[token_refresh] ([id], [id_user], [refresh_token], [expire]) VALUES (N'1002', N'1', N'829f3797-a4d4-4774-82d4-999077d30109', N'2024-09-09 14:05:32.000')
GO

SET IDENTITY_INSERT [dbo].[token_refresh] OFF
GO

COMMIT
GO


-- ----------------------------
-- Table structure for users
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[users]') AND type IN ('U'))
	DROP TABLE [dbo].[users]
GO

CREATE TABLE [dbo].[users] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [name] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [password] varchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [role_id] int  NOT NULL,
  [status] int  NULL
)
GO

ALTER TABLE [dbo].[users] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of users
-- ----------------------------
BEGIN TRANSACTION
GO

SET IDENTITY_INSERT [dbo].[users] ON
GO

INSERT INTO [dbo].[users] ([id], [name], [password], [role_id], [status]) VALUES (N'1', N'admin@admin.cl', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'2', N'1')
GO

INSERT INTO [dbo].[users] ([id], [name], [password], [role_id], [status]) VALUES (N'14', N'user2@example.cl', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'4', N'1')
GO

INSERT INTO [dbo].[users] ([id], [name], [password], [role_id], [status]) VALUES (N'1016', N'supervisor2@example.cl', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'3', N'1')
GO

INSERT INTO [dbo].[users] ([id], [name], [password], [role_id], [status]) VALUES (N'1017', N'supervisor4@example.cl', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'3', N'1')
GO

INSERT INTO [dbo].[users] ([id], [name], [password], [role_id], [status]) VALUES (N'11', N'supervisor@example.cl', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'3', N'1')
GO

INSERT INTO [dbo].[users] ([id], [name], [password], [role_id], [status]) VALUES (N'16', N'user4@example.cl', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'4', N'1')
GO

INSERT INTO [dbo].[users] ([id], [name], [password], [role_id], [status]) VALUES (N'13', N'user@example.net', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'4', N'1')
GO

INSERT INTO [dbo].[users] ([id], [name], [password], [role_id], [status]) VALUES (N'15', N'user3@example.cl', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'4', N'1')
GO

SET IDENTITY_INSERT [dbo].[users] OFF
GO

COMMIT
GO


-- ----------------------------
-- procedure structure for SP_USERS_GET
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_USERS_GET]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[SP_USERS_GET]
GO

CREATE PROCEDURE [dbo].[SP_USERS_GET]

AS
BEGIN

SELECT id, name, role_id, status FROM users WHERE status = 1 order by id asc;

END
GO


-- ----------------------------
-- procedure structure for SP_USER_GET_BY_ID
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_USER_GET_BY_ID]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[SP_USER_GET_BY_ID]
GO

CREATE PROCEDURE [dbo].[SP_USER_GET_BY_ID]
@id int
AS
BEGIN

SELECT TOP 1 id, name, role_id, status FROM users WHERE id = @id AND status = 1 order by id asc

END
GO


-- ----------------------------
-- procedure structure for SP_USER_GET_BY_NAME
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_USER_GET_BY_NAME]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[SP_USER_GET_BY_NAME]
GO

CREATE PROCEDURE [dbo].[SP_USER_GET_BY_NAME]
  @name AS varchar(255)
AS
BEGIN

  SELECT id, name, role_id, password, status FROM users 
		WHERE lower(name) = @name AND status = 1
	
END
GO


-- ----------------------------
-- procedure structure for SP_USER_ADD
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_USER_ADD]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[SP_USER_ADD]
GO

CREATE PROCEDURE [dbo].[SP_USER_ADD]
  @name as varchar(255),
	@role_id as int,
	@password as varchar(255)
AS
BEGIN

INSERT INTO users (name, role_id, password, status) VALUES (@name, @role_id, @password, 1)

DECLARE @lastInsertId int;

SET @lastInsertId = SCOPE_IDENTITY();

EXEC SP_GET_USER_BY_ID @lastInsertId;


END
GO


-- ----------------------------
-- procedure structure for SP_USER_UPDATE_ROL
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_USER_UPDATE_ROL]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[SP_USER_UPDATE_ROL]
GO

CREATE PROCEDURE [dbo].[SP_USER_UPDATE_ROL]
	@id as int,
	@role_id as int
	
AS
BEGIN

UPDATE users SET role_id = @role_id WHERE id = @id;

EXEC SP_GET_USER_BY_ID @id;

END
GO


-- ----------------------------
-- procedure structure for SP_USER_UPDATE_ROL_PASSWORD
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_USER_UPDATE_ROL_PASSWORD]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[SP_USER_UPDATE_ROL_PASSWORD]
GO

CREATE PROCEDURE [dbo].[SP_USER_UPDATE_ROL_PASSWORD]
	@id as int,
	@role_id as int,
	@password as varchar(255)
	
AS
BEGIN

UPDATE users SET role_id = @role_id, password = @password WHERE id = @id;

EXEC SP_GET_USER_BY_ID @id;

END
GO


-- ----------------------------
-- procedure structure for SP_USER_DELETE
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_USER_DELETE]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[SP_USER_DELETE]
GO

CREATE PROCEDURE [dbo].[SP_USER_DELETE]
 @id as int
AS
BEGIN

UPDATE users SET status = 0 WHERE id = @id;

EXEC SP_GET_USER_BY_ID @id;


END
GO


-- ----------------------------
-- procedure structure for SP_TOKEN_ADD
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_TOKEN_ADD]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[SP_TOKEN_ADD]
GO

CREATE PROCEDURE [dbo].[SP_TOKEN_ADD]
  @idUser as int,
	@refreshToken as varchar(255), 
	@expire as datetime
AS
BEGIN

INSERT INTO token_refresh (id_user, refresh_token, expire) VALUES (@idUser, @refreshToken, @expire)

DECLARE @lastInsertId int;

SET @lastInsertId = SCOPE_IDENTITY();

EXEC SP_GET_TOKEN_BY_ID @lastInsertId;


END
GO


-- ----------------------------
-- procedure structure for SP_TOKEN_GET_BY_ID
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_TOKEN_GET_BY_ID]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[SP_TOKEN_GET_BY_ID]
GO

CREATE PROCEDURE [dbo].[SP_TOKEN_GET_BY_ID]
@id int
AS
BEGIN

SELECT TOP 1 id_user, refresh_token, expire FROM token_refresh WHERE id = @id order by id asc

END
GO


-- ----------------------------
-- procedure structure for SP_TOKEN_GET_BY_TOKEN
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_TOKEN_GET_BY_TOKEN]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[SP_TOKEN_GET_BY_TOKEN]
GO

CREATE PROCEDURE [dbo].[SP_TOKEN_GET_BY_TOKEN]
@token int
AS
BEGIN

SELECT id_user, refresh_token, expire FROM token_refresh WHERE refresh_token = @token

END
GO


-- ----------------------------
-- procedure structure for SP_TOKEN_GET_BY_USER
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_TOKEN_GET_BY_USER]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[SP_TOKEN_GET_BY_USER]
GO

CREATE PROCEDURE [dbo].[SP_TOKEN_GET_BY_USER]
	@id_user as int
AS
BEGIN

SELECT TOP 1 id_user, refresh_token, expire FROM token_refresh WHERE id_user = @id_user ORDER BY id DESC

END
GO


-- ----------------------------
-- Auto increment value for roles
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[roles]', RESEED, 1001)
GO


-- ----------------------------
-- Indexes structure for table roles
-- ----------------------------
CREATE UNIQUE NONCLUSTERED INDEX [id_index]
ON [dbo].[roles] (
  [id] ASC
)
GO


-- ----------------------------
-- Uniques structure for table roles
-- ----------------------------
ALTER TABLE [dbo].[roles] ADD CONSTRAINT [id_unique] UNIQUE NONCLUSTERED ([id] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table roles
-- ----------------------------
ALTER TABLE [dbo].[roles] ADD CONSTRAINT [PK__roles__3213E83F5BE9A73C] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for token_refresh
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[token_refresh]', RESEED, 1)
GO


-- ----------------------------
-- Indexes structure for table token_refresh
-- ----------------------------
CREATE UNIQUE NONCLUSTERED INDEX [index_refresh_token ]
ON [dbo].[token_refresh] (
  [id] ASC
)
GO


-- ----------------------------
-- Uniques structure for table token_refresh
-- ----------------------------
ALTER TABLE [dbo].[token_refresh] ADD CONSTRAINT [unique_id_refresh_token] UNIQUE NONCLUSTERED ([id] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for users
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[users]', RESEED, 2015)
GO


-- ----------------------------
-- Indexes structure for table users
-- ----------------------------
CREATE NONCLUSTERED INDEX [idindex_users]
ON [dbo].[users] (
  [id] ASC
)
GO


-- ----------------------------
-- Uniques structure for table users
-- ----------------------------
ALTER TABLE [dbo].[users] ADD CONSTRAINT [id_users_unique] UNIQUE NONCLUSTERED ([id] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table token_refresh
-- ----------------------------
ALTER TABLE [dbo].[token_refresh] ADD CONSTRAINT [id_user_refresh_token] FOREIGN KEY ([id_user]) REFERENCES [dbo].[users] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table users
-- ----------------------------
ALTER TABLE [dbo].[users] ADD CONSTRAINT [foreg_roles_id_users] FOREIGN KEY ([role_id]) REFERENCES [dbo].[roles] ([id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

