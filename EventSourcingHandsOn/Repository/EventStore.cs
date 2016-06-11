using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using EventSourcingHandsOn.Domain.Contract;
using EventSourcingHandsOn.Repository.Contract;


namespace EventSourcingHandsOn.Repository
{
    public class EventStore : IEventStore
    {
        private readonly EventStoreDbContext _eventStoreDbContext;


        public EventStore()
        {
            _eventStoreDbContext = new EventStoreDbContext();
        }

        public IList<IEvent> Get(Guid aggregateId)
        {
            var eventDbModel = _eventStoreDbContext.EventDbModels.Where(edm => edm.AggregateId == aggregateId).ToList();
            var events = new List<IEvent>();
            foreach (var eventModel in eventDbModel)
            {
                using (var memoryStream = new MemoryStream(eventModel.Data))
                {
                    var binaryFormatter = new BinaryFormatter();
                    events.AddRange((IList<IEvent>)binaryFormatter.Deserialize(memoryStream));
                }
            }
            return events;
        }

        public void Save(Guid aggregateId, IList<IEvent> events)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, events);
                var eventDbModel = new EventDbModel(aggregateId, memoryStream.ToArray());
                _eventStoreDbContext.EventDbModels.Add(eventDbModel);
                _eventStoreDbContext.SaveChanges();
            }
        }
    }
}
