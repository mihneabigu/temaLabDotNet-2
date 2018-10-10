using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Classes.Tests {

    [TestClass]
    public class ProductRepositoryUnitTests {

        private ProductRepository SUT;
        private const String PRODUCT_NAME_FOR_TEST = "Pizza";
        private const int SIZE_AFTER_ADD = 4;

        [TestInitialize]
        public void TestInitialize() {
            SUT = new ProductRepository(new Product(1, "Lapte", "Se bea", DateTime.Parse("1/1/2010"), DateTime.Parse("1/1/2020"), 100, 20), new Product(1, "Pizza", "Se bea", DateTime.Parse("1/1/2010"), DateTime.Parse("1/1/2020"), 100, 20), new Product(1, "Paine", "Se bea", DateTime.Parse("1/1/2010"), DateTime.Parse("1/1/2020"), 100, 20));
        }

        [TestCleanup]
        public void TestCleanup() {
            SUT = null;
        }

        [TestMethod]
        public void Given_ProductName_When_GetProductByNameIsCalled_Then_ReturnsExpectedResult() {
            // Arrange
            Product expectedResult = new Product(1, "Pizza", "Se bea", DateTime.Parse("1/1/2010"), DateTime.Parse("1/1/2020"), 100, 20);
            // Act
            Product actualResult = SUT.GetProductByName(PRODUCT_NAME_FOR_TEST);
            // Assert
            Assert.IsTrue(expectedResult.GetName().Equals(actualResult.GetName()));
        }

        [TestMethod]
        public void Given_ProductNameNotAvailable_When_GetProductByNameIsCalled_Then_ThrowsException() {
            // Arrange && Act
            Action action = () => SUT.GetProductByName("Alabalaportocala");
            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void Given_LessThanThreeParamsToConstructor_When_ConstructorIsCalled_Then_ThrowsException() {
            // Arrange && Act
            Action action = () => new ProductRepository(new Product(1, "ala", "aasdas", new DateTime(), new DateTime(), 100, 20));
            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void Given_AddProduct_When_AddProductIsCalled_Then_ShouldAddNewProduct() {
            // Arrange && Act
            SUT.AddProduct(new Product(1, "ala", "aasdas", new DateTime(), new DateTime(), 100, 20));
            // Assert
            SUT.FindAllProducts().Count.Should().Be(SIZE_AFTER_ADD);
        }

        [TestMethod]
        public void Given_AddProductWithNullParam_When_AddProductIsCalled_Then_ThrowsException() {
            // Arrange && Act
            Action action = () => SUT.AddProduct(null);
            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void Given_AvailableIndex_When_GetProductByPositionIsCalled_Then_ShouldReturnProductAtIndex() {
            // Arrange && Act && Assert
            SUT.GetProductByPosition(1).GetName().Should().Be(PRODUCT_NAME_FOR_TEST);
        }

        [TestMethod]
        public void Given_IndexOutOfBoundsBiggerThanListCount_When_GetProductByPositionIsCalled_Then_ThrowsException() {
            // Arrange && Act
            Action action = () => SUT.GetProductByPosition(30);
            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void Given_IndexOutOfBoundsNegativeNumber_When_GetProductByPositionIsCalled_Then_ThrowsException() {
            // Arrange && Act
            Action action = () => SUT.GetProductByPosition(-5);
            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void Given_RemovingProductByName_When_RemoveProductByNameIsCalled_Then_ListCountShouldBeTwo() {
            // Arrange && Act
            SUT.RemoveProductByName(PRODUCT_NAME_FOR_TEST);
            // Assert
            SUT.FindAllProducts().Count.Should().Be(2);
        }
    }
}