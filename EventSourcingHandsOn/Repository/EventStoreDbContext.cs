using System.Data.Entity;

namespace EventSourcingHandsOn.Repository
{
    public class EventStoreDbContext : DbContext
    {
        public EventStoreDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<EventDbModel> EventDbModels { get; set; }
    }
}