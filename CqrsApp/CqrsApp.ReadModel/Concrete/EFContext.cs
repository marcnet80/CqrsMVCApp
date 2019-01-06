using CqrsApp.ReadModel.Entities;
using System.Data.Entity;

namespace CqrsApp.ReadModel.Concrete
{
    public class EFContext : DbContext
    {
        public EFContext() : base("name=EFContext")
        {
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EFContext>(null);
            //relationship 1 - 1 (coach and team)
            // 1 to many relation ( Player - Team)
            modelBuilder.Entity<Player>().HasOptional(p => p.Team).WithMany(t => t.Players);
        }
    }
}
