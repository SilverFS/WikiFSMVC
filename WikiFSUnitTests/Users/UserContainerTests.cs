using BusinessLogic.Containers;
using BusinessLogic.Converter;
using BusinessLogic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcCore.Converters;
using MvcCore.Models;
using System.Collections.Generic;
using WikiFSUnitTests.Mockups;

namespace WikiFSUnitTests.Users
{
    [TestClass]
    public class UserContainerTests
    {
        [TestMethod]
        public void ShouldCreateUser()
        {
            // Arrange
            SQLUserContextMockup mockup = new SQLUserContextMockup();
            UserConverter converter = new UserConverter();
            UserContainer pageContainer = new UserContainer(mockup, converter);
            UserModel userModel = new UserModel
            {
                UserName = "Bruh man",
                Email = "arandom@email.net",
                Password = "That'ssomeP@ssword#",
                created_at = System.DateTime.Now,
            };

            // Act
            pageContainer.CreateUser(userModel);
            // Assert
            // Check if pagemodel.title is equal to title in mockup from list
            Assert.AreEqual(userModel.UserName, mockup.userList[1].UserName);
        }
    }
}
