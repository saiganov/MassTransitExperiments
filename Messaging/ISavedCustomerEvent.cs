using System;

namespace Messaging
{
    public interface ISavedCustomerEvent
    {
        Guid CorrelationId { get; }
    }
}
