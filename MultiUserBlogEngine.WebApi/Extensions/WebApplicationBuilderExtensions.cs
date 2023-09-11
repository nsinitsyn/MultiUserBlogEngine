using Microsoft.EntityFrameworkCore;
using MultiUserBlogEngine.Infrastructure.DbAccess;

namespace MultiUserBlogEngine.WebApi.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        var connectionString = builder.Configuration.GetConnectionString("PostgreConnection");
        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
    }
}
