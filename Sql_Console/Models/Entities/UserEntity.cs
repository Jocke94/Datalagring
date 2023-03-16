using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sql_Console.Models.Entities;

[Index(nameof(Email), IsUnique = true)]
internal class UserEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string FirstName { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Email { get; set; } = null!;
}
