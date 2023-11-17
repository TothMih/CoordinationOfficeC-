using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinatorOffice.ApiClient.Models.DTO
{
    public class StudyDTO
    {
        public StudyDTO(int studyId, string protocol, string indication, int phase, string iP, string comparator, string nickname, SiteDTO? site, CoordinatorDTO? coordinator)
        {
            StudyId = studyId;
            Protocol = protocol;
            Indication = indication;
            Phase = phase;
            IP = iP;
            Comparator = comparator;
            Nickname = nickname;
            Site = site;
            Coordinator = coordinator;
        }

        public int StudyId { get; set; }    
        public string Protocol { get; set;}
        public string Indication { get; set;}
        public int Phase { get; set;}
        public string IP { get; set;}
        public string Comparator { get; set;}
        public string Nickname { get; set;}
        public SiteDTO? Site { get; set;}
        public CoordinatorDTO? Coordinator { get; set;}

        public StudyDTO()
        {
            
        }

    }
}
