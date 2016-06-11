using System;

namespace EventSourcingHandsOn.Domain.Contract
{
    public interface ICommand
    {
        Guid AggregateId { get; set; }
    }
}