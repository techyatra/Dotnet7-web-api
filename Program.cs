using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using TechYatraAPI.Context;
using TechYatraAPI.CustomMiddleware;
using TechYatraAPI.Interface;
using TechYatraAPI.Service;
using TechYatraAPI.Unit_Of_Work;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ToDoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});
builder.Services.AddControllers();
builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IToDoRepository, ToDoRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddSingleton<SieveProcessor>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
//app.UseExceptionHandler("something went wrong");
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();

app.Run();

