using System;
using System.Collections.Generic;
using Challenge3_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge3_RepoTest
{
    [TestClass]
    public class UnitTest1
    {
        private BadgeRepository _repo = new BadgeRepository();
        List<string> _list1 = new List<string>();
        Dictionary<string, List<string>> badgeDictionary = new Dictionary<string, List<string>>();
        private List<Badge> _badgeDirectory = new List<Badge>();
        
        //[TestInitialize]
        /*public void Seed()
        {
            List<string> _b1DoorList = new List<string>();  //Badge 1 List
            Badge b1 = new Badge("B1", _b1DoorList); //Badge 1 Created
            _b1DoorList.Add("D1");  //Add #1 door to badge
            _b1DoorList.Add("D2");  //Add #2 door to badge
            _repo.AddBadgeToDirectory(b1);

            List<string> _b2DoorList = new List<string>(); //Badge 2 List
            Badge b2 = new Badge("B2", _b2DoorList); //Badge 2 Created
            _b2DoorList.Add("D2");  //Add #1 door to badge
            _repo.AddBadgeToDirectory(b2);

            List<string> _b3DoorList = new List<string>(); //Badge 3 List
            Badge b3 = new Badge("B3", _b3DoorList); //Badge 3 Created
            _b2DoorList.Add("D2"); //Add #1 door to badge
            _b2DoorList.Add("D3"); //Add #2 door to badge
            _repo.AddBadgeToDirectory(b3);

            List<string> _b4DoorList = new List<string>(); //Badge 4 List
            Badge b4 = new Badge("B4", _b4DoorList); //Badge 4 Created
            _b2DoorList.Add("D2"); //Add #1 door to badge
            _b2DoorList.Add("D4"); //Add #2 door to badge
            _repo.AddBadgeToDirectory(b4);

        }*/

       
        [TestMethod]
        public void AddBadgeGetCount()
        {
            _repo.DictionarySeed();

            int expected = 4;
            int actual = _repo.GetBadgeList().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddBadgeCountShouldIncrease()
        {
            
            Badge b1 = new Badge("B1", _list1); //Badge 1 Created
            _list1.Add("D1");  //Add #1 door to badge
            _list1.Add("D2");  //Add #2 door to badge

            bool wasAdded = _repo.AddBadgeToDirectory(b1);

            Assert.IsTrue(wasAdded);

        }

        [TestMethod]
        public void GetBadgeByIDShouldGetBadge()
        {
            Badge b1 = new Badge("B1", _list1); //Badge 1 Created
            _list1.Add("D1");  //Add #1 door to badge
            _list1.Add("D2");  //Add #2 door to badge

            _repo.AddBadgeToDirectory(b1);
            Badge testBadge = _repo.GetBadgeByID("B1");

            Assert.AreEqual(b1, testBadge);
        }

        [TestMethod]
        public void UpdateBadgeShouldUpdate()
        {

            Badge newItem = new Badge("B7", new List<string> { "D1", "D2" });
            _repo.UpdateBadgeByID("B4", newItem);

            string expected = "B7";
            string actual = _repo.GetBadgeByID("B7").BadgeID;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void UpdateDictionaryShouldUpdate()
        {

            _repo.DictionarySeed();

            List<Badge> listOfBadges = _repo.GetBadgeList();
            foreach (Badge line in listOfBadges)
            {
                badgeDictionary.Add(line.BadgeID, line.DoorNames);
            }



            bool expected = true;
            bool actual = false;
            if (badgeDictionary.ContainsKey("B1"))
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);
        }

      


          
    }
}
