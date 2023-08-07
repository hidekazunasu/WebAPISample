using Microsoft.EntityFrameworkCore;
using Sample.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<SampleDbCotext>(options =>
{
    var path = builder.Configuration.GetConnectionString("MyDbConnection");
    DbContextOptionsBuilder dbContextOptionsBuilder = options.UseSqlite(path);
    SampleDbCotext.ConfigPath = path;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseEndpoints(x => x.MapControllers());
app.UseHttpsRedirection();
app.Run();
