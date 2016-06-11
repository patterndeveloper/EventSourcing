using System;

namespace EventSourcingHandsOn.Domain.Contract
{
    public interface IEvent
    {
        Guid AggregateId { get; set; }
    }
}