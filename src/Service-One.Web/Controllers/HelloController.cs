using Microsoft.AspNetCore.Mvc;
using Service_One.Web.Services;
using System.Threading.Tasks;

namespace Service_One.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        private readonly ServiceTwo serviceTwo;

        public HelloController(ServiceTwo serviceTwo)
        {
            this.serviceTwo = serviceTwo;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            return await this.serviceTwo.GetGreeting();
        }
    }
}
