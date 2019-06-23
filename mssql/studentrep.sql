USE Master
Go

If EXISTS(select * from sys.databases where name = 'StudentRep')
DROP DATABASE StudentRep
Go

CREATE DATABASE StudentRep
Go

USE StudentRep
Go

DROP TABLE IF EXISTS "Feedback"
CREATE TABLE "Feedback" (
  "id" int NOT NULL PRIMARY KEY IDENTITY(1, 1),
  "issue" varchar(500) NOT NULL,
  "feedback" varchar(500) NOT NULL,
  "votes" int NOT NULL,
  "following" varchar(100)
)

DROP TABLE IF EXISTS "Students"
CREATE TABLE "Students" (
  "studentNumber" int NOT NULL PRIMARY KEY,
  "password" varchar(50) NOT NULL,
  "isStudentRep" tinyInt NOT NULL,
)

DROP TABLE IF EXISTS "Issue"
CREATE TABLE "Issue" (
  "id" int NOT NULL PRIMARY KEY IDENTITY(1, 1),
  "date" varchar(50) NOT NULL,
  "title" varchar(200) NOT NULL,
  "description" varchar(500) NOT NULL,
  "type" varchar(50) NOT NULL,
  "upVotes" int,
  "downVotes" int,
  "show" tinyInt NOT NULL,
  "statusDescription" varchar(500),
  "priority" int,
  "flaggedInappropiate" int
)

DROP TABLE IF EXISTS "Contact"
CREATE TABLE "Contact" (
  "id" int NOT NULL PRIMARY KEY IDENTITY(1, 1),
  "name" varchar(200) NOT NULL,
  "role" varchar(100) NOT NULL,
  "department" varchar(100) NOT NULL,
  "emailAddress" varchar(100) NOT NULL
)

INSERT INTO Feedback (issue, feedback, votes) VALUES 
('We want teams!', 'You can now use teams', 4);