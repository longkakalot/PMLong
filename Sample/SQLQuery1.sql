USE Sample
GO

CREATE PROC [Post_Add]
	@PostID INT OUTPUT, --output: tuong tu nhu truyen tham chieu trong OOP
	@Title nvarchar(50),
	@Body NVARCHAR(4000),
	@Publish DATETIME
AS
INSERT INTO [dbo].[Post]
        ( [Title], [Body], [Publish] )
VALUES  ( @Title, -- Title - nvarchar(50)
          @Body, -- Body - nvarchar(4000)
          @Publish -- Publish - datetime
          )
-- Lay gia tri tu tang cua record vua moi them vao
SET @PostID = @@IDENTITY
GO


