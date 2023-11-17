
namespace CoordinatorOffice.ApiClient.Models.DTO
{
    public class CoordinatorDTO
    {
        public int CoordinatorId { get; set; }
        public string? CoordinatorName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }

    public class LoginDTO : CoordinatorDTO 
    {
        public LoginDTO(int coordinatorid, string coordinatorname, string password, string role, ApiClient.Models.JwtToken jwtToken)
        {
            CoordinatorId = coordinatorid;
            CoordinatorName = coordinatorname;
            Password = password;
            Role = role;
            Access_Token = jwtToken.Access_Token;
            Refresh_Token = jwtToken.Refresh_Token;
        }

        public string? Access_Token { get; set; }
        public string? Refresh_Token { get; set; }
    }
}
