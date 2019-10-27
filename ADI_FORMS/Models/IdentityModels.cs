using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ADI_FORMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<FixedAsset> FixedAssets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<DepreciationMTD> DepreciationMTDs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<AssetStatus> AssetStatus { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<AssetMaintenanceInterval> AssetMaintenanceIntervals { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<AssetsMaintenanceDetails> AssetsMaintenanceDetails { get; set; }
        public DbSet<AssetUsageLog> AssetUsagelogs { get; set; }
        public DbSet<AssetsValuationDetail> AssetsValuationDetails { get; set; }
        public DbSet<AssetsInsuranceDetail> AssetsInsuranceDetails { get; set; }
        public DbSet<AssetsInspectionDetails> AssetsInspectionDetail { get; set; }
        public DbSet<AssetsTransferData> AssetsTransferDatas { get; set; }
        public DbSet<AssetsDisposalData> AssetsDisposalDatas { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Months> Months { get; set; }
        public DbSet<EndOfMonth> EndOfMonth { get; set; }
        public DbSet<EndOfYear> EndOfYears { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<AssetsMaintenanceCode> AssetsMaintenanceCodes { get; set; }
        public DbSet<AssetsDetailReport> AssetsDetailReports { get; set; }
        public DbSet<SortBy> SortBies { get; set; }
        public DbSet<DeprInterval> DeprIntervals { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}