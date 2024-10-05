--Procedura dodania pilkarza

CREATE PROCEDURE AddPlayer
    @Name NVARCHAR(100),
    @Age INT,
    @TeamName NVARCHAR(100)
AS
BEGIN
    INSERT INTO Players (Name, Age, TeamName)
    VALUES (@Name, @Age, @TeamName);
    
    UPDATE Teams
    SET PlayerCount = PlayerCount + 1
    WHERE Name = @TeamName;
END;