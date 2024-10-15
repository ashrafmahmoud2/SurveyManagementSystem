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
//INSERT INTO [dbo].[Polls] 
//    ([Title], [Summary], [StartAt], [EndAt], [CreatedById], [CreatedOn], [UpdatedById], [UpdatedOn])
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
