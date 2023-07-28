CREATE TABLE
  [dbo].[Customer] (
    [CustomerID] [int] NOT NULL Primary key identity(1, 1),
    [Name] [varchar] (100) NULL,
    [Address] [varchar] (300) NULL,
    [Mobileno] [varchar] (15) NULL,
    [Birthdate] [datetime] NULL,
    [EmailID] [varchar] (300) NULL
  ) CREATE PROCEDURE [dbo].[Customer_CRUD] @ CustomerID INT = NULL,
  @ Name VARCHAR(100) = NULL,
  @ Address VARCHAR(300) = NULL,
  @ Mobileno VARCHAR(15) = NULL,
  @ Birthdate DATETIME = NULL,
  @ EmailID VARCHAR(300) = NULL,
  @ Action VARCHAR(10) AS BEGIN
SET
  NOCOUNT ON;


IF @ Action = 'CREATE' BEGIN
INSERT INTO
  [dbo].[Customer] (
    [Name],
    [Address],
    [Mobileno],
    [Birthdate],
    [EmailID]
  )
VALUES
  (@ Name, @ Address, @ Mobileno, @ Birthdate, @ EmailID)
END
ELSE IF @ Action = 'READ' BEGIN
SELECT
  *
FROM
  [dbo].[Customer]
WHERE
  [CustomerID] = @ CustomerID
END
ELSE IF @ Action = 'UPDATE' BEGIN
UPDATE
  [dbo].[Customer]
SET
  [Name] = @ Name,
  [Address] = @ Address,
  [Mobileno] = @ Mobileno,
  [Birthdate] = @ Birthdate,
  [EmailID] = @ EmailID
WHERE
  [CustomerID] = @ CustomerID
END
ELSE IF @ Action = 'DELETE' BEGIN
DELETE FROM
  [dbo].[Customer]
WHERE
  [CustomerID] = @ CustomerID
END
END