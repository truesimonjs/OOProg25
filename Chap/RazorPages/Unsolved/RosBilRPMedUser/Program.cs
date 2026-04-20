using Microsoft.AspNetCore.Authentication.Cookies;
using RosBilRP.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Biler");
    options.Conventions.AuthorizeFolder("/Kunder");
    options.Conventions.AuthorizeFolder("/Lejer");

}
    );

builder.Services.AddSingleton<IBilRepository, BilRepository>();
builder.Services.AddSingleton<IKundeRepository, KundeRepository>();
builder.Services.AddSingleton<ILejeRepository, LejeRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
    {
        options.LoginPath = "/UserLogin/Login";
        options.AccessDeniedPath = "/UserLogin/AccessDenied";
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); // Aktivér cookie-baseret Authentication
app.UseAuthorization();

app.MapRazorPages();

app.Run();
