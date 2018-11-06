using System.Collections.Concurrent;
using System.Collections.Generic;
using QCallerWebService.Models.Reservation;

namespace QCallerWebService.Reservations
{
    public static class ActiveReservations
    {
        /// <summary> 
        /// ConcurrentDictionary Reservations  
        /// { 
        ///     Key   = Restaurant ID 
        ///     Value = ConcurrentDictionary of Restaurant Reservation Queues 
        ///     { 
        ///         Key   = Guest Count 
        ///         Value = Queue of ReservationModels 
        ///     } 
        /// } 
        /// </summary> 
        public static ConcurrentDictionary<int, ConcurrentDictionary<int, List<ReservationModel>>> Reservations =
            new ConcurrentDictionary<int, ConcurrentDictionary<int, List<ReservationModel>>>();
    }
}