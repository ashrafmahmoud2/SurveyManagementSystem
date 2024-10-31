//SELECT *fROM AspNetUsers
//SELECT *fROM Polls
//select *from Questions
//select *From Answers
//select *From VoteAnswers
//select *From Votes


//Delete from VoteAnswers
//Delete from Answers
//Delete from Questions
//Delete from Votes
//Delete from Polls
//Delete from AspNetUsers



//-- Reset the identity seed of the Polls, Questions, Answers, Votes, and VoteAnswers tables
//DBCC CHECKIDENT ('[dbo].[Polls]', RESEED, 0);
//DBCC CHECKIDENT ('[dbo].[Questions]', RESEED, 0);
//DBCC CHECKIDENT ('[dbo].[Answers]', RESEED, 0);
//DBCC CHECKIDENT ('[dbo].[Votes]', RESEED, 0);
//DBCC CHECKIDENT ('[dbo].[VoteAnswers]', RESEED, 0);
//GO




//Un Hash password in Secrit .jesone;..............................
//-- Users Table
//INSERT INTO [dbo].[AspNetUsers] 
//    ( [Id], [FirstName], [LastName], [IsDisabled], [UserName], [NormalizedUserName], 
//      [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], 
//      [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], 
//      [LockoutEnd], [LockoutEnabled], [AccessFailedCount])
//VALUES 
//    ('1', 'John', 'Doe', 0, 'john.doe@example.com', 'JOHN.DOE@EXAMPLE.COM', 'john.doe@example.com', 'JOHN.DOE@EXAMPLE.COM', 1, 
//     'AQAAAAIAAYagAAAAEMwJYJjlxZfgcL38khoffnl7WDqHq+RO/DkoKJI7VydxdCQfXijV8HK9Wz0LS+jVxw==', 'security_stamp_1', 'concurrency_stamp_1', NULL, 0, 0, NULL, 1, 0),

//    ('2', 'Jane', 'Smith', 0, 'jane.smith@example.com', 'JANE.SMITH@EXAMPLE.COM', 'jane.smith@example.com', 'JANE.SMITH@EXAMPLE.COM', 1, 
//     'AQAAAAIAAYagAAAAEMwJYJjlxZfgcL38khoffnl7WDqHq+RO/DkoKJI7VydxdCQfXijV8HK9Wz0LS+jVxw==', 'security_stamp_2', 'concurrency_stamp_2', NULL, 0, 0, NULL, 1, 0),

//    ('3', 'Alice', 'Johnson', 0, 'alice.johnson@example.com', 'ALICE.JOHNSON@EXAMPLE.COM', 'alice.johnson@example.com', 'ALICE.JOHNSON@EXAMPLE.COM', 1, 
//     'AQAAAAIAAYagAAAAEMwJYJjlxZfgcL38khoffnl7WDqHq+RO/DkoKJI7VydxdCQfXijV8HK9Wz0LS+jVxw==', 'security_stamp_3', 'concurrency_stamp_3', NULL, 0, 0, NULL, 1, 0),

//    ('4', 'Bob', 'Brown', 0, 'bob.brown@example.com', 'BOB.BROWN@EXAMPLE.COM', 'bob.brown@example.com', 'BOB.BROWN@EXAMPLE.COM', 1, 
//     'AQAAAAIAAYagAAAAEMwJYJjlxZfgcL38khoffnl7WDqHq+RO/DkoKJI7VydxdCQfXijV8HK9Wz0LS+jVxw==', 'security_stamp_4', 'concurrency_stamp_4', NULL, 0, 0, NULL, 1, 0),

