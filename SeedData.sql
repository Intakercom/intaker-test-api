-- ============================================================
-- Seed Data Script for TaskTrackingSystem
-- Database: TaskTrackingDb (SQL Server)
-- ============================================================
-- Insert order respects FK dependencies:
--   1. Teams       (no FK dependencies)
--   2. Users       (FK -> Teams, nullable)
--   3. Sprints     (FK -> Teams)
--   4. SprintTasks (FK -> Sprints, Users)
-- ============================================================

-- ============================================================
-- SECTION 1: INSERT TEMPLATES (with placeholders)
-- ============================================================

-- --------------------
-- 1. Team
-- --------------------
-- INSERT INTO [Teams] ([Id], [Name], [Description], [CreatedAtUtc], [UpdatedAtUtc])
-- VALUES
--     ('<GUID>', '<TeamName>', '<Description>' /* or NULL */, GETUTCDATE(), NULL);

-- --------------------
-- 2. User
-- --------------------
-- Role values: 'Member', 'Admin'
--
-- INSERT INTO [Users] ([Id], [Email], [PasswordHash], [FirstName], [LastName], [Role], [TeamId], [CreatedAtUtc], [UpdatedAtUtc])
-- VALUES
--     ('<GUID>', '<email@example.com>', '<bcrypt_hash>', '<FirstName>', '<LastName>', 'Member', '<TeamId_GUID>' /* or NULL */, GETUTCDATE(), NULL);

-- --------------------
-- 3. Sprint
-- --------------------
-- Constraint: EndDate must be greater than StartDate
--
-- INSERT INTO [Sprints] ([Id], [Name], [StartDate], [EndDate], [TeamId], [CreatedAtUtc], [UpdatedAtUtc])
-- VALUES
--     ('<GUID>', '<SprintName>', '<YYYY-MM-DD>', '<YYYY-MM-DD>', '<TeamId_GUID>', GETUTCDATE(), NULL);

-- --------------------
-- 4. SprintTask
-- --------------------
-- Status values: 'ToDo', 'InProgress', 'Done'
--
-- INSERT INTO [SprintTasks] ([Id], [Title], [Description], [Status], [AssigneeId], [SprintId], [CreatedByUserId], [CreatedAtUtc], [UpdatedAtUtc])
-- VALUES
--     ('<GUID>', '<TaskTitle>', '<Description>' /* or NULL */, 'ToDo', '<AssigneeId_GUID>' /* or NULL */, '<SprintId_GUID>', '<CreatedByUserId_GUID>', GETUTCDATE(), NULL);


-- ============================================================
-- SECTION 2: SAMPLE SEED DATA (runnable)
-- ============================================================
-- Creates: 1 Team, 2 Users (Admin + Member), 1 Sprint, 2 Tasks

DECLARE @TeamId         UNIQUEIDENTIFIER = NEWID();
DECLARE @AdminUserId    UNIQUEIDENTIFIER = NEWID();
DECLARE @MemberUserId   UNIQUEIDENTIFIER = NEWID();
DECLARE @SprintId       UNIQUEIDENTIFIER = NEWID();
DECLARE @Task1Id        UNIQUEIDENTIFIER = NEWID();
DECLARE @Task2Id        UNIQUEIDENTIFIER = NEWID();
DECLARE @Now            DATETIME2 = GETUTCDATE();

-- 1. Team
INSERT INTO [Teams] ([Id], [Name], [Description], [CreatedAtUtc], [UpdatedAtUtc])
VALUES
    (@TeamId, 'Backend Team', 'Core backend development team', @Now, NULL);

-- 2. Users
-- Note: PasswordHash below is a BCrypt hash of 'Password123!' — replace with actual hash from the API registration endpoint
INSERT INTO [Users] ([Id], [Email], [PasswordHash], [FirstName], [LastName], [Role], [TeamId], [CreatedAtUtc], [UpdatedAtUtc])
VALUES
    (@AdminUserId,  'admin@example.com',  '$2a$11$EXAMPLEHASHREPLACEWITHACTUAL000000000000000000000000', 'John', 'Admin',  'Admin',  @TeamId, @Now, NULL),
    (@MemberUserId, 'member@example.com', '$2a$11$EXAMPLEHASHREPLACEWITHACTUAL000000000000000000000000', 'Jane', 'Member', 'Member', @TeamId, @Now, NULL);

-- 3. Sprint
INSERT INTO [Sprints] ([Id], [Name], [StartDate], [EndDate], [TeamId], [CreatedAtUtc], [UpdatedAtUtc])
VALUES
    (@SprintId, 'Sprint 1 - Foundation', '2025-01-06', '2025-01-17', @TeamId, @Now, NULL);

-- 4. SprintTasks
INSERT INTO [SprintTasks] ([Id], [Title], [Description], [Status], [AssigneeId], [SprintId], [CreatedByUserId], [CreatedAtUtc], [UpdatedAtUtc])
VALUES
    (@Task1Id, 'Set up CI/CD pipeline',  'Configure GitHub Actions for build and deploy', 'ToDo',       @MemberUserId, @SprintId, @AdminUserId, @Now, NULL),
    (@Task2Id, 'Implement user auth API', 'JWT-based authentication endpoints',           'InProgress', @AdminUserId,  @SprintId, @AdminUserId, @Now, NULL);

-- ============================================================
-- VERIFICATION QUERIES
-- ============================================================
-- SELECT * FROM [Teams];
-- SELECT * FROM [Users];
-- SELECT * FROM [Sprints];
-- SELECT * FROM [SprintTasks];
