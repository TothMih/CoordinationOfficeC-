
namespace CoordinatorOffice.ApiClient.Models
{
    public class JwtToken
    {
        public JwtToken()
        {
        }

        public JwtToken(string access_Token, string refresh_Token)
        {
            Access_Token = access_Token;
            Refresh_Token = refresh_Token;
        }

        public string Access_Token { get; set; }
        public string Refresh_Token { get; set; }
    }
}

