using LiveLinker.Events.LiveLinker.Events.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LiveLinker.Events.LiveLinker.Events.Infrastructure.Data.Contexts{

    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("linker_events");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("eventId");
        }
    }
}