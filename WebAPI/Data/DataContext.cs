using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profile> Profiles { get; set; }    
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<ComboDetail> ComboDetails { get; set; }
        public DbSet<Order> Orders { get; set; } 
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .HasOne(p => p.Account)
                .WithOne(a => a.Profile)
                .HasForeignKey<Account>(a => a.ProfileId)
                .IsRequired();
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Order)
                .WithOne(o => o.Account)
                .HasForeignKey(o => o.AccountId)
                .IsRequired();
            modelBuilder.Entity<Food>()
                .HasOne(f => f.FoodCategory)
                .WithMany(fc => fc.Foods)
                .HasForeignKey(f => f.FoodCategoryId)
                .IsRequired();
            modelBuilder.Entity<ComboDetail>()
                .HasOne(cd => cd.Combo)
                .WithMany(c => c.ComboDetails)
                .HasForeignKey(cd => cd.ComboId)
                .IsRequired();
            modelBuilder.Entity<ComboDetail>()
                .HasOne(cd => cd.Food)
                .WithMany(f => f.ComboDetails)
                .HasForeignKey(cd => cd.FoodId)
                .IsRequired();
            modelBuilder.Entity<ComboDetail>()
            base.OnModelCreating(modelBuilder);
        }
    }
}
