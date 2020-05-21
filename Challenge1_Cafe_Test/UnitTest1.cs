using System;
using System.Collections.Generic;
using Challenge1_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge1_RepoTest
{
    [TestClass]
    public class UnitTest1
    {
        private MenuRepository _repo = new MenuRepository();
        private List<Ingredient> _ingredientList = new List<Ingredient>();

        public void Seed()
        {
            Ingredient chicken = new Ingredient("chicken");
            Ingredient bread = new Ingredient("bread");

            //Act or performed an action
            _ingredientList.Add(chicken);
            _ingredientList.Add(bread);

            //Arranged Data
            Menu chickenSandwich = new Menu(1, "Chicken Sandwich", "Chicken on a bun", _ingredientList, 5.99);
            Menu spicyChickSandwich = new Menu(2, "Spicy Chicken Sandwich", "Spicy Chicken on a bun", _ingredientList, 6.99);

            //Act or performed an action
            _repo.AddItemToMenuList(chickenSandwich);
            _repo.AddItemToMenuList(spicyChickSandwich);
        }
        

        [TestMethod]
        public void AddItemGetCount()
        {
            Seed();

            //Assert
            int expected = 2;
            int actual = _repo.GetMenuList().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddItemCountShouldIncrease()
        {
            Menu chickenSandwich = new Menu(1, "Chicken Sandwich", "Chicken on a bun", _ingredientList, 5.99);
            bool wasAdded = _repo.AddItemToMenuList(chickenSandwich);

            Assert.IsTrue(wasAdded);

        }

        [TestMethod]
        public void GetItemByNameShouldGetItem()
        {
            //arrange
            Menu chickenSandwich = new Menu(1, "Chicken Sandwich", "Chicken on a bun", _ingredientList, 5.99);
            _repo.AddItemToMenuList(chickenSandwich);
            Menu testItem = _repo.GetItemByName("Chicken Sandwich");

            //assert
            Assert.AreEqual(chickenSandwich, testItem);
        }

        [TestMethod]
        public void RemoveFromListShouldRemove()
        {
            Seed();

            _repo.RemoveItemByName("Chicken Sandwich");
            int expected = 1;
            int actual = _repo.GetMenuList().Count;
            Assert.AreEqual(expected, actual);

        }
    }
    
}
