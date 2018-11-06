using QCallerWebService.Utilities.Database;
using QCallerWebService.Utilities.Json;
using QCallerWebService.Utilities.ReturnValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QCallerWebService.Controllers.Restaurant
{
    public class RestaurantDeleteController : ApiController
    {
        public string Get(int id)
        {
            try
            {
                var retVal = QCallerDBDelete.DeleteRestaurant(id);
                return retVal.ToJsonString();
            }
            catch (Exception e)
            {
                return new IntegerReturnValue()
                {
                    Description = $"Failed to execute DeleteRestaurant: {e.Message}",
                    Result = -1
                }.ToJsonString();
            }
        }
    }
}
