namespace Authorisation.Core.Responses
{
    public class AssignRoleToUserResponse
    {
        public enum StatusCode
        {
            Success,
            UserDoesNotExist,
            Unknown
        }
        public StatusCode Status { get; set; } = StatusCode.Unknown;
        public bool Succeeded
        {
            get
            {
                return Status == StatusCode.Success;
            }
        }
    }
}
