using System;
using Challenge6_GreenPlan;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge6_RepoTest
{
    [TestClass]
    public class UnitTest1
    {
        //I completed one unit test for all 4 repositories becuase the methods were the same amoungst them all
            private GasCarRepository _repo = new GasCarRepository();
        
        
        [TestInitialize]
        public void SeedGas()
        {
            GasCar f150 = new GasCar("Ford F-150", 16);
            GasCar fiestaST = new GasCar("Ford Fiesta ST", 25);

            _repo.AddGasCarToDirectory(f150);
            _repo.AddGasCarToDirectory(fiestaST);

        }
        [TestMethod]
        public void AddCarGetCount()
        {
            int expected = 2;
            int actual = _repo.GetGasContents().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddCarCountShouldIncrease()
        {

            GasCar focusST = new GasCar("Ford Focus ST", 25);

            bool wasAdded = _repo.AddGasCarToDirectory(focusST);

            Assert.IsTrue(wasAdded);

        }

        [TestMethod]
        public void GetGasByNameShouldGetGas()
        {
            GasCar focusST = new GasCar("Ford Focus ST", 25);

            _repo.AddGasCarToDirectory(focusST);
            GasCar test = _repo.GetGasByName("Ford Focus ST");

            Assert.AreEqual(focusST, test);
        }

        [TestMethod]
        public void UpdateCarShouldUpdate()
        {

            GasCar newCar = new GasCar("Ford F-150", 10);
            _repo.UpdateGasByName("Ford F-150", newCar);

            int expected = 10;
            int actual = _repo.GetGasByName("Ford F-150").GasMileage;
            Assert.AreEqual(expected, actual);

        }
       

    }
}

