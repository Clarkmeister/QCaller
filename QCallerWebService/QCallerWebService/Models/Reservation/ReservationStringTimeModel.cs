using System;
using System.Globalization;
using QCallerWebService.Utilities.Enums;

namespace QCallerWebService.Models.Reservation
{
    public class ReservationStringTimeModel
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public string ReservationTime { get; set; }
        public int GuestCount { get; set; }
        public ReservationStatus Status { get; set; }

        public ReservationStringTimeModel()
        {
            ReservationId = 0;
            CustomerId = 0;
            RestaurantId = 0;
            ReservationTime = "Base Constructor";
            GuestCount = 0;
            Status = 0;
        }

        public ReservationStringTimeModel(ReservationModel timeModel)
        {
            var dateTime = timeModel.ReservationTime.ToString("yyyy-MM-dd HH:mm:ss");

            ReservationId = timeModel.ReservationId;
            CustomerId = timeModel.CustomerId;
            RestaurantId = timeModel.RestaurantId;
            ReservationTime = dateTime;
            GuestCount = timeModel.GuestCount;
            Status = timeModel.Status;
        }
    }
}