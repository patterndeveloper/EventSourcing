using System;
using System.Collections.Generic;
using EventSourcingHandsOn.Domain.Contract;

namespace EventSourcingHandsOn.Domain
{
    public class Customer : IAggregateRoot
    {
        public Guid Id { get; set; }
        public decimal Balance { get; set; }
        public IList<IEvent> Changes { get; set; }


        public Customer(IList<IEvent> events)
        {
            new List<IEvent>();
            Changes = new List<IEvent>();

            foreach (var @event in events)
            {
                MutateToCurrentState(@event);
            }
        }

        public void CreateCustomer(Guid id, decimal balance)
        {
            var @event = new CustomerCreated(id, balance);
            ApplyEvent(@event);

            InsertMoney(10m);
        }

        public void InsertMoney(decimal money)
        {
            var @event = new MoneyInserted(Id, money);
            ApplyEvent(@event);
        }

        public void TakeMoney(decimal money)
        {
            var @event = new MoneyToken(Id, money);
            ApplyEvent(@event);
        }

        public void When(CustomerCreated customerCreated)
        {
            Id = customerCreated.AggregateId;
            Balance = customerCreated.Balance;
        }


        public void When(MoneyInserted moneyInserted)
        {
            Balance += moneyInserted.Money;
        }

        public void When(MoneyToken moneyToken)
        {
            Balance -= moneyToken.Money;
        }


        public void MutateToCurrentState(IEvent @event)
        {
            ((dynamic)this).When((dynamic)@event);
        }

        public void ApplyEvent(IEvent @event)
        {
            Changes.Add(@event);
            ((dynamic)this).When((dynamic)@event);
        }
    }
}
