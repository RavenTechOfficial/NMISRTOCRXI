using DomainLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfastructureLayer.Data;

public class AppDbContext : IdentityDbContext<AccountDetails>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<AccountDetails> AccountDetails { get; set; }
    public DbSet<Antemortem> Antemortems { get; set; }
    public DbSet<DisapprovedApplication> DisapprovedApplications { get; set; }
    public DbSet<MeatDealer> MeatDealers { get; set; }
    public DbSet<MeatEstablishment> MeatEstablishments { get; set; }
    public DbSet<MeatInspectionReport> MeatInspectionReports { get; set; }
    public DbSet<MTVApplication> MTVApplications { get; set; }
    public DbSet<MTVApplicationResult> MTVApplicationResults { get; set; }
    public DbSet<MTVDetails> MTVDetails { get; set; }
    public DbSet<MTVInspection> MTVInspections { get; set; }
    public DbSet<PassedForSlaughter> PassedForSlaughters { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Postmortem> Postmortems { get; set; }
    public DbSet<Receiving> Receivings{ get; set; }
    public DbSet<ReceivingReport> ReceivingReports { get; set; }
    public DbSet<SummaryAndDistributionOfMIC> SummaryAndDistributionOfMICs { get; set; }
    public DbSet<TotalNoFitForHumanConsumption> TotalNoFitForHumanConsumptions { get; set; }
    public DbSet<Driver> Drivers { get; set; }
	public DbSet<Helper> Helpers { get; set; }
	public DbSet<MTVQuiz> MTVQuizzes { get; set; }
	public DbSet<CheckList> CheckLists { get; set; }
	public DbSet<VehicleInfo> VehicleInfos { get; set; }
	public DbSet<QrCode> QrCodes { get; set; }
	public DbSet<Result> Results { get; set; }
	public DbSet<PostArticle> PostArticles { get; set; }
	public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<LogTransaction> LogTransactions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
