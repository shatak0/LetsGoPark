

using NUnit.Framework;

using LetsGoPark.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Read
{
    public class ReadTests
    {
        #region TestSetup
        public static ReadModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            // Initialize the page model with ProductService
            pageModel = new ReadModel(TestHelper.ProductService)
            {
                // Additional initialization parameters can be added here if necessary
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange (preparing the necessary objects or data for the test)

            // Act (performing the actual operation being tested)
            pageModel.OnGet("LAKE SAMMAMISH STATE PARK");

            // Assert (verifying the expected outcome)
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("LAKE SAMMAMISH STATE PARK", pageModel.Product.Title);
        }
        #endregion OnGet
    }
}