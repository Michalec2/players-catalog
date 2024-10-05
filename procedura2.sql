--Procedura aktualizacji wieku
CREATE PROCEDURE UpdatePlayerAge
    @PlayerId INT,
    @NewAge INT
AS
BEGIN
    UPDATE Players
    SET Age = @NewAge
    WHERE Id = @PlayerId;
END;