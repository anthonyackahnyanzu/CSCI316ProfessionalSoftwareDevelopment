CREATE TABLE [RolePermission] (
    RolePermissionId INT PRIMARY KEY IDENTITY,
    RoleId INT NOT NULL,
    PermissionId INT NOT NULL,
    FOREIGN KEY (RoleId) REFERENCES [Role](RoleId),
    FOREIGN KEY (PermissionId) REFERENCES [Permission](PermissionId)
);