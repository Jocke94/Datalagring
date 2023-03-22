using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sql_Console.Models.Entities;

internal class AddressEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Address { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string City { get; set; } = null!;

    //public int UserId { get; set; }
    public UserEntity User { get; set; } = null!;

    public ICollection<UserEntity> Users = new HashSet<UserEntity>();


    //public int EmployeeId { get; set; }
    public EmployeeEntity Employee { get; set; } = null!;

    public ICollection<EmployeeEntity> Employees = new HashSet<EmployeeEntity>();
}