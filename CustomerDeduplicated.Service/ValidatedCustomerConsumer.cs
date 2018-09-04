using System;
using System.Threading.Tasks;
using MassTransit;
using Messaging;

namespace CustomerDeduplicated.Service
{
    public class ValidatedCustomerConsumer : IConsumer<IValidatedCustomerEvent>
    {
        public async Task Consume(ConsumeContext<IValidatedCustomerEvent> context)
        {
            // TODO: deduplicate customer

            await Console.Out.WriteLineAsync($"Customer deduplicated and do smth then: CorrelationId {context.Message.CorrelationId}; Name {context.Message.Name}");
        }
    }
}
