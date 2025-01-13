namespace LiveLinker.Events.LiveLinker.Events.Service.Models
{
    public class EventModel
    {
        public Guid Id { get;  set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public int DurationInMinutes { get; set; }
        public string? Location { get; set; }
        public Guid OrganizerId { get; set; }
        public EventStatus Status { get; set; } = EventStatus.Upcoming;
        public List<string>? Tags { get; set; }
        public int? MaxAttendees { get; set; }
        public decimal? TicketPrice { get; set; }
        public DateTime CreatedAt { get;  set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get;  set; } = DateTime.UtcNow;
    }
    public enum EventStatus
    {
        Upcoming,
        Live,
        Completed,
        Cancelled
    }
}


