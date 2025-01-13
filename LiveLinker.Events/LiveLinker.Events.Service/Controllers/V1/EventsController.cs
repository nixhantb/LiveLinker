
using FluentValidation;
using LiveLinker.Events.LiveLinker.Events.Core.Entities;
using LiveLinker.Events.LiveLinker.Events.Core.Interfaces;
using LiveLinker.Events.LiveLinker.Events.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiveLinker.Events.LiveLinker.Events.Service.Controller.V1{

    [Route("api/v1/events")]
    public class EventsController : BaseApiController<Event, EventModel, IEventRepository>
    {
        public EventsController(IEventRepository repository, IValidator<Event> validator) : base(repository, validator)
        {
        }
    }
}