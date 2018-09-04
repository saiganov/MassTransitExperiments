using System;
using Messaging;

namespace Saga
{
    public class SavedCustomerEvent : ISavedCustomerEvent
    {
        private readonly CustomerSagaState _customerSagaState;

        public SavedCustomerEvent(CustomerSagaState customerSagaState)
        {
            this._customerSagaState = customerSagaState;
        }

        public Guid CorrelationId => _customerSagaState.CorrelationId;
        public string Name => _customerSagaState.Name;
        public string Tin => _customerSagaState.Tin;
        public string Ogrn => _customerSagaState.Ogrn;
    }
}
