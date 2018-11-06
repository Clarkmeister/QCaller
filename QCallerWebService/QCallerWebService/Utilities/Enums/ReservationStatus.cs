using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace QCallerWebService.Utilities.Enums
{
    public enum ReservationStatus
    {
        Waiting, Ready, Seated, Complete, Cancelled, Unknown
    }

    public static class GetReservationStatus
    {
        public static ReservationStatus GetStatus(string status)
        {
            switch (status)
            {
                case "Waiting":
                {
                    return ReservationStatus.Waiting;
                }
                case "Ready":
                {
                    return ReservationStatus.Ready;
                }
                case "Seated":
                {
                    return ReservationStatus.Seated;
                }
                case "Complete":
                {
                    return ReservationStatus.Complete;
                }
                case "Cancelled":
                {
                    return ReservationStatus.Cancelled;
                }
                default:
                {
                    return ReservationStatus.Unknown;
                }
            }
        }
    }
}