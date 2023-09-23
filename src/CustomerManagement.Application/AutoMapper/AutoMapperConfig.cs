using AutoMapper;
using CustomerManagement.Application.Requests.Customer;
using CustomerManagement.Application.Responses.Customer;
using CustomerManagement.Domain;

namespace CustomerManagement.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AddCustomerRequest, Customer>();
            CreateMap<Customer, CustomerResponse>();
        }
    }
}
