
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;


using LetsGoPark.WebSite.Models;
using LetsGoPark.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Update
{
    public class UpdateTests
    {
        #region TestSetup
        public static UpdateModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            //Initialize the page model with ProductService
            pageModel = new UpdateModel(TestHelper.ProductService)
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
            pageModel.OnGet("Lake Roosevelt National Recreation Area");

            // Assert (verifying the expected outcome)
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Lake Roosevelt National Recreation Area", pageModel.Product.Title);
        }
        #endregion OnGet

        #region OnPost
        [Test]
        public void OnPost_Valid_Should_Return_Products()
        {
            // Arrange (preparing the necessary objects or data for the test)
            pageModel.Product = new ProductModel
            {
                Id = "San Juan Island National Historical Park",
                Title = "title",
                Description = "description",
                Url = "url",
                Image = "image"
            };

            // Act (performing the actual operation being tested)
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert (verifying the expected outcome)
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }

        [Test]
        public void OnPost_InValid_Model_NotValid_Return_Page()
        {
            // Arrange (preparing the necessary objects or data for the test)

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act (performing the actual operation being tested)
            var result = pageModel.OnPost() as ActionResult;

            // Assert (verifying the expected outcome)
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPost
    }
}