using LiveLinker.Events.LiveLinker.Events.Core.Entities;
using LiveLinker.Events.LiveLinker.Events.Service.Models;

namespace LiveLinker.Events.LiveLinker.Events.Core.Interfaces{

    public interface IEventRepository : IRepository<Event, EventModel>
    {
       
    }
}