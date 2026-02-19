using Microsoft.EntityFrameworkCore;
using TaskTrackingSystem.Domain.Entities;
using TaskTrackingSystem.Domain.Enums;

namespace TaskTrackingSystem.Infrastructure.Persistence;

public static class DataSeeder
{
    // BCrypt hash of "pass1234"
    private const string PasswordHash = "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW";

    private static readonly DateTime SeedDate = new(2026, 2, 17, 21, 52, 0, DateTimeKind.Utc);

    // ---- Team GUIDs ----
    private static readonly Guid TeamDataAnalytics = Guid.Parse("a0000001-0000-0000-0000-000000000001");
    private static readonly Guid TeamMain = Guid.Parse("a0000001-0000-0000-0000-000000000002");
    private static readonly Guid TeamPlatformEng = Guid.Parse("a0000001-0000-0000-0000-000000000003");
    private static readonly Guid TeamFrontendGuild = Guid.Parse("a0000001-0000-0000-0000-000000000004");

    // ---- User GUIDs ----
    // Admins
    private static readonly Guid UserAdmin = Guid.Parse("b0000001-0000-0000-0000-000000000001");
    // Members — Main team
    private static readonly Guid UserOliviaReyes = Guid.Parse("b0000001-0000-0000-0000-000000000003");
    private static readonly Guid UserJakeMorrison = Guid.Parse("b0000001-0000-0000-0000-000000000005");
    // Members — Platform Engineering
    private static readonly Guid UserGraceLindqvist = Guid.Parse("b0000001-0000-0000-0000-000000000006");
    private static readonly Guid UserPaulNakamura = Guid.Parse("b0000001-0000-0000-0000-000000000007");
    // Members — Frontend Guild
    private static readonly Guid UserRosaAndersen = Guid.Parse("b0000001-0000-0000-0000-000000000008");
    private static readonly Guid UserBrianKowalski = Guid.Parse("b0000001-0000-0000-0000-000000000009");
    // Members — Data & Analytics
    private static readonly Guid UserFelixRomero = Guid.Parse("b0000001-0000-0000-0000-000000000010");
    private static readonly Guid UserElenaOkonkwo = Guid.Parse("b0000001-0000-0000-0000-000000000011");
    private static readonly Guid UserKiraBellamy = Guid.Parse("b0000001-0000-0000-0000-000000000012");
    private static readonly Guid UserIrisCastillo = Guid.Parse("b0000001-0000-0000-0000-000000000013");
    // Members — No team
    private static readonly Guid UserClaraNguyen = Guid.Parse("b0000001-0000-0000-0000-000000000014");
    private static readonly Guid UserDerekPatel = Guid.Parse("b0000001-0000-0000-0000-000000000015");
    private static readonly Guid UserSamKofi = Guid.Parse("b0000001-0000-0000-0000-000000000016");
    private static readonly Guid UserHenryYamamoto = Guid.Parse("b0000001-0000-0000-0000-000000000017");
    private static readonly Guid UserAliceHartman = Guid.Parse("b0000001-0000-0000-0000-000000000018");
    private static readonly Guid UserNolanBergstrom = Guid.Parse("b0000001-0000-0000-0000-000000000019");
    private static readonly Guid UserTaraVoss = Guid.Parse("b0000001-0000-0000-0000-000000000020");
    private static readonly Guid UserQuinnFitzgerald = Guid.Parse("b0000001-0000-0000-0000-000000000021");
    private static readonly Guid UserMayaThornton = Guid.Parse("b0000001-0000-0000-0000-000000000022");
    private static readonly Guid UserLiamOsei = Guid.Parse("b0000001-0000-0000-0000-000000000023");

    // ---- Sprint GUIDs ----
    // Main team
    private static readonly Guid SprintMain1 = Guid.Parse("c0000001-0000-0000-0000-000000000001");
    private static readonly Guid SprintMain2 = Guid.Parse("c0000001-0000-0000-0000-000000000002");
    // Data & Analytics
    private static readonly Guid SprintNova1 = Guid.Parse("c0000001-0000-0000-0000-000000000003");
    private static readonly Guid SprintNova2 = Guid.Parse("c0000001-0000-0000-0000-000000000004");
    private static readonly Guid SprintNova3 = Guid.Parse("c0000001-0000-0000-0000-000000000005");
    private static readonly Guid SprintNova4 = Guid.Parse("c0000001-0000-0000-0000-000000000006");
    // Platform Engineering
    private static readonly Guid SprintTitan1 = Guid.Parse("c0000001-0000-0000-0000-000000000007");
    private static readonly Guid SprintTitan2 = Guid.Parse("c0000001-0000-0000-0000-000000000008");
    // Frontend Guild
    private static readonly Guid SprintFalcon1 = Guid.Parse("c0000001-0000-0000-0000-000000000009");
    private static readonly Guid SprintFalcon2 = Guid.Parse("c0000001-0000-0000-0000-000000000010");
    private static readonly Guid SprintFalcon3 = Guid.Parse("c0000001-0000-0000-0000-000000000011");

