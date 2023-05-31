using Antelcat.DependencyInjection.Autowired.ServerTest;
using Antelcat.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDependency,Dependency>();
builder.Services.AddSingleton<ITest, TestClass>();
// Add services to the container.
builder.Services.AddControllers().AddControllersAsServices().UseAutowiredControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseAutowiredServiceProviderFactory();

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