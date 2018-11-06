using QCallerWebService.Utilities.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QCallerWebService.Models.Reservation;
using QCallerWebService.Utilities.Database;
using QCallerWebService.Utilities.ReturnValue;

namespace QCallerWebService.Controllers.Reservation
{
    public class ReservationUpdateController : ApiController
    {
        public string Post([FromBody]string value)
        {
            try
            {
                var reservation = value.ToObject<ReservationModel>();
                var retVal = QCallerDBUpdate.UpdateReservation(reservation);
                return retVal.ToJsonString();
            }
            catch (Exception e)
            {
                return new IntegerReturnValue()
                {
                    Description = $"Failed to UpdateReservation: {e.Message}",
                    Result = -1
                }.ToJsonString();
            }

        }
    }
}
