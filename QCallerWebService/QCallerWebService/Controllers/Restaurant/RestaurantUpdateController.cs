using QCallerWebService.Utilities.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QCallerWebService.Models.Restaurant;
using QCallerWebService.Utilities.Database;
using QCallerWebService.Utilities.ReturnValue;

namespace QCallerWebService.Controllers.Restaurant
{
    public class RestaurantUpdateController : ApiController
    {
        public string Post([FromBody]string value)
        {
            try
            {
                var restaurant = value.ToObject<RestaurantModel>();
                var retVal = QCallerDBUpdate.UpdateRestaurant(restaurant);
                return retVal.ToJsonString();
            }
            catch (Exception e)
            {
                return new IntegerReturnValue()
                {
                    Description = $"Error: {e.Message}",
                    Result = -1
                }.ToJsonString();
            }

        }
    }
}
