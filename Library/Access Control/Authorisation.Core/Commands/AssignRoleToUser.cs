namespace Authorisation.Core.Commands
{
    public class AssignRoleToUser
    {
        public string EmailAddress { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
    }
}
