using QCallerWebService.Models.Restaurant;
using QCallerWebService.Utilities.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QCallerWebService.Utilities.Database;
using QCallerWebService.Utilities.ReturnValue;

namespace QCallerWebService.Controllers.Restaurant
{
    public class RestaurantController : ApiController
    {
        public string Get()
        {
            try
            {
                return new RestaurantModel()
                {
                    Address = "5227 N Main St",
                    City = "Union",
                    EmailAddress = "test@gmail.com",
                    LogoId = 0,
                    Name = "Clarks Home Cooking",
                    PhoneNumber = "541-562-5227",
                    RestaurantId = 2,
                    State = "OR",
                    ZipCode = "97883"
                }.ToJsonString();
            }
            catch (Exception)
            {
                return new RestaurantModel()
                {
                    Address = "Failed",
                    City = "Failed",
                    EmailAddress = "Failed",
                    LogoId = -1,
                    Name = "Failed",
                    PhoneNumber = "Failed",
                    RestaurantId = -1,
                    State = "Failed",
                    ZipCode = "Failed"
                }.ToJsonString(); ;
            }
        }
        /// <summary>
        /// Gets a restaurants information using the RestaurantID.
        /// FORMAT: /api/restaurant/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get(int id)
        {
            try
            {
                using (var db = new QCallerEntities())
                {
                    var r = (from a in db.DBRestaurants
                             where a.RestaurantId == id
                             select a).FirstOrDefault();

                    if (r == null) throw new Exception("Restaurant Does Not Exist");

                    var result = new RestaurantModel()
                    {
                        Address = r.Address,
                        City = r.City,
                        EmailAddress = r.EmailAddress,
                        LogoId = 0,
                        Name = r.Name,
                        PhoneNumber = r.PhoneNumber,
                        RestaurantId = r.RestaurantId,
                        State = r.State,
                        ZipCode = r.ZipCode
                    };

                    if (r.LogoID.HasValue)
                    {
                        result.LogoId = r.LogoID.Value;
                    }

                    return result.ToJsonString();

                }
            }
            catch (Exception)
            {
                return new RestaurantModel()
                {
                    Address = "Failed",
                    City = "Failed",
                    EmailAddress = "Failed",
                    LogoId = -1,
                    Name = "Failed",
                    PhoneNumber = "Failed",
                    RestaurantId = -1,
                    State = "Failed",
                    ZipCode = "Failed"
                }.ToJsonString();
            }
        }

        /// <summary>
        /// Used to insert a restaurant into the database.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Post([FromBody] string value)
        {
            try
            {
                var restaurant = value.ToObject<RestaurantModel>();
                var retVal = QCallerDBInsert.InsertRestaurant(restaurant);
                return retVal.ToJsonString();
            }
            catch (Exception e)
            {
                return new IntegerReturnValue()
                {
                    Description = e.Message,
                    Result = -1
                }.ToJsonString();
            }
        }
    }
}
