using MultiUserBlogEngine.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();

var app = builder.Build();

app.ConfigureApplication();

app.Run();