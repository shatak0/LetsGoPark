using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using NUnit.Framework;

using LetsGoPark.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Index
{
    public class IndexTests
    {
        #region TestSetup
        public static PageContext pageContext;

        public static IndexModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            // This method is executed before each test case to set up any necessary configurations or dependencies.

            // Create a new instance of the IndexModel with the ProductService passed as a dependency
            pageModel = new IndexModel(TestHelper.ProductService)
            {
                // Set up any additional properties or configurations of the page model if required
            };
        }
        

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();
            // Assert
            // Validate that the ModelState is valid after the OnGet method is called
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            // Validate that the Products property of the page model contains at least one item
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }
        #endregion OnGet
    }
}