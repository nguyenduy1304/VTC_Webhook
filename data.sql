USE [VTC_Kasperskey]
GO
/****** Object:  Table [dbo].[VTC_MapProducts]    Script Date: 4/19/2023 5:56:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VTC_MapProducts](
	[VTC_Product_Code] [varchar](40) NOT NULL,
	[VTC_Product_Id] [varchar](40) NOT NULL,
	[Abaha_Product_Code] [varchar](20) NULL,
	[ProductName] [nvarchar](max) NULL,
	[ShortName] [varchar](20) NULL,
 CONSTRAINT [PK_VTC_MapProducts] PRIMARY KEY CLUSTERED 
(
	[VTC_Product_Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VTC_Order_Detail]    Script Date: 4/19/2023 5:56:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VTC_Order_Detail](
	[Id] [varchar](40) NOT NULL,
	[RefId_Abaha] [varchar](20) NOT NULL,
	[RefId_Telcohub] [varchar](30) NOT NULL,
	[Key_Value] [varchar](30) NULL,
	[ActivationDate] [date] NULL,
	[Expires] [date] NULL,
	[Abaha_Product_Code] [varchar](40) NULL,
	[Product_Code] [varchar](40) NULL,
	[RequestId_Activate] [varchar](20) NOT NULL,
	[RequestId_ShippingData] [varchar](20) NULL,
 CONSTRAINT [PK_VTC_Order_Detail_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VTC_Orders]    Script Date: 4/19/2023 5:56:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VTC_Orders](
	[RefId] [varchar](20) NOT NULL,
	[UserId] [varchar](20) NULL,
	[FullName] [nvarchar](100) NULL,
	[Address] [nvarchar](500) NULL,
	[Phone] [nchar](15) NULL,
	[OrdersTime] [date] NULL,
	[Total] [varchar](20) NULL,
	[Status_sms] [bit] NOT NULL,
 CONSTRAINT [PK_VTC_Orders_1] PRIMARY KEY CLUSTERED 
(
	[RefId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[VTC_MapProducts] ([VTC_Product_Code], [VTC_Product_Id], [Abaha_Product_Code], [ProductName], [ShortName]) VALUES (N'2022011201', N'KAS1', N'720865', N'Phần mềm Kaspersky Internet Security - Multi-Device (1DVC)', N'Kas1DVC')
INSERT [dbo].[VTC_MapProducts] ([VTC_Product_Code], [VTC_Product_Id], [Abaha_Product_Code], [ProductName], [ShortName]) VALUES (N'2022011202', N'KAS2', N'720875', N'Phần mềm Kaspersky Internet Security - Multi-Device (3DVC)', N'Kas3DVC')
INSERT [dbo].[VTC_MapProducts] ([VTC_Product_Code], [VTC_Product_Id], [Abaha_Product_Code], [ProductName], [ShortName]) VALUES (N'2022011203', N'KAS3', N'720878', N'Phần mềm Kaspersky Internet Security - Multi-Device (5DVC)', N'Kas5DVC')
INSERT [dbo].[VTC_MapProducts] ([VTC_Product_Code], [VTC_Product_Id], [Abaha_Product_Code], [ProductName], [ShortName]) VALUES (N'2022011204', N'KSK', N'720879', N'Phần mềm Kaspersky Safe Kid', N'Kas_Kid')
GO
INSERT [dbo].[VTC_Order_Detail] ([Id], [RefId_Abaha], [RefId_Telcohub], [Key_Value], [ActivationDate], [Expires], [Abaha_Product_Code], [Product_Code], [RequestId_Activate], [RequestId_ShippingData]) VALUES (N'5982c1e5-e6bd-4457-9743-6e4bc892cc88', N'582568', N'582568_1_1', N'ADO0S-LGWGD-LCKCR-MCWHB', CAST(N'2023-04-19' AS Date), CAST(N'2024-04-18' AS Date), N'720865', N'2022011201', N'109525', N'109526')
INSERT [dbo].[VTC_Order_Detail] ([Id], [RefId_Abaha], [RefId_Telcohub], [Key_Value], [ActivationDate], [Expires], [Abaha_Product_Code], [Product_Code], [RequestId_Activate], [RequestId_ShippingData]) VALUES (N'be2705e1-02fa-4274-8593-efc08b744048', N'582568', N'582568_2_1', N'SQH6W-XBCQK-PU4FU-EQFBT', CAST(N'2023-04-19' AS Date), CAST(N'2024-04-18' AS Date), N'720875', N'2022011202', N'109529', N'109530')
INSERT [dbo].[VTC_Order_Detail] ([Id], [RefId_Abaha], [RefId_Telcohub], [Key_Value], [ActivationDate], [Expires], [Abaha_Product_Code], [Product_Code], [RequestId_Activate], [RequestId_ShippingData]) VALUES (N'd615670f-396f-4d71-bb1c-8aabc8f398c8', N'582568', N'582568_1_2', N'RAVJN-4NMD3-2LY6T-GFQEB', CAST(N'2023-04-19' AS Date), CAST(N'2024-04-18' AS Date), N'720865', N'2022011201', N'109527', N'109528')
INSERT [dbo].[VTC_Order_Detail] ([Id], [RefId_Abaha], [RefId_Telcohub], [Key_Value], [ActivationDate], [Expires], [Abaha_Product_Code], [Product_Code], [RequestId_Activate], [RequestId_ShippingData]) VALUES (N'd913d3b9-93e7-478f-a0b8-4b754ad2b156', N'582568', N'582568_2_2', N'Z6LPT-VZIHA-S5MEJ-EDHTA', CAST(N'2023-04-19' AS Date), CAST(N'2024-04-18' AS Date), N'720875', N'2022011202', N'109531', N'109532')
GO
INSERT [dbo].[VTC_Orders] ([RefId], [UserId], [FullName], [Address], [Phone], [OrdersTime], [Total], [Status_sms]) VALUES (N'582568', N'4293373', N'Nguyễn Duy', N'Quí Thạnh(Xã Tân Hội,Thị xã Cai Lậy,Tỉnh Tiền Giang)', N'84369852701    ', CAST(N'2023-04-19' AS Date), N'900000', 1)
GO
ALTER TABLE [dbo].[VTC_Order_Detail]  WITH CHECK ADD  CONSTRAINT [FK_VTC_Order_Detail_VTC_MapProducts] FOREIGN KEY([Product_Code])
REFERENCES [dbo].[VTC_MapProducts] ([VTC_Product_Code])
GO
ALTER TABLE [dbo].[VTC_Order_Detail] CHECK CONSTRAINT [FK_VTC_Order_Detail_VTC_MapProducts]
GO
ALTER TABLE [dbo].[VTC_Order_Detail]  WITH CHECK ADD  CONSTRAINT [FK_VTC_Order_Detail_VTC_Orders] FOREIGN KEY([RefId_Abaha])
REFERENCES [dbo].[VTC_Orders] ([RefId])
GO
ALTER TABLE [dbo].[VTC_Order_Detail] CHECK CONSTRAINT [FK_VTC_Order_Detail_VTC_Orders]
GO
