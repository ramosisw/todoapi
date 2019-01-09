CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

CREATE TABLE IF NOT EXISTS `TodoItems`(
    `Id` varchar(36) NOT NULL,
    `Name` varchar(100) NOT NULL,
    `Details` varchar(1000) NULL,
    `StartDate` datetime NOT NULL,
    `EndDate` datetime NOT NULL,
    `IsDone` bit NOT NULL,
    PRIMARY KEY (`Id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20190107065043_InitialCreate', '2.1.4-rtm-31024');

