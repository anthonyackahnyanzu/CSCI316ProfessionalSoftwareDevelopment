-- Insert roles
INSERT INTO [Role] (RoleName) VALUES ('Student');
INSERT INTO [Role] (RoleName) VALUES ('Professor');
INSERT INTO [Role] (RoleName) VALUES ('Administrator');

-- Insert permissions
INSERT INTO [Permission] (PermissionName) VALUES ('CanRegister');
INSERT INTO [Permission] (PermissionName) VALUES ('CanViewSchedule');
INSERT INTO [Permission] (PermissionName) VALUES ('CanManageClasses');
INSERT INTO [Permission] (PermissionName) VALUES ('CanManageUsers');
INSERT INTO [Permission] (PermissionName) VALUES ('CanEditCourses');
INSERT INTO [Permission] (PermissionName) VALUES ('FullAccess');
