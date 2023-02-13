using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA531.Helpers
{
    public static class Constants
    {
        //The Application or Client ID will be generated while registering the app in the Azure portal. Copy and paste the GUID.
        public static readonly string ClientId = "f4b3f1a5-fe9a-4f68-b7b6-41abb1942c9c";

        //Leaving the scope to its default values.
        public static readonly string[] Scopes = 
            new string[] { "User.Read", "profile", "User.Read.All" ,
             "email"};
    }
}
