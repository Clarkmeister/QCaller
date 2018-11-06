using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Validation;
using QCallerWebService.Models.Customer;
using QCallerWebService.Models.Reservation;
using QCallerWebService.Models.Restaurant;
using QCallerWebService.Utilities.Enums;
using QCallerWebService.Utilities.Json;
using QCallerWebService.Utilities.ReturnValue;

namespace QCallerWebService.Utilities.Database
{
    public static class QCallerDBUpdate
    {
        #region Restaurant
        public static IntegerReturnValue UpdateRestaurant(RestaurantModel nv)
        {
            try
            {
                using (var db = new QCallerEntities())
                {
                    var result = db.UpdateRestaurant(nv.RestaurantId, nv.Name, nv.Address, nv.City, nv.State,
                        nv.ZipCode,
                        nv.PhoneNumber,
                        nv.EmailAddress);

                    return new IntegerReturnValue()
                    {
                        Description = "Successfully Updated Restaurant",
                        Result = result
                    };
                }
            }
            catch (Exception e)
            {
                return new IntegerReturnValue()
                {
                    Description = $"Failed to Update Restaurant: {e.Message}",
                    Result = -1
                };
            }
        }
        #endregion

        #region Reservations
        public static IntegerReturnValue ReservationComplete(ReservationModel nv)
        {
            nv.Status = ReservationStatus.Complete;
            return UpdateReservation(nv);
        }
        public static IntegerReturnValue ReservationReady(ReservationModel nv)
        {
            nv.Status = ReservationStatus.Ready;
            return UpdateReservation(nv);
        }

        public static IntegerReturnValue ReservationSeated(ReservationModel nv)
        {
            nv.Status = ReservationStatus.Seated;
            return UpdateReservation(nv);
        }

        public static IntegerReturnValue CancelReservation(ReservationModel nv)
        {
            nv.ReservationTime = DateTime.Now;
            nv.Status = ReservationStatus.Cancelled;
            return UpdateReservation(nv);
        }

        public static IntegerReturnValue UpdateReservation(ReservationModel nv)
        {
            try
            {
                using (var db = new QCallerEntities())
                {
                    var result = db.UpdateReservation(nv.ReservationId, nv.ReservationTime, nv.GuestCount,
                        nv.Status.ToString("g"));

                    return new IntegerReturnValue()
                    {
                        Description = "Successfully Updated Reservation",
                        Result = result
                    };
                }
            }
            catch (Exception e)
            {
                return new IntegerReturnValue()
                {
                    Description = $"Failed to Update Reservation: {e.Message}",
                    Result = -1
                };
            }
        }
        #endregion

        #region Customer
        public static IntegerReturnValue UpdateCustomer(CustomerModel nv)
        {
            try
            {
                using (var db = new QCallerEntities())
                {
                    var result = db.UpdateCustomer(nv.CustomerId, nv.FirstName, nv.LastName, nv.PhoneNumber,
                        nv.EmailAddress);

                    return new IntegerReturnValue()
                    {
                        Description = "Successfully Updated Reservation",
                        Result = result
                    };
                }
            }
            catch (Exception e)
            {
                return new IntegerReturnValue()
                {
                    Description = $"Failed to Update Reservation: {e.Message}",
                    Result = -1
                };
            }
        }
        #endregion
    }
}