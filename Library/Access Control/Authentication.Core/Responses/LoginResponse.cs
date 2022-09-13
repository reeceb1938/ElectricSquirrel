namespace Authentication.Core.Responses
{
    public class LoginResponse
    {
        public enum StatusCode
        {
            Success,
            AccountDoesNotExist,
            InvalidCredentails,
            Unkown
        };
        public StatusCode Status { get; set; } = StatusCode.Unkown;
        public bool Succeeded { 
            get
            {
                return Status == StatusCode.Success;
            }
        }
        public string UserName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new List<string>();
        public string Token { get; set; } = string.Empty;
    }
}
