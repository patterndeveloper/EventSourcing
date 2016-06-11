using System.Collections.Generic;

namespace EventSourcingHandsOn.Domain.Contract
{
    public interface IAggregateRoot: IEntity
    {
        IList<IEvent> Changes { get; set; }
    }
}