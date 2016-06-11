using System;
using EventSourcingHandsOn.Domain.Contract;

namespace EventSourcingHandsOn.Domain
{
    [Serializable]
    public class MoneyToken : IEvent
    {
        public Guid AggregateId { get; set; }
        public decimal Money { get; set; }

        public MoneyToken(Guid aggregateId, decimal money)
        {
            AggregateId = aggregateId;
            Money = money;
        }
    }
}
