using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookTest.Models
{
    public class FacebookUserModel
    {
        
        public string id { get; set; }

        public string name { get; set; }

        public string email { get; set; }


    }

    public class TokenModel
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public string expires_in { get; set; }

    }
}