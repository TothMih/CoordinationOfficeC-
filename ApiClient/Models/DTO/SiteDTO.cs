using System;

namespace CoordinatorOffice.ApiClient.Models.DTO
{
    public class SiteDTO
    {
        public SiteDTO(int siteId, string siteName, PIDTO? pIDTO)
        {
            SiteId = siteId;
            SiteName = siteName;
            PIDTO = pIDTO;
        }

        public int SiteId { get; set; }
        public string SiteName { get; set; }

        public PIDTO? PIDTO { get; set; }

        public SiteDTO()
        {
            
        }
    }
}
