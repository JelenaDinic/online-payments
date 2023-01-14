using Microsoft.EntityFrameworkCore;
using PaymentBackend.Models;

namespace PaymentBackend.Settings
{
    public class PaymentDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, Email = "jelena@email.com", Password = "password", Name= "Jelena", Budget=500, Lastname="Dinic", PhoneNumber=97986}

            );
            modelBuilder.Entity<Currency>().HasData(
                new Currency() { Id = CurrencyName.EUR.ToString(), Rate = 117.36 },
                new Currency() { Id = CurrencyName.USD.ToString(), Rate = 109.26 },
                new Currency() { Id = CurrencyName.CHF.ToString(), Rate = 118.57 },
                new Currency() { Id = CurrencyName.GBP.ToString(), Rate = 132.96 },
                new Currency() { Id = CurrencyName.AUD.ToString(), Rate = 75.51 },
                new Currency() { Id = CurrencyName.BAM.ToString(), Rate = 60.01 },
                new Currency() { Id = CurrencyName.BGN.ToString(), Rate = 60.01 },
                new Currency() { Id = CurrencyName.CZK.ToString(), Rate = 4.89 },
                new Currency() { Id = CurrencyName.TRY.ToString(), Rate = 5.82 },
                new Currency() { Id = CurrencyName.CNY.ToString(), Rate = 16.14 },
                new Currency() { Id = CurrencyName.CAD.ToString(), Rate = 81.64 }
            );
            

        }
    }
}
