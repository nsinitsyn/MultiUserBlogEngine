using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiUserBlogEngine.Domain.Entities;
using MultiUserBlogEngine.Domain.Entities.Base;
using System.Reflection;

namespace MultiUserBlogEngine.Infrastructure.DbAccess;

public class AppDbContext : DbContext
{
    /*
     * todo:
     * индексы
     * ограничения на MaxLength для string
     * автозаполнение авторских полей
     * логгирование sql запросов в отдельный файл
     * точно ли нужен AddUtcConverter
     * попробовать вместо связи 1:1 для BlockedUser технику Собственные типы - стр. 320-324
     * Как быстро получать Лучшее, Новое?
     */

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
        SetupDateTimeProperties(modelBuilder);
    }

    private static void SetupDateTimeProperties(ModelBuilder modelBuilder)
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

                    if (entityProperty.Name == nameof(AuthoredEntity.CreatedDateTime) || 
                        entityProperty.Name == nameof(AuthoredEntity.LastUpdatedDateTime))
                    {
                        entityProperty.SetDefaultValueSql("now()");
                    }
                }
            }
        }
    }
}
