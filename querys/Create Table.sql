IF OBJECT_ID('[dbo].[CreditLoan]', 'U') IS NOT NULL
DROP TABLE [dbo].[CreditLoan]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[CreditLoan](
  [Id] [int] IDENTITY(1,1) NOT NULL,
  [Name] [varchar](255) NULL,
  [Email] [Varchar](255) NULL,
  [Phone] [Varchar](255) NULL,
  [Amount] [int] NULL
);
GO