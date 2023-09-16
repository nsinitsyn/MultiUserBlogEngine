using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiUserBlogEngine.Domain.Dependencies;
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
     */

    private IApplicationContext _applicationContext;

    public AppDbContext(DbContextOptions<AppDbContext> options, IApplicationContext applicationContext) 
        : base(options)
    {
        _applicationContext = applicationContext;
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Post> Posts { get; set; }

    public DbSet<Visitor> Visitors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        SetupConverters(modelBuilder);
    }

    public override int SaveChanges()
    {
        int? userId = _applicationContext.GetCurrentUserId();

        if(!userId.HasValue)
        {
            throw new InvalidOperationException("Cannot find user for SaveChanges method.");
        }

        HandleUpdatedEntities(userId.Value);

        ChangeTracker.AutoDetectChangesEnabled = false;

        try
        {
            return base.SaveChanges();
        }
        finally
        {
            ChangeTracker.AutoDetectChangesEnabled = true;
        }
    }

    private void HandleUpdatedEntities(int userId)
    {
        ChangeTracker.DetectChanges();

        var entries = ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Modified || x.State == EntityState.Added);

        foreach (var entry in entries)
        {
            if (entry.Entity is AuthoredEntity authoredEntity)
            {
                LogAuthoredEntity(authoredEntity, entry, userId);
            }
        }
    }

    private void LogAuthoredEntity(AuthoredEntity entity, EntityEntry entry, int userId)
    {
        var state = entry.State;

        if(state != EntityState.Added && state != EntityState.Modified)
        {
            return;
        }

        var utcNow = DateTime.UtcNow;

        entity.LastUpdatedUserId = userId;
        entity.LastUpdatedDateTime = utcNow;

        if(state == EntityState.Added)
        {
            entity.CreatedUserId = userId;
            entity.CreatedDateTime = utcNow;
        }
        else
        {
            entry.Property(nameof(AuthoredEntity.LastUpdatedUserId)).IsModified = true;
            entry.Property(nameof(AuthoredEntity.LastUpdatedDateTime)).IsModified = true;
        }
    }

    private static void SetupConverters(ModelBuilder modelBuilder)
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
