using BookTradeWebApp.DataContexts;
using BookTradeWebApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserDbContext>(opt => opt.UseInMemoryDatabase("User"));

var app = builder.Build();

app.MapPost("/SaveUser", async (User user, UserDbContext db) =>
{
    db.Users.Add(user);
    await db.SaveChangesAsync();

    return Results.Created($"/save/{user.Id}", user);
});

app.MapGet("/GetAllUsers", async (UserDbContext db) =>
    await db.Users.ToListAsync());

app.MapPut("/UpdateUsers/{id}", async (int id, User studentinput, UserDbContext db) =>
{
    var user = await db.Users.FindAsync(id);

    if (user is null) return Results.NotFound();

    user.Username = studentinput.Username;
    user.FirstName = studentinput.FirstName;
    user.LastName = studentinput.LastName;
    user.Email = studentinput.Email;
    user.PasswordHash= studentinput.PasswordHash;
 

    await db.SaveChangesAsync();

    return Results.NoContent();
});
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
