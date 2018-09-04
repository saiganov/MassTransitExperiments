using System;

namespace Messaging
{
    public interface IValidatedCustomerEvent
    {
        Guid CorrelationId { get; }
        string Name { get; }
        string Tin { get; }
        string Ogrn { get; }
    }
}
