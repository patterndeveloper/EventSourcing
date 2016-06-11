using System;

namespace EventSourcingHandsOn.Domain.Contract
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}