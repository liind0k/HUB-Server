using ICTInfoHub.Model.Model;
using Microsoft.EntityFrameworkCore;
using ICTInfoHub.Services.AdminServices;
using ICTInfoHub.Services.NewsServices;
using ICTInfoHub.Services.CampusServices;
using ICTInfoHub.Services.ServiceServices;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AdminDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IAdminServices, AdminServices>();
builder.Services.AddScoped<INewsServices, NewsServices>();
builder.Services.AddScoped<IServiceServices, ServiceServices>();
builder.Services.AddScoped<ICampusServices, CampusServices>();

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
