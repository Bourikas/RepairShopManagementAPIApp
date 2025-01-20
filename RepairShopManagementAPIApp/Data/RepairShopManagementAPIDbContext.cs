using Microsoft.EntityFrameworkCore;

namespace RepairShopManagementAPIApp.Data
{
    public class RepairShopManagementAPIDbContext : DbContext
    {
        public RepairShopManagementAPIDbContext()
        {
        }

        public RepairShopManagementAPIDbContext(DbContextOptions<RepairShopManagementAPIDbContext> options) : base(options)
        {
        }
    

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<ServiceEntry> ServiceEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Firstname).HasMaxLength(50).HasColumnName("FIRSTNAME");
                entity.Property(e => e.Lastname).HasMaxLength(50).HasColumnName("LASTNAME");
                entity.Property(e => e.Email).HasMaxLength(50).HasColumnName("EMAIL");
                entity.Property(e => e.Role).HasConversion<string>().HasMaxLength(50).IsRequired();
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMERS");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Firstname).HasMaxLength(50).HasColumnName("FIRSTNAME");
                entity.Property(e => e.Lastname).HasMaxLength(50).HasColumnName("LASTNAME");
                entity.Property(e => e.PrimaryPhone).HasMaxLength(20).HasColumnName("PRIMARY_PHONE");
                entity.Property(e => e.SecondaryPhone).HasMaxLength(20).HasColumnName("SECONDARY_PHONE");
                entity.Property(e => e.Email).HasMaxLength(50).HasColumnName("EMAIL");
                entity.Property(e => e.Address).HasMaxLength(50).HasColumnName("ADDRESS");
                entity.Property(e => e.Notes).HasColumnName("NOTES");
            });
            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("DEVICES");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.SerialNumber).HasMaxLength(50).HasColumnName("SERIAL_NUMBER");
                entity.Property(e => e.Maker).HasMaxLength(50).HasColumnName("MAKER");
                entity.Property(e => e.Model).HasMaxLength(50).HasColumnName("MODEL");
                entity.Property(e => e.DeviceType).HasColumnName("DEVICE_TYPE").HasConversion<String>().HasMaxLength(50).IsRequired();
                entity.Property(e => e.DateOfPurchase).HasColumnName("DATE_OF_PURCHASE").HasConversion<DateOnly>();
                entity.HasOne(d => d.Customer).WithMany(p => p.Devices).HasForeignKey(d => d.CustomerID).HasConstraintName("FK_CUSTOMERS_DEVICES");
            });
            modelBuilder.Entity<ServiceEntry>(entity =>
            {
                entity.ToTable("SERVICE_ENTRY");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.DateTimeOfEntry).HasColumnName("DATE_TIME_OF_ENTRY").HasConversion<DateTime>().IsRequired();
                entity.Property(e => e.Problem).HasColumnName("PROBLEM");
                entity.Property(e => e.Damages).HasColumnName("DAMAGES");
                entity.Property(e => e.EstimatedPrice).HasColumnName("ESTIMATED_PRICE").HasConversion<double>();
                entity.Property(e => e.PartsUsed).HasColumnName("PARTS_USED");
                entity.Property(e => e.DateOfServiceStart).HasColumnName("DATE_OF_SERVICE_START").HasConversion<DateTime>();
                entity.Property(e => e.DateOfServiceEnd).HasColumnName("DATE_OF_SERVICE_END").HasConversion<DateTime>();
                entity.Property(e => e.FinalPrice).HasColumnName("FINAL_PRICE").HasConversion<double>();
                entity.Property(e => e.Deposit).HasColumnName("DEPOSIT").HasConversion<double>();
                entity.Property(e => e.DateOfReturn).HasColumnName("DATE_OF_RETURN").HasConversion<DateTime>();
                entity.Property(e => e.Notes).HasColumnName("NOTES");
                entity.Property(e => e.IsReturned).HasColumnName("IS_RETURNED").HasConversion<bool>();
                entity.HasOne(c => c.Device).WithMany(t => t.DeviceEntries).HasForeignKey(e => e.DeviceId).HasConstraintName("FK_DEVICES_DEVICE_ENTRIES");
            });
        }
    }
}
