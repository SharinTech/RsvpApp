using Microsoft.EntityFrameworkCore;
using RsvpEventApp.Models; // ✅ Make sure this matches your namespace

var builder = WebApplication.CreateBuilder(args);

// ✅ 1. Register MVC
builder.Services.AddControllersWithViews();

// ✅ 2. Register Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// ✅ 3. Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ✅ 4. Set Default Route to our RSVP form
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Rsvp}/{action=Form}/{id?}");

app.Run();

