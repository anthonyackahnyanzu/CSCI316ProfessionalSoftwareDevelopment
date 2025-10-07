CREATE TABLE [Permission] (
    PermissionId INT PRIMARY KEY IDENTITY,
    PermissionName NVARCHAR(50) NOT NULL UNIQUE
);