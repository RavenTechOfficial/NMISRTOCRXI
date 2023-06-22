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
    public DbSet<MeatEstablishmentInspector> meatEstablishmentInspectors { get; set; }
    public DbSet<MeatEstablishmentMeatDealer> meatEstablishmentMeatDealers { get; set; }
    public DbSet<ReceivingReportMeatEstablishment> receivingReportMeatEstablishments { get; set; }
    public DbSet<ReceivingMeatEstablishment> receivingMeatEstablishments { get; set; }

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

        modelBuilder.Entity<MeatEstablishmentInspector>()
                .HasKey(uc => new { uc.MeatEstablishmentId, uc.InspectorId });
        modelBuilder.Entity<MeatEstablishmentInspector>()
            .HasOne(u => u.MeatEstablishment)
            .WithMany(uc => uc.meatEstablishmentInspectors)
            .HasForeignKey(u => u.MeatEstablishmentId);
        modelBuilder.Entity<MeatEstablishmentInspector>()
            .HasOne(c => c.Inspector)
            .WithMany(uc => uc.meatEstablishmentInspectors)
            .HasForeignKey(c => c.InspectorId);

        modelBuilder.Entity<MeatEstablishmentMeatDealer>()
                .HasKey(uc => new { uc.MeatEstablishmentId, uc.MeatDealerId });
        modelBuilder.Entity<MeatEstablishmentMeatDealer>()
            .HasOne(u => u.MeatEstablishment)
            .WithMany(uc => uc.meatEstablishmentMeatDealers)
            .HasForeignKey(u => u.MeatEstablishmentId);
        modelBuilder.Entity<MeatEstablishmentMeatDealer>()
            .HasOne(c => c.MeatDealer)
            .WithMany(uc => uc.meatEstablishmentMeatDealers)
            .HasForeignKey(c => c.MeatDealerId);

        modelBuilder.Entity<ReceivingReportMeatEstablishment>()
                .HasKey(uc => new { uc.MeatEstablishmentId, uc.ReceivingReportId });
        modelBuilder.Entity<ReceivingReportMeatEstablishment>()
            .HasOne(u => u.MeatEstablishment)
            .WithMany(uc => uc.receivingReportMeatEstablishments)
            .HasForeignKey(u => u.MeatEstablishmentId);
        modelBuilder.Entity<ReceivingReportMeatEstablishment>()
            .HasOne(c => c.ReceivingReport)
            .WithMany(uc => uc.receivingReportMeatEstablishments)
            .HasForeignKey(c => c.ReceivingReportId);

        modelBuilder.Entity<ReceivingMeatEstablishment>()
                .HasKey(uc => new { uc.MeatEstablishmentId, uc.ReceivingId });
        modelBuilder.Entity<ReceivingMeatEstablishment>()
            .HasOne(u => u.MeatEstablishment)
            .WithMany(uc => uc.receivingMeatEstablishments)
            .HasForeignKey(u => u.MeatEstablishmentId);
        modelBuilder.Entity<ReceivingMeatEstablishment>()
            .HasOne(c => c.Receiving)
            .WithMany(uc => uc.receivingMeatEstablishments)
            .HasForeignKey(c => c.ReceivingId);
    }
}
