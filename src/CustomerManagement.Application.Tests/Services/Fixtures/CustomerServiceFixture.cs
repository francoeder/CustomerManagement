using AutoMapper;
using CustomerManagement.Application.Notifications;
using CustomerManagement.Application.Services;
using CustomerManagement.Application.Tests.Base;
using CustomerManagement.Domain.Interfaces.Repositories;
using Moq;

namespace CustomerManagement.Application.Tests.Services.Fixtures
{
    public class CustomerServiceFixture : BaseFixture
    {
        public readonly Mock<ICustomerRepository> CustomerRepositoryMock;
        public readonly Mock<INotifier> NotifierMock;
        public readonly Mock<IMapper> MapperMock;

        public CustomerServiceFixture()
        {
            CustomerRepositoryMock = new Mock<ICustomerRepository>();
            NotifierMock = new Mock<INotifier>();
            MapperMock = new Mock<IMapper>();
        }

        public CustomerService GetInstance()
        {
            return new CustomerService(CustomerRepositoryMock.Object, NotifierMock.Object, MapperMock.Object);
        }
    }
}
