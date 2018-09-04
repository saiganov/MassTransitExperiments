using System;
using Messaging;

namespace CustomerValidation.Service.Messages
{
    public class ValidatedCustomerEvent : IValidatedCustomerEvent
    {
        private ICustomerValidationCommand command;
        private Guid id;

        public ValidatedCustomerEvent(ICustomerValidationCommand command, Guid id)
        {
            this.command = command;
            this.id = id;
        }

        public Guid CorrelationId => id;
        public string Name => command.Name;
        public string Tin => command.Tin;
        public string Ogrn => command.Ogrn;
    }
}
