using System;
using Automatonymous;
using Messaging;

namespace Saga
{
    public class CustomerSaga : MassTransitStateMachine<CustomerSagaState>
    {
        public State Saved { get; private set; }
        public State Validated { get; private set; }

        public Event<ICustomerValidationCommand> CustomerValidation { get; private set; }
        public Event<IValidatedCustomerEvent> ValidatedCustomer { get; private set; }


        public CustomerSaga()
        {
            InstanceState(s => s.CurrentState);

            Event(() => CustomerValidation,
                cc =>
                    cc.CorrelateBy(state => state.Name, context =>
                            context.Message.Name)
                        .SelectId(context => Guid.NewGuid()));

            Event(() => ValidatedCustomer, x => x.CorrelateById(context =>
                context.Message.CorrelationId));

            Initially(
                When(CustomerValidation)
                    .Then(context =>
                    {
                        context.Instance.ReceivedDateTime = DateTime.Now;
                        context.Instance.Name = context.Data.Name;
                        context.Instance.Ogrn = context.Data.Ogrn;
                        context.Instance.Tin = context.Data.Tin;
                        // do smth
                    })
                    .ThenAsync(
                        context => Console.Out.WriteLineAsync($"Saga for customer" +
                                                              $" {context.Data.Name} recieved"))
                    .TransitionTo(Saved)
                    .Publish(context => new SavedCustomerEvent(context.Instance))
            );

            During(Saved,
                When(ValidatedCustomer)
                    .Then(context => context.Instance.RegisteredDateTime =
                        DateTime.Now)
                    .ThenAsync(
                        context => Console.Out.WriteLineAsync(
                            $"Saga for customer {context.Instance.Name} " +
                            $"registered"))
                    .Finalize()
            );

            SetCompletedWhenFinalized();
        }
    }
}
