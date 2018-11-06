using QCallerWebService.Utilities.Database;
using QCallerWebService.Utilities.ReturnValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QCallerWebService.Utilities.Json;

namespace QCallerWebService.Controllers.Customer
{
    public class CustomerDeleteController : ApiController
    {
        public string Get(int id)
        {
            try
            {
                return QCallerDBDelete.DeleteCustomer(id).ToJsonString();
            }
            catch (Exception e)
            {
                return new IntegerReturnValue()
                {
                    Description = $"Failed to DeleteCustomer: {e.Message}",
                    Result = -1
                }.ToJsonString();
            }
        }
    }
}
