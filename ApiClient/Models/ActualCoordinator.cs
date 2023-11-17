
namespace CoordinatorOffice.ApiClient.Models
{
    public class ActualCoordinator
    {
        public ActualCoordinator(int coordinatorId, string email, string password, string role, string? access_Token, string? refresh_Token)
        {
            this.coordinatorId = coordinatorId;
            this.email = email;
            this.password = password;
            this.role = role;
            this.access_Token = access_Token;
            this.refresh_Token = refresh_Token;
        }

        public int coordinatorId { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string? access_Token { get; set; }
        public string? refresh_Token { get; set; }

        public ActualCoordinator()
        {
            
        }
    }
}
