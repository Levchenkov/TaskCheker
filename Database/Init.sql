USE [aspnet-TaskChecker.Web-20180814050004]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 20.08.2018 17:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 20.08.2018 17:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 20.08.2018 17:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 20.08.2018 17:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 20.08.2018 17:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CourseClasses]    Script Date: 20.08.2018 17:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseClasses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsOpened] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.CourseClasses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExerciseResults]    Script Date: 20.08.2018 17:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExerciseResults](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Mark] [int] NOT NULL,
	[Exercise_Id] [int] NULL,
	[Student_Id] [int] NULL,
	[Submission_Id] [int] NULL,
	[LabWorkResult_Id] [int] NULL,
 CONSTRAINT [PK_dbo.ExerciseResults] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Exercises]    Script Date: 20.08.2018 17:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exercises](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Value] [int] NOT NULL,
	[LabWork_Id] [int] NULL,
	[IsStatic] [bit] NOT NULL,
	[TypeName] [nvarchar](max) NULL,
	[MethodName] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Exercises] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExerciseTestResults]    Script Date: 20.08.2018 17:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExerciseTestResults](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Information] [nvarchar](max) NULL,
	[IsPassed] [bit] NOT NULL,
	[Submission_Id] [int] NULL,
 CONSTRAINT [PK_dbo.ExerciseTestResults] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExerciseTests]    Script Date: 20.08.2018 17:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExerciseTests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](max) NULL,
	[IsEnabled] [bit] NOT NULL,
	[Exercise_Id] [int] NULL,
 CONSTRAINT [PK_dbo.ExerciseTests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LabWorkCourseClasses]    Script Date: 20.08.2018 17:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LabWorkCourseClasses](
	[LabWork_Id] [int] NOT NULL,
	[CourseClass_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.LabWorkCourseClasses] PRIMARY KEY CLUSTERED 
(
	[LabWork_Id] ASC,
	[CourseClass_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LabWorkResults]    Script Date: 20.08.2018 17:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LabWorkResults](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Mark] [int] NOT NULL,
	[LabWork_Id] [int] NULL,
	[Student_Id] [int] NULL,
 CONSTRAINT [PK_dbo.LabWorkResults] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LabWorks]    Script Date: 20.08.2018 17:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LabWorks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsOpened] [bit] NOT NULL,
	[DueDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.LabWorks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentCourseClasses]    Script Date: 20.08.2018 17:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourseClasses](
	[Student_Id] [int] NOT NULL,
	[CourseClass_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.StudentCourseClasses] PRIMARY KEY CLUSTERED 
(
	[Student_Id] ASC,
	[CourseClass_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 20.08.2018 17:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[User_Id] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Submissions]    Script Date: 20.08.2018 17:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Submissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsFinal] [bit] NOT NULL,
	[IsTested] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Student_Id] [int] NULL,
	[SubmittedContent_Id] [int] NULL,
	[Exercise_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Submissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubmittedContents]    Script Date: 20.08.2018 17:42:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubmittedContents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[TypeName] [nvarchar](max) NULL,
	[MethodName] [nvarchar](max) NULL,
	[IsStatic] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.SubmittedContents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Exercises] ADD  DEFAULT ((0)) FOR [IsStatic]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[ExerciseResults]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ExerciseResults_dbo.Exercises_Exercise_Id] FOREIGN KEY([Exercise_Id])
