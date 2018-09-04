using System;
using System.Threading.Tasks;
using System.Web.Http;
using Api.Models;
using Messaging;

namespace Api.Controllers
{
    public class CustomersController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            var bus = BusConfigurator.ConfigureBus();

            var sendToUri = new Uri($"{RabbitMqConstants.RabbitMqUri}{RabbitMqConstants.CustomerValidationServiceQueue}");
            var endPoint = await bus.GetSendEndpoint(sendToUri);

            var fakeViewModel = new CustomerViewModel();
            fakeViewModel.Name = "Gazprom";
            fakeViewModel.Tin = "1234567890";
            fakeViewModel.Ogrn = "123456";

            await endPoint.Send<ICustomerValidationCommand>(new
            {
                Name = fakeViewModel.Name,
                Tin = fakeViewModel.Tin,
                Ogrn = fakeViewModel.Ogrn
            });

            return Ok("its ok!");
        }
    }
}
