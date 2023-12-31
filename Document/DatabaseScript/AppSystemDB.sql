USE [AppSystemDB]
GO
/****** Object:  Table [dbo].[SysArea]    Script Date: 2023/8/10 8:56:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysArea](
	[Id] [bigint] NOT NULL,
	[BaseIsDelete] [int] NOT NULL,
	[BaseCreateTime] [datetime] NOT NULL,
	[BaseModifyTime] [datetime] NOT NULL,
	[BaseCreatorId] [bigint] NOT NULL,
	[BaseModifierId] [bigint] NOT NULL,
	[BaseVersion] [int] NOT NULL,
	[AreaCode] [varchar](6) NOT NULL,
	[ParentAreaCode] [varchar](6) NOT NULL,
	[AreaName] [nvarchar](50) NOT NULL,
	[ZipCode] [varchar](50) NOT NULL,
	[AreaLevel] [int] NOT NULL,
 CONSTRAINT [PK_SysArea] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysAutoJob]    Script Date: 2023/8/10 8:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysAutoJob](
	[Id] [bigint] NOT NULL,
	[BaseIsDelete] [int] NOT NULL,
	[BaseCreateTime] [datetime] NOT NULL,
	[BaseModifyTime] [datetime] NOT NULL,
	[BaseCreatorId] [bigint] NOT NULL,
	[BaseModifierId] [bigint] NOT NULL,
	[BaseVersion] [int] NOT NULL,
	[JobGroupName] [nvarchar](50) NOT NULL,
	[JobName] [nvarchar](50) NOT NULL,
	[JobStatus] [int] NOT NULL,
	[CronExpression] [varchar](50) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[NextStartTime] [datetime] NOT NULL,
	[Remark] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_SysAutoJob] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysAutoJobLog]    Script Date: 2023/8/10 8:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysAutoJobLog](
	[Id] [bigint] NOT NULL,
	[BaseCreateTime] [datetime] NOT NULL,
	[BaseCreatorId] [bigint] NOT NULL,
	[JobGroupName] [nvarchar](50) NOT NULL,
	[JobName] [nvarchar](50) NOT NULL,
	[LogStatus] [int] NOT NULL,
	[Remark] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_SysAutoJobLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysDataDict]    Script Date: 2023/8/10 8:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysDataDict](
	[Id] [bigint] NOT NULL,
	[BaseIsDelete] [int] NOT NULL,
	[BaseCreateTime] [datetime] NOT NULL,
	[BaseModifyTime] [datetime] NOT NULL,
	[BaseCreatorId] [bigint] NOT NULL,
	[BaseModifierId] [bigint] NOT NULL,
	[BaseVersion] [int] NOT NULL,
	[DictType] [varchar](50) NOT NULL,
	[DictSort] [int] NOT NULL,
	[Remark] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SysDataDict] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysDataDictDetail]    Script Date: 2023/8/10 8:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysDataDictDetail](
	[Id] [bigint] NOT NULL,
	[BaseIsDelete] [int] NOT NULL,
	[BaseCreateTime] [datetime] NOT NULL,
	[BaseModifyTime] [datetime] NOT NULL,
	[BaseCreatorId] [bigint] NOT NULL,
	[BaseModifierId] [bigint] NOT NULL,
	[BaseVersion] [int] NOT NULL,
	[DictType] [varchar](50) NOT NULL,
	[DictSort] [int] NOT NULL,
	[DictKey] [int] NOT NULL,
	[DictValue] [varchar](50) NOT NULL,
	[ListClass] [varchar](50) NOT NULL,
	[DictStatus] [int] NOT NULL,
	[IsDefault] [int] NOT NULL,
	[Remark] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SysDataDictDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysDepartment]    Script Date: 2023/8/10 8:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysDepartment](
	[Id] [bigint] NOT NULL,
	[BaseIsDelete] [int] NOT NULL,
	[BaseCreateTime] [datetime] NOT NULL,
	[BaseModifyTime] [datetime] NOT NULL,
	[BaseCreatorId] [bigint] NOT NULL,
	[BaseModifierId] [bigint] NOT NULL,
	[BaseVersion] [int] NOT NULL,
	[ParentId] [bigint] NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL,
	[Telephone] [varchar](50) NOT NULL,
	[Fax] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[PrincipalId] [bigint] NOT NULL,
	[DepartmentSort] [int] NOT NULL,
	[Remark] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_SysDepartment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysLogApi]    Script Date: 2023/8/10 8:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysLogApi](
	[Id] [bigint] NOT NULL,
	[BaseCreateTime] [datetime] NOT NULL,
	[BaseCreatorId] [bigint] NOT NULL,
	[LogStatus] [int] NOT NULL,
	[Remark] [nvarchar](50) NOT NULL,
	[ExecuteUrl] [varchar](100) NOT NULL,
	[ExecuteParam] [nvarchar](4000) NOT NULL,
	[ExecuteResult] [nvarchar](4000) NOT NULL,
	[ExecuteTime] [int] NOT NULL,
 CONSTRAINT [PK_SysLogApi] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysLogLogin]    Script Date: 2023/8/10 8:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysLogLogin](
	[Id] [bigint] NOT NULL,
	[BaseCreateTime] [datetime] NOT NULL,
	[BaseCreatorId] [bigint] NOT NULL,
	[LogStatus] [int] NOT NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[IpLocation] [nvarchar](50) NOT NULL,
	[Browser] [nvarchar](50) NOT NULL,
	[OS] [nvarchar](50) NOT NULL,
	[Remark] [nvarchar](50) NOT NULL,
	[ExtraRemark] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_SysLogLogin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysLogOperate]    Script Date: 2023/8/10 8:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysLogOperate](
	[Id] [bigint] NOT NULL,
	[BaseCreateTime] [datetime] NOT NULL,
	[BaseCreatorId] [bigint] NOT NULL,
	[LogStatus] [int] NOT NULL,
	[IpAddress] [varchar](20) NOT NULL,
	[IpLocation] [nvarchar](50) NOT NULL,
	[Remark] [nvarchar](50) NOT NULL,
	[LogType] [varchar](50) NOT NULL,
	[BusinessType] [varchar](50) NOT NULL,
	[ExecuteUrl] [nvarchar](100) NOT NULL,
	[ExecuteParam] [nvarchar](4000) NOT NULL,
	[ExecuteResult] [nvarchar](4000) NOT NULL,
	[ExecuteTime] [int] NOT NULL,
 CONSTRAINT [PK_SysLogOperate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysMenu]    Script Date: 2023/8/10 8:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysMenu](
	[Id] [bigint] NOT NULL,
	[BaseIsDelete] [int] NOT NULL,
	[BaseCreateTime] [datetime] NOT NULL,
	[BaseModifyTime] [datetime] NOT NULL,
	[BaseCreatorId] [bigint] NOT NULL,
	[BaseModifierId] [bigint] NOT NULL,
	[BaseVersion] [int] NOT NULL,
	[ParentId] [bigint] NOT NULL,
	[MenuName] [nvarchar](50) NOT NULL,
	[MenuIcon] [varchar](50) NOT NULL,
	[MenuUrl] [varchar](100) NOT NULL,
	[MenuTarget] [varchar](50) NOT NULL,
	[MenuSort] [int] NOT NULL,
	[MenuType] [int] NOT NULL,
	[MenuStatus] [int] NOT NULL,
	[Authorize] [varchar](50) NOT NULL,
	[Remark] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SysMenu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysMenuAuthorize]    Script Date: 2023/8/10 8:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysMenuAuthorize](
	[Id] [bigint] NOT NULL,
	[BaseCreateTime] [datetime] NOT NULL,
	[BaseCreatorId] [bigint] NOT NULL,
	[MenuId] [bigint] NOT NULL,
	[AuthorizeId] [bigint] NOT NULL,
	[AuthorizeType] [int] NOT NULL,
 CONSTRAINT [PK_SysMenuAuthorize] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysNews]    Script Date: 2023/8/10 8:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysNews](
	[Id] [bigint] NOT NULL,
	[BaseIsDelete] [int] NOT NULL,
	[BaseCreateTime] [datetime] NOT NULL,
	[BaseModifyTime] [datetime] NOT NULL,
	[BaseCreatorId] [bigint] NOT NULL,
	[BaseModifierId] [bigint] NOT NULL,
	[BaseVersion] [int] NOT NULL,
	[NewsTitle] [nvarchar](300) NOT NULL,
	[NewsContent] [ntext] NOT NULL,
	[NewsTag] [nvarchar](200) NOT NULL,
	[ThumbImage] [varchar](200) NOT NULL,
	[NewsAuthor] [nvarchar](50) NOT NULL,
	[NewsSort] [int] NOT NULL,
	[NewsDate] [datetime] NOT NULL,
	[NewsType] [int] NOT NULL,
	[ViewTimes] [int] NOT NULL,
	[ProvinceId] [bigint] NOT NULL,
	[CityId] [bigint] NOT NULL,
	[CountyId] [bigint] NOT NULL,
 CONSTRAINT [PK_SysNews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysPosition]    Script Date: 2023/8/10 8:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysPosition](
	[Id] [bigint] NOT NULL,
	[BaseIsDelete] [int] NOT NULL,
	[BaseCreateTime] [datetime] NOT NULL,
	[BaseModifyTime] [datetime] NOT NULL,
	[BaseCreatorId] [bigint] NOT NULL,
	[BaseModifierId] [bigint] NOT NULL,
	[BaseVersion] [int] NOT NULL,
	[PositionName] [nvarchar](50) NOT NULL,
	[PositionSort] [int] NOT NULL,
	[PositionStatus] [int] NOT NULL,
	[Remark] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SysPosition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysRole]    Script Date: 2023/8/10 8:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysRole](
	[Id] [bigint] NOT NULL,
	[BaseIsDelete] [int] NOT NULL,
	[BaseCreateTime] [datetime] NOT NULL,
	[BaseModifyTime] [datetime] NOT NULL,
	[BaseCreatorId] [bigint] NOT NULL,
	[BaseModifierId] [bigint] NOT NULL,
	[BaseVersion] [int] NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[RoleSort] [int] NOT NULL,
	[RoleStatus] [int] NOT NULL,
	[Remark] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SysRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysUser]    Script Date: 2023/8/10 8:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysUser](
	[Id] [bigint] NOT NULL,
	[BaseIsDelete] [int] NOT NULL,
	[BaseCreateTime] [datetime] NOT NULL,
	[BaseModifyTime] [datetime] NOT NULL,
	[BaseCreatorId] [bigint] NOT NULL,
	[BaseModifierId] [bigint] NOT NULL,
	[BaseVersion] [int] NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Password] [varchar](32) NOT NULL,
	[ClearTextPassword] [varchar](32) NULL,
	[Salt] [varchar](5) NOT NULL,
	[RealName] [nvarchar](20) NOT NULL,
	[DepartmentId] [bigint] NOT NULL,
	[Gender] [int] NOT NULL,
	[Birthday] [varchar](10) NOT NULL,
	[Portrait] [varchar](200) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Mobile] [varchar](11) NOT NULL,
	[QQ] [varchar](20) NOT NULL,
	[WeChat] [varchar](20) NOT NULL,
	[LoginCount] [int] NOT NULL,
	[UserStatus] [int] NOT NULL,
	[IsSystem] [int] NOT NULL,
	[IsOnline] [int] NOT NULL,
	[FirstVisit] [datetime] NOT NULL,
	[PreviousVisit] [datetime] NOT NULL,
	[LastVisit] [datetime] NOT NULL,
	[Remark] [nvarchar](200) NOT NULL,
	[WebToken] [varchar](32) NOT NULL,
	[ApiToken] [varchar](32) NOT NULL,
 CONSTRAINT [PK_SysUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysUserBelong]    Script Date: 2023/8/10 8:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysUserBelong](
	[Id] [bigint] NOT NULL,
	[BaseCreateTime] [datetime] NOT NULL,
	[BaseCreatorId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[BelongId] [bigint] NOT NULL,
	[BelongType] [int] NOT NULL,
 CONSTRAINT [PK_SysUserBelong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_AppInstallRecord]    Script Date: 2023/8/10 8:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_AppInstallRecord](
	[Id] [int] NOT NULL,
	[BaseIsDelete] [int] NOT NULL,
	[BaseCreateTime] [datetime] NOT NULL,
	[BaseModifyTime] [datetime] NOT NULL,
	[BaseCreatorId] [bigint] NOT NULL,
	[BaseModifierId] [bigint] NOT NULL,
	[BaseVersion] [int] NOT NULL,
	[UserId] [bigint] NULL,
	[AppName] [nvarchar](500) NULL,
	[AppApkName] [nvarchar](100) NULL,
	[IMEI] [nvarchar](100) NULL,
	[InstallDate] [datetime] NULL,
	[PartnerProfit] [decimal](18, 2) NULL,
	[AgentProfit] [decimal](18, 2) NULL,
	[ClerkProfit] [decimal](18, 2) NULL,
	[AdvertFrom] [int] NULL,
 CONSTRAINT [PK_T_AppInstallRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_ProportionSetting]    Script Date: 2023/8/10 8:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_ProportionSetting](
	[Id] [int] NOT NULL,
	[BaseIsDelete] [int] NOT NULL,
	[BaseCreateTime] [datetime] NOT NULL,
	[BaseModifyTime] [datetime] NOT NULL,
	[BaseCreatorId] [bigint] NOT NULL,
	[BaseModifierId] [bigint] NOT NULL,
	[BaseVersion] [int] NOT NULL,
	[PartnerProportion] [decimal](18, 2) NULL,
	[AgentProportion] [decimal](18, 2) NULL,
	[ClerkProportion] [decimal](18, 2) NULL,
 CONSTRAINT [PK_T_ProportionSetting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_SettlementRecord]    Script Date: 2023/8/10 8:56:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_SettlementRecord](
	[Id] [int] NOT NULL,
	[BaseIsDelete] [int] NOT NULL,
	[BaseCreateTime] [datetime] NOT NULL,
	[BaseModifyTime] [datetime] NOT NULL,
	[BaseCreatorId] [bigint] NOT NULL,
	[BaseModifierId] [bigint] NOT NULL,
	[BaseVersion] [int] NOT NULL,
	[SettlementDate] [datetime] NULL,
	[InstallCount] [int] NULL,
	[SettlementAmount] [decimal](18, 2) NULL,
	[UnitPrice] [decimal](18, 2) NULL,
	[ActualSettlementAmount] [decimal](18, 2) NULL,
	[ActualUnitPrice] [decimal](18, 2) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_T_SettlementRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysArea', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除标记(0正常 1删除)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysArea', @level2type=N'COLUMN',@level2name=N'BaseIsDelete'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysArea', @level2type=N'COLUMN',@level2name=N'BaseCreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysArea', @level2type=N'COLUMN',@level2name=N'BaseModifyTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysArea', @level2type=N'COLUMN',@level2name=N'BaseCreatorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysArea', @level2type=N'COLUMN',@level2name=N'BaseModifierId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据版本(每次更新+1)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysArea', @level2type=N'COLUMN',@level2name=N'BaseVersion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地区编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysArea', @level2type=N'COLUMN',@level2name=N'AreaCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父地区编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysArea', @level2type=N'COLUMN',@level2name=N'ParentAreaCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地区名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysArea', @level2type=N'COLUMN',@level2name=N'AreaName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮政编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysArea', @level2type=N'COLUMN',@level2name=N'ZipCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地区层级(1省份 2城市 3区县)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysArea', @level2type=N'COLUMN',@level2name=N'AreaLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务组名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysAutoJob', @level2type=N'COLUMN',@level2name=N'JobGroupName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysAutoJob', @level2type=N'COLUMN',@level2name=N'JobName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务状态(0禁用 1启用)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysAutoJob', @level2type=N'COLUMN',@level2name=N'JobStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'cron表达式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysAutoJob', @level2type=N'COLUMN',@level2name=N'CronExpression'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运行开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysAutoJob', @level2type=N'COLUMN',@level2name=N'StartTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运行结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysAutoJob', @level2type=N'COLUMN',@level2name=N'EndTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下次执行时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysAutoJob', @level2type=N'COLUMN',@level2name=N'NextStartTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysAutoJob', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务组名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysAutoJobLog', @level2type=N'COLUMN',@level2name=N'JobGroupName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysAutoJobLog', @level2type=N'COLUMN',@level2name=N'JobName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行状态(0失败 1成功)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysAutoJobLog', @level2type=N'COLUMN',@level2name=N'LogStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysAutoJobLog', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysDataDict', @level2type=N'COLUMN',@level2name=N'DictType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysDataDict', @level2type=N'COLUMN',@level2name=N'DictSort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysDataDict', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典类型(外键)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysDataDictDetail', @level2type=N'COLUMN',@level2name=N'DictType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysDataDictDetail', @level2type=N'COLUMN',@level2name=N'DictSort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典键(一般从1开始)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysDataDictDetail', @level2type=N'COLUMN',@level2name=N'DictKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysDataDictDetail', @level2type=N'COLUMN',@level2name=N'DictValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示样式(default primary success info warning danger)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysDataDictDetail', @level2type=N'COLUMN',@level2name=N'ListClass'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典状态(0禁用 1启用)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysDataDictDetail', @level2type=N'COLUMN',@level2name=N'DictStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'默认选中(0不是 1是)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysDataDictDetail', @level2type=N'COLUMN',@level2name=N'IsDefault'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysDataDictDetail', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父部门Id(0表示是根部门)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysDepartment', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysDepartment', @level2type=N'COLUMN',@level2name=N'DepartmentName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysDepartment', @level2type=N'COLUMN',@level2name=N'Telephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门传真' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysDepartment', @level2type=N'COLUMN',@level2name=N'Fax'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门Email' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysDepartment', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门负责人Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysDepartment', @level2type=N'COLUMN',@level2name=N'PrincipalId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysDepartment', @level2type=N'COLUMN',@level2name=N'DepartmentSort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysDepartment', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行状态(0失败 1成功)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogApi', @level2type=N'COLUMN',@level2name=N'LogStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogApi', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'接口地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogApi', @level2type=N'COLUMN',@level2name=N'ExecuteUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求参数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogApi', @level2type=N'COLUMN',@level2name=N'ExecuteParam'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求结果' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogApi', @level2type=N'COLUMN',@level2name=N'ExecuteResult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogApi', @level2type=N'COLUMN',@level2name=N'ExecuteTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行状态(0失败 1成功)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogLogin', @level2type=N'COLUMN',@level2name=N'LogStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ip地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogLogin', @level2type=N'COLUMN',@level2name=N'IpAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ip位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogLogin', @level2type=N'COLUMN',@level2name=N'IpLocation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'浏览器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogLogin', @level2type=N'COLUMN',@level2name=N'Browser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作系统' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogLogin', @level2type=N'COLUMN',@level2name=N'OS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogLogin', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'额外备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogLogin', @level2type=N'COLUMN',@level2name=N'ExtraRemark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行状态(0失败 1成功)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogOperate', @level2type=N'COLUMN',@level2name=N'LogStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ip地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogOperate', @level2type=N'COLUMN',@level2name=N'IpAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ip位置' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogOperate', @level2type=N'COLUMN',@level2name=N'IpLocation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogOperate', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志类型(暂未用到)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogOperate', @level2type=N'COLUMN',@level2name=N'LogType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'业务类型(暂未用到)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogOperate', @level2type=N'COLUMN',@level2name=N'BusinessType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'页面地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogOperate', @level2type=N'COLUMN',@level2name=N'ExecuteUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求参数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogOperate', @level2type=N'COLUMN',@level2name=N'ExecuteParam'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'请求结果' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogOperate', @level2type=N'COLUMN',@level2name=N'ExecuteResult'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysLogOperate', @level2type=N'COLUMN',@level2name=N'ExecuteTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父菜单Id(0表示是根菜单)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysMenu', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysMenu', @level2type=N'COLUMN',@level2name=N'MenuName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysMenu', @level2type=N'COLUMN',@level2name=N'MenuIcon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单Url' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysMenu', @level2type=N'COLUMN',@level2name=N'MenuUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链接打开方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysMenu', @level2type=N'COLUMN',@level2name=N'MenuTarget'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysMenu', @level2type=N'COLUMN',@level2name=N'MenuSort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单类型(1目录 2页面 3按钮)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysMenu', @level2type=N'COLUMN',@level2name=N'MenuType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单状态(0禁用 1启用)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysMenu', @level2type=N'COLUMN',@level2name=N'MenuStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单权限标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysMenu', @level2type=N'COLUMN',@level2name=N'Authorize'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysMenu', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysMenuAuthorize', @level2type=N'COLUMN',@level2name=N'MenuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'授权Id(角色Id或者用户Id)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysMenuAuthorize', @level2type=N'COLUMN',@level2name=N'AuthorizeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'授权类型(1角色 2用户)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysMenuAuthorize', @level2type=N'COLUMN',@level2name=N'AuthorizeType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新闻标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysNews', @level2type=N'COLUMN',@level2name=N'NewsTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新闻内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysNews', @level2type=N'COLUMN',@level2name=N'NewsContent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新闻标签' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysNews', @level2type=N'COLUMN',@level2name=N'NewsTag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缩略图' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysNews', @level2type=N'COLUMN',@level2name=N'ThumbImage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysNews', @level2type=N'COLUMN',@level2name=N'NewsAuthor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新闻排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysNews', @level2type=N'COLUMN',@level2name=N'NewsSort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发布时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysNews', @level2type=N'COLUMN',@level2name=N'NewsDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'新闻类型(1产品案例 2行业新闻)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysNews', @level2type=N'COLUMN',@level2name=N'NewsType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'查看次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysNews', @level2type=N'COLUMN',@level2name=N'ViewTimes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'省份Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysNews', @level2type=N'COLUMN',@level2name=N'ProvinceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'城市Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysNews', @level2type=N'COLUMN',@level2name=N'CityId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'区县Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysNews', @level2type=N'COLUMN',@level2name=N'CountyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职位名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysPosition', @level2type=N'COLUMN',@level2name=N'PositionName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职位排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysPosition', @level2type=N'COLUMN',@level2name=N'PositionSort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职位状态(0禁用 1启用)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysPosition', @level2type=N'COLUMN',@level2name=N'PositionStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysPosition', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRole', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRole', @level2type=N'COLUMN',@level2name=N'RoleSort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色状态(0禁用 1启用)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRole', @level2type=N'COLUMN',@level2name=N'RoleStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysRole', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码盐值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'Salt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'RealName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属部门Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'DepartmentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别(0未知 1男 2女)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出生日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'Birthday'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'头像' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'Portrait'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Email' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'QQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'WeChat'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'LoginCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户状态(0禁用 1启用)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'UserStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统用户(0不是 1是[系统用户拥有所有的权限])' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'IsSystem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'在线(0不是 1是)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'IsOnline'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'首次登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'FirstVisit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上一次登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'PreviousVisit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后一次登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'LastVisit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'后台Token' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'WebToken'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ApiToken' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUser', @level2type=N'COLUMN',@level2name=N'ApiToken'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUserBelong', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职位Id或者角色Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUserBelong', @level2type=N'COLUMN',@level2name=N'BelongId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属类型(1职位 2角色)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SysUserBelong', @level2type=N'COLUMN',@level2name=N'BelongType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'店员ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_AppInstallRecord', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应用名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_AppInstallRecord', @level2type=N'COLUMN',@level2name=N'AppName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'合作伙伴收益' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_AppInstallRecord', @level2type=N'COLUMN',@level2name=N'PartnerProfit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代理商收益' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_AppInstallRecord', @level2type=N'COLUMN',@level2name=N'AgentProfit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'店员收益' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_AppInstallRecord', @level2type=N'COLUMN',@level2name=N'ClerkProfit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'广告来源：1鲨鱼宝；2海螺广告。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_AppInstallRecord', @level2type=N'COLUMN',@level2name=N'AdvertFrom'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'合作伙伴比例' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_ProportionSetting', @level2type=N'COLUMN',@level2name=N'PartnerProportion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代理商比例' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_ProportionSetting', @level2type=N'COLUMN',@level2name=N'AgentProportion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'店员比例' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_ProportionSetting', @level2type=N'COLUMN',@level2name=N'ClerkProportion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'结算日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SettlementRecord', @level2type=N'COLUMN',@level2name=N'SettlementDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效总量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SettlementRecord', @level2type=N'COLUMN',@level2name=N'InstallCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预估结算金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SettlementRecord', @level2type=N'COLUMN',@level2name=N'SettlementAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SettlementRecord', @level2type=N'COLUMN',@level2name=N'UnitPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际结算金额（T+7）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SettlementRecord', @level2type=N'COLUMN',@level2name=N'ActualSettlementAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实际单价（T+7之后才有数据）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SettlementRecord', @level2type=N'COLUMN',@level2name=N'ActualUnitPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态：0未结算；1已结算；' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SettlementRecord', @level2type=N'COLUMN',@level2name=N'Status'
GO
