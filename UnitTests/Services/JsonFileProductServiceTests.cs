using Microsoft.AspNetCore.Mvc;



using NUnit.Framework;



using LetsGoPark.WebSite.Pages.Product;
using LetsGoPark.WebSite.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace UnitTests.Services.JsonFileProductServiceTests
{
    public class JsonFileProductServiceTests
    {
        #region TestSetup
        // The pageModel instance is declared as a static variable
        public static UpdateModel pageModel;


        // This method is executed before each test method
        [SetUp]
        public void TestInitialize()
        {
            // Instantiate a new UpdateModel with the ProductService dependency from the TestHelper
            pageModel = new UpdateModel(TestHelper.ProductService);
        }



        #endregion TestSetup



        #region AddRating
        // Test method for the AddRating method of the ProductService class when the product is null
        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange

            // Act

            // Call the AddRating method of the ProductService with a null product



            var result = TestHelper.ProductService.AddRating(null, 1);



            // Assert
            Assert.AreEqual(false, result);
        }



        [Test]
        public void AddRating_InValid_()
        {
            // Arrange



            // Act
            //var result = TestHelper.ProductService.AddRating(null, 1);



            // Assert
            //Assert.AreEqual(false, result);
        }



        // ....



        [Test]
        public void AddRating_Valid_Product_Valid_Rating_Valid_Should_Return_True()
        {
            // Arrange



            // Get the first data item
            var data = TestHelper.ProductService.GetAllData().First();
            var countOriginal = data.Ratings.Length;



            // Act
            // Call the AddRating method of the ProductService with a valid product ID and rating
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetAllData().First();



            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }



        [Test]
        public void AddRating_Valid_Product_Valid_Rating_Less_Than_0_Should_Return_False()
        {
            // Arrange



            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();



            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, -1);



            // Assert
            Assert.AreEqual(false, result);
        }
        [Test]
        public void AddRating_Valid_Product_Valid_Rating_More_Than_5_Should_Return_False()
        {
            // Arrange



            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();



            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 6);



            // Assert
            Assert.AreEqual(false, result);
        }
        [Test]
        public void AddRating_Valid_Data_Invalid_Should_Return_False()
        {
            // Arrange



            // Act
            var result = TestHelper.ProductService.AddRating("----", 5);



            // Assert
            Assert.AreEqual(false, result);
        }
        [Test]
        public void AddRating_Valid_Product_Valid_Rating_InValid_Should_Return_True()
        {
            // Arrange



            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().Last();
            var tempData = data;



            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetAllData().Last();



            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
            Assert.AreEqual(null, tempData.Ratings);
        }



        #endregion AddRating



        #region UpdateData
        [Test]
        public void UpdateData_Valid_Data_InValid_Should_Return_Null()
        {
            // Arrange



            // Create the product which is invald
            pageModel.Product = TestHelper.ProductService.CreateData();
            pageModel.Product.Id = "Example to Test";



            // Act
            // Call the UpdateData method of the ProductService with the invalid product
            var result = TestHelper.ProductService.UpdateData(pageModel.Product);



            // Assert
            Assert.AreEqual(null, result);
        }
        #endregion UpdateData
    }
}
