USE [MainDB]
GO
/****** Object:  StoredProcedure [dbo].[Booking_Delete]    Script Date: 30.09.2024 13:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alex Gorby>
-- Create date: <28.07.2024>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Booking_Delete] 
@Id AS INT

AS
BEGIN
	DELETE FROM Booking
	WHERE Id = @Id 
	
END
GO
/****** Object:  StoredProcedure [dbo].[Booking_GetData]    Script Date: 30.09.2024 13:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alex Gorby>
-- Create date: <28.07.2024>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Booking_GetData] 
@Id AS INT

AS
BEGIN
	SELECT * FROM Booking b
	WHERE b.Id = @Id 
	
END
GO
/****** Object:  StoredProcedure [dbo].[Booking_GetDataAll]    Script Date: 30.09.2024 13:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alex Gorby>
-- Create date: <28.07.2024>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Booking_GetDataAll] 
	
AS
BEGIN
	SELECT * FROM Booking b
	
END
GO
/****** Object:  StoredProcedure [dbo].[Booking_Insert]    Script Date: 30.09.2024 13:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alex Gorby>
-- Create date: <28.07.2024>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Booking_Insert]  
@RoomId AS INT NULL,
@CustomerId AS INT NULL,
@CheckInDate AS DATETIME NULL,
@CheckOutDate AS DATETIME NULL,
@Note AS NVARCHAR(250) NULL

AS
BEGIN
	DECLARE @CountOfDays AS INT 
	DECLARE @PricePerNigth AS FLOAT 
	DECLARE @TotalAmount AS FLOAT 

	SET @CountOfDays = (SELECT DATEDIFF(day, @CheckInDate, @CheckOutDate))
	SET @PricePerNigth = (SELECT r.PricePerNigth FROM Rooms r
													WHERE r.Id = @RoomId)     
	
	SET @TotalAmount = @CountOfDays * @PricePerNigth 

	INSERT INTO Booking(RoomId, CustomerId, CheckInDate , CheckOutDate, TotalAmount,Note)
	VALUES ( @RoomId, @CustomerId, @CheckInDate, @CheckOutDate, @TotalAmount, @Note) 
	
END
GO
/****** Object:  StoredProcedure [dbo].[Booking_Update]    Script Date: 30.09.2024 13:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alex Gorby>
-- Create date: <28.07.2024>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Booking_Update] 
@Id AS INT,
@RoomId AS INT NULL,
@CustomerId AS INT NULL,
@CheckInDate AS DATETIME NULL,
@CheckOutDate AS DATETIME NULL,
@Note AS NVARCHAR(250) NULL

AS
BEGIN

	DECLARE @CountOfDays AS INT 
	DECLARE @PricePerNigth AS FLOAT 
	DECLARE @TotalAmount AS FLOAT 

	SET @CountOfDays = (SELECT DATEDIFF(day, @CheckInDate, @CheckOutDate))
	SET @PricePerNigth = (SELECT r.PricePerNigth FROM Rooms r
													WHERE r.Id = @RoomId)     
	
	SET @TotalAmount = @CountOfDays * @PricePerNigth 

	UPDATE Booking
	SET RoomId = @RoomId, 
		CustomerId = @CustomerId,
		CheckInDate = @CheckInDate,
		CheckOutDate = @CheckOutDate,
		TotalAmount = @TotalAmount, 
		Note = @Note
	WHERE Id = @Id 
	
END
GO
/****** Object:  StoredProcedure [dbo].[Customers_Delete]    Script Date: 30.09.2024 13:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alex Gorby>
-- Create date: <28.07.2024>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Customers_Delete] 
@Id AS INT

AS
BEGIN
	DELETE FROM Customers
	WHERE Id = @Id 
	
END
GO
/****** Object:  StoredProcedure [dbo].[Customers_GetData]    Script Date: 30.09.2024 13:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alex Gorby>
-- Create date: <28.07.2024>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Customers_GetData] 
@Id AS INT

AS
BEGIN
	SELECT c.Id, c.FirstName, c.LastName, c.Email, c.PhoneNumber, c.[Address], c.DateOfBirth, c.Note
		FROM Customers c
	WHERE c.Id = @Id 
	
END
GO
/****** Object:  StoredProcedure [dbo].[Customers_GetDataAll]    Script Date: 30.09.2024 13:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alex Gorby>
-- Create date: <28.07.2024>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Customers_GetDataAll] 
AS
BEGIN
	SELECT * FROM Customers c
END
GO
/****** Object:  StoredProcedure [dbo].[Customers_Insert]    Script Date: 30.09.2024 13:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alex Gorby>
-- Create date: <28.07.2024>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Customers_Insert] 
@FirstName AS NVARCHAR(50) NULL,
@LastName AS NVARCHAR(50)NULL,
@Email AS NVARCHAR(50) NULL,
@PhoneNumber AS NVARCHAR(50) NULL,
@Address AS NVARCHAR(50) NULL,
@DateOfBirth AS DATE,
@Note AS NVARCHAR(250) NULL

AS
BEGIN
	INSERT INTO Customers(FirstName, LastName, Email, PhoneNumber, [Address], DateOfBirth, Note)
	VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Address, @DateOfBirth, @Note)
	
END
GO
/****** Object:  StoredProcedure [dbo].[Customers_Update]    Script Date: 30.09.2024 13:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alex Gorby>
-- Create date: <28.07.2024>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Customers_Update] 
@Id AS INT NULL,
@FirstName AS NVARCHAR(50) NULL,
@LastName AS NVARCHAR(50)NULL,
@Email AS NVARCHAR(50) NULL,
@PhoneNumber AS NVARCHAR(50) NULL,
@Address AS NVARCHAR(50) NULL,
@DateOfBirth AS DATE NULL,
@Note AS NVARCHAR(250) NULL

AS
BEGIN
	UPDATE Customers 
	SET FirstName  = @FirstName , 
		LastName  = @LastName ,
		Email  = @Email ,
		PhoneNumber  = @PhoneNumber, 
		[Address] = @Address,
		DateOfBirth = @DateOfBirth,
		Note = @Note
	WHERE Id = @Id 
	
END
GO
/****** Object:  StoredProcedure [dbo].[Rooms_Delete]    Script Date: 30.09.2024 13:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alex Gorby>
-- Create date: <28.07.2024>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Rooms_Delete] 
@Id AS INT

AS
BEGIN
	DELETE FROM Rooms
		WHERE Id = @Id 
END
GO
/****** Object:  StoredProcedure [dbo].[Rooms_GetData]    Script Date: 30.09.2024 13:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alex Gorby>
-- Create date: <28.07.2024>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Rooms_GetData] 
@Id AS INT

AS
BEGIN
	SELECT * FROM Rooms r
	WHERE r.Id = @Id 
	
END
GO
/****** Object:  StoredProcedure [dbo].[Rooms_GetDataAll]    Script Date: 30.09.2024 13:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alex Gorby>
-- Create date: <28.07.2024>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Rooms_GetDataAll] 
	
AS
BEGIN
	SELECT * FROM Rooms p
	ORDER BY p.RoomNumber
END
GO
/****** Object:  StoredProcedure [dbo].[Rooms_Insert]    Script Date: 30.09.2024 13:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alex Gorby>
-- Create date: <28.07.2024>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Rooms_Insert] 
 
@RoomNumber AS INT NULL,
@RoomType AS NVARCHAR(50)NULL,
@PricePerNigth AS FLOAT NULL,
@Status AS NVARCHAR(50) NULL,
@Note AS NVARCHAR(250) NULL

AS
BEGIN
	INSERT INTO Rooms(RoomNumber, RoomType, PricePerNigth, [Status], Note)
	VALUES ( @RoomNumber, @RoomType, @PricePerNigth , @Status, @Note )
	
END
GO
/****** Object:  StoredProcedure [dbo].[Rooms_Update]    Script Date: 30.09.2024 13:04:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alex Gorby>
-- Create date: <28.07.2024>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Rooms_Update] 
@Id AS INT NULL,
@RoomNumber AS INT NULL,
@RoomType AS NVARCHAR(50)NULL,
@PricePerNigth AS FLOAT NULL,
@Status AS NVARCHAR(50) NULL,
@Note AS NVARCHAR(250) NULL

AS
BEGIN
	UPDATE Rooms
	SET RoomNumber = @RoomNumber, 
		RoomType = @RoomType,
		PricePerNigth = @PricePerNigth,
		[Status] = @Status,
		Note = @Note
	WHERE Id = @Id 
	
END
GO
