using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TccDB;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Configurar o DbContext e a string de conexão para SQLite
builder.Services.AddDbContext<TCCDbContext>(options =>{
    options.UseSqlite("Data Source=Tcc.db");
});
builder.Services.AddScoped<TccServices>();

// Adicionar outros serviços, se necessário

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Adicionar o DbContext ao escopo para injeção de dependência
app.Services.CreateScope().ServiceProvider.GetRequiredService<TCCDbContext>().Database.Migrate();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
