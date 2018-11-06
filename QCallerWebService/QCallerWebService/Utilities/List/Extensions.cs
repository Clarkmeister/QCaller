using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCallerWebService.Utilities.List
{
    public static class Extensions
    {
        public static bool Enqueue<T>(this List<T> list, T value)
        {
            try
            {
                list.Add(value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static T Dequeue<T>(this List<T> list)
        {
            if (!list.Any()) throw new NullReferenceException("List is Empty!");
            var retVal = list.First();
            list.Remove(list.First());
            return retVal;
        }

        public static T Peek<T>(this List<T> list)
        {
            if (list.Any())
            {
                return list.First();
            }
            throw new NullReferenceException("List is Empty!");
        }
    }
}