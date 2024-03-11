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
        public void FizzBuzzFullInputTest(string value)
        {
            //Arrange
            var inputValues = "3, 5, 15, 1";
            var expectedResults = new FizzBuzzList
            {
                fizzBuzzes = new List<FizzBuzz>
                {
                    new FizzBuzz
                    {
                        input = "3",
                        validInput = true,
                        fizzBuzzOutput = "Fizz<br />",
                        divisions = new List<String>
                        {
                            new string("Divided 3 by 3"),
                            new string("Divided 3 by 5")
                        }
                    },

                    new FizzBuzz
                    {
                        input = "5",
                        validInput = true,
                        fizzBuzzOutput = "Buzz<br />",
                        divisions = new List<String>
                        {
                            new string("Divided 5 by 3"),
                            new string("Divided 5 by 5")
                        }
                    },

                    new FizzBuzz
                    {
                        input = "15",
                        validInput = true,
                        fizzBuzzOutput = "FizzBuzz<br />",
                        divisions = new List<String>
                        {
                            new string("Divided 15 by 3"),
                            new string("Divided 15 by 5")
                        }
                    },

                    new FizzBuzz
                    {
                        input = "1",
                        validInput = true,
                        fizzBuzzOutput = "Divided 1 by 3<br />Divided 1 by 5<br />",
                        divisions = new List<String>
                        {
                            new string("Divided 1 by 3"),
                            new string("Divided 1 by 5")
                        }
                    }
                }
                
            };

            //Act
            var actualResults = new FizzBuzzList(inputValues);


            //Assert
            
        }

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