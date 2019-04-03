
CREATE TABLE [dbo].[Mst_Result](
	[Srno] [bigint] IDENTITY(1,1) NOT NULL,
	[ResultDate] [nvarchar](50) NULL DEFAULT (''),
	[ResultType] [nvarchar](50) NULL DEFAULT (''),
	[Status] [nvarchar](50) NULL DEFAULT ('ACTIVE'),
	[F1] [nvarchar](4) NULL DEFAULT ('-'),
	[F2] [nvarchar](4) NULL DEFAULT ('-'),
	[F3] [nvarchar](4) NULL DEFAULT ('-'), 
	[S1] [nvarchar](4) NULL DEFAULT ('-'), 
	[S2] [nvarchar](4) NULL DEFAULT ('-'), 
	[S3] [nvarchar](4) NULL DEFAULT ('-'), 
	[S4] [nvarchar](4) NULL DEFAULT ('-'), 
	[S5] [nvarchar](4) NULL DEFAULT ('-'), 
	[S6] [nvarchar](4) NULL DEFAULT ('-'), 
	[S7] [nvarchar](4) NULL DEFAULT ('-'), 
	[S8] [nvarchar](4) NULL DEFAULT ('-'), 
	[S9] [nvarchar](4) NULL DEFAULT ('-'), 
	[S10] [nvarchar](4) NULL DEFAULT ('-'),
	[T1] [nvarchar](4) NULL DEFAULT ('-'), 
	[T2] [nvarchar](4) NULL DEFAULT ('-'), 
	[T3] [nvarchar](4) NULL DEFAULT ('-'), 
	[T4] [nvarchar](4) NULL DEFAULT ('-'), 
	[T5] [nvarchar](4) NULL DEFAULT ('-'), 
	[T6] [nvarchar](4) NULL DEFAULT ('-'), 
	[T7] [nvarchar](4) NULL DEFAULT ('-'), 
	[T8] [nvarchar](4) NULL DEFAULT ('-'), 
	[T9] [nvarchar](4) NULL DEFAULT ('-'), 
	[T10] [nvarchar](4) NULL DEFAULT ('-')
) ON [PRIMARY]