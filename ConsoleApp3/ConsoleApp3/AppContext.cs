using Microsoft.EntityFrameworkCore;

namespace ConsoleApp3;

internal class AppContext : DbContext
{
    private const string _connString = @"Data Source=C:\sqlite\db1.db";

    public DbSet<User> Users => Set<User>();

    public AppContext() =>
        Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite(_connString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}