//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QCallerWebService
{
    using System;
    using System.Collections.Generic;
    
    public partial class DBReservation
    {
        public int ReservationID { get; set; }
        public int RestaurantID { get; set; }
        public int CustomerID { get; set; }
        public System.DateTime Time { get; set; }
        public int GuestCount { get; set; }
        public string Status { get; set; }
    
        public virtual DBCustomer DBCustomer { get; set; }
        public virtual DBRestaurant DBRestaurant { get; set; }
    }
}
