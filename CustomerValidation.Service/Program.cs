using System;
using MassTransit;
using Messaging;

namespace CustomerValidation.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Validation";

            var bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(host, RabbitMqConstants.CustomerValidationServiceQueue, e =>
                {
                    e.Consumer<CustomerValidationCommandConsumer>();

                });
            });

            bus.Start();

            Console.WriteLine("Listening for Customer validation commands.. Press enter to exit");
            Console.ReadLine();

            bus.Stop();
        }
    }
}
