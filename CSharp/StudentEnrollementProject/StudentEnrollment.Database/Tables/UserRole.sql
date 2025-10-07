CREATE TABLE [UserRole] (
    UserRoleId INT PRIMARY KEY IDENTITY,
    UserId INT NOT NULL,
    RoleId INT NOT NULL,
    ApprovalStatusId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES [User](UserId),
    FOREIGN KEY (RoleId) REFERENCES [Role](RoleId),
    FOREIGN KEY (ApprovalStatusId) REFERENCES [ApprovalStatus](Id)
);