//    ('5', 'Ashraf', 'Mahmoud', 0, 'ashraf.mahmoud@example.com', 'ASHRAF.MAHMOUD@EXAMPLE.COM', 'ashraf.mahmoud@example.com', 'ASHRAF.MAHMOUD@EXAMPLE.COM', 1, 
//     'AQAAAAIAAYagAAAAEMwJYJjlxZfgcL38khoffnl7WDqHq+RO/DkoKJI7VydxdCQfXijV8HK9Wz0LS+jVxw==', 'security_stamp_5', 'concurrency_stamp_5', NULL, 0, 0, NULL, 1, 0),

//    ('6', 'Khaled', 'Ali', 0, 'khaled.ali@example.com', 'KHALED.ALI@EXAMPLE.COM', 'khaled.ali@example.com', 'KHALED.ALI@EXAMPLE.COM', 1, 
//     'AQAAAAIAAYagAAAAEMwJYJjlxZfgcL38khoffnl7WDqHq+RO/DkoKJI7VydxdCQfXijV8HK9Wz0LS+jVxw==', 'security_stamp_6', 'concurrency_stamp_6', NULL, 0, 0, NULL, 1, 0);




//     --pollsTable
//INSERT INTO[dbo].[Polls]
//([Title], [Summary], [StartsAt], [EndsAt], [CreatedById], [CreatedOn], [UpdatedById], [UpdatedOn])
//VALUES
//    ('Favorite Programming Language', 'Vote for your favorite programming language', '2024-01-01 10:00:00', '2024-01-10 23:59:59', '1', '2024-01-01 09:00:00', NULL, NULL),

//    ('Best Mobile OS', 'Choose the best mobile operating system', '2024-02-01 10:00:00', '2024-02-05 23:59:59', '2', '2024-02-01 09:00:00', NULL, NULL),

//    ('Preferred Coding Editor', 'Select your preferred code editor', '2024-03-01 10:00:00', '2024-03-10 23:59:59', '3', '2024-03-01 09:00:00', NULL, NULL),

//    ('Favorite Social Media Platform', 'Which social media platform do you use the most?', '2024-04-01 10:00:00', '2024-04-07 23:59:59', '4', '2024-04-01 09:00:00', NULL, NULL),

//    ('Best Cloud Provider', 'Vote for the best cloud service provider', '2024-05-01 10:00:00', '2024-05-07 23:59:59', '5', '2024-05-01 09:00:00', NULL, NULL),

//    ('Preferred Database System', 'Choose your preferred database management system', '2024-06-01 10:00:00', '2024-06-07 23:59:59', '6', '2024-06-01 09:00:00', NULL, NULL),

//    ('Best Streaming Service', 'Vote for the best video streaming platform', '2024-07-01 10:00:00', '2024-07-05 23:59:59', '1', '2024-07-01 09:00:00', NULL, NULL),

//    ('Favorite Web Framework', 'Select your favorite web development framework', '2024-08-01 10:00:00', '2024-08-10 23:59:59', '2', '2024-08-01 09:00:00', NULL, NULL),

//    ('Best Laptop Brand', 'Vote for the best laptop brand in 2024', '2024-09-01 10:00:00', '2024-09-07 23:59:59', '3', '2024-09-01 09:00:00', NULL, NULL),

//    ('Favorite Game Console', 'Which game console do you prefer the most?', '2024-10-01 10:00:00', '2024-10-07 23:59:59', '4', '2024-10-01 09:00:00', NULL, NULL);





//--QuestionTable
//    USE [SurveyManagementSystem]
//GO

//-- Poll 1: Favorite Programming Language (1 Question)
//INSERT INTO [dbo].[Questions] 
//    ([Content], [PollId], [IsActive], [CreatedById], [CreatedOn], [UpdatedById], [UpdatedOn])
//VALUES
//    ('What is your favorite programming language?', 1, 1, '1', '2024-01-01 09:00:00', NULL, NULL),

//-- Poll 2: Best Mobile OS (3 Questions)
//    ('Which mobile OS do you think is the best?', 2, 1, '2', '2024-02-01 09:00:00', NULL, NULL),
//    ('What feature do you value most in a mobile OS?', 2, 1, '2', '2024-02-01 09:00:00', NULL, NULL),
//    ('Which mobile OS has the best app ecosystem?', 2, 1, '2', '2024-02-01 09:00:00', NULL, NULL),

