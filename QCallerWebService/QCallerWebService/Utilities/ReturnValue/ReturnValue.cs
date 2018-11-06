using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCallerWebService.Utilities.ReturnValue
{
    public class IntegerReturnValue
    {
        public int Result { get; set; }
        public string Description { get; set; }
    }

    public class StringReturnValue
    {
        public string Result { get; set; }
        public string Description { get; set; }
    }

}