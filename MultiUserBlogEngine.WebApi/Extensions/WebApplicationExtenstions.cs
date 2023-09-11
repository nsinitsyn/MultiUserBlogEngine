using Microsoft.EntityFrameworkCore;
using MultiUserBlogEngine.Infrastructure.DbAccess;
using MultiUserBlogEngine.Infrastructure.Extenstions;

namespace MultiUserBlogEngine.WebApi.Extensions
{
    public static class WebApplicationExtenstions
    {
        public static void ConfigureApplication(this WebApplication app)
        {
            app.UseAuthorization();

            app.MapControllers();

            app.MigrateDatabase();
        }

        public static void MigrateDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            using var db = services.GetRequiredService<AppDbContext>();

            try
            {
                db.Database.Migrate();
                db.SeedDatabase();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogCritical(ex, "An error occurred while migrating the database.");

                throw;
            }
        }
    }
}
