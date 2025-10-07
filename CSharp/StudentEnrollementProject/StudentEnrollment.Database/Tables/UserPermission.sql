CREATE TABLE [UserPermission] (
    UserPermissionId INT PRIMARY KEY IDENTITY,
    UserId INT NOT NULL,
    PermissionId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES [User](UserId),
    FOREIGN KEY (PermissionId) REFERENCES [Permission](PermissionId)
);