USE CheckDifDb
GO

exec sp_changedbowner 'sa'

/****** Object:  User [hamster\lancer]    Script Date: 08.03.2014 14:23:46 ******/
CREATE USER [hamster\lancer] FOR LOGIN [hamster\lancer] WITH DEFAULT_SCHEMA=[dbo]
GO

--drop user dbo
--alter user dbo with login = sa
