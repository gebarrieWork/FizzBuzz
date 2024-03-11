using Microsoft.AspNetCore.Mvc;

namespace FizzBuzzParse.Models
{
    public class FizzBuzzList
    {
        public List<FizzBuzz> fizzBuzzes;
        public string userInput;
        public bool notEmpty = true;

        public FizzBuzzList()
        {
            fizzBuzzes = new List<FizzBuzz>();
            userInput = string.Empty;

        }

        public FizzBuzzList(string input)
        {
            fizzBuzzes = new List<FizzBuzz>();
            userInput = input;
            InputParse(input);
        }


        public void InputParse(string input)
        {
            try
            {
                var splitInput = input.Split(',');
                foreach (var item in splitInput)
                {
                    fizzBuzzes.Add(new FizzBuzz(item));
                }
            }
            catch (NullReferenceException)
            {
                notEmpty = false;
            }  
        }

    }
}
