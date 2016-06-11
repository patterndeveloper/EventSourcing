using System;
using System.Collections.Generic;
using EventSourcingHandsOn.Domain.Contract;

namespace EventSourcingHandsOn.Repository.Contract
{
    public interface IEventStore
    {
        IList<IEvent> Get(Guid aggregateId);

        void Save(Guid aggregateId, IList<IEvent> events);
    }
}