using QCallerWebService.Models.Restaurant;
using QCallerWebService.Utilities.ReturnValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QCallerWebService.Models.Customer;
using QCallerWebService.Models.Reservation;
using QCallerWebService.Utilities.Enums;
using QCallerWebService.Utilities.Json;

namespace QCallerWebService.Utilities.Database
{
    public static class QCallerDBInsert
    {
        #region Restaurant
        public static IntegerReturnValue InsertRestaurant(RestaurantModel nv)
        {
            try
            {
                using (var db = new QCallerEntities())
                {
                    var result = db.SaveRestaurant(nv.Name, nv.Address, nv.City, nv.State, nv.ZipCode, nv.PhoneNumber,
                        nv.EmailAddress, null).FirstOrDefault();

                    if (result != null)
                    {
                        return new IntegerReturnValue()
                        {
                            Description = "Successfully Created Reservation",
                            Result = result.Value
                        };
                    }
                    throw new Exception("Failed to Create Restaurant");
                }
            }
            catch (Exception e)
            {
                return new IntegerReturnValue()
                {
                    Description = e.Message,
                    Result = -1
                };
            }
        }
        #endregion

        #region Reservation
        public static IntegerReturnValue InsertReservation(ReservationModel nv)
        {
            try
            {
                using (var db = new QCallerEntities())
                {
                    nv.ReservationTime = DateTime.Now + TimeSpan.FromHours(1);
                    var result = db.SaveReservation(nv.RestaurantId, nv.CustomerId, nv.ReservationTime, nv.GuestCount, ReservationStatus.Waiting.ToString("g")).FirstOrDefault();

                    if (result != null)
                    {
                        return new IntegerReturnValue()
                        {
                            Description = $"Successfully Created Reservation Time: {nv.ReservationTime:yyyy-MM-dd HH:mm:ss}",
                            Result = result.Value
                        };
                    }
                    throw new Exception("Failed to Create Reservation");
                }
            }
            catch (Exception e)
            {
                return new IntegerReturnValue()
                {
                    Description = "Insert Reservation Error: " + e.Message + "\n ReservationModel: " + nv.ToJsonString(),
                    Result = -1
                };
            }
        }
        #endregion

        #region Customer
        public static IntegerReturnValue InsertCustomer(CustomerModel nv)
        {
            try
            {
                using (var db = new QCallerEntities())
                {
                    var result = db.SaveCustomer(nv.PhoneNumber, nv.FirstName, nv.LastName, nv.EmailAddress).FirstOrDefault();

                    if (result != null)
                    {
                        return new IntegerReturnValue()
                        {
                            Description = "Successfully Created Customer",
                            Result = result.Value
                        };
                    }
                    throw new Exception("Failed to Create Customer");
                    //return new ReturnValue<int?>()
                    //{
                    //    RequestString = nv.ToJsonString(),
                    //    Description = "Successfully Inserted Customer",
                    //    Result = result,
                    //    Success = true
                    //};
                }
            }
            catch (Exception e)
            {
                var p = string.Empty;
                var f = string.Empty;
                var l = string.Empty;
                var ema = string.Empty;
                if (nv != null)
                {
                    if (nv.PhoneNumber != null)
                    {
                        p = nv.PhoneNumber;
                    }

                    if (nv.FirstName != null)
                    {
                        f = nv.FirstName;
                    }

                    if (nv.LastName != null)
                    {
                        l = nv.LastName;
                    }

                    if (nv.EmailAddress != null)
                    {
                        ema = nv.EmailAddress;
                    }
                }
                return new IntegerReturnValue()
                {
                    Description = $"Failed in insert Customer: {e.Message}, {p}, {f}, {l}, {ema}",
                    Result = -1
                };
            }
        }
        #endregion
    }
}