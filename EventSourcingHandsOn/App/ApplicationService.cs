using System;
using EventSourcingHandsOn.Domain;
using EventSourcingHandsOn.Repository.Contract;

namespace EventSourcingHandsOn.App
{
    public class ApplicationService
    {
        private readonly IEventStore _eventStore;

        public ApplicationService(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public Customer CreateCustomer()
        {
            return EsRoutine(Guid.Empty, customer => customer.CreateCustomer(Guid.NewGuid(), 0m));
        }

        public Customer InsertMoney(Guid id, decimal money)
        {
            return EsRoutine(id, customer => customer.InsertMoney(money));
        }

        public Customer TakeMoney(Guid id, decimal money)
        {
            return EsRoutine(id, customer => customer.TakeMoney(money));
        }

        public Customer EsRoutine(Guid id, Action<Customer> action)
        {
            var events = _eventStore.Get(id);

            var customer = new Customer(events);

            action(customer);

            _eventStore.Save(customer.Id, customer.Changes);

            return customer;
        }
    }
}
