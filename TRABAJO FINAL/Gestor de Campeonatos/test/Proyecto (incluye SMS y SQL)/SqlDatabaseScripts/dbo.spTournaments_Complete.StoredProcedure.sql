USE [Tournaments]
GO
/****** Object:  StoredProcedure [dbo].[spTournaments_Complete]    Script Date: 7/26/2021 10:32:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spTournaments_Complete] 
	@id int
AS
BEGIN
	SET NOCOUNT ON;

    update dbo.Tournaments
	set Active = 0
	where id = @id;
END

GO
