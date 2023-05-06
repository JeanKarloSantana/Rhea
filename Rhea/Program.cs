
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Rhea.DAL.SQL;
using Rhea.Domain.ReservationManager;
using Rhea.Domain.UserManager;
using Rhea.Interfaces.Domain;
using Rhea.Interfaces.Generic;
using Rhea.Interfaces.Service;
using Rhea.Persistance.Generic;
using Rhea.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RheaDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("RheaDbContext")));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IEventManager, EventManager>();
builder.Services.AddTransient<IUserManager, UserManager>();
builder.Services.AddTransient<IReservationValidationService, ReservationValidationService>();

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
