using JPProject.Domain.Core.Events;
using JPProject.EntityFrameworkCore.Mappings;
using Microsoft.EntityFrameworkCore;

namespace JPProject.EntityFrameworkCore.Context
{
    public class EventStoreContext : DbContext
    {
        public DbSet<StoredEvent> StoredEvent { get; set; }
        public DbSet<EventDetails> StoredEventDetails { get; set; }
        public EventStoreContext(DbContextOptions<EventStoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());
            modelBuilder.ApplyConfiguration(new EventDetailsMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