//-- Poll 3: Preferred Coding Editor (1 Question)
//    ('Which code editor do you prefer the most?', 3, 1, '3', '2024-03-01 09:00:00', NULL, NULL),

//-- Poll 4: Favorite Social Media Platform (3 Questions)
//    ('Which social media platform do you use the most?', 4, 1, '4', '2024-04-01 09:00:00', NULL, NULL),
//    ('What feature do you like most on your preferred platform?', 4, 1, '4', '2024-04-01 09:00:00', NULL, NULL),
//    ('How often do you use your favorite social media platform?', 4, 1, '4', '2024-04-01 09:00:00', NULL, NULL),

//-- Poll 5: Best Cloud Provider (1 Question)
//    ('Which cloud provider do you consider the best?', 5, 1, '5', '2024-05-01 09:00:00', NULL, NULL),

//-- Poll 6: Preferred Database System (3 Questions)
//    ('Which is your preferred database management system?', 6, 1, '6', '2024-06-01 09:00:00', NULL, NULL),
//    ('What makes your chosen database system preferable?', 6, 1, '6', '2024-06-01 09:00:00', NULL, NULL),
//    ('Which database system offers the best performance for your needs?', 6, 1, '6', '2024-06-01 09:00:00', NULL, NULL),

//-- Poll 7: Best Streaming Service (1 Question)
//    ('Which video streaming service do you prefer?', 7, 1, '1', '2024-07-01 09:00:00', NULL, NULL),

//-- Poll 8: Favorite Web Framework (3 Questions)
//    ('What is your favorite web development framework?', 8, 1, '2', '2024-08-01 09:00:00', NULL, NULL),
//    ('Why do you prefer your chosen web framework?', 8, 1, '2', '2024-08-01 09:00:00', NULL, NULL),
//    ('Which web framework do you think is the most scalable?', 8, 1, '2', '2024-08-01 09:00:00', NULL, NULL),

//-- Poll 9: Best Laptop Brand (1 Question)
//    ('Which laptop brand do you think is the best?', 9, 1, '3', '2024-09-01 09:00:00', NULL, NULL),

//-- Poll 10: Favorite Game Console (3 Questions)
//    ('Which game console do you prefer?', 10, 1, '4', '2024-10-01 09:00:00', NULL, NULL),
//    ('What do you like most about your favorite game console?', 10, 1, '4', '2024-10-01 09:00:00', NULL, NULL),
//    ('Which game console has the best exclusive games?', 10, 1, '4', '2024-10-01 09:00:00', NULL, NULL);

//GO




//--answers table
//USE [SurveyManagementSystem]
//GO

//-- Poll 1: Favorite Programming Language
//INSERT INTO [dbo].[Answers] ([Content], [QuestionId], [IsActive])
//VALUES 
//    ('Python', 1, 1),
//    ('JavaScript', 1, 1),
//    ('C#', 1, 1);

//-- Poll 2: Best Mobile OS
//INSERT INTO [dbo].[Answers] ([Content], [QuestionId], [IsActive])
//VALUES 
//    ('Android', 2, 1),
//    ('iOS', 2, 1),
//    ('Windows Mobile', 2, 1),

//    ('Security', 3, 1),
//    ('User Interface', 3, 1),
//    ('Battery Life', 3, 1),

//    ('Google Play Store', 4, 1),
//    ('Apple App Store', 4, 1),
//    ('Microsoft Store', 4, 1);

//-- Poll 3: Preferred Code Editor
//INSERT INTO [dbo].[Answers] ([Content], [QuestionId], [IsActive])
//VALUES 
//    ('Visual Studio Code', 5, 1),
//    ('Sublime Text', 5, 1),
//    ('Atom', 5, 1);

