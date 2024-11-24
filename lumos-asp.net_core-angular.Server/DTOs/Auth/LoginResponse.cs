namespace lumos_asp.net_core_angular.Server.DTOs.Auth
{
    public class LoginResponse()
    {
        public string AccessToken { get; set; }
        public long ExpiresIn { get; set; }
        public string Roles { get; set; }
    }
}
