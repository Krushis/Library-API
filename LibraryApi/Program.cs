using LibraryApi.Data;
using Microsoft.EntityFrameworkCore;

// The main class of the program

// For now, if when wanting to reserve the book you click on a type that the book is not in, it just doesnt allow you
// to make the reservation, so for the Hitchhiker's guide, you won't be able to reserve the audiobook version

// Also, you have to reload the web page for the reservations to show, and when you reserve something then a modal will popup
// only then will it be confirmed that you have reserved sth, then reload the website

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseInMemoryDatabase("LibraryDb"));

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowReactApp");

app.UseRouting();

app.MapControllers();

app.UseStaticFiles(); // this is for images

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

app.Run();
