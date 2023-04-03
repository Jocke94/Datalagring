using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sql_Console.Models.Entities;

internal class CommentEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Column(TypeName = "nvarchar(200)")]
    public string Comment { get; set; } = null!;

    [Required]
    public DateTime CommentDate { get; set; }

    [Required]
    public Guid IssueId { get; set; }
    public IssueEntity Issue { get; set; } = null!;
}