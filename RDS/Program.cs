using Microsoft.EntityFrameworkCore;
using RDS.Libs.Data;
using RDS.Libs.Implements;
using RDS.Libs.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IGetPerson, GetPerson>();
builder.Services.AddSingleton<IPutPerson, PutPerson>();
builder.Services.AddSingleton<IDeletePerson, DeletePerson>();

builder.Services.AddDbContext<RDSContext>(
options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("NorthwindDB"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
});

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

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
