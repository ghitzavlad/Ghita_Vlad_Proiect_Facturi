using Ghita_Vlad_Proiect_Facturi.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<GhitaVladProiectFacturiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GhitaVladProiectFacturiContext")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Ghita_Vlad_Proiect_FacturiContext>();

var app = builder.Build();

// 👇 Auto-open browser when app starts
app.Lifetime.ApplicationStarted.Register(() =>
{
    var url = "http://localhost:5000";

    Process.Start(new ProcessStartInfo
    {
        FileName = url,
        UseShellExecute = true
    });
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();