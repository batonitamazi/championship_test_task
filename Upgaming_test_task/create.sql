
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ChampionShip')
BEGIN
    CREATE DATABASE ChampionShip;
END
GO

USE ChampionShip; -- Switch to ChampionShip database

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'users')
BEGIN
    CREATE TABLE users (
        id INT IDENTITY(1,1) PRIMARY KEY,
        name NVARCHAR(200),
        surname NVARCHAR(MAX),
        username NVARCHAR(200) UNIQUE NOT NULL,
        create_date DATETIME DEFAULT GETDATE()
    );
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'user_scores')
BEGIN
    CREATE TABLE user_scores (
        id INT IDENTITY(1,1) PRIMARY KEY,
        user_id INT NOT NULL,
        date DATETIME NOT NULL,
        score INT,
        FOREIGN KEY (user_id) REFERENCES users(id)
    );
END
GO