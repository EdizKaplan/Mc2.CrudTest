using Mc2.CrudTest.Presentation.Shared;

namespace Mc2.CrudTest.Presentation.Server.Interface
{
    public interface ICustomerService
    {
        Task<bool> CreateAsync(CustomerViewModel model);
    }
}
