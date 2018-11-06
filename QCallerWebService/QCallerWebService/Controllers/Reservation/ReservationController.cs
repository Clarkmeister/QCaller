using QCallerWebService.Models.Customer;
using QCallerWebService.Models.Reservation;
using QCallerWebService.Utilities.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QCallerWebService.Utilities.Database;
using QCallerWebService.Utilities.Enums;
using QCallerWebService.Utilities.ReturnValue;

namespace QCallerWebService.Controllers.Reservation
{
    public class ReservationController : ApiController
    {
        //GET /api/reservation/
        public string Get()
        {
            using (var db = new QCallerEntities())
            {
                var restaurants = from a in db.DBRestaurants
                                  select a;
                var customer = (from b in db.DBCustomers
                                select b).FirstOrDefault();

                return new ReservationModel()
                {
                    CustomerId = customer.CustomerId,
                    GuestCount = 0,
                    ReservationId = 0,
                    ReservationTime = DateTime.Now,
                    RestaurantId = restaurants.First().RestaurantId,
                    Status = ReservationStatus.Waiting
                }.ToJsonString();
            }
        }

        //GET api/reservation/id
        /// <summary>
        /// Gets Reservation From Reservation ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get(int id)
        {
            try
            {
                using (var db = new QCallerEntities())
                {
                    var rc = (from a in db.DBReservations
                              where a.ReservationID == id
                              select a).FirstOrDefault();
                    if (rc == null)
                    {
                        throw new Exception("Failed");
                    }

                    return new ReservationModel()
                    {
                        CustomerId = rc.CustomerID,
                        ReservationId = rc.ReservationID,
                        RestaurantId = rc.RestaurantID,
                        ReservationTime = rc.Time,
                        GuestCount = rc.GuestCount,
                        Status = GetReservationStatus.GetStatus(rc.Status)
                    }.ToJsonString();
                }
            }
            catch (Exception)
            {
                return new ReservationModel()
                {
                    CustomerId = -1,
                    ReservationId = -1,
                    RestaurantId = -1,
                    ReservationTime = DateTime.Now,
                    GuestCount = -1,
                    Status = ReservationStatus.Unknown
                }.ToJsonString();
            }
        }

        //POST api/reservation { BODY = ReservationModel.cs }
        /// <summary>
        /// Reserved for Submitting A Reservation
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Post(ReservationStringTimeModel value)
        {
            try
            {
                var res = new ReservationModel(value);

                return QCallerDBInsert.InsertReservation(res).ToJsonString();
            }
            catch (Exception e)
            {
                return new IntegerReturnValue()
                {
                    Description = "Reservation Controller Error: " + e.Message,
                    Result = -1
                }.ToJsonString();
            }

        }
    }
}