//-- Poll 4: Most Used Social Media Platform
//INSERT INTO [dbo].[Answers] ([Content], [QuestionId], [IsActive])
//VALUES 
//    ('Facebook', 6, 1),
//    ('Twitter', 6, 1),
//    ('Instagram', 6, 1),

//    ('Ease of Use', 7, 1),
//    ('Privacy Features', 7, 1),
//    ('Networking Opportunities', 7, 1),

//    ('Daily', 8, 1),
//    ('Weekly', 8, 1),
//    ('Rarely', 8, 1);

//-- Poll 5: Best Cloud Provider
//INSERT INTO [dbo].[Answers] ([Content], [QuestionId], [IsActive])
//VALUES 
//    ('AWS', 9, 1),
//    ('Microsoft Azure', 9, 1),
//    ('Google Cloud Platform', 9, 1);

//-- Poll 6: Preferred Database System
//INSERT INTO [dbo].[Answers] ([Content], [QuestionId], [IsActive])
//VALUES 
//    ('MySQL', 10, 1),
//    ('PostgreSQL', 10, 1),
//    ('SQL Server', 10, 1),

//    ('Performance', 11, 1),
//    ('Scalability', 11, 1),
//    ('Community Support', 11, 1),

//    ('Transactional Speed', 12, 1),
//    ('Data Security', 12, 1),
//    ('Reliability', 12, 1);

//-- Poll 7: Preferred Streaming Service
//INSERT INTO [dbo].[Answers] ([Content], [QuestionId], [IsActive])
//VALUES 
//    ('Netflix', 13, 1),
//    ('Hulu', 13, 1),
//    ('Disney+', 13, 1);

//-- Poll 8: Favorite Web Development Framework
//INSERT INTO [dbo].[Answers] ([Content], [QuestionId], [IsActive])
//VALUES 
//    ('React', 14, 1),
//    ('Angular', 14, 1),
//    ('Vue.js', 14, 1),

//    ('Speed', 15, 1),
//    ('Community Support', 15, 1),
//    ('Ease of Learning', 15, 1),

//    ('Node.js', 16, 1),
//    ('Django', 16, 1),
//    ('Spring', 16, 1);

//-- Poll 9: Best Laptop Brand
//INSERT INTO [dbo].[Answers] ([Content], [QuestionId], [IsActive])
//VALUES 
//    ('HP', 17, 1),
//    ('Lenovo', 17, 1),
//    ('Dell', 17, 1);

//-- Poll 10: Preferred Game Console
//INSERT INTO [dbo].[Answers] ([Content], [QuestionId], [IsActive])
//VALUES 
//    ('PlayStation', 18, 1),
//    ('Xbox', 18, 1),
//    ('Nintendo Switch', 18, 1),

//    ('Exclusive Games', 19, 1),
//    ('Controller Design', 19, 1),
//    ('Graphics Quality', 19, 1),

//    ('PlayStation Exclusives', 20, 1),
//    ('Xbox Game Pass', 20, 1),
//    ('Nintendo Exclusives', 20, 1);
//GO



//--vote table
//USE [SurveyManagementSystem]
//GO
//INSERT INTO [dbo].[Votes] (PollId, UserId, SubmittedOn) VALUES 
//    (1, '1', '2024-01-01 10:00:00'),
//    (1, '2', '2024-01-01 10:05:00'),
//    (2, '3', '2024-02-01 10:10:00'),
//    (2, '4', '2024-02-01 10:15:00'),
//    (3, '5', '2024-02-01 10:20:00'),
//    (3, '6', '2024-02-01 10:25:00'),
//    (4, '1', '2024-02-01 10:30:00'),
//    (5, '2', '2024-03-01 10:35:00'),
//    (5, '3', '2024-03-01 10:40:00'),
//    (6, '4', '2024-04-01 10:45:00'),
//    (6, '5', '2024-04-01 10:50:00'),
//    (7, '6', '2024-04-01 10:55:00'),
//    (8, '1', '2024-04-01 11:00:00'),
//    (9, '2', '2024-05-01 11:05:00'),
//    (10, '3', '2024-06-01 11:10:00')  
//GO


