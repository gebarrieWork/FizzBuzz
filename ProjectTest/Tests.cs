using FizzBuzzParse.Models;
using FizzBuzzParse.Controllers;
using Xunit.Sdk;
using Microsoft.AspNetCore.Mvc;

namespace ProjectTest
{
    public class FizzBuzzUnitTest
    {
        [Theory]
        [InlineData("1", true)]
        [InlineData("", false)]
        [InlineData("3", true)]
        [InlineData("town", false)]
        [InlineData("15", true)]
        public void InputCheckTest(string value, bool expected)
        {
            //Arrange
            FizzBuzz f = new FizzBuzz(value);
            //Act
            f.InputCheck();
            //Assert
            Assert.Equal(expected, f.validInput);
        }

        [Theory]
        [InlineData("3", "Fizz<br />")]
        [InlineData("5", "Buzz<br />")]
        [InlineData("15", "FizzBuzz<br />")]
        public void ParseTest(string value, string expected)
        {
            //Arrange
            FizzBuzz f = new FizzBuzz(value);
            //Act
            f.Parse();
            //Assert
            Assert.Equal(expected, f.fizzBuzzOutput);
        }

        [Theory]
        [InlineData(3, new string[] {"Divided 8 by 3"})]
        [InlineData(5, new string[] {"Divided 8 by 5"})]
        public void LogDivisionTest(int divisor, string[] expectedOutput)
        {
            //Arrange
            var baseValue = "8";
            int input = divisor;
            FizzBuzz f = new FizzBuzz(baseValue);


            //Act
            f.LogDivision(input);

            //Assert
            Assert.Equal(expectedOutput, f.divisions);
        }


    }

    public class FizzBuzzIntegrationTest
    {
        [Theory]
        [InlineData("1", "Divided 1 by 3<br />Divided 1 by 5<br />")]
        [InlineData("3", "Fizz<br />")]
        [InlineData("15", "FizzBuzz<br />")]
        [InlineData("egg", "Invalid Item <br />")]
        public void FizzBuzzControllerTest(string value, string expectedOutput)
        {
            //Arrange
            HomeController c = new HomeController();
            //Act
            ViewResult v = c.Index(value) as ViewResult;

            //Assert
            Assert.Equal(expectedOutput, v.ViewData["Result"]);
        }
    }
}