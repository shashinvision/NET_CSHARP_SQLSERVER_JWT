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

 Date: 18/09/2024 09:39:29
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

INSERT INTO [dbo].[roles] ([id], [name]) VALUES (N'3', N'moderator')
GO

INSERT INTO [dbo].[roles] ([id], [name]) VALUES (N'4', N'user')
GO

INSERT INTO [dbo].[roles] ([id], [name]) VALUES (N'1003', N'asistant')
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

INSERT INTO [dbo].[token_refresh] ([id], [id_user], [refresh_token], [expire]) VALUES (N'1002', N'1', N'94b18ab3-edee-486e-b303-e5ed9fb139f7', N'2024-09-23 18:11:39.617')
GO

INSERT INTO [dbo].[token_refresh] ([id], [id_user], [refresh_token], [expire]) VALUES (N'9', N'1', N'946391de-a553-4fcb-8648-12f20f52d76c', N'2024-09-14 13:09:26.950')
GO

INSERT INTO [dbo].[token_refresh] ([id], [id_user], [refresh_token], [expire]) VALUES (N'10', N'14', N'dd827644-4c41-472b-991d-e812eaeff8cc', N'2024-09-18 13:49:17.167')
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

INSERT INTO [dbo].[users] ([id], [name], [password], [role_id], [status]) VALUES (N'14', N'user@user.cl', N'73l8gRjwLftklgfdXT+MdiMEjJwGPVMsyVxe16iYpk8=', N'3', N'1')
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

INSERT INTO [dbo].[users] ([id], [name], [password], [role_id], [status]) VALUES (N'3029', N'user_front_5@example.cl', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'3', N'1')
GO

SET IDENTITY_INSERT [dbo].[users] OFF
GO

COMMIT
GO


-- ----------------------------
-- View structure for VW_ROLES_GET
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[VW_ROLES_GET]') AND type IN ('V'))
	DROP VIEW [dbo].[VW_ROLES_GET]
GO

CREATE VIEW [dbo].[VW_ROLES_GET] AS SELECT id, name FROM roles;
GO


-- ----------------------------
-- View structure for VW_USERS_GET
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[VW_USERS_GET]') AND type IN ('V'))
	DROP VIEW [dbo].[VW_USERS_GET]
GO

CREATE VIEW [dbo].[VW_USERS_GET] AS SELECT u.id, u.name, u.role_id, r.name as role_name, u.status 
	FROM users as u
	LEFT JOIN roles as r
		ON u.role_id = r.id;
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

SELECT u.id, u.name, u.role_id, r.name as role_name, u.status 
	FROM users as u
	LEFT JOIN roles as r
		ON u.role_id = r.id
	WHERE u.status = 1 
	order by u.id asc;

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

SELECT top 1 u.id, u.name, u.role_id, r.name as role_name, u.status 
	FROM users as u
	LEFT JOIN roles as r
		ON u.role_id = r.id
	WHERE u.id = @id
	order by u.id asc;
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
		
		SELECT top 1 u.id, u.name, u.role_id, r.name as role_name, u.password, u.status
		FROM users as u
		LEFT JOIN roles as r
			ON u.role_id = r.id
		WHERE lower(u.name) = @name
		order by u.id asc;
	
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

EXEC SP_USER_GET_BY_ID @lastInsertId;


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

EXEC SP_USER_GET_BY_ID @id;

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

EXEC SP_USER_GET_BY_ID @id;

END
GO


-- ----------------------------
-- procedure structure for SP_USER_DEACTIVATE
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_USER_DEACTIVATE]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[SP_USER_DEACTIVATE]
GO

CREATE PROCEDURE [dbo].[SP_USER_DEACTIVATE]
 @id as int
AS
BEGIN

UPDATE users SET status = 0 WHERE id = @id;

SELECT top 1 u.id, u.name, u.role_id, r.name as role_name, u.status 
	FROM users as u
	LEFT JOIN roles as r
		ON u.role_id = r.id
	WHERE u.id = @id
	order by u.id asc;


END
GO


-- ----------------------------
-- procedure structure for SP_TOKEN_ADD
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_TOKEN_ADD]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[SP_TOKEN_ADD]
GO

CREATE PROCEDURE [dbo].[SP_TOKEN_ADD]
  @id_user as int,
	@refresh_token as varchar(255),
	@expire as DATETIME 
AS
BEGIN

INSERT INTO token_refresh (id_user, refresh_token, expire) VALUES (@id_user, @refresh_token, @expire)

DECLARE @lastInsertId int;

SET @lastInsertId = SCOPE_IDENTITY();

EXEC SP_TOKEN_GET_BY_ID @lastInsertId;


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

SELECT TOP 1 id_user, refresh_token, expire FROM token_refresh WHERE id = @id order by id desc

END
GO


-- ----------------------------
-- procedure structure for SP_TOKEN_GET_BY_TOKEN
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_TOKEN_GET_BY_TOKEN]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[SP_TOKEN_GET_BY_TOKEN]
GO

CREATE PROCEDURE [dbo].[SP_TOKEN_GET_BY_TOKEN]
@token varchar(255)
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
-- procedure structure for SP_USER_ACTIVATE
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_USER_ACTIVATE]') AND type IN ('P', 'PC', 'RF', 'X'))
	DROP PROCEDURE[dbo].[SP_USER_ACTIVATE]
GO

CREATE PROCEDURE [dbo].[SP_USER_ACTIVATE]
 @id as int
AS
BEGIN

UPDATE users SET status = 1 WHERE id = @id;

SELECT top 1 u.id, u.name, u.role_id, r.name as role_name, u.status 
	FROM users as u
	LEFT JOIN roles as r
		ON u.role_id = r.id
	WHERE u.id = @id
	order by u.id asc;


END
GO


-- ----------------------------
-- Auto increment value for roles
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[roles]', RESEED, 1003)
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
DBCC CHECKIDENT ('[dbo].[token_refresh]', RESEED, 1002)
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
DBCC CHECKIDENT ('[dbo].[users]', RESEED, 3030)
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

