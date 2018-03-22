using Customer.Web.Data.Entities;
using Customer.Web.Data.Interfaces;
using Moq;
using Xunit;

namespace Customer.Web.Tests.Data
{
    public class CustomerRepositoryTests
    {
        private Mock<ICustomerRepository> _repo;
        private CustomerDto _testCustomer;

        public CustomerRepositoryTests()
        {
            _repo = new Mock<ICustomerRepository>();

            _testCustomer = new CustomerDto
            {
                Email = "test@email.com",
                FirstName = "TestFirstName",
                LastName = "TestLastName"
            };

        }

        [Fact]
        public void CallToGetCustomersExecuted()
        {
            var sut = _repo.Setup(x => x.GetCustomersAsync());
            sut.Verifiable();
            _repo.Verify(x => x.GetCustomersAsync(), Times.Once);
        }

        [Fact]
        public void CallToUpdateCustomerExecuted()
        {
            var sut = _repo.Setup(x => x.UpdateCustomerAsync(_testCustomer));
            sut.Verifiable();
            _repo.Verify(x => x.UpdateCustomerAsync(_testCustomer), Times.Once);
        }
    }
}