//--[VoteAnswers] Table
//USE [SurveyManagementSystem]
//GO

//-- Sample data insert for the VoteAnswers table
//INSERT INTO [dbo].[VoteAnswers] (VoteId, QuestionId, AnswerId) VALUES 
//    (1, 1, 1),    -- User 1 votes for answer 1 on question 1 (favorite programming language)
//    (2, 1, 2),    -- User 2 votes for answer 2 on question 1
//    (3, 2, 1),    -- User 3 votes for answer 1 on question 2 (best mobile OS)
//    (4, 2, 2),    -- User 4 votes for answer 2 on question 2
//    (5, 3, 1),    -- User 5 votes for answer 1 on question 3 (most valued feature in mobile OS)
//    (6, 3, 2),    -- User 6 votes for answer 2 on question 3
//    (7, 4, 1),    -- User 1 votes for answer 1 on question 4 (best app ecosystem in mobile OS)
//    (8, 5, 1),    -- User 2 votes for answer 1 on question 5 (preferred code editor)
//    (9, 5, 2),    -- User 3 votes for answer 2 on question 5
//    (10, 6, 1),   -- User 4 votes for answer 1 on question 6 (most used social media platform)
//    (11, 6, 2),   -- User 5 votes for answer 2 on question 6
//    (12, 7, 1),   -- User 6 votes for answer 1 on question 7 (liked feature on social media platform)
//    (13, 8, 1),   -- User 1 votes for answer 1 on question 8 (frequency of social media usage)
//    (14, 9, 1),   -- User 2 votes for answer 1 on question 9 (best cloud provider)
//    (15, 10, 1);  -- User 3 votes for answer 1 on question 10 (preferred database management system)
//GO







//--[VoteAnswers]
//USE [SurveyManagementSystem]
//GO

//-- Sample data insert for the VoteAnswers table based on the updated votes data
//INSERT INTO [dbo].[VoteAnswers] (VoteId, QuestionId, AnswerId) VALUES 
//    (1, 1, 1),    -- VoteId 1: User voted for AnswerId 1 for QuestionId 1
//    (2, 1, 2),    -- VoteId 2: User voted for AnswerId 2 for QuestionId 1
//    (3, 2, 3),    -- VoteId 3: User voted for AnswerId 3 for QuestionId 2
//    (4, 2, 4),    -- VoteId 4: User voted for AnswerId 4 for QuestionId 2
//    (5, 3, 5),    -- VoteId 5: User voted for AnswerId 5 for QuestionId 3
//    (6, 3, 6),    -- VoteId 6: User voted for AnswerId 6 for QuestionId 3
//    (7, 4, 1),    -- VoteId 7: User voted for AnswerId 1 for QuestionId 4
//    (8, 5, 2),    -- VoteId 8: User voted for AnswerId 2 for QuestionId 5
//    (9, 5, 3),    -- VoteId 9: User voted for AnswerId 3 for QuestionId 5
//    (10, 6, 4),   -- VoteId 10: User voted for AnswerId 4 for QuestionId 6
//    (11, 6, 5),   -- VoteId 11: User voted for AnswerId 5 for QuestionId 6
//    (12, 7, 6),   -- VoteId 12: User voted for AnswerId 6 for QuestionId 7
//    (13, 8, 1),   -- VoteId 13: User voted for AnswerId 1 for QuestionId 8
//    (14, 9, 2),   -- VoteId 14: User voted for AnswerId 2 for QuestionId 9
//    (15, 10, 3);  -- VoteId 15: User voted for AnswerId 3 for QuestionId 10
//GO


