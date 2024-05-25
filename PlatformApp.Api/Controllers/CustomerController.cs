using Microsoft.AspNetCore.Mvc;
using PlatformApp.Service.Services;

namespace PlatformApp.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomerController( ICustomerService _customerService )
        {
            this.customerService = _customerService;
        }
        [HttpGet]
        [Route( "" )]
        public async Task<IActionResult> Get()
        {
            return Ok( await customerService.GetAllCustomers() );
        }
    }
}
