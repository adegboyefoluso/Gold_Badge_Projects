using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeRepositoryPattern
{
    public class BadgeRepository
    {
        public Dictionary<int, List<string>> Badges = new Dictionary<int, List<string>>();

        public void AddBadgetoDic(Badge newbadge)
        {


            Badges.Add(newbadge.BadgeID, newbadge.DoorNameList);
        }

        public Dictionary<int, List<string>> ReadBadgefromDIC()
        {
            return Badges;
        }

        

        public bool DeleteBadge(int badgeid)
        {

            if (Badges.Remove(badgeid))
            {
                return true;
            }
            else return false;

        }


        public KeyValuePair<int, List<string>> GetBadgeFrommDIcByBadgeID(int badgeID)

        {
            KeyValuePair<int, List<string>> kvpfirst = new KeyValuePair<int, List<string>>();
            //search through badge dictionary to find the badge with the right id
            //if badgeid is equal to parameter passed in (badgeID).
            //return badge
            foreach (KeyValuePair<int, List<string>> kvp in Badges)
            {
                if (kvp.Key == badgeID)
                {
                    return kvp;
                }
            }
            return kvpfirst;
        }

        public void RemoveDooronBadge(int badgeid, string olddoor)
        {
            KeyValuePair<int, List<string>> anotherkvp = GetBadgeFrommDIcByBadgeID(badgeid);
            List<string> doorList = anotherkvp.Value;
            foreach (string door in doorList)
            {
                if (door == olddoor)
                {
                    doorList.Remove(door);

                }
                //break;
            }


        }
        public void AddDoorToBadge(int badgeid, string newdoor)
        {
            KeyValuePair<int, List<string>> oldbadge = GetBadgeFrommDIcByBadgeID(badgeid);
            List<string> doorList = oldbadge.Value;
            doorList.Add(newdoor);


        }

        public void ReplaceADoor(int badgeId, string olddoor, string newdoor)
        {

            RemoveDooronBadge(badgeId, olddoor);
            AddDoorToBadge(badgeId, newdoor);



        }

    }
}

