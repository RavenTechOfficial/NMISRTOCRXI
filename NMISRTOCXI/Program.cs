using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Models;
using ServiceLayer.Services.IRepositories;
using InfastructureLayer.Data;
using InfastructureLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string from the configuration
var connectionString = builder.Configuration.GetConnectionString("thesisContextConnection") ?? throw new InvalidOperationException("Connection string 'thesisContextConnection' not found.");

// Configure Entity Framework Core with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(connectionString));

// Configure Identity with custom roles
builder.Services.AddIdentityCore<AccountDetail>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<AppDbContext>();

// Add services to the container	
builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();

// Configure authentication cookie settings
builder.Services.ConfigureApplicationCookie(options =>
{
	options.Cookie.HttpOnly = true;
	options.ExpireTimeSpan = TimeSpan.FromDays(1); // Set the expiration time for the cookie
	options.SlidingExpiration = true; // Renew the cookie as long as the user is active
});

// Configure session settings
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromHours(4);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

builder.Services.AddRazorPages();

// Add custom authorization policies
AddAuthorizationPolicies();

// Add scoped services
AddScopedServices();

var app = builder.Build();

// Configure the HTTP request pipeline for production
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



void AddScopedServices()
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
		options.AddPolicy("RequireSuperAdmin", policy => policy.RequireRole("SuperAdministrator"));
		options.AddPolicy("RequireInspectorAdmin", policy => policy.RequireRole("InspectorAdministrator"));
		options.AddPolicy("RequireMTVAdmin", policy => policy.RequireRole("MTVAdministrator"));
		options.AddPolicy("RequireMeatEstablishmentRep", policy => policy.RequireRole("MeatEstablishmentRepresentative"));
		options.AddPolicy("RequireMeatInspector", policy => policy.RequireRole("MeatInspector"));
		options.AddPolicy("RequireMtvInspector", policy => policy.RequireRole("MtvInspector"));
		options.AddPolicy("RequireMtvUsers", policy => policy.RequireRole("MtvUsers"));
	});
}