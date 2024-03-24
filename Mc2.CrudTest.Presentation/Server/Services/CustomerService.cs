using Mc2.CrudTest.Presentation.Server.Interface;
using Mc2.CrudTest.Presentation.Shared;
using Mc2.CrudTest.Presentation.Server.Interface;

namespace Mc2.CrudTest.Presentation.Server.Services
{
    public class CustomerService : Interface.ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> CreateAsync(CustomerViewModel model)
        {
            return await _customerRepository.CreateAsync(model);
        }
    }
}
