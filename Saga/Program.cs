using System;
using MassTransit;
using MassTransit.Saga;
using Messaging;

namespace Saga
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Saga";
            var saga = new CustomerSaga();;
            var repo = new InMemorySagaRepository<CustomerSagaState>();

            var bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, RabbitMqConstants.SagaQueue, e =>
                {
                    e.StateMachineSaga(saga, repo);
                });
            });
            bus.Start();
            Console.WriteLine("Saga active.. Press enter to exit");
            Console.ReadLine();
            bus.Stop();
        }
    }
}
