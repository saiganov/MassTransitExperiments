using System;

namespace Messaging
{
    public interface IValidatedCustomerEvent
    {
        Guid Id { get; }
        string Name { get; }
        string Tin { get; }
        string Ogrn { get; }
    }
}
