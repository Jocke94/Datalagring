using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sql_Console.Models.Entities;

internal class StatusEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(10)")]
    public string Status { get; set; } = "Open";

    public ICollection<IssueEntity> Issues = new HashSet<IssueEntity>();
}