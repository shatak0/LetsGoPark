using System.Linq;

using NUnit.Framework;

using LetsGoPark.WebSite.Pages.Product;


namespace UnitTests.Pages.Product.Create
{
    public class CreateTests
    {
        #region TestSetup
        //pageModel instance is declared as a static variable
        public static CreateModel pageModel;

        //method is executed before each test method
        [SetUp]
        public void TestInitialize()
        {
            //Instantiate a new CreateModel with the ProductService dependency from the TestHelper
            pageModel = new CreateModel(TestHelper.ProductService)
            {
             // Additional setup for the CreateModel instance can be added here if needed
            };
        }

        #endregion TestSetup

        #region OnGet
        // Test method for the OnGet() method of the CreateModel class
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange
            // Get the count of products before executing the OnGet() method
            var oldCount = TestHelper.ProductService.GetAllData().Count();

            // Act
            // Call the OnGet() method of the pageModel instance
            pageModel.OnGet();

            // Assert
            // Assert that the ModelState of the pageModel is valid
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            // Assert that the count of products has increased by one after executing the OnGet() method
            Assert.AreEqual(oldCount + 1, TestHelper.ProductService.GetAllData().Count());
        }
        #endregion OnGet
    }
}