    public static void Seed(ModelBuilder modelBuilder)
    {
        SeedTeams(modelBuilder);
        SeedUsers(modelBuilder);
        SeedSprints(modelBuilder);
        SeedSprintTasks(modelBuilder);
    }

    private static void SeedTeams(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>().HasData(
            new Team { Id = TeamDataAnalytics, Name = "Data & Analytics", Description = "Responsible for data pipelines, reporting, and ML experiments", CreatedAtUtc = SeedDate },
            new Team { Id = TeamMain, Name = "Main team", Description = "main team", CreatedAtUtc = SeedDate },
            new Team { Id = TeamPlatformEng, Name = "Platform Engineering", Description = "Handles infrastructure, CI/CD pipelines, and cloud architecture", CreatedAtUtc = SeedDate },
            new Team { Id = TeamFrontendGuild, Name = "Frontend Guild", Description = "Owns all UI/UX development and design system work", CreatedAtUtc = SeedDate }
        );
    }

    private static void SeedUsers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            // Admins (no team)
            new User { Id = UserAdmin, Email = "admin@example.com", PasswordHash = PasswordHash, FirstName = "Admin", LastName = "U", Role = TeamRole.Admin, TeamId = null, CreatedAtUtc = SeedDate },
            // Members — Main team
            new User { Id = UserOliviaReyes, Email = "olivia.reyes@mailhub.net", PasswordHash = PasswordHash, FirstName = "Olivia", LastName = "Reyes", Role = TeamRole.Member, TeamId = TeamMain, CreatedAtUtc = SeedDate },
            new User { Id = UserJakeMorrison, Email = "jake.morrison@codehaus.dev", PasswordHash = PasswordHash, FirstName = "Jake", LastName = "Morrison", Role = TeamRole.Member, TeamId = TeamMain, CreatedAtUtc = SeedDate },
            // Members — Platform Engineering
            new User { Id = UserGraceLindqvist, Email = "grace.lindqvist@nordic.dev", PasswordHash = PasswordHash, FirstName = "Grace", LastName = "Lindqvist", Role = TeamRole.Member, TeamId = TeamPlatformEng, CreatedAtUtc = SeedDate },
            new User { Id = UserPaulNakamura, Email = "paul.nakamura@devmail.jp", PasswordHash = PasswordHash, FirstName = "Paul", LastName = "Nakamura", Role = TeamRole.Member, TeamId = TeamPlatformEng, CreatedAtUtc = SeedDate },
            // Members — Frontend Guild
            new User { Id = UserRosaAndersen, Email = "rosa.andersen@scandev.net", PasswordHash = PasswordHash, FirstName = "Rosa", LastName = "Andersen", Role = TeamRole.Member, TeamId = TeamFrontendGuild, CreatedAtUtc = SeedDate },
            new User { Id = UserBrianKowalski, Email = "brian.kowalski@techcorp.net", PasswordHash = PasswordHash, FirstName = "Brian", LastName = "Kowalski", Role = TeamRole.Member, TeamId = TeamFrontendGuild, CreatedAtUtc = SeedDate },
            // Members — Data & Analytics
            new User { Id = UserFelixRomero, Email = "felix.romero@webdev.co", PasswordHash = PasswordHash, FirstName = "Felix", LastName = "Romero", Role = TeamRole.Member, TeamId = TeamDataAnalytics, CreatedAtUtc = SeedDate },
            new User { Id = UserElenaOkonkwo, Email = "elena.okonkwo@fastmail.io", PasswordHash = PasswordHash, FirstName = "Elena", LastName = "Okonkwo", Role = TeamRole.Member, TeamId = TeamDataAnalytics, CreatedAtUtc = SeedDate },
            new User { Id = UserKiraBellamy, Email = "kira.bellamy@devzone.io", PasswordHash = PasswordHash, FirstName = "Kira", LastName = "Bellamy", Role = TeamRole.Member, TeamId = TeamDataAnalytics, CreatedAtUtc = SeedDate },
            new User { Id = UserIrisCastillo, Email = "iris.castillo@latintech.net", PasswordHash = PasswordHash, FirstName = "Iris", LastName = "Castillo", Role = TeamRole.Member, TeamId = TeamDataAnalytics, CreatedAtUtc = SeedDate },
            // Members — No team
            new User { Id = UserClaraNguyen, Email = "clara.nguyen@outlook.dev", PasswordHash = PasswordHash, FirstName = "Clara", LastName = "Nguyen", Role = TeamRole.Member, TeamId = null, CreatedAtUtc = SeedDate },
            new User { Id = UserDerekPatel, Email = "derek.patel@mailbox.org", PasswordHash = PasswordHash, FirstName = "Derek", LastName = "Patel", Role = TeamRole.Member, TeamId = null, CreatedAtUtc = SeedDate },
            new User { Id = UserSamKofi, Email = "sam.kofi@ghanatech.io", PasswordHash = PasswordHash, FirstName = "Sam", LastName = "Kofi", Role = TeamRole.Member, TeamId = null, CreatedAtUtc = SeedDate },
            new User { Id = UserHenryYamamoto, Email = "henry.yamamoto@jptech.io", PasswordHash = PasswordHash, FirstName = "Henry", LastName = "Yamamoto", Role = TeamRole.Member, TeamId = null, CreatedAtUtc = SeedDate },
            new User { Id = UserAliceHartman, Email = "alice.hartman@devmail.io", PasswordHash = PasswordHash, FirstName = "Alice", LastName = "Hartman", Role = TeamRole.Member, TeamId = null, CreatedAtUtc = SeedDate },
            new User { Id = UserNolanBergstrom, Email = "nolan.bergstrom@nordic.io", PasswordHash = PasswordHash, FirstName = "Nolan", LastName = "Bergstrom", Role = TeamRole.Member, TeamId = null, CreatedAtUtc = SeedDate },
            new User { Id = UserTaraVoss, Email = "tara.voss@eurohub.dev", PasswordHash = PasswordHash, FirstName = "Tara", LastName = "Voss", Role = TeamRole.Member, TeamId = null, CreatedAtUtc = SeedDate },
            new User { Id = UserQuinnFitzgerald, Email = "quinn.fitzgerald@irishtech.io", PasswordHash = PasswordHash, FirstName = "Quinn", LastName = "Fitzgerald", Role = TeamRole.Member, TeamId = null, CreatedAtUtc = SeedDate },
            new User { Id = UserMayaThornton, Email = "maya.thornton@cloudmail.dev", PasswordHash = PasswordHash, FirstName = "Maya", LastName = "Thornton", Role = TeamRole.Member, TeamId = null, CreatedAtUtc = SeedDate },
            new User { Id = UserLiamOsei, Email = "liam.osei@afritech.co", PasswordHash = PasswordHash, FirstName = "Liam", LastName = "Osei", Role = TeamRole.Member, TeamId = null, CreatedAtUtc = SeedDate }
        );
    }

    private static void SeedSprints(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sprint>().HasData(
            // Main team
            new Sprint { Id = SprintMain1, Name = "Sprint 1", StartDate = new DateTime(2026, 2, 16, 15, 39, 44, DateTimeKind.Utc), EndDate = new DateTime(2026, 3, 16, 15, 39, 44, DateTimeKind.Utc), TeamId = TeamMain, CreatedAtUtc = SeedDate },
            new Sprint { Id = SprintMain2, Name = "Sprint 2", StartDate = new DateTime(2026, 2, 17, 0, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2026, 3, 3, 0, 0, 0, DateTimeKind.Utc), TeamId = TeamMain, CreatedAtUtc = SeedDate },
            // Data & Analytics
            new Sprint { Id = SprintNova1, Name = "Sprint Nova 1", StartDate = new DateTime(2026, 2, 17, 0, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2026, 3, 10, 0, 0, 0, DateTimeKind.Utc), TeamId = TeamDataAnalytics, CreatedAtUtc = SeedDate },
            new Sprint { Id = SprintNova2, Name = "Sprint Nova 2", StartDate = new DateTime(2026, 3, 10, 0, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2026, 4, 3, 0, 0, 0, DateTimeKind.Utc), TeamId = TeamDataAnalytics, CreatedAtUtc = SeedDate },
            new Sprint { Id = SprintNova3, Name = "Sprint Nova 3", StartDate = new DateTime(2026, 4, 3, 0, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2026, 4, 28, 0, 0, 0, DateTimeKind.Utc), TeamId = TeamDataAnalytics, CreatedAtUtc = SeedDate },
            new Sprint { Id = SprintNova4, Name = "Sprint Nova 4", StartDate = new DateTime(2026, 4, 28, 0, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2026, 5, 19, 0, 0, 0, DateTimeKind.Utc), TeamId = TeamDataAnalytics, CreatedAtUtc = SeedDate },
            // Platform Engineering
            new Sprint { Id = SprintTitan1, Name = "Sprint Titan 1", StartDate = new DateTime(2026, 2, 17, 0, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2026, 3, 17, 0, 0, 0, DateTimeKind.Utc), TeamId = TeamPlatformEng, CreatedAtUtc = SeedDate },
            new Sprint { Id = SprintTitan2, Name = "Sprint Titan 2", StartDate = new DateTime(2026, 3, 17, 0, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2026, 4, 14, 0, 0, 0, DateTimeKind.Utc), TeamId = TeamPlatformEng, CreatedAtUtc = SeedDate },
            // Frontend Guild
            new Sprint { Id = SprintFalcon1, Name = "Sprint Falcon 1", StartDate = new DateTime(2026, 2, 17, 0, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2026, 3, 10, 0, 0, 0, DateTimeKind.Utc), TeamId = TeamFrontendGuild, CreatedAtUtc = SeedDate },
            new Sprint { Id = SprintFalcon2, Name = "Sprint Falcon 2", StartDate = new DateTime(2026, 3, 10, 0, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2026, 4, 7, 0, 0, 0, DateTimeKind.Utc), TeamId = TeamFrontendGuild, CreatedAtUtc = SeedDate },
            new Sprint { Id = SprintFalcon3, Name = "Sprint Falcon 3", StartDate = new DateTime(2026, 4, 7, 0, 0, 0, DateTimeKind.Utc), EndDate = new DateTime(2026, 5, 5, 0, 0, 0, DateTimeKind.Utc), TeamId = TeamFrontendGuild, CreatedAtUtc = SeedDate }
        );
    }

    private static void SeedSprintTasks(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SprintTask>().HasData(
            // ---- Sprint 1 (Main team) ----
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000001"), Title = "Integrate payments", Description = "payments", Status = SprintTaskStatus.InProgress, AssigneeId = UserAdmin, SprintId = SprintMain1, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },

            // ---- Sprint 2 (Main team) ----
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000002"), Title = "Basket implementation", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = UserOliviaReyes, SprintId = SprintMain2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },

            // ---- Sprint Nova 1 (Data & Analytics) ----
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000003"), Title = "Design ETL pipeline", Description = "ETL pipeline description", Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintNova1, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000004"), Title = "Ingest raw event data", Description = null, Status = SprintTaskStatus.Done, AssigneeId = null, SprintId = SprintNova1, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000005"), Title = "Write data quality checks", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintNova1, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000006"), Title = "Build reporting schema", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintNova1, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000067"), Title = "Implement CI-CD", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = UserAdmin, SprintId = SprintNova1, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },

            // ---- Sprint Nova 2 (Data & Analytics) ----
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000007"), Title = "Create sales dashboard", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintNova2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000008"), Title = "Implement funnel analysis", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintNova2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000009"), Title = "Build cohort report", Description = null, Status = SprintTaskStatus.Done, AssigneeId = null, SprintId = SprintNova2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000010"), Title = "Optimize slow queries", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintNova2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000011"), Title = "Add revenue metrics", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintNova2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000012"), Title = "Set up dbt models", Description = null, Status = SprintTaskStatus.Done, AssigneeId = null, SprintId = SprintNova2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000013"), Title = "Document pipeline architecture", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintNova2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000014"), Title = "Write data dictionary", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintNova2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },

            // ---- Sprint Nova 3 (Data & Analytics) ----
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000015"), Title = "Train churn prediction model", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintNova3, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000016"), Title = "Evaluate model metrics", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintNova3, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000017"), Title = "Set up MLflow tracking", Description = null, Status = SprintTaskStatus.Done, AssigneeId = null, SprintId = SprintNova3, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000018"), Title = "Feature engineering for LTV", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintNova3, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000019"), Title = "Build prediction API", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintNova3, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000020"), Title = "Write model card", Description = null, Status = SprintTaskStatus.Done, AssigneeId = null, SprintId = SprintNova3, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000021"), Title = "A/B test framework setup", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintNova3, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },

            // ---- Sprint Nova 4 (Data & Analytics) ----
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000022"), Title = "Deploy model to production", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintNova4, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000023"), Title = "Monitor model drift", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintNova4, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000024"), Title = "Update stakeholder report", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintNova4, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000025"), Title = "Retrain pipeline automation", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintNova4, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000026"), Title = "Build alerting for predictions", Description = null, Status = SprintTaskStatus.Done, AssigneeId = null, SprintId = SprintNova4, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000027"), Title = "Archive old experiments", Description = null, Status = SprintTaskStatus.Done, AssigneeId = null, SprintId = SprintNova4, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000028"), Title = "Load test prediction API", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintNova4, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000029"), Title = "Migrate feature store", Description = null, Status = SprintTaskStatus.Done, AssigneeId = null, SprintId = SprintNova4, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000030"), Title = "Review data retention policy", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintNova4, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000031"), Title = "Document model endpoints", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintNova4, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },

            // ---- Sprint Titan 1 (Platform Engineering) ----
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000032"), Title = "Set up Kubernetes cluster", Description = null, Status = SprintTaskStatus.Done, AssigneeId = null, SprintId = SprintTitan1, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000033"), Title = "Configure Helm charts", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintTitan1, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000034"), Title = "Set up CI/CD pipeline", Description = null, Status = SprintTaskStatus.Done, AssigneeId = null, SprintId = SprintTitan1, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000035"), Title = "Implement secret management", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintTitan1, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000036"), Title = "Write infrastructure docs", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = UserRosaAndersen, SprintId = SprintTitan1, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000037"), Title = "Configure load balancer", Description = null, Status = SprintTaskStatus.Done, AssigneeId = null, SprintId = SprintTitan1, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },

            // ---- Sprint Titan 2 (Platform Engineering) ----
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000038"), Title = "Set up monitoring with Grafana", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintTitan2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000039"), Title = "Configure alerting rules", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintTitan2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000040"), Title = "Migrate to Docker Compose v2", Description = null, Status = SprintTaskStatus.Done, AssigneeId = null, SprintId = SprintTitan2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000041"), Title = "Automate DB backups", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintTitan2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000042"), Title = "Audit IAM permissions", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintTitan2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000043"), Title = "Update Terraform modules", Description = null, Status = SprintTaskStatus.Done, AssigneeId = null, SprintId = SprintTitan2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000044"), Title = "Add health check endpoints", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintTitan2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000045"), Title = "Set up staging environment", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintTitan2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000046"), Title = "Implement log aggregation", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintTitan2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },

            // ---- Sprint Falcon 1 (Frontend Guild) ----
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000047"), Title = "Design landing page mockup", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintFalcon1, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000048"), Title = "Set up Tailwind CSS config", Description = null, Status = SprintTaskStatus.Done, AssigneeId = null, SprintId = SprintFalcon1, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000049"), Title = "Build navigation component", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintFalcon1, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000050"), Title = "Implement dark mode toggle", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintFalcon1, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000051"), Title = "Write component unit tests", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintFalcon1, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },

            // ---- Sprint Falcon 2 (Frontend Guild) ----
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000052"), Title = "Refactor button library", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintFalcon2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000053"), Title = "Add form validation", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintFalcon2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000054"), Title = "Implement toast notifications", Description = null, Status = SprintTaskStatus.Done, AssigneeId = null, SprintId = SprintFalcon2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000055"), Title = "Fix mobile layout bugs", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintFalcon2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000056"), Title = "Create storybook stories", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintFalcon2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000057"), Title = "Update design tokens", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintFalcon2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000058"), Title = "Accessibility audit", Description = null, Status = SprintTaskStatus.Done, AssigneeId = null, SprintId = SprintFalcon2, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },

            // ---- Sprint Falcon 3 (Frontend Guild) ----
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000059"), Title = "Build data table component", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintFalcon3, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000060"), Title = "Integrate chart library", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintFalcon3, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000061"), Title = "Implement pagination", Description = null, Status = SprintTaskStatus.Done, AssigneeId = null, SprintId = SprintFalcon3, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000062"), Title = "Write E2E tests for dashboard", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintFalcon3, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000063"), Title = "Add export to CSV feature", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintFalcon3, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000064"), Title = "Performance profiling", Description = null, Status = SprintTaskStatus.ToDo, AssigneeId = null, SprintId = SprintFalcon3, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000065"), Title = "Fix Safari rendering issues", Description = null, Status = SprintTaskStatus.Done, AssigneeId = null, SprintId = SprintFalcon3, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate },
            new SprintTask { Id = Guid.Parse("d0000001-0000-0000-0000-000000000066"), Title = "Add skeleton loaders", Description = null, Status = SprintTaskStatus.InProgress, AssigneeId = null, SprintId = SprintFalcon3, CreatedByUserId = UserAdmin, CreatedAtUtc = SeedDate }
        );
    }
}
