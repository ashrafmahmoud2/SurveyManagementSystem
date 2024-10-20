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






//--pollsTable
//INSERT INTO[dbo].[Polls]
//([Title], [Summary], [StartAt], [EndAt], [CreatedById], [CreatedOn], [UpdatedById], [UpdatedOn])
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
//USE [SurveyManagementSystem]
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
