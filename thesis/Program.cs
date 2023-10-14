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

builder.Services.AddDefaultIdentity<AccountDetails>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<thesisContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();


#region Authorization

AddAuthorizationPolicies();
AddScoped();

#endregion

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddatas")
{
    Seed3.SeedDatas(app);
}

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
    builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
    builder.Services.AddScoped<IAnalyticsRepository, AnalyticsRepository>();
    builder.Services.AddScoped<IUsersManangementRepository, UsersManagementRepository>();
    builder.Services.AddScoped<IGeolocationRepository, GeolocationRepository>();
    builder.Services.AddScoped<IResultsRepository, ResultsRepository>();
    builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
    builder.Services.AddScoped<IChroplethMapRepository, ChroplethMapRepository>();
}

void AddAuthorizationPolicies()
{

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("RequireAllAdmins", policy =>
        {
            policy.RequireRole("SuperAdministrator");
            policy.RequireRole("InspectorAdministrator");
            policy.RequireRole("MTVAdministrator");
        });
        options.AddPolicy("RequireSuperAdmin", policy => policy.RequireRole("SuperAdministrator"));
        options.AddPolicy("RequireInspectorAdmin", policy => policy.RequireRole("InspectorAdministrator"));
        options.AddPolicy("RequireMTVAdmin", policy => policy.RequireRole("MTVAdministrator"));
        options.AddPolicy("RequireMeatEstablishmentRep", policy => policy.RequireRole("MeatEstablishmentRepresentative"));
        options.AddPolicy("RequireMeatInspector", policy => policy.RequireRole("MeatInspector"));
        options.AddPolicy("RequireMtvInspector", policy => policy.RequireRole("MtvInspector"));
        options.AddPolicy("RequireMtvUsers", policy => policy.RequireRole("MtvUsers"));
    });
}