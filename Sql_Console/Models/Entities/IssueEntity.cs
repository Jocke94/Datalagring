using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sql_Console.Models.Entities;

internal class IssueEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public DateTime DateOpened { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string Title { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(500)")]
    public string Description { get; set; } = null!;

    [Required]
    public int UserId { get; set; }
    public UserEntity User { get; set; } = null!;

    [Required]
    public int StatusId { get; set; }
    public StatusEntity Status { get; set; } = null!;

    public ICollection<CommentEntity> Comments { get; set; } = new HashSet<CommentEntity>();
}
