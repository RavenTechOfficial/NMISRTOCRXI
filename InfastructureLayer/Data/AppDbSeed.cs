using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfastructureLayer.Data
{
    public class AppDbSeed
    {
        //Role Ids
        private static string SuperAdminRoleId = Guid.NewGuid().ToString();
        private static string InspectorAdminRoleId = Guid.NewGuid().ToString();
        private static string MTVAdminRoleId = Guid.NewGuid().ToString();
        private static string UserRoleId = Guid.NewGuid().ToString();
        private static string MeatEstRepRoleId = Guid.NewGuid().ToString();
        private static string MeatInspectorRoleId = Guid.NewGuid().ToString();
        private static string MTVInspectorRoleId = Guid.NewGuid().ToString();
        private static string MTVUserRoleId = Guid.NewGuid().ToString();

        //User Ids
        private static string SuperAdminId = Guid.NewGuid().ToString();
        private static string InspectorAdminId = Guid.NewGuid().ToString();
        private static string MTVAdminId = Guid.NewGuid().ToString();
        private static string UserId = Guid.NewGuid().ToString();
        private static string MeatEstRepId = Guid.NewGuid().ToString();
        private static string MeatInspectorId = Guid.NewGuid().ToString();
        private static string MTVInspectorId = Guid.NewGuid().ToString();
        private static string MTVUserId = Guid.NewGuid().ToString();


        public static void SeedRole(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = SuperAdminRoleId, Name = "SuperAdministrator", NormalizedName = "SUPERADMIN", ConcurrencyStamp = null },
                new IdentityRole { Id = InspectorAdminRoleId, Name = "InspectorAdministrator", NormalizedName = "INSPECTORADMIN", ConcurrencyStamp = null },
                new IdentityRole { Id = MTVAdminRoleId, Name = "MTVAdministrator", NormalizedName = "MTVADMIN", ConcurrencyStamp = null },
                new IdentityRole { Id = UserRoleId, Name = "User", NormalizedName = "USER", ConcurrencyStamp = null },
                new IdentityRole { Id = MeatEstRepRoleId, Name = "MeatEstablishmentRepresentative", NormalizedName = "MEATESTABLISHMENTREPRESENTATIVE", ConcurrencyStamp = null },
                new IdentityRole { Id = MeatInspectorRoleId, Name = "MeatInspector", NormalizedName = "MEATINSPECTOR", ConcurrencyStamp = null },
                new IdentityRole { Id = MTVInspectorRoleId, Name = "MtvInspector", NormalizedName = "MTVINSPECTOR", ConcurrencyStamp = null },
                new IdentityRole { Id = MTVUserRoleId, Name = "MtvUsers", NormalizedName = "MTVUSERS", ConcurrencyStamp = null }
            );
        }
        public static void SeedUserRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = SuperAdminId, RoleId = SuperAdminRoleId }, 
                new IdentityUserRole<string> { UserId = InspectorAdminId, RoleId = InspectorAdminRoleId },
                new IdentityUserRole<string> { UserId = MTVAdminId, RoleId = MTVAdminRoleId },
                new IdentityUserRole<string> { UserId = UserId, RoleId = UserRoleId },
                new IdentityUserRole<string> { UserId = MeatEstRepId, RoleId = MeatEstRepRoleId },
                new IdentityUserRole<string> { UserId = MeatInspectorId, RoleId = MeatInspectorRoleId },
                new IdentityUserRole<string> { UserId = MTVInspectorId, RoleId = MTVInspectorRoleId },
                new IdentityUserRole<string> { UserId = MTVUserId, RoleId = MTVUserRoleId }
            );
        }

        public static void SeedUsers(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<AccountDetails>();


            var superadmin = new AccountDetails
            {
                Id = SuperAdminId,
                UserName = "superadmin",
                NormalizedUserName = "SUPERADMIN",
                Email = "super@admin.com",
                NormalizedEmail = "SUPER@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = string.Empty
            };
            superadmin.PasswordHash = hasher.HashPassword(superadmin, "pass@123");
            modelBuilder.Entity<AccountDetails>().HasData(superadmin);

            modelBuilder.Entity<AccountDetails>().HasData(
                new AccountDetails
                {
                    Id = InspectorAdminId,
                    UserName = "inspectoradmin",
                    NormalizedUserName = "INSPECTORADMIN",
                    Email = "mtv@admin.com",
                    NormalizedEmail = "INSPECTOR@ADMIN.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "pass@123"),
                    SecurityStamp = string.Empty
                },
                new AccountDetails
                {
                    Id = MTVAdminId,
                    UserName = "mtvadmin",
                    NormalizedUserName = "MTVRADMIN",
                    Email = "mtv@admin.com",
                    NormalizedEmail = "MTV@ADMIN.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "pass@123"),
                    SecurityStamp = string.Empty
                },
                new AccountDetails
                {
                    Id = UserId,
                    UserName = "user",
                    NormalizedUserName = "USER",
                    Email = "user@user.com",
                    NormalizedEmail = "USER@USER.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "pass@123"),
                    SecurityStamp = string.Empty
                },
                new AccountDetails
                {
                    Id = MeatEstRepId,
                    UserName = "meatrep",
                    NormalizedUserName = "MEATREP",
                    Email = "meat@rep.com",
                    NormalizedEmail = "MEAT@REP.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "pass@123"),
                    SecurityStamp = string.Empty
                },
                new AccountDetails
                {
                    Id = MeatInspectorId,
                    UserName = "meatinspector",
                    NormalizedUserName = "MEATINSPECTOR",
                    Email = "meat@inspector.com",
                    NormalizedEmail = "MEAT@INSPECTOR.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "pass@123"),
                    SecurityStamp = string.Empty
                },
                new AccountDetails
                {
                    Id = MTVInspectorId,
                    UserName = "mtvinspector",
                    NormalizedUserName = "MTVINSPECTOR",
                    Email = "mtv@inspector.com",
                    NormalizedEmail = "MTV@INSPECTOR.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "pass@123"),
                    SecurityStamp = string.Empty
                },
                new AccountDetails
                {
                    Id = MTVUserId,
                    UserName = "mtvuser",
                    NormalizedUserName = "MTVUSER",
                    Email = "mtv@user.com",
                    NormalizedEmail = "MTV@USER.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "pass@123"),
                    SecurityStamp = string.Empty
                }
            );
        }
    }
}
