using System;
using Automatonymous;

namespace Saga
{
    public class CustomerSagaState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public State CurrentState { get; set; }

        public DateTime ReceivedDateTime { get; set; }
        public DateTime RegisteredDateTime { get; set; }

        public string Name { get; set; }
        public string Tin { get; set; }
        public string Ogrn { get; set; }
    }
}
