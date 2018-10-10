using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;

namespace Classes.Tests {
    [TestClass]
    public class EmployeeUnitTests {

        private Employee sut;

        [TestInitialize]
        public void TestInitialize() {
            sut = new Manager(1, "Mihnea", "Bigu", new DateTime(), new DateTime(), 100);
        }

        [TestCleanup]
        public void TestCleanup() {
            sut = null;
        }

        [TestMethod]
        public void Given_FirstNameAndLastName_When_GetFullNameIsCalled_Then_ShouldReturnFullName() {
            
            //Arrange
            String expectedResult = "Mihnea Bigu";

            //Act
            String actualResult = sut.GetFullName();

            //Assert
            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void Given_TodayIsBetweenStartDateAndEndDate_When_IsActiveIsCalled_Then_ShouldReturnTrue() {

            //Arrange
            sut.SetStartDate(DateTime.Parse("1/1/2009"));
            sut.SetEndDate(DateTime.Parse("1/1/2020"));

            //Act
            bool isActive = sut.IsActive();

            //Assert
            Assert.IsTrue(isActive);
        }

        [TestMethod]
        public void Given_TodayIsBetweenStartDateAndEndDate_When_IsActiveIsCalled_Then_ShouldReturnFalse() {

            //Arrange
            sut.SetStartDate(DateTime.Parse("1/1/2019"));
            sut.SetEndDate(DateTime.Parse("1/1/2020"));

            //Act
            bool isActive = sut.IsActive();

            //Assert
            Assert.IsFalse(isActive);
        }
    }
}