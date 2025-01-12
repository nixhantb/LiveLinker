using LiveLinker.Events.LiveLinker.Events.Core.Entities;
using LiveLinker.Events.LiveLinker.Events.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LiveLinker.Events.LiveLinker.Events.Infrastructure.Data{

    public class BaseDbContext : DbContext
    {
       
        public BaseDbContext(DbContextOptions<BaseDbContext> options)
        :base(options)
        {

        }
        public virtual DbSet<Event> Events{get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            base.OnModelCreating(modelBuilder);
        }


    }
}