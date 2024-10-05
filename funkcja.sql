--funkcja pobrania sredniego wieku na zespol

CREATE FUNCTION GetAverageAgeByTeam
    (@TeamName NVARCHAR(100))
RETURNS DECIMAL(5, 2)
AS
BEGIN
    DECLARE @AverageAge DECIMAL(5, 2);
    
    SELECT @AverageAge = AVG(Age)
    FROM Players
    WHERE TeamName = @TeamName;

    RETURN @AverageAge;
END;
