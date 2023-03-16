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
    [Column(TypeName = "nvarchar(50)")]
    public string Title { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(500)")]
    public string Description { get; set; } = null!;

    [Required]
    [Range(1, 3)]
    public int Status { get; set; }

    [Required]
    public int UserId { get; set; }
    public UserEntity User { get; set; } = null!;

    public ICollection<CommentEntity> Comments = new HashSet<CommentEntity>();
    
}
