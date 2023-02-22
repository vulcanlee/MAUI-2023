namespace MA531.Helpers;

public static class Constants
{
    //The Application or Client ID will be generated while registering the app in the Azure portal. Copy and paste the GUID.
    public static readonly string ClientId = "2f43d642-8134-4b0a-9841-2a0b1521f9a4";

    //Leaving the scope to its default values.
    public static readonly string[] Scopes =
        new string[] { "User.Read", "profile", "openid" ,
             "email"};
}
