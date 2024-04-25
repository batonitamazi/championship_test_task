CREATE DATABASE [ChampionShip]
GO

CREATE TABLE users (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(200),
    surname NVARCHAR(MAX),
    username NVARCHAR(200) UNIQUE NOT NULL,
    create_date DATETIME DEFAULT GETDATE()
);

CREATE TABLE user_scores (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    date DATETIME NOT NULL,
    score INT,
    FOREIGN KEY (user_id) REFERENCES users(id)
);