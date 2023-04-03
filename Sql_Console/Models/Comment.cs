namespace Sql_Console.Models;

internal class Comment
{
    public Guid Id { get; set; }
    public string CommentString { get; set; } = null!;
    public DateTime CommentDate { get; set; }
    public Guid IssueId { get; set; }
}
