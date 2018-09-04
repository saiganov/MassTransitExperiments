namespace Messaging
{
    public class RabbitMqConstants
    {
        public const string RabbitMqUri = "rabbitmq://localhost/";
        public const string UserName = "guest";
        public const string Password = "guest";

        public const string CustomerValidationServiceQueue = "customervalidation.service";
        public const string CustomerDeduplicatedServiceQueue = "customerdeduplicated.service";
    }
}
