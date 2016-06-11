using System;
using EventSourcingHandsOn.Domain.Contract;

namespace EventSourcingHandsOn.Domain
{
    [Serializable]
    public class CustomerCreated : IEvent
    {
        public decimal Balance { get; set; }
        public Guid AggregateId { get; set; }

        public CustomerCreated(Guid aggregateId, decimal balance)
        {
            Balance = balance;
            AggregateId = aggregateId;
        }
    }
}