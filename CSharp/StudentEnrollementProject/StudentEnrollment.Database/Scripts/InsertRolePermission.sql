-- Example: Assign permissions to roles
-- Student: CanRegister, CanViewSchedule
INSERT INTO [RolePermission] (RoleId, PermissionId) VALUES (1, 1); -- Student, CanRegister
INSERT INTO [RolePermission] (RoleId, PermissionId) VALUES (1, 2); -- Student, CanViewSchedule

-- Professor: CanManageClasses, CanViewSchedule
INSERT INTO [RolePermission] (RoleId, PermissionId) VALUES (2, 3); -- Professor, CanManageClasses
INSERT INTO [RolePermission] (RoleId, PermissionId) VALUES (2, 2); -- Professor, CanViewSchedule

-- Administrator: CanManageUsers, CanEditCourses, FullAccess
INSERT INTO [RolePermission] (RoleId, PermissionId) VALUES (3, 4); -- Administrator, CanManageUsers
INSERT INTO [RolePermission] (RoleId, PermissionId) VALUES (3, 5); -- Administrator, CanEditCourses
INSERT INTO [RolePermission] (RoleId, PermissionId) VALUES (3, 6); -- Administrator, FullAccess
