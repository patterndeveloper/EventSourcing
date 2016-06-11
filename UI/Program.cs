using System;
using EventSourcingHandsOn.App;
using EventSourcingHandsOn.Repository;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventStore = new EventStore();

            var applicationService = new ApplicationService(eventStore);

            var customer = applicationService.CreateCustomer();

            customer = applicationService.InsertMoney(customer.Id, 20m);

            customer = applicationService.TakeMoney(customer.Id, 5m);

            Console.WriteLine($"Customer balance is {customer.Balance}");

            Console.ReadLine();
        }
    }
}
