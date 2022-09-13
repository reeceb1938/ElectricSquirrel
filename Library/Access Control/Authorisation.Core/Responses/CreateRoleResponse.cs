namespace Authorisation.Core.Responses
{
    public class CreateRoleResponse
    {
        public bool Succeeded { get; set; } = false;
        public string RoleName { get; set; } = String.Empty;
    }
}
