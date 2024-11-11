using Microsoft.EntityFrameworkCore;
using players_catalog.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dodanie polaczenia z baza
builder.Services.AddDbContext<DataContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnetcion")));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
