namespace AccessControl.Core.Responses
{
    public class LoginResponse
    {
        public bool IsAuthenticated { get; set; } = false;
        public string UserName { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new List<string>();
        public string Token { get; set; } = string.Empty;
    }
}
