using Entities.Models;

namespace Repository.FilerExtensions;

public static class EmployeeFilterExtensions
{
    public static IQueryable<Employee> FilterEmployees(
        this IQueryable<Employee> query, 
        uint minAge, 
        uint maxAge
        ) =>
    query.Where(e => e.Age >= minAge && e.Age <= maxAge);
    
    public static IQueryable<Employee> FilterEmployees(
        this IQueryable<Employee> query, 
        string searchKey
        ) =>
    query.Where(e => e.Name.Contains(searchKey));
}