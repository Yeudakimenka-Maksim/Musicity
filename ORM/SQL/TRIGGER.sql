DROP TRIGGER AddRoleToUser
GO

CREATE TRIGGER AddRoleToUser 
ON [User]
AFTER INSERT AS
BEGIN
	DECLARE @UserId int, @RoleId int
	SELECT @UserId = i.Id FROM inserted i
	SELECT @RoleId = Id FROM ROLE WHERE Name = 'Reader'
	INSERT INTO UsersInRoles (UserId, RoleId) VALUES (@UserId, @RoleId)
END
GO