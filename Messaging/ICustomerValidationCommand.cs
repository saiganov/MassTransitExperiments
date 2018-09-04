namespace Messaging
{
    public interface ICustomerValidationCommand
    {
        string Name { get; set; }
        string Tin { get; set; }
        string Ogrn { get; set; }
    }
}
