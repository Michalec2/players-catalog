--trigger przy usuwaniu ktory akutalizuje liczbe graczy

CREATE TRIGGER UpdatePlayerCountAfterDelete
AFTER DELETE ON Players
FOR EACH ROW
BEGIN
    UPDATE Teams
    SET PlayerCount = PlayerCount - 1
    WHERE Name = OLD.TeamName;
END;
