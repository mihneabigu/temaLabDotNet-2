using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;
using FluentAssertions;
using System;

namespace Tests {
    [TestClass]
    public class ProductUnitTests {
        [TestMethod]
        public void Given_TodayIsBetweenStartDateAndEndDate_When_IsValidIsCalled_Then_ShouldReturnTrue() {

            //Arrange
            Product product = new Product(1, "Paine", "Se mananca", DateTime.Parse("1/1/2009"), DateTime.Parse("1/1/2020"), 100, 20);

            //Act
            bool isValid = product.IsValid();

            //Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void Given_TodayIsAfterEndDate_When_IsValidIsCalled_Then_ShouldReturnFalse() {

            //Arrange
            Product product = new Product(1, "Paine", "Se mananca", DateTime.Parse("1/1/2009"), DateTime.Parse("1/1/2015"), 100, 20);

            //Act
            bool isValid = product.IsValid();

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void Given_PriceAndVatAreCorrect_When_ComputeVatIsCalled_Then_ShouldReturnExpectedResult() {
            //Arrange
            Product product = new Product(1, "Paine", "Se mananca", DateTime.Parse("1/1/2009"), DateTime.Parse("1/1/2015"), 100, 20);
            int expectedResult = 120;

            //Act
            int actualResult = product.ComputeVAT();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Given_PriceOrVatIsWrong_When_ComputeVatIsCalled_Then_ShouldThrowArgumentException() {
            //Arrange
            Product product = new Product(1, "Paine", "Se mananca", DateTime.Parse("1/1/2009"), DateTime.Parse("1/1/2015"), 100, -30);

            //Act
            Action action = () => product.ComputeVAT();

            //Assert
            action.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void Given_CreatingNewProduct_When_ConstructorIsCalled_Then_ProductShouldBeCreated() {
            // Arrange && Act && Assert
            new Product(1, "Pizza", "ala", new DateTime(), new DateTime(), 100, 20).GetName().Should().Be("Pizza");
        }

        [TestMethod]
        public void Given_GettingProductName_When_GetNameIsCalled_Then_NameShouldBeCorrect() {
            // Arrange
            Product product = new Product(1, "Pizza", "ala", new DateTime(), new DateTime(), 100, 20);
            String testName = "Pizza";
            // Act && Assert
            product.GetName().Should().Be(testName);
        }

        [TestMethod]
        public void Given_ValidDate_When_IsValidIsCalled_Then_ShouldReturnTrue() {
            // Arrange && Act
            bool result = new Product(1, "Pizza", "ala", DateTime.Parse("1/1/2000"), DateTime.Parse("1/1/2020"), 100, 20).IsValid();
            // Assert
            result.Should().Be(true);
        }

        [TestMethod]
        public void Given_InvalidDate_When_IsValidIsCalled_Then_ShouldReturnTrue() {
            // Arrange && Act
            bool result = new Product(1, "Pizza", "ala", DateTime.Parse("1/1/2019"), DateTime.Parse("1/1/2020"), 100, 20).IsValid();
            // Assert
            result.Should().Be(false);
        }

        [TestMethod]
        public void Given_InvalidPriceOrVat_When_ComputeVATIsCalled_Then_ThrowsException() {
            // Arrange && Act
            Action action = () => new Product(1, "Pizza", "ala", DateTime.Parse("1/1/2019"), DateTime.Parse("1/1/2020"), -100, 20).ComputeVAT();
            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void Given_ValidPriceOrVat_When_ComputeVATIsCalled_Then_MethodShouldReturnGoodNumber() {
            // Arrange && Act
            int price = new Product(1, "Pizza", "ala", DateTime.Parse("1/1/2019"), DateTime.Parse("1/1/2020"), 100, 20).ComputeVAT();
            // Assert
            price.Should().Be(120);
        }
    }
}
