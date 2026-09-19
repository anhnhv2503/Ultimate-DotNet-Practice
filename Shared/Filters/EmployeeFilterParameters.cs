namespace Shared.Filters;

public class EmployeeFilterParameters
{
    public uint MinAge { get; set; }
    public uint MaxAge { get; set; } = int.MaxValue;
    public string? SearchKey { get; set; } = string.Empty;
    public string? Fields { get; set; } = string.Empty;
    public bool ValidAgeRange => MinAge <= MaxAge;
}