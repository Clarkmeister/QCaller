using QCallerWebService.Models.Reservation;
using QCallerWebService.Utilities.Database;
using QCallerWebService.Utilities.Json;
using QCallerWebService.Utilities.ReturnValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QCallerWebService.Models.Customer;

namespace QCallerWebService.Controllers.Customer
{
    public class CustomerUpdateController : ApiController
    {
        public string Post([FromBody]string value)
        {
            try
            {
                var customer = value.ToObject<CustomerModel>();
                var retVal = QCallerDBUpdate.UpdateCustomer(customer);
                return retVal.ToJsonString();
            }
            catch (Exception e)
            {
                return new IntegerReturnValue()
                {
                    Description = $"Failed to UpdateCustomer: {e.Message}",
                    Result = -1
                }.ToJsonString();
            }

        }
    }
}
