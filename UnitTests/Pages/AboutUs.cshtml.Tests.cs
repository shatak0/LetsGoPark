using Microsoft.Extensions.Logging;



using NUnit.Framework;



using Moq;



using LetsGoPark.WebSite.Pages;

namespace UnitTests.Pages.AboutUs
{
    /// Testing for the AboutUs 

    public class AboutUsTests
    {
        #region TestSetup

        /// Page model for the AboutUs

        public static AboutUsModel pageModel;

        /// Initializing the test class

        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<AboutUsModel>>();



            pageModel = new AboutUsModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }



        #endregion TestSetup



        #region OnGet

        /// Testing  OnGet of the AboutUs 

        [Test]
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {
            // Arrange



            // Act
            pageModel.OnGet();


            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }



        #endregion OnGet
    }
}
