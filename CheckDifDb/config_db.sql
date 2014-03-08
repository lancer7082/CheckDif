USE master;
GO
CREATE DATABASE CheckDifDb
ON 
( NAME = RiskAppDb_dat,
    FILENAME = 'f:\Projects\dotNet\CheckDif\CheckDifDb\CheckDifDb.mdf',
    SIZE = 10MB,
    MAXSIZE = 50MB,
    FILEGROWTH = 5MB )
LOG ON
( NAME = RiskAppDb_log,
    FILENAME = 'f:\Projects\dotNet\CheckDif\CheckDifDb\CheckDifDb.ldf',
    SIZE = 5MB,
    MAXSIZE = 25MB,
    FILEGROWTH = 5MB ) ;
GO

alter database CheckDifDb
collate Cyrillic_General_CI_AS
go