

namespace CoordinatorOffice.ApiClient.Models.DTO
{
    public class PIDTO
    {
        public PIDTO(int pID, string? pIName)
        {
            PID = pID;
            PIName = pIName;
        }

        public int PID { get; set; }    
        public string? PIName { get; set; }

        public PIDTO()
        {
            
        }
    }
}
