using System;
using Challenge2_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge2_RepoTest
{
    [TestClass]
    public class UnitTest1
    {
        private ClaimRepository _repo = new ClaimRepository();

        public void Seed()
        {

            Claim kevin = new Claim("123KB", ClaimType.CarAccident, "hit by old woman", 5.00m, new DateTime(2018, 01, 23), new DateTime(2018, 01, 24), true);
            Claim steve = new Claim("456SD", ClaimType.CarAccident, "hit by bus", 1000.00m, new DateTime(2018, 01, 25), new DateTime(2018, 01, 26), true);

            _repo.AddClaimToDirectory(kevin);
            _repo.AddClaimToDirectory(steve);
        }

        [TestMethod]
        public void AddClaimGetCount()
        {
            Seed();

            int expected = 2;
            int actual = _repo.GetContents().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddClaimCountShouldIncrease()
        {
            Claim kevin = new Claim("123KB", ClaimType.CarAccident, "hit by old woman", 5.00m, new DateTime(2018, 01, 23), new DateTime(2018, 01, 24), true);

            bool wasAdded = _repo.AddClaimToDirectory(kevin);

            Assert.IsTrue(wasAdded);

        }

        [TestMethod]
        public void GetClaimByIDShouldGetClaim()
        {
            Claim kevin = new Claim("123KB", ClaimType.CarAccident, "hit by old woman", 5.00m, new DateTime(2018, 01, 23), new DateTime(2018, 01, 24), true);
            
            _repo.AddClaimToDirectory(kevin);
            Claim testClaim = _repo.GetClaimByID("123KB");

            //assert
            Assert.AreEqual(kevin, testClaim);
        }

        [TestMethod]
        public void UpdateClaimShouldUpdate()
        {

            Seed();
            Claim newContent = new Claim("123KB", ClaimType.CarAccident, "hit by old woman", 5.00m, new DateTime(2018, 01, 23), new DateTime(2018, 01, 24), false);
            _repo.UpdateClaimByID("123KB", newContent);

            bool expected = false;
            bool actual = _repo.GetClaimByID("123KB").IsValid;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void RemoveClaimShouldRemove()
        {
            Seed();

            _repo.RemoveClaimByID("123KB");
            int expected = 1;
            int actual = _repo.GetContents().Count;
            Assert.AreEqual(expected, actual);

        }
    }
}
