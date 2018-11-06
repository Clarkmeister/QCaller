using System;
using System.Globalization;
using QCallerWebService.Utilities.Enums;

namespace QCallerWebService.Models.Reservation
{
    public class ReservationModel
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime ReservationTime { get; set; }
        public int GuestCount { get; set; }
        public ReservationStatus Status { get; set; }

        public ReservationModel()
        {
            ReservationId = 0;
            CustomerId = 0;
            RestaurantId = 0;
            ReservationTime = DateTime.MinValue;
            GuestCount = 0;
            Status = 0;
        }

        public ReservationModel(ReservationStringTimeModel stringTimeModel)
        {
            //var dateTime = DateTime.ParseExact(stringTimeModel.ReservationTime, "yyyy-MM-dd HH:mm:ss",
            //    CultureInfo.InvariantCulture);

            var outTime = DateTime.MinValue;

            if (!DateTime.TryParseExact(stringTimeModel.ReservationTime, "yyyy-MM-dd HH:mm:ss",
                CultureInfo.DefaultThreadCurrentCulture, DateTimeStyles.None, out outTime))
            {
                throw new Exception("Failed to convert time.");
            }

            ReservationId = stringTimeModel.ReservationId;
            CustomerId = stringTimeModel.CustomerId;
            RestaurantId = stringTimeModel.RestaurantId;
            ReservationTime = outTime;
            GuestCount = stringTimeModel.GuestCount;
            Status = stringTimeModel.Status;
        }
    }
}