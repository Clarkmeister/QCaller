using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json;
using QCallerWebService.Models.Customer;
using QCallerWebService.Models.Reservation;
using QCallerWebService.Utilities.Database;
using QCallerWebService.Utilities.Enums;
using QCallerWebService.Utilities.Json;
using QCallerWebService.Utilities.ReturnValue;

namespace QCallerWebService.Controllers.Customer
{
    public class CustomerController : ApiController
    {
        //GET /api/reservation/
        public string Get()
        {
            try
            {
                return new CustomerModel()
                {
                    CustomerId = 1,
                    EmailAddress = "clark.arthur57@gmail.com",
                    FirstName = "Arthur",
                    LastName = "Clark",
                    PhoneNumber = "541-805-5007"
                }.ToJsonString();
            }
            catch (Exception e)
            {
                return new CustomerModel()
                {
                    CustomerId = -1,
                    EmailAddress = e.Message,
                    FirstName = "Failed",
                    LastName = "Failed",
                    PhoneNumber = "Failed"
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
                    var customer = (from a in db.DBCustomers
                        where a.CustomerId == id
                        select a).FirstOrDefault();

                    if (customer == null)
                    {
                        throw new Exception("DB Customer is Null");
                    }

                    return new CustomerModel()
                    {
                        CustomerId = customer.CustomerId,
                        EmailAddress = customer.EmailAddress,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        PhoneNumber = customer.PhoneNumber
                    }.ToJsonString();
                }
            }
            catch (Exception e)
            {
                return new CustomerModel()
                {
                    CustomerId = -1,
                    EmailAddress = e.Message,
                    FirstName = "Failed",
                    LastName = "Failed",
                    PhoneNumber = "Failed"
                }.ToJsonString();
            }
        }



        //POST api/reservation { BODY = ReservationModel.cs }
        /// <summary>
        /// Reserved for Submitting A Reservation
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Customer ID</returns>
        public string Post(CustomerModel value)
        {
            try
            {
                return QCallerDBInsert.InsertCustomer(value).ToJsonString();
            }
            catch (Exception e)
            {
                return new IntegerReturnValue()
                {
                    Description = $"Failed to Create Customer: {e.Message}, Value {value}, Test: \n",
                    Result = -1,
                }.ToJsonString();
            }

        }
    }
}
