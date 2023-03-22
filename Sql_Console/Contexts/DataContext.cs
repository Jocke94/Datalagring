using Microsoft.EntityFrameworkCore;
using Sql_Console.Models.Entities;

namespace Sql_Console.Contexts;

internal class DataContext : DbContext
{
    private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jocke\source\repos\Sql_Console\Sql_Console\Contexts\sql_db.mdf;Integrated Security=True;Connect Timeout=30";
    
    #region constructors
    public DataContext()
    {
    }
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    #endregion

    #region overrides
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
    #endregion

    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<IssueEntity> Issues { get; set; } = null!;
    public DbSet<CommentEntity> Comments { get; set; } = null!;
    public DbSet<EmployeeEntity> Employees { get; set; } = null!;
    public DbSet<AddressEntity> Addresses { get; set; } = null!;
    public DbSet<StatusEntity> Statuses { get; set; } = null!;
}
