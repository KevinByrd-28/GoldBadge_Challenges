using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Badges
{
    public class Badge
    {
        public string BadgeID { get; set; }
        public List<string> DoorNames { get; set; }
        

        public Badge()
        {

        }

        public Badge(string aBadgeID, List<string> aDoorNames)
        {
            BadgeID = aBadgeID;
            DoorNames = aDoorNames;
        }
    }
}
