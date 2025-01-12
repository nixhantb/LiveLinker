using LiveLinker.Events.LiveLinker.Events.Core.Entities;
using LiveLinker.Events.LiveLinker.Events.Service.Models;


namespace LiveLinker.Events.LiveLinker.Events.Mapper{

    public static class EventsMapper{

        public static Event ToDB(Event entity){
           if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return new Event
            {
                Id = entity.Id, 
                Title = entity.Title,
                Description = entity.Description,
                Date = entity.Date,
                DurationInMinutes = entity.DurationInMinutes,
                Location = entity.Location,
                OrganizerId = entity.OrganizerId,
                Status = entity.Status,
                Tags = entity.Tags?.ToList(), 
                MaxAttendees = entity.MaxAttendees,
                TicketPrice = entity.TicketPrice,
                CreatedAt = entity.CreatedAt, 
                UpdatedAt = DateTime.UtcNow 
            };
        }

        public static EventModel ToModel(Event entity){
           if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return new EventModel
            {
                Id = entity.Id, 
                Title = entity.Title,
                Description = entity.Description,
                Date = entity.Date,
                DurationInMinutes = entity.DurationInMinutes,
                Location = entity.Location,
                OrganizerId = entity.OrganizerId,
                Status = (Service.Models.EventStatus)entity.Status,
                Tags = entity.Tags?.ToList(), 
                MaxAttendees = entity.MaxAttendees,
                TicketPrice = entity.TicketPrice,
                CreatedAt = entity.CreatedAt, 
                UpdatedAt = DateTime.UtcNow 
            };
        }
    }
}