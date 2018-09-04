using System;
using System.Threading.Tasks;
using CustomerValidation.Service.Messages;
using MassTransit;
using Messaging;

namespace CustomerValidation.Service
{
    public class CustomerValidationCommandConsumer : IConsumer<ICustomerValidationCommand>
    {
        public async Task Consume(ConsumeContext<ICustomerValidationCommand> context)
        {
            var command = context.Message;

            // TODO: validation rules
            var id = Guid.NewGuid();
            var name = command.Name;

            await Console.Out.WriteLineAsync($"Customer with name {name} validate");

            var validatedCustomerEvent = new ValidatedCustomerEvent(command, id);
            await context.Publish<IValidatedCustomerEvent>(validatedCustomerEvent);
            //throw new System.NotImplementedException();
        }
    }
}
