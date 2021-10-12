using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using PaySpace.Domain.Model;
using System;
using System.Threading.Tasks;

namespace PaySpace.Infra.Data
{
    public class PaySpaceDbContext : DbContext, IDbContext
    {
        private readonly IConfiguration configuration;

        public PaySpaceDbContext(DbContextOptions<DbContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }
        public PaySpaceDbContext(DbContextOptions options, IConfiguration configuration)
          : base(options)
        {
            this.configuration = configuration;
        }

        public PaySpaceDbContext(DbContextOptions<DbContext> options)
           : base(options)
        {
        }

        public PaySpaceDbContext(DbContextOptions options)
          : base(options)
        {
        }

        protected string CommandName { get; private set; }

        public DbSet<Calc> Calcs { get; set; }
        public DbSet<CalcMethod> CalcMethods { get; set; }
        public DbSet<ProgressiveTable> ProgressiveTables { get; set; }

        public IDbContextTransaction GetCurrentTransaction()
        {
            return Database.CurrentTransaction;
        }

        public bool HasActiveTransaction
        {
            get
            {
                return GetCurrentTransaction() != null;
            }
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(string commandName)
        {
            CommandName = commandName;
            if (GetCurrentTransaction() is null)
            {
                return await Database.BeginTransactionAsync();
            }

            return GetCurrentTransaction();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();
                Database.CommitTransaction();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                GetCurrentTransaction()?.Dispose();
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                GetCurrentTransaction()?.Rollback();
            }
            finally
            {
                GetCurrentTransaction()?.Dispose();
            }
        }
        public virtual async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalcMethod>().HasAlternateKey(u => u.PostalCode);

            modelBuilder.Entity<CalcMethod>().HasData(
                new CalcMethod(Guid.NewGuid(), "7441", "Progressive"),
                new CalcMethod(Guid.NewGuid(), "A100", "FlatValue"),
                new CalcMethod(Guid.NewGuid(), "7000", "FlatRate"),
                new CalcMethod(Guid.NewGuid(), "1000", "Progressive")
            );

            modelBuilder.Entity<ProgressiveTable>().HasData(
                new ProgressiveTable
                {
                    Id = Guid.NewGuid(),
                    From = 0M,
                    To = 8350M,
                    Rate = 0.1M
                },
                new ProgressiveTable
                {
                    Id = Guid.NewGuid(),
                    From = 8351M,
                    To = 33950M,
                    Rate = 0.15M
                },
                new ProgressiveTable
                {
                    Id = Guid.NewGuid(),
                    From = 33951M,
                    To = 82250M,
                    Rate = 0.25M
                },
                new ProgressiveTable
                {
                    Id = Guid.NewGuid(),
                    From = 82251M,
                    To = 171550M,
                    Rate = 0.28M
                },
                new ProgressiveTable
                {
                    Id = Guid.NewGuid(),
                    From = 171551M,
                    To = 372950M,
                    Rate = 0.33M
                },
                new ProgressiveTable
                {
                    Id = Guid.NewGuid(),
                    From = 372951M,
                    To = null,
                    Rate = 0.35M
                }
            );
        }
    }
}
