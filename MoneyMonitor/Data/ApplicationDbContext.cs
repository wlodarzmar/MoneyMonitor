using MoneyMonitor.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace MoneyMonitor.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Wealth> Wealths { get; set; }
        public DbSet<Year> Years { get; internal set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Wealth>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);
            builder.Entity<Wealth>()
                .HasOne(x => x.Owner)
                .WithMany(x => x.Wealths)
                .HasForeignKey(x => x.OwnerId)
                .IsRequired();
            builder.Entity<Wealth>().HasMany(x => x.Years)
                .WithOne(x => x.Wealth)
                .HasForeignKey(x => x.WealthId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Year>()
                .HasKey(x => x.Id);
        }
    }
}
