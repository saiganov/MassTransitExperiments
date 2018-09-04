using System;
using MassTransit;
using Messaging;

namespace CustomerDeduplicated.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Deduplicate";

            var bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, RabbitMqConstants.CustomerDeduplicatedServiceQueue, e =>
                {
                    e.Consumer<ValidatedCustomerConsumer>();
                });
            });

            bus.Start();

            Console.WriteLine("Listening for Validate customer for deduplicated events.. Press enter to exit");
            Console.ReadLine();

            bus.Stop();
        }
    }
}
