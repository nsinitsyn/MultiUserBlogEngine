using MultiUserBlogEngine.Infrastructure.DbAccess;

namespace MultiUserBlogEngine.WebApi.Background
{
    public class TestHostedService : BackgroundService
    {
        IServiceScopeFactory _scopeFactory;

        public TestHostedService(IServiceScopeFactory scopeFactory) 
        {
            _scopeFactory = scopeFactory;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _scopeFactory.CreateScope();

            using var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // ...

            return Task.CompletedTask;
        }
    }
}
