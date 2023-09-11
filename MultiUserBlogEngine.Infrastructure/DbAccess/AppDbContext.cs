using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiUserBlogEngine.Domain.Entities;
using System.Reflection;

namespace MultiUserBlogEngine.Infrastructure.DbAccess;

public class AppDbContext : DbContext
{
    // todo: индексы, ограничения на MaxLength для string

    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Post> Posts { get; set; }

    public DbSet<Visitor> Visitors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        AddUtcConverter(modelBuilder);
    }

    /// <summary>
    /// Добавляет конвертер, указывающий Kind равным Utc во все поля DateTime для всех сущностей при чтении из БД.
    /// </summary>
    /// <param name="modelBuilder"></param>
    private static void AddUtcConverter(ModelBuilder modelBuilder)
    {
        var utcConverter = new ValueConverter<DateTime, DateTime>(
            toDb => toDb,
            fromDb => DateTime.SpecifyKind(fromDb, DateTimeKind.Utc));

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var entityProperty in entityType.GetProperties())
            {
                if (entityProperty.ClrType == typeof(DateTime))
                {
                    entityProperty.SetValueConverter(utcConverter);
                }
            }
        }
    }
}
