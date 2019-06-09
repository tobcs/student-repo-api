USE Master
Go

If EXISTS(select * from sys.databases where name = 'StudentRep')
DROP DATABASE FleetDB
Go

CREATE DATABASE StudentRep
Go

USE StudentRep
Go

CREATE TABLE "Feedback" (
  "id" int NOT NULL PRIMARY KEY IDENTITY(1, 1),
  "issue" varchar(500) NOT NULL,
  "feedback" varchar(500) NOT NULL,
  "votes" int NOT NULL
)

INSERT INTO Feedback (issue, feedback, votes) VALUES ('We want teams!', 'You can now use teams', 4);