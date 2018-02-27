using Microsoft.EntityFrameworkCore;

namespace BlockChain.Infraestructure
{
    public class Db : DbContext
    {
        #region Tables
        public DbSet<Equipment> Equipament { get; set; }
        public DbSet<Tariff> Tariff { get; set; }
        public DbSet<PowerDistribuitor> PowerDistribuitor { get; set; }
        #endregion

        public Db(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder m)
        {
           
        }
    }
}
