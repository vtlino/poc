using Business;
using Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CurrentAccountController : ControllerBase
    {
        private readonly CurrentAccountBusiness _CurrentAccountBusiness = new CurrentAccountBusiness();

        [HttpGet("balance/users/{user}")]
        public ActionResult GetBalance(string user)
        {
            try
            {
                var(codeResponse, balance) = _CurrentAccountBusiness.GetBalance(user);
                return StatusCode((int)HttpStatusCode.OK, balance);
            }
            catch (Exception ex)
            {
                //TODO: log da ex
                return StatusCode((int)HttpStatusCode.BadRequest, ApiErrorReturn.InternalError());
            }
        }

        [HttpGet("transactions/users/{user}")]
        public ActionResult GetTransactions(string user, string datainicial, string datafinal)
        {
            try
            {
                var initialDate = new DateTime();
                var endDate = new DateTime();
                try
                {
                    initialDate = DateTime.Parse(datainicial);
                    endDate = DateTime.Parse(datafinal);
                }
                catch (Exception ex)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, ApiErrorReturn.InvalidDate());
                }
                if (initialDate > endDate)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, ApiErrorReturn.InvalidInitialDate());
                }

                var(codeResponse, transactions) = _CurrentAccountBusiness.GetTransactions(user, initialDate, endDate);
                return StatusCode(codeResponse, transactions);
            }
            catch (Exception ex)
            {
                //TODO: log da ex
                return StatusCode((int)HttpStatusCode.BadRequest, ApiErrorReturn.InternalError());
            }
        }
    }
}
