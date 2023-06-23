using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using LetsGoPark.WebSite.Models;
using LetsGoPark.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Delete
{
    public class DeleteTests
    {
        #region TestSetup
        public static DeleteModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            // Initialize the page model with ProductService
            pageModel = new DeleteModel(TestHelper.ProductService)
            {
                // Additional initialization parameters can be added here if necessary
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            /// Arrange (preparing the necessary objects or data for the test)

            // Act (performing the actual operation being tested)
            pageModel.OnGet("Juanita Beach Park");

            // Assert (verifying the expected outcome)
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Juanita Beach Park", pageModel.Product.Title);
        }
        #endregion OnGet

        #region OnPostAsync
        [Test]
        public void OnPostAsync_Valid_Should_Return_Products()
        {
            /// Arrange (preparing the necessary objects or data for the test)

            // First Create the product to delete

            pageModel.Product = TestHelper.ProductService.CreateData();
            pageModel.Product.Title = "Example to Delete";
            TestHelper.ProductService.UpdateData(pageModel.Product);

            // Act (performing the actual operation being tested)
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert (verifying the expected outcome)
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));

            // Confirm the item is deleted
            Assert.AreEqual(null, TestHelper.ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(pageModel.Product.Id)));
        }

        [Test]
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange (preparing the necessary objects or data for the test)
            
            pageModel.Product = new ProductModel
            {
                Id = "bogus",
                Title = "bogus",
                Description = "bogus",
                Url = "bogus",
                Image = "bougs"
            };

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act (performing the actual operation being tested)
            var result = pageModel.OnPost() as ActionResult;

            // Assert (verifying the expected outcome)
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPostAsync
    }
}
