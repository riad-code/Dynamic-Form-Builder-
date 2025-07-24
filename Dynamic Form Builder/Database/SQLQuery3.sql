USE [FormDatabase]
GO
/****** Object:  Table [dbo].[DropdownFields]    Script Date: 7/24/2025 12:04:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DropdownFields](
	[FieldId] [int] IDENTITY(1,1) NOT NULL,
	[FormId] [int] NOT NULL,
	[Label] [nvarchar](max) NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[SelectedOption] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DropdownFields] PRIMARY KEY CLUSTERED 
(
	[FieldId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DropdownFields] ON 
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (11, 2, N'Level 1', 0, N'Option 1')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (12, 2, N'Level 2', 0, N'Option 1')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (19, 4, N'Level 1', 0, N'Option 1')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (20, 4, N'Level 2', 0, N'Option 2')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (21, 4, N'Level 3', 0, N'Option 1')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (32, 6, N'Level 1', 0, N'Option 2')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (33, 6, N'Level 2', 0, N'Option 2')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (34, 6, N'Level 3', 0, N'Option 2')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (35, 6, N'Level 4', 0, N'Option 1')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (36, 7, N'Level 1', 0, N'Option 2')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (37, 7, N'Level 2', 0, N'Option 2')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (38, 7, N'Level 3', 0, N'Option 2')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (39, 1, N'Level 1', 0, N'Option 2')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (40, 1, N'Level 2', 0, N'Option 1')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (41, 1, N'Level 3', 0, N'Option 2')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (42, 8, N'Level 1', 0, N'Option 1')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (43, 8, N'Level 2', 0, N'Option 2')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (44, 8, N'Level 3', 0, N'Option 1')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (45, 8, N'Level 4', 0, N'Option 1')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (46, 9, N'Level 1', 0, N'Option 2')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (47, 9, N'Level 2', 0, N'Option 1')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (48, 9, N'Level 3', 0, N'Option 1')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (49, 3, N'Level 1', 0, N'Option 2')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (50, 3, N'Level 2', 0, N'Option 1')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (51, 3, N'Level 3', 0, N'Option 3')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (52, 3, N'Level 4', 0, N'Option 1')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (53, 5, N'Level 1', 1, N'Option 2')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (54, 5, N'Level 2', 1, N'Option 2')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (55, 5, N'Level 3', 1, N'Option 2')
GO
INSERT [dbo].[DropdownFields] ([FieldId], [FormId], [Label], [IsRequired], [SelectedOption]) VALUES (56, 5, N'Level 4', 1, N'Option 1')
GO
SET IDENTITY_INSERT [dbo].[DropdownFields] OFF
GO
ALTER TABLE [dbo].[DropdownFields]  WITH CHECK ADD  CONSTRAINT [FK_DropdownFields_Forms_FormId] FOREIGN KEY([FormId])
REFERENCES [dbo].[Forms] ([FormId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DropdownFields] CHECK CONSTRAINT [FK_DropdownFields_Forms_FormId]
GO
