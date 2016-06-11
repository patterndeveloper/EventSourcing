using System;
using EventSourcingHandsOn.Domain.Contract;

namespace EventSourcingHandsOn.Domain
{
    [Serializable]
    public class MoneyInserted : IEvent
    {
        public Guid AggregateId { get; set; }
        public decimal Money { get; set; }

        public MoneyInserted(Guid aggregateId, decimal money)
        {
            Money = money;
            AggregateId = aggregateId;
        }
    }
}