using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using thesis.Areas.Identity.Data;
using thesis.Core.IRepositories;
using thesis.Data;
using thesis.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("thesisContextConnection") ?? throw new InvalidOperationException("Connection string 'thesisContextConnection' not found.");

builder.Services.AddDbContext<thesisContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AccountDetails>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<thesisContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();


#region Authorization

AddAuthorizationPolicies();
AddScoped();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


void AddScoped()
{
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IReceivingReportRepository, ReceivingReportRepository>();
    builder.Services.AddScoped<IMeatInspectionReportRepository, MeatInspectionReportRepository>();
}

void AddAuthorizationPolicies()
{
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("RequireSuperAdmin", policy => policy.RequireRole("SuperAdministrator"));
        options.AddPolicy("RequireInspectorAdmin", policy => policy.RequireRole("InspectorAdministrator"));
        options.AddPolicy("RequireMTVAdmin", policy => policy.RequireRole("MTVAdministrator"));
    });
}