using Microsoft.EntityFrameworkCore;
using SwapPortal_API.DAL.Context;
using SwapPortal_API.DAL.Repository.Implementation;
using SwapPortal_API.DAL.Repository.Interface;
using SwapPortal_API.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDbConnection"));
});
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IJobListingRepo, JobListingRepo>();
builder.Services.AddScoped<IApplicationRepo, ApplicationRepo>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddControllers();
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

app.MapControllers();

app.Run();
