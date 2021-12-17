using BusinessLogic.Containers;
using BusinessLogic.Converter;
using BusinessLogic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WikiFSUnitTests.Mockups;

namespace WikiFSUnitTests.Pages
{
    [TestClass]
    public class PageContainerTests
    {
        [TestMethod]
        public void ShouldGetallTextWhenDalProvidesList()
        {
            // Arrange
            SQLPageContextMockup mockup = new SQLPageContextMockup();
            PageConverter converter = new PageConverter();
            PageContainer pageContainer = new PageContainer(mockup, converter);
            List<PageModel> list;

            // Act
            list = pageContainer.GetallText();

            // Assert
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void ShouldGetSinglePageWhenDalProvidesFunction()
        {
            // Arrange
            SQLPageContextMockup mockup = new SQLPageContextMockup();
            PageConverter converter = new PageConverter();
            PageContainer pageContainer = new PageContainer(mockup, converter);
            PageModel pageModel;

            // Act
            pageModel = pageContainer.GetPage(69);

            // Assert
            Assert.IsNotNull(pageModel);
            Assert.AreEqual(pageModel.ID, 69);
        }

        [TestMethod]
        public void ShouldCreatePage()
        {
            // Arrange
            SQLPageContextMockup mockup = new SQLPageContextMockup();
            PageConverter converter = new PageConverter();
            PageContainer pageContainer = new PageContainer(mockup, converter);
            PageModel pageModel;
            // Act
            //pageModel = pageContainer.CreatePage();
            // Assert
            Assert.IsNull(pageModel);
        }
    }
}
