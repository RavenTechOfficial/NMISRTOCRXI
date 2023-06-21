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
    public DbSet<AntemortemInspection> antemortemInspections { get; set; }
    public DbSet<ConductOfInspection> conductOfInspections { get; set; }
    public DbSet<Inspector> inspectors { get; set; }
    public DbSet<MeatDealer> meatDealers { get; set; }
    public DbSet<MeatEstablishment> meatEstablishments { get; set; }
    public DbSet<MeatEstablishmentRepresentative> meatEstablishmentRepresentatives { get; set; }
    public DbSet<MeatInspectionCertUtilization> meatInspectionCertUtilizations { get; set; }
    public DbSet<MeatInspectionReport> meatInspectionReports { get; set; }
    public DbSet<MeatInspectionSummary> meatInspectionSummaries { get; set; }
    public DbSet<PassedForSlaughter> passedForSlaughters { get; set; }
    //public DbSet<PostmortemInspection> postmortemInspections { get; set; }
    public DbSet<PostmortemReport> postmortemReports { get; set; }
    public DbSet<Receiving> receivings { get; set; }
    public DbSet<ReceivingReport> receivingReports { get; set; }
    public DbSet<SecondaryMeatEstablishmentReport> secondaryMeatEstablishmentReports { get; set; }
    public DbSet<ServiceTransactionDescription> serviceTransactionDescription { get; set; }
    public DbSet<ServiceTransactionDescriptionReport> serviceTransactionDescriptionReports { get; set; }
    public DbSet<SummaryAndDistributionOfMIC> summaryAndDistributionOfMICs { get; set; }
    public DbSet<TotalNoFitForHumanConsumption> totalNoFitForHumanConsumptions { get; set; }
    public DbSet<ReceivingConductOfInspection> receivingConductOfInspections { get; set; }
    public DbSet<ReceivingPassedForSlaughter> receivingPassedForSlaughters { get; set; }
    public DbSet<ReceivingPostmortemReport> receivingPostmortemReports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ReceivingConductOfInspection>()
                .HasKey(uc => new { uc.ReceivingId, uc.ConductOfInspectionId });
        modelBuilder.Entity<ReceivingConductOfInspection>()
            .HasOne(u => u.Receiving)
            .WithMany(uc => uc.receivingConductOfInspections)
            .HasForeignKey(u => u.ReceivingId);
        modelBuilder.Entity<ReceivingConductOfInspection>()
            .HasOne(c => c.ConductOfInspection)
            .WithMany(uc => uc.receivingConductOfInspections)
            .HasForeignKey(c => c.ConductOfInspectionId);

        modelBuilder.Entity<ReceivingPassedForSlaughter>()
                .HasKey(uc => new { uc.ReceivingId, uc.PassedForSlaughterId });
        modelBuilder.Entity<ReceivingPassedForSlaughter>()
            .HasOne(u => u.Receiving)
            .WithMany(uc => uc.receivingPassedForSlaughters)
            .HasForeignKey(u => u.ReceivingId);
        modelBuilder.Entity<ReceivingPassedForSlaughter>()
            .HasOne(c => c.PassedForSlaughter)
            .WithMany(uc => uc.receivingPassedForSlaughters)
            .HasForeignKey(c => c.PassedForSlaughterId);

        modelBuilder.Entity<ReceivingPostmortemReport>()
                .HasKey(uc => new { uc.ReceivingId, uc.PostmortemReportId });
        modelBuilder.Entity<ReceivingPostmortemReport>()
            .HasOne(u => u.Receiving)
            .WithMany(uc => uc.receivingPostmortemReports)
            .HasForeignKey(u => u.ReceivingId);
        modelBuilder.Entity<ReceivingPostmortemReport>()
            .HasOne(c => c.PostmortemReport)
            .WithMany(uc => uc.receivingPostmortemReports)
            .HasForeignKey(c => c.PostmortemReportId);

    }
}
