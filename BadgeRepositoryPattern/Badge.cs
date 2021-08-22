using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeRepositoryPattern
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> DoorNameList { get; set; } = new List<string>();



        public Badge() { }

        public Badge(List<string> doorNameList, int badgeID)
        {
            DoorNameList = doorNameList;
            BadgeID = badgeID;
        }
    }
}
