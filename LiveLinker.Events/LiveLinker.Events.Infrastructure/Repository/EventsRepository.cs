using LiveLinker.Events.LiveLinker.Events.Core.Entities;
using LiveLinker.Events.LiveLinker.Events.Core.Interfaces;
using LiveLinker.Events.LiveLinker.Events.Infrastructure.Data;

namespace LiveLinker.Events.LiveLinker.Events.Infrastructure.Repository{

    public class EventsRepository : IEventRepository
    {
        private readonly BaseDbContext _dbContext;

        public EventsRepository(BaseDbContext dbContext){
            _dbContext = dbContext?? throw new ArgumentNullException(nameof(dbContext));
        }
        public Task<Event> AddAsync(Event entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync<TKey>(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Event>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Event> GetByIdAsync<TKey>(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<Event> UpdateAsync(Event entity)
        {
            throw new NotImplementedException();
        }
    }
}