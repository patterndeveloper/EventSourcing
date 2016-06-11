using System;

namespace EventSourcingHandsOn.Repository
{
    public class EventDbModel
    {
        public int Id { get; set; }
        public Guid AggregateId { get; set; }
        public byte[] Data { get; set; }

        public EventDbModel()
        {
            
        }

        public EventDbModel(Guid aggregateId, byte[] data)
        {
            AggregateId = aggregateId;
            Data = data;
        }
    }
}
