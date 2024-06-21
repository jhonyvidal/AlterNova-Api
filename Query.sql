-- To insert Doctors
USE [Alternova]
GO

INSERT INTO [dbo].[Doctor]
           ([Name]
           ,[Speciality])
     VALUES
           ('Doctor 1'
           ,'General')

INSERT INTO [dbo].[Doctor]
           ([Name]
           ,[Speciality])
     VALUES
           ('Doctor 2'
           ,'Especialista')
GO

-- To insert Types
USE [Alternova]
GO

INSERT INTO [dbo].[TypeAppointment]
           ([Name])
     VALUES
           ('General')
INSERT INTO [dbo].[TypeAppointment]
           ([Name])
     VALUES
           ('Especializada')
GO
