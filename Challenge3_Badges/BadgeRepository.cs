using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Badges
{
    public class BadgeRepository
    {
        private List<Badge> _badgeDirectory = new List<Badge>();
        Dictionary<string, List<string>> badgeDictionary = new Dictionary<string, List<string>>();

        //CRUD - Create, Read, Update, Delete
        public bool AddBadgeToDirectory(Badge item)
        {
            int startingCount = _badgeDirectory.Count;
            _badgeDirectory.Add(item);
            bool wasAdded = _badgeDirectory.Count == startingCount + 1;
            return wasAdded;
        }

        public List<Badge> GetBadgeList()
        {
            return _badgeDirectory;
        }

        public Badge GetBadgeByID(string idName)
        {

            foreach (var item in _badgeDirectory)
            {
                if (item.BadgeID.ToLower() == idName.ToLower())
                {
                    return item;
                }
            }
            return null;

        }

        public bool UpdateBadgeByID(string idName, Badge newBadge)
        {
            Badge item = GetBadgeByID(idName);

            if (item == null)
            {
                return false;
            }
            else
            {
                item.BadgeID = newBadge.BadgeID;
                item.DoorNames = newBadge.DoorNames;
                return true;
            }
        }

        public void DictionarySeed()
        {
            List<string> _b1DoorList = new List<string>();  //Badge 1 List
            Badge b1 = new Badge("B1", _b1DoorList); //Badge 1 Created
            _b1DoorList.Add("D1");  //Add #1 door to badge
            _b1DoorList.Add("D2");  //Add #2 door to badge
            badgeDictionary.Add(b1.BadgeID, _b1DoorList); //Badge 1 in Dictionary
            _badgeDirectory.Add(b1);

            List<string> _b2DoorList = new List<string>(); //Badge 2 List
            Badge b2 = new Badge("B2", _b2DoorList); //Badge 2 Created
            _b2DoorList.Add("D2");  //Add #1 door to badge
            badgeDictionary.Add("B2", _b2DoorList);  //Badge 2 in Dictionary
            _badgeDirectory.Add(b2);

            List<string> _b3DoorList = new List<string>(); //Badge 3 List
            Badge b3 = new Badge("B3", _b3DoorList); //Badge 3 Created
            _b3DoorList.Add("D2"); //Add #1 door to badge
            _b3DoorList.Add("D3"); //Add #2 door to badge
            badgeDictionary.Add("B3", _b3DoorList);  //Badge 3 in Dictionary
            _badgeDirectory.Add(b3);

            List<string> _b4DoorList = new List<string>(); //Badge 4 List
            Badge b4 = new Badge("B4", _b4DoorList); //Badge 4 Created
            _b4DoorList.Add("D2"); //Add #1 door to badge
            _b4DoorList.Add("D4"); //Add #2 door to badge
            badgeDictionary.Add("B4", _b4DoorList);  //Badge 4 in Dictionary
            _badgeDirectory.Add(b4);

        }

        public void ConvertListToDictionary()
        {
            badgeDictionary.Clear();
            List<Badge> listOfBadges = GetBadgeList();
            foreach (Badge line in listOfBadges)
            {
                badgeDictionary.Add(line.BadgeID, line.DoorNames);
            }
            
        }
    }
}
