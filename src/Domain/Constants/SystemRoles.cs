namespace Domain.Constants;

public static class SystemRoles
{
    private const string Admin = "Admin";
    private const string Architect = "Architect";
    private const string Manager = "Manager";
    private const string Developer = "Developer";
    private const string Auditor = "Auditor";

    public static readonly IReadOnlyCollection<string> All =
    [
        Admin,
        Architect,
        Manager,
        Developer,
        Auditor
    ];
}