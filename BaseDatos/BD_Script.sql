USE [BD_Formulario]
GO
/****** Object:  Table [dbo].[Formulario]    Script Date: 12/10/2019 02:05:08 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formulario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[ApellidoPaterno] [varchar](100) NULL,
	[ApellidoMaterno] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetFormulario]    Script Date: 12/10/2019 02:05:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetFormulario]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, Nombre, ApellidoPaterno, ApellidoMaterno
	FROM Formulario
	FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

END
GO
/****** Object:  StoredProcedure [dbo].[InsertFormulario]    Script Date: 12/10/2019 02:05:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertFormulario] 
	-- Add the parameters for the stored procedure here
	@Nombre nvarchar(50) = NULL,
	@ApellidoPaterno nvarchar(100) = NULL,
	@ApellidoMaterno nvarchar(100) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Formulario VALUES(@Nombre, @ApellidoPaterno, @ApellidoMaterno); 

	select Id, Nombre, ApellidoPaterno, ApellidoMaterno
	from Formulario
	where Id = @@IDENTITY
	FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateFormulario]    Script Date: 12/10/2019 02:05:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateFormulario] 
	-- Add the parameters for the stored procedure here
	@Nombre nvarchar(50) = NULL,
	@ApellidoPaterno nvarchar(100) = NULL,
	@ApellidoMaterno nvarchar(100) = NULL,
	@Id int = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Formulario
	SET Nombre = @Nombre,
		ApellidoPaterno = @ApellidoPaterno,
		ApellidoMaterno = @ApellidoMaterno
	WHERE Id = @Id

	select Id, Nombre, ApellidoPaterno, ApellidoMaterno
	from Formulario
	where Id = @Id
	FOR JSON PATH, INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER

END
GO
