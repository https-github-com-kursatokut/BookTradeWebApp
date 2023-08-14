using BookTradeWebApp.DataContexts;
using BookTradeWebApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserDbContext>(opt => opt.UseInMemoryDatabase("User"));
builder.Services.AddDbContext<TradeOfferDbContext>(opt => opt.UseInMemoryDatabase("TradeOffer"));
builder.Services.AddDbContext<ReviewDbContext>(opt => opt.UseInMemoryDatabase("Review"));
builder.Services.AddDbContext<BookDbContext>(opt => opt.UseInMemoryDatabase("Book"));

var app = builder.Build();

app.MapPost("/SaveUser", async (User user, UserDbContext db) =>
{
    db.Users.Add(user);
    await db.SaveChangesAsync();

    return Results.Created($"/save/{user.UserId}", user);
});

app.MapGet("/GetAllUsers", async (UserDbContext db) =>
    await db.Users.ToListAsync());

app.MapPut("/UpdateUsers/{id}", async (int id, User userinput, UserDbContext db) =>
{
    var user = await db.Users.FindAsync(id);

    if (user is null) return Results.NotFound();

    user.Username = userinput.Username;
    user.FirstName = userinput.FirstName;
    user.LastName = userinput.LastName;
    user.Email = userinput.Email;
    user.PasswordHash= userinput.PasswordHash;
 

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapPost("/SaveBook", async (Book book, BookDbContext db) =>
{
    db.Books.Add(book);
    await db.SaveChangesAsync();

    return Results.Created($"/save/{book.BookId}", book);
});

app.MapGet("/GetAllBooks", async (BookDbContext db) =>
     await db.Books.ToListAsync());

app.MapGet("/GetBookById/{bookId}", async (int bookId, BookDbContext db) =>
{
    var book = await db.Books.FindAsync(bookId);

    if (book == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(book);
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
