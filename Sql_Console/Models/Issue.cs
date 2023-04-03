using System.Globalization;

namespace Sql_Console.Models;

internal class Issue
{
    public Guid Id { get; set; }
    public DateTime DateOpened { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int UserId { get; set; }
    public int StatusId { get; set; }
}
