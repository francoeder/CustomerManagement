using AutoMapper;
using CustomerManagement.Api.Constants;
using CustomerManagement.Application.Interfaces;
using CustomerManagement.Application.Notifications;
using CustomerManagement.Application.Requests.Customer;
using CustomerManagement.Application.Responses.Base;
using CustomerManagement.Application.Responses.Customer;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace CustomerManagement.Api.Controllers
{
    [Route(ApiRoutes.Global.BaseRoute)]
    [ApiVersion("1.0")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly INotifier _notifier;

        public CustomerController(
            ICustomerService customerService,
            INotifier notifier)
        {
            _customerService = customerService;
            _notifier = notifier;
        }

        [HttpPost]
        [Route(ApiRoutes.Customer.DefaultRoute)]
        [SwaggerResponse((int)HttpStatusCode.Created, "", typeof(Response<CustomerResponse>))]
        [SwaggerOperation(Summary = SwaggerDescriptions.Customer.Add)]
        public async Task<IActionResult> Add(AddCustomerRequest request)
        {            
            var response = await _customerService.Add(request);

            if (_notifier.HasNotification())
            {
                return BadRequest(new Response<object>
                {
                    Success = false,
                    Data = _notifier.GetNotifications(),
                });
            }

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
            var response = await _customerService.GetCustomerById(id);

            if (_notifier.HasNotification())
            {
                return BadRequest(new Response<object>
                {
                    Success = false,
                    Data = _notifier.GetNotifications(),
                });
            }

            return Ok(new Response<CustomerResponse>
            {
                Success = true,
                Data = response
            });
        }

        [HttpGet]
        [Route(ApiRoutes.Customer.DefaultRoute)]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(Response<List<CustomerResponse>>))]
        [SwaggerOperation(Summary = SwaggerDescriptions.Customer.GetAll)]
        public async Task<IActionResult> GetAllFiltered([FromQuery] GetAllFilteredRequest request)
        {
            var response = await _customerService.GetAllFiltered(request.CompanyName);
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
            var response = await _customerService.Update(id, request);

            if (_notifier.HasNotification())
            {
                return BadRequest(new Response<object>
                {
                    Success = false,
                    Data = _notifier.GetNotifications(),
                });
            }

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
            await _customerService.Delete(id);

            if (_notifier.HasNotification())
            {
                return BadRequest(new Response<object>
                {
                    Success = false,
                    Data = _notifier.GetNotifications(),
                });
            }

            return Ok(new Response<string>
            {
                Success = true
            });
        }

    }
}
