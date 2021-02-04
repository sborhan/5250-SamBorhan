﻿using Mine.Models;
using NUnit.Framework;

namespace UnitTests.Models
{
    [TestFixture]
    public class HomeMenuItemTests
    {
        [Test]
        public void HomeMenuItem_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new HomeMenuItem();
            // Reset

            // Assert 
            Assert.IsNotNull(result);

        }

        [Test]
        public void HomeMenuItem_Set_Get_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new HomeMenuItem();
            result.Id = MenuItemType.Items;
            result.Title = "New Item";

            // Reset

            // Assert 
            Assert.AreEqual("New Item", result.Title);
            Assert.AreEqual(MenuItemType.Items, result.Id);
        }

    }
}
