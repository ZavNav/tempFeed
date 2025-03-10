using System.Text;
using FeedbackPages.Components;
using FeedbackPages.Data;
using FeedbackPages.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddDbContext<DataContext>(optionsAction: options =>
{
    options.UseSqlite($"Data Source={builder.Environment.WebRootPath}/data.db");
});
builder.Services.AddScoped<IStatsService, StatsService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/admin/login";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
        options.AccessDeniedPath = "/access-denied";
    });
builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(FeedbackPages.Client._Imports).Assembly);

app.Run();

public class AuthOptions
{
    public const string ISSUER = "RemServer";
    public const string AUDIENCE = "AdminClient";
    const string KEY = "trytofindthisoutyoulittlecocksucker";
    public static SymmetricSecurityKey GetSymmetricSecurityKey() => 
        new (Encoding.UTF8.GetBytes(KEY));
}