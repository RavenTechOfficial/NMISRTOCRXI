using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using thesis.Areas.Identity.Data;
using thesis.Models;

namespace thesis.Data;

public class thesisContext : IdentityDbContext<AccountDetails>
{
    public thesisContext(DbContextOptions<thesisContext> options)
        : base(options)
    {
    }
    public DbSet<ConductOfInspection> ConductOfInspections { get; set; }
    public DbSet<DisapprovedApplication> DisapprovedApplications { get; set; }
    public DbSet<MeatDealers> MeatDealers { get; set; }
    public DbSet<MeatEstablishment> MeatEstablishment { get; set; }
    public DbSet<MeatInspectionReport> MeatInspectionReports { get; set; }
    public DbSet<MTVApplication> MTVApplications { get; set; }
    public DbSet<MTVApplicationResult> MTVApplicationResults { get; set; }
    public DbSet<MTVDetails> MTVDetails { get; set; }
    public DbSet<MTVInspection> MTVInspection { get; set; }
    public DbSet<PassedForSlaughter> PassedForSlaughters { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Postmortem> Postmortems { get; set; }
    public DbSet<Receiving> Receivings{ get; set; }
    public DbSet<ReceivingReport> ReceivingReports { get; set; }
    public DbSet<SummaryAndDistributionOfMIC> SummaryAndDistributionOfMICs { get; set; }
    public DbSet<totalNoFitForHumanConsumptions> totalNoFitForHumanConsumptions { get; set; }
    public DbSet<Driver> Drivers { get; set; }
	public DbSet<Helper> Helpers { get; set; }
	public DbSet<MTVquiz> MTVquizzes { get; set; }
	public DbSet<checklist> checklists { get; set; }
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
	public DbSet<thesis.Models.PostArticle>? PostArticle { get; set; }
}
