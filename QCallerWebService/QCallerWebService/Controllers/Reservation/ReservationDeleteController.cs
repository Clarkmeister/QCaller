using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QCallerWebService.Utilities.Database;
using QCallerWebService.Utilities.Json;
using QCallerWebService.Utilities.ReturnValue;

namespace QCallerWebService.Controllers.Reservation
{
    public class ReservationDeleteController : ApiController
    {
        public string Get(int id)
        {
            try
            {
                var retVal = QCallerDBDelete.DeleteReservation(id);
                return retVal.ToJsonString();
            }
            catch (Exception e) 
            {
                return new IntegerReturnValue()
                {
                    Description = $"Failed to DeleteReservation: {e.Message}",
                    Result = -1
                }.ToJsonString();
            }
        }
    }
}
