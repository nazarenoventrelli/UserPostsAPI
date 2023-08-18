using Microsoft.Extensions.Configuration;
using UserPostsAPI.C;
using UserPostsAPI.Cache;
using UserPostsAPI.Clients;
using UserPostsAPI.Configuration;
using UserPostsAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IHttpClient, UserPostsAPI.Clients.HttpClient>();
builder.Services.AddSingleton<ICacheService, CacheService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
