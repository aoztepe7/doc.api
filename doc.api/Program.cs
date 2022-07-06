using doc.api.Context;
using doc.api.Handler;
using doc.api.Interface;
using doc.api.Repository;
using doc.api.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<DbContext>();
builder.Services.AddSingleton<TokenService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<LoginHandler>();
builder.Services.AddScoped<UserCreateHandler>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
}

app.UseAuthorization();

app.MapControllers();

app.Run();
