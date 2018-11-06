using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using QCallerWebService.Models.Reservation;
using QCallerWebService.Reservations;

namespace QCallerWebService
{
    public static class StartupFunctions
    {
        public static void LoadRestaurants()
        {
            using (var db = new QCallerEntities())
            {
                var rc = from a in db.DBRestaurants
                        select a.RestaurantId;
                foreach (var restaurantId in rc)
                {
                    if (!ActiveReservations.Reservations.Keys.Contains(restaurantId))
                    {
                        ActiveReservations.Reservations.TryAdd(restaurantId, new ConcurrentDictionary<int, List<ReservationModel>>());
                    }
                }
            }
        }
    }
}