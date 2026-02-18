namespace TaskTrackingSystem.Application.Common;

public static class CacheKeys
{
    public static string TeamMembers(Guid teamId) => $"team-members:{teamId}";
    public static string SprintsByTeam(Guid teamId) => $"sprints-by-team:{teamId}";
}
