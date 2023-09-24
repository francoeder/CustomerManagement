using AutoMapper;
using CustomerManagement.Api.Constants;
using CustomerManagement.Application.Constants;
using CustomerManagement.Application.Requests.Customer;
using CustomerManagement.Application.Responses.Base;
using CustomerManagement.Application.Responses.Customer;
using CustomerManagement.Domain;
using CustomerManagement.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace CustomerManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(
            ICustomerService customerService,
            IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route(ApiRoutes.Customer.DefaultRoute)]
        [SwaggerResponse((int)HttpStatusCode.Created, "", typeof(Response<CustomerResponse>))]
        [SwaggerOperation(Summary = SwaggerDescriptions.Customer.Add)]
        public async Task<IActionResult> Add(AddCustomerRequest request)
        {
            if (!request.IsValid())
            {
                return BadRequest(new Response<object>
                {
                    Success = false,
                    Data = request.GetErrors().Select(s => new { s.PropertyName, s.ErrorMessage }),
                });
            }

            var customer = _mapper.Map<Customer>(request);
            await _customerService.Add(customer);
            await _customerService.SaveChangesAsync();
            var response = _mapper.Map<CustomerResponse>(customer);

            return Created(ApiRoutes.Customer.RouteById, new Response<CustomerResponse>
            {
                Success = true,
                Data = response
            });
        }

        [HttpGet]
        [Route(ApiRoutes.Customer.RouteById)]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Response<CustomerResponse>))]
        [SwaggerOperation(Summary = SwaggerDescriptions.Customer.GetById)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var customer = await _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound(new Response<string>
                {
                    Success = true,
                    Data = ValidationMessages.Customer.CustomerNotFound
                });
            }

            var response = _mapper.Map<CustomerResponse>(customer);
            return Ok(new Response<CustomerResponse>
            {
                Success = true,
                Data = response
            });
        }

        [HttpGet]
        [Route(ApiRoutes.Customer.DefaultRoute)]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Response<List<CustomerResponse>>))]
        [SwaggerOperation(Summary = SwaggerDescriptions.Customer.GetById)]
        public async Task<IActionResult> GetAllFiltered([FromQuery] GetAllFilteredRequest request)
        {
            var customers = await _customerService.GetAllFiltered(request.CompanyName);
            var response = _mapper.Map<List<CustomerResponse>>(customers);
            return Ok(new Response<List<CustomerResponse>>
            {
                Success = true,
                Data = response
            });
        }

        [HttpPut]
        [Route(ApiRoutes.Customer.RouteById)]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Response<CustomerResponse>))]
        [SwaggerOperation(Summary = SwaggerDescriptions.Customer.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCustomerRequest request)
        {
            if (!request.IsValid())
            {
                return BadRequest(new Response<object>
                {
                    Success = false,
                    Data = request.GetErrors().Select(s => new { s.PropertyName, s.ErrorMessage }),
                });
            }

            var customer = await _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound(new Response<string>
                {
                    Success = true,
                    Data = ValidationMessages.Customer.CustomerNotFound
                });
            }

            await _customerService.SaveChangesAsync();
            _mapper.Map(request, customer);
            await _customerService.Update(customer);

            var response = _mapper.Map<CustomerResponse>(customer);
            return Ok(new Response<CustomerResponse>
            {
                Success = true,
                Data = response
            });
        }

        [HttpDelete]
        [Route(ApiRoutes.Customer.RouteById)]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Response<string>))]
        [SwaggerOperation(Summary = SwaggerDescriptions.Customer.Delete)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var customer = await _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound(new Response<string>
                {
                    Success = true,
                    Data = ValidationMessages.Customer.CustomerNotFound
                });
            }

            await _customerService.Delete(customer);
            await _customerService.SaveChangesAsync();

            return Ok(new Response<string>
            {
                Success = true
            });
        }

    }
}
