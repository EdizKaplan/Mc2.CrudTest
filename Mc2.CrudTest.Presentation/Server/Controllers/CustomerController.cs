using Mc2.CrudTest.Presentation.Server.Interface;
using Mc2.CrudTest.Presentation.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerViewModel model)
        {
            // Call service to create customer
            var result = await _customerService.CreateAsync(model);
            if (result)
            {
                return Ok("Customer created successfully.");
            }
            return BadRequest("Failed to create customer.");
        }
    }
}
