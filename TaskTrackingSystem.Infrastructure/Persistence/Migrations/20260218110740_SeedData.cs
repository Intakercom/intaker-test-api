using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskTrackingSystem.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedAtUtc", "Description", "Name", "UpdatedAtUtc" },
                values: new object[,]
                {
                    { new Guid("a0000001-0000-0000-0000-000000000001"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "Responsible for data pipelines, reporting, and ML experiments", "Data & Analytics", null },
                    { new Guid("a0000001-0000-0000-0000-000000000002"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "main team", "Main team", null },
                    { new Guid("a0000001-0000-0000-0000-000000000003"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "Handles infrastructure, CI/CD pipelines, and cloud architecture", "Platform Engineering", null },
                    { new Guid("a0000001-0000-0000-0000-000000000004"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "Owns all UI/UX development and design system work", "Frontend Guild", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAtUtc", "Email", "FirstName", "LastName", "PasswordHash", "Role", "TeamId", "UpdatedAtUtc" },
                values: new object[,]
                {
                    { new Guid("b0000001-0000-0000-0000-000000000001"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "admin@example.com", "Admin", "U", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Admin", null, null },
                    { new Guid("b0000001-0000-0000-0000-000000000014"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "clara.nguyen@outlook.dev", "Clara", "Nguyen", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", null, null },
                    { new Guid("b0000001-0000-0000-0000-000000000015"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "derek.patel@mailbox.org", "Derek", "Patel", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", null, null },
                    { new Guid("b0000001-0000-0000-0000-000000000016"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "sam.kofi@ghanatech.io", "Sam", "Kofi", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", null, null },
                    { new Guid("b0000001-0000-0000-0000-000000000017"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "henry.yamamoto@jptech.io", "Henry", "Yamamoto", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", null, null },
                    { new Guid("b0000001-0000-0000-0000-000000000018"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "alice.hartman@devmail.io", "Alice", "Hartman", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", null, null },
                    { new Guid("b0000001-0000-0000-0000-000000000019"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "nolan.bergstrom@nordic.io", "Nolan", "Bergstrom", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", null, null },
                    { new Guid("b0000001-0000-0000-0000-000000000020"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "tara.voss@eurohub.dev", "Tara", "Voss", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", null, null },
                    { new Guid("b0000001-0000-0000-0000-000000000021"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "quinn.fitzgerald@irishtech.io", "Quinn", "Fitzgerald", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", null, null },
                    { new Guid("b0000001-0000-0000-0000-000000000022"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "maya.thornton@cloudmail.dev", "Maya", "Thornton", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", null, null },
                    { new Guid("b0000001-0000-0000-0000-000000000023"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "liam.osei@afritech.co", "Liam", "Osei", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", null, null }
                });

            migrationBuilder.InsertData(
                table: "Sprints",
                columns: new[] { "Id", "CreatedAtUtc", "EndDate", "Name", "StartDate", "TeamId", "UpdatedAtUtc" },
                values: new object[,]
                {
                    { new Guid("c0000001-0000-0000-0000-000000000001"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 16, 15, 39, 44, 0, DateTimeKind.Utc), "Sprint 1", new DateTime(2026, 2, 16, 15, 39, 44, 0, DateTimeKind.Utc), new Guid("a0000001-0000-0000-0000-000000000002"), null },
                    { new Guid("c0000001-0000-0000-0000-000000000002"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Sprint 2", new DateTime(2026, 2, 17, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a0000001-0000-0000-0000-000000000002"), null },
                    { new Guid("c0000001-0000-0000-0000-000000000003"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Sprint Nova 1", new DateTime(2026, 2, 17, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a0000001-0000-0000-0000-000000000001"), null },
                    { new Guid("c0000001-0000-0000-0000-000000000004"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Sprint Nova 2", new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a0000001-0000-0000-0000-000000000001"), null },
                    { new Guid("c0000001-0000-0000-0000-000000000005"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Sprint Nova 3", new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a0000001-0000-0000-0000-000000000001"), null },
                    { new Guid("c0000001-0000-0000-0000-000000000006"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Sprint Nova 4", new DateTime(2026, 4, 28, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a0000001-0000-0000-0000-000000000001"), null },
                    { new Guid("c0000001-0000-0000-0000-000000000007"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Sprint Titan 1", new DateTime(2026, 2, 17, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a0000001-0000-0000-0000-000000000003"), null },
                    { new Guid("c0000001-0000-0000-0000-000000000008"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Sprint Titan 2", new DateTime(2026, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a0000001-0000-0000-0000-000000000003"), null },
                    { new Guid("c0000001-0000-0000-0000-000000000009"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Sprint Falcon 1", new DateTime(2026, 2, 17, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a0000001-0000-0000-0000-000000000004"), null },
                    { new Guid("c0000001-0000-0000-0000-000000000010"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new DateTime(2026, 4, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Sprint Falcon 2", new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a0000001-0000-0000-0000-000000000004"), null },
                    { new Guid("c0000001-0000-0000-0000-000000000011"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new DateTime(2026, 5, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Sprint Falcon 3", new DateTime(2026, 4, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a0000001-0000-0000-0000-000000000004"), null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAtUtc", "Email", "FirstName", "LastName", "PasswordHash", "Role", "TeamId", "UpdatedAtUtc" },
                values: new object[,]
                {
                    { new Guid("b0000001-0000-0000-0000-000000000003"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "olivia.reyes@mailhub.net", "Olivia", "Reyes", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", new Guid("a0000001-0000-0000-0000-000000000002"), null },
                    { new Guid("b0000001-0000-0000-0000-000000000005"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "jake.morrison@codehaus.dev", "Jake", "Morrison", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", new Guid("a0000001-0000-0000-0000-000000000002"), null },
                    { new Guid("b0000001-0000-0000-0000-000000000006"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "grace.lindqvist@nordic.dev", "Grace", "Lindqvist", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", new Guid("a0000001-0000-0000-0000-000000000003"), null },
                    { new Guid("b0000001-0000-0000-0000-000000000007"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "paul.nakamura@devmail.jp", "Paul", "Nakamura", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", new Guid("a0000001-0000-0000-0000-000000000003"), null },
                    { new Guid("b0000001-0000-0000-0000-000000000008"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "rosa.andersen@scandev.net", "Rosa", "Andersen", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", new Guid("a0000001-0000-0000-0000-000000000004"), null },
                    { new Guid("b0000001-0000-0000-0000-000000000009"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "brian.kowalski@techcorp.net", "Brian", "Kowalski", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", new Guid("a0000001-0000-0000-0000-000000000004"), null },
                    { new Guid("b0000001-0000-0000-0000-000000000010"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "felix.romero@webdev.co", "Felix", "Romero", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", new Guid("a0000001-0000-0000-0000-000000000001"), null },
                    { new Guid("b0000001-0000-0000-0000-000000000011"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "elena.okonkwo@fastmail.io", "Elena", "Okonkwo", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", new Guid("a0000001-0000-0000-0000-000000000001"), null },
                    { new Guid("b0000001-0000-0000-0000-000000000012"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "kira.bellamy@devzone.io", "Kira", "Bellamy", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", new Guid("a0000001-0000-0000-0000-000000000001"), null },
                    { new Guid("b0000001-0000-0000-0000-000000000013"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), "iris.castillo@latintech.net", "Iris", "Castillo", "$2a$11$O1xLiQXLjHihe82/tilSR.G0/rF87lIT/vAziJ8qU5KEpUftJKFoW", "Member", new Guid("a0000001-0000-0000-0000-000000000001"), null }
                });

            migrationBuilder.InsertData(
                table: "SprintTasks",
                columns: new[] { "Id", "AssigneeId", "CreatedAtUtc", "CreatedByUserId", "Description", "SprintId", "Status", "Title", "UpdatedAtUtc" },
                values: new object[,]
                {
                    { new Guid("d0000001-0000-0000-0000-000000000001"), new Guid("b0000001-0000-0000-0000-000000000001"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), "payments", new Guid("c0000001-0000-0000-0000-000000000001"), "InProgress", "Integrate payments", null },
                    { new Guid("d0000001-0000-0000-0000-000000000002"), new Guid("b0000001-0000-0000-0000-000000000003"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000002"), "ToDo", "Basket implementation", null },
                    { new Guid("d0000001-0000-0000-0000-000000000003"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), "ETL pipeline description", new Guid("c0000001-0000-0000-0000-000000000003"), "InProgress", "Design ETL pipeline", null },
                    { new Guid("d0000001-0000-0000-0000-000000000004"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000003"), "Done", "Ingest raw event data", null },
                    { new Guid("d0000001-0000-0000-0000-000000000005"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000003"), "ToDo", "Write data quality checks", null },
                    { new Guid("d0000001-0000-0000-0000-000000000006"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000003"), "ToDo", "Build reporting schema", null },
                    { new Guid("d0000001-0000-0000-0000-000000000007"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000004"), "ToDo", "Create sales dashboard", null },
                    { new Guid("d0000001-0000-0000-0000-000000000008"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000004"), "InProgress", "Implement funnel analysis", null },
                    { new Guid("d0000001-0000-0000-0000-000000000009"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000004"), "Done", "Build cohort report", null },
                    { new Guid("d0000001-0000-0000-0000-000000000010"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000004"), "InProgress", "Optimize slow queries", null },
                    { new Guid("d0000001-0000-0000-0000-000000000011"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000004"), "ToDo", "Add revenue metrics", null },
                    { new Guid("d0000001-0000-0000-0000-000000000012"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000004"), "Done", "Set up dbt models", null },
                    { new Guid("d0000001-0000-0000-0000-000000000013"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000004"), "InProgress", "Document pipeline architecture", null },
                    { new Guid("d0000001-0000-0000-0000-000000000014"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000004"), "ToDo", "Write data dictionary", null },
                    { new Guid("d0000001-0000-0000-0000-000000000015"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000005"), "InProgress", "Train churn prediction model", null },
                    { new Guid("d0000001-0000-0000-0000-000000000016"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000005"), "ToDo", "Evaluate model metrics", null },
                    { new Guid("d0000001-0000-0000-0000-000000000017"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000005"), "Done", "Set up MLflow tracking", null },
                    { new Guid("d0000001-0000-0000-0000-000000000018"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000005"), "ToDo", "Feature engineering for LTV", null },
                    { new Guid("d0000001-0000-0000-0000-000000000019"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000005"), "InProgress", "Build prediction API", null },
                    { new Guid("d0000001-0000-0000-0000-000000000020"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000005"), "Done", "Write model card", null },
                    { new Guid("d0000001-0000-0000-0000-000000000021"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000005"), "ToDo", "A/B test framework setup", null },
                    { new Guid("d0000001-0000-0000-0000-000000000022"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000006"), "ToDo", "Deploy model to production", null },
                    { new Guid("d0000001-0000-0000-0000-000000000023"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000006"), "InProgress", "Monitor model drift", null },
                    { new Guid("d0000001-0000-0000-0000-000000000024"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000006"), "InProgress", "Update stakeholder report", null },
                    { new Guid("d0000001-0000-0000-0000-000000000025"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000006"), "ToDo", "Retrain pipeline automation", null },
                    { new Guid("d0000001-0000-0000-0000-000000000026"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000006"), "Done", "Build alerting for predictions", null },
                    { new Guid("d0000001-0000-0000-0000-000000000027"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000006"), "Done", "Archive old experiments", null },
                    { new Guid("d0000001-0000-0000-0000-000000000028"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000006"), "InProgress", "Load test prediction API", null },
                    { new Guid("d0000001-0000-0000-0000-000000000029"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000006"), "Done", "Migrate feature store", null },
                    { new Guid("d0000001-0000-0000-0000-000000000030"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000006"), "ToDo", "Review data retention policy", null },
                    { new Guid("d0000001-0000-0000-0000-000000000031"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000006"), "ToDo", "Document model endpoints", null },
                    { new Guid("d0000001-0000-0000-0000-000000000032"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000007"), "Done", "Set up Kubernetes cluster", null },
                    { new Guid("d0000001-0000-0000-0000-000000000033"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000007"), "InProgress", "Configure Helm charts", null },
                    { new Guid("d0000001-0000-0000-0000-000000000034"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000007"), "Done", "Set up CI/CD pipeline", null },
                    { new Guid("d0000001-0000-0000-0000-000000000035"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000007"), "ToDo", "Implement secret management", null },
                    { new Guid("d0000001-0000-0000-0000-000000000036"), new Guid("b0000001-0000-0000-0000-000000000008"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000007"), "InProgress", "Write infrastructure docs", null },
                    { new Guid("d0000001-0000-0000-0000-000000000037"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000007"), "Done", "Configure load balancer", null },
                    { new Guid("d0000001-0000-0000-0000-000000000038"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000008"), "InProgress", "Set up monitoring with Grafana", null },
                    { new Guid("d0000001-0000-0000-0000-000000000039"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000008"), "ToDo", "Configure alerting rules", null },
                    { new Guid("d0000001-0000-0000-0000-000000000040"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000008"), "Done", "Migrate to Docker Compose v2", null },
                    { new Guid("d0000001-0000-0000-0000-000000000041"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000008"), "ToDo", "Automate DB backups", null },
                    { new Guid("d0000001-0000-0000-0000-000000000042"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000008"), "InProgress", "Audit IAM permissions", null },
                    { new Guid("d0000001-0000-0000-0000-000000000043"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000008"), "Done", "Update Terraform modules", null },
                    { new Guid("d0000001-0000-0000-0000-000000000044"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000008"), "ToDo", "Add health check endpoints", null },
                    { new Guid("d0000001-0000-0000-0000-000000000045"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000008"), "InProgress", "Set up staging environment", null },
                    { new Guid("d0000001-0000-0000-0000-000000000046"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000008"), "ToDo", "Implement log aggregation", null },
                    { new Guid("d0000001-0000-0000-0000-000000000047"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000009"), "InProgress", "Design landing page mockup", null },
                    { new Guid("d0000001-0000-0000-0000-000000000048"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000009"), "Done", "Set up Tailwind CSS config", null },
                    { new Guid("d0000001-0000-0000-0000-000000000049"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000009"), "InProgress", "Build navigation component", null },
                    { new Guid("d0000001-0000-0000-0000-000000000050"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000009"), "ToDo", "Implement dark mode toggle", null },
                    { new Guid("d0000001-0000-0000-0000-000000000051"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000009"), "ToDo", "Write component unit tests", null },
                    { new Guid("d0000001-0000-0000-0000-000000000052"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000010"), "InProgress", "Refactor button library", null },
                    { new Guid("d0000001-0000-0000-0000-000000000053"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000010"), "ToDo", "Add form validation", null },
                    { new Guid("d0000001-0000-0000-0000-000000000054"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000010"), "Done", "Implement toast notifications", null },
                    { new Guid("d0000001-0000-0000-0000-000000000055"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000010"), "InProgress", "Fix mobile layout bugs", null },
                    { new Guid("d0000001-0000-0000-0000-000000000056"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000010"), "ToDo", "Create storybook stories", null },
                    { new Guid("d0000001-0000-0000-0000-000000000057"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000010"), "ToDo", "Update design tokens", null },
                    { new Guid("d0000001-0000-0000-0000-000000000058"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000010"), "Done", "Accessibility audit", null },
                    { new Guid("d0000001-0000-0000-0000-000000000059"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000011"), "ToDo", "Build data table component", null },
                    { new Guid("d0000001-0000-0000-0000-000000000060"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000011"), "InProgress", "Integrate chart library", null },
                    { new Guid("d0000001-0000-0000-0000-000000000061"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000011"), "Done", "Implement pagination", null },
                    { new Guid("d0000001-0000-0000-0000-000000000062"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000011"), "InProgress", "Write E2E tests for dashboard", null },
                    { new Guid("d0000001-0000-0000-0000-000000000063"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000011"), "ToDo", "Add export to CSV feature", null },
                    { new Guid("d0000001-0000-0000-0000-000000000064"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000011"), "ToDo", "Performance profiling", null },
                    { new Guid("d0000001-0000-0000-0000-000000000065"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000011"), "Done", "Fix Safari rendering issues", null },
                    { new Guid("d0000001-0000-0000-0000-000000000066"), null, new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000011"), "InProgress", "Add skeleton loaders", null },
                    { new Guid("d0000001-0000-0000-0000-000000000067"), new Guid("b0000001-0000-0000-0000-000000000001"), new DateTime(2026, 2, 17, 21, 52, 0, 0, DateTimeKind.Utc), new Guid("b0000001-0000-0000-0000-000000000001"), null, new Guid("c0000001-0000-0000-0000-000000000003"), "ToDo", "Implement CI-CD", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000031"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000032"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000033"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000034"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000035"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000036"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000037"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000038"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000039"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000040"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000041"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000042"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000043"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000044"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000045"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000046"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000047"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000048"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000049"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000050"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000051"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000052"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000053"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000054"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000055"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000056"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000057"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000058"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000059"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000060"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000061"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000062"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000063"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000064"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000065"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000066"));

            migrationBuilder.DeleteData(
                table: "SprintTasks",
                keyColumn: "Id",
                keyValue: new Guid("d0000001-0000-0000-0000-000000000067"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "Sprints",
                keyColumn: "Id",
                keyValue: new Guid("c0000001-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Sprints",
                keyColumn: "Id",
                keyValue: new Guid("c0000001-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Sprints",
                keyColumn: "Id",
                keyValue: new Guid("c0000001-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Sprints",
                keyColumn: "Id",
                keyValue: new Guid("c0000001-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Sprints",
                keyColumn: "Id",
                keyValue: new Guid("c0000001-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Sprints",
                keyColumn: "Id",
                keyValue: new Guid("c0000001-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Sprints",
                keyColumn: "Id",
                keyValue: new Guid("c0000001-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Sprints",
                keyColumn: "Id",
                keyValue: new Guid("c0000001-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Sprints",
                keyColumn: "Id",
                keyValue: new Guid("c0000001-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Sprints",
                keyColumn: "Id",
                keyValue: new Guid("c0000001-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Sprints",
                keyColumn: "Id",
                keyValue: new Guid("c0000001-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b0000001-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("a0000001-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("a0000001-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("a0000001-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: new Guid("a0000001-0000-0000-0000-000000000004"));
        }
    }
}
