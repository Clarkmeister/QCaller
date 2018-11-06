using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCallerWebService.Models.Customer
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}