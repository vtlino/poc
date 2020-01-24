using Business;
using Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerBusiness _CustomerBusiness = new CustomerBusiness();

        [HttpGet("customer/users/{user}")]
        public ActionResult GetCustomer(string user)
        {
            try
            {
                var (codeResponse, customer) = _CustomerBusiness.GetCustomer(user);
                return StatusCode(codeResponse, customer);
            }
            catch (Exception ex)
            {
                //TODO: log da ex
                return StatusCode((int)HttpStatusCode.BadRequest, ApiErrorReturn.InternalError());
            }
        }
    }
}
