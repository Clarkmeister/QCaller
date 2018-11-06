using QCallerWebService.Models.Restaurant;
using QCallerWebService.Utilities.ReturnValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCallerWebService.Utilities.Database
{
    public static class QCallerDBDelete
    {
        #region Restaurant
        public static IntegerReturnValue DeleteRestaurant(int restaurantId)
        {
            try
            {
                using (var db = new QCallerEntities())
                {
                    var result = db.DeleteRestaurant(restaurantId);

                    return new IntegerReturnValue()
                    {
                        Description = "Successfully Deleted Restaurant",
                        Result = result
                    };
                }
            }
            catch (Exception e)
            {
                return new IntegerReturnValue()
                {
                    Description = $"Failed to Delete Restaurant: {e.Message}",
                    Result = -1
                };
            }
        }
        #endregion

        #region Reservation
        public static IntegerReturnValue DeleteReservation(int reservationId)
        {
            try
            {
                using (var db = new QCallerEntities())
                {
                    var result = db.DeleteReservation(reservationId);

                    return new IntegerReturnValue()
                    {
                        Description = "Successfully Deleted Reservation",
                        Result = result
                    };
                }
            }
            catch (Exception e)
            {
                return new IntegerReturnValue()
                {
                    Description = $"Failed to Delete Reservation: {e.Message}",
                    Result = -1
                };
            }
        }
        #endregion

        #region Customer
        public static IntegerReturnValue DeleteCustomer(int customerId)
        {
            try
            {
                using (var db = new QCallerEntities())
                {
                    var result = db.DeleteCustomer(customerId);

                    return new IntegerReturnValue()
                    {
                        Description = "Successfully Deleted Customer",
                        Result = result
                    };
                }
            }
            catch (Exception e)
            {
                return new IntegerReturnValue()
                {
                    Description = $"Failed to Delete Customer: {e.Message}",
                    Result = -1
                };
            }
        }
        #endregion
    }
}