REFERENCES [dbo].[Exercises] ([Id])
GO
ALTER TABLE [dbo].[ExerciseResults] CHECK CONSTRAINT [FK_dbo.ExerciseResults_dbo.Exercises_Exercise_Id]
GO
ALTER TABLE [dbo].[ExerciseResults]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ExerciseResults_dbo.LabWorkResults_LabWorkResult_Id] FOREIGN KEY([LabWorkResult_Id])
REFERENCES [dbo].[LabWorkResults] ([Id])
GO
ALTER TABLE [dbo].[ExerciseResults] CHECK CONSTRAINT [FK_dbo.ExerciseResults_dbo.LabWorkResults_LabWorkResult_Id]
GO
ALTER TABLE [dbo].[ExerciseResults]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ExerciseResults_dbo.Students_Student_Id] FOREIGN KEY([Student_Id])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[ExerciseResults] CHECK CONSTRAINT [FK_dbo.ExerciseResults_dbo.Students_Student_Id]
GO
ALTER TABLE [dbo].[ExerciseResults]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ExerciseResults_dbo.Submissions_Submission_Id] FOREIGN KEY([Submission_Id])
REFERENCES [dbo].[Submissions] ([Id])
GO
ALTER TABLE [dbo].[ExerciseResults] CHECK CONSTRAINT [FK_dbo.ExerciseResults_dbo.Submissions_Submission_Id]
GO
ALTER TABLE [dbo].[Exercises]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Exercises_dbo.LabWorks_LabWork_Id] FOREIGN KEY([LabWork_Id])
REFERENCES [dbo].[LabWorks] ([Id])
GO
ALTER TABLE [dbo].[Exercises] CHECK CONSTRAINT [FK_dbo.Exercises_dbo.LabWorks_LabWork_Id]
GO
ALTER TABLE [dbo].[ExerciseTestResults]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ExerciseTestResults_dbo.Submissions_Submission_Id] FOREIGN KEY([Submission_Id])
REFERENCES [dbo].[Submissions] ([Id])
GO
ALTER TABLE [dbo].[ExerciseTestResults] CHECK CONSTRAINT [FK_dbo.ExerciseTestResults_dbo.Submissions_Submission_Id]
GO
ALTER TABLE [dbo].[ExerciseTests]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ExerciseTests_dbo.Exercises_Exercise_Id] FOREIGN KEY([Exercise_Id])
REFERENCES [dbo].[Exercises] ([Id])
GO
ALTER TABLE [dbo].[ExerciseTests] CHECK CONSTRAINT [FK_dbo.ExerciseTests_dbo.Exercises_Exercise_Id]
GO
ALTER TABLE [dbo].[LabWorkCourseClasses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LabWorkCourseClasses_dbo.CourseClasses_CourseClass_Id] FOREIGN KEY([CourseClass_Id])
REFERENCES [dbo].[CourseClasses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LabWorkCourseClasses] CHECK CONSTRAINT [FK_dbo.LabWorkCourseClasses_dbo.CourseClasses_CourseClass_Id]
GO
ALTER TABLE [dbo].[LabWorkCourseClasses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LabWorkCourseClasses_dbo.LabWorks_LabWork_Id] FOREIGN KEY([LabWork_Id])
REFERENCES [dbo].[LabWorks] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LabWorkCourseClasses] CHECK CONSTRAINT [FK_dbo.LabWorkCourseClasses_dbo.LabWorks_LabWork_Id]
GO
ALTER TABLE [dbo].[LabWorkResults]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LabWorkResults_dbo.LabWorks_LabWork_Id] FOREIGN KEY([LabWork_Id])
REFERENCES [dbo].[LabWorks] ([Id])
GO
ALTER TABLE [dbo].[LabWorkResults] CHECK CONSTRAINT [FK_dbo.LabWorkResults_dbo.LabWorks_LabWork_Id]
GO
ALTER TABLE [dbo].[LabWorkResults]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LabWorkResults_dbo.Students_Student_Id] FOREIGN KEY([Student_Id])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[LabWorkResults] CHECK CONSTRAINT [FK_dbo.LabWorkResults_dbo.Students_Student_Id]
GO
ALTER TABLE [dbo].[StudentCourseClasses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StudentCourseClasses_dbo.CourseClasses_CourseClass_Id] FOREIGN KEY([CourseClass_Id])
REFERENCES [dbo].[CourseClasses] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentCourseClasses] CHECK CONSTRAINT [FK_dbo.StudentCourseClasses_dbo.CourseClasses_CourseClass_Id]
GO
ALTER TABLE [dbo].[StudentCourseClasses]  WITH CHECK ADD  CONSTRAINT [FK_dbo.StudentCourseClasses_dbo.Students_Student_Id] FOREIGN KEY([Student_Id])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentCourseClasses] CHECK CONSTRAINT [FK_dbo.StudentCourseClasses_dbo.Students_Student_Id]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Students_dbo.AspNetUsers_User_Id] FOREIGN KEY([User_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_dbo.Students_dbo.AspNetUsers_User_Id]
GO
ALTER TABLE [dbo].[Submissions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Submissions_dbo.Exercises_Exercise_Id] FOREIGN KEY([Exercise_Id])
REFERENCES [dbo].[Exercises] ([Id])
GO
ALTER TABLE [dbo].[Submissions] CHECK CONSTRAINT [FK_dbo.Submissions_dbo.Exercises_Exercise_Id]
GO
ALTER TABLE [dbo].[Submissions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Submissions_dbo.Students_Student_Id] FOREIGN KEY([Student_Id])
REFERENCES [dbo].[Students] ([Id])
GO
ALTER TABLE [dbo].[Submissions] CHECK CONSTRAINT [FK_dbo.Submissions_dbo.Students_Student_Id]
GO
ALTER TABLE [dbo].[Submissions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Submissions_dbo.SubmittedContents_SubmittedContent_Id] FOREIGN KEY([SubmittedContent_Id])
REFERENCES [dbo].[SubmittedContents] ([Id])
GO
ALTER TABLE [dbo].[Submissions] CHECK CONSTRAINT [FK_dbo.Submissions_dbo.SubmittedContents_SubmittedContent_Id]
GO
