using Microsoft.AspNetCore.Mvc;

namespace FizzBuzzParse.Models
{
    /* Need to hold division history, final output/result, and be able to process the string inputted 
     * by the user
     * Check for invalid expressions (words, nothing)
     */
    public class FizzBuzz
    {
        
        public string input { get; set; }
        public bool validInput { get; set; }
        public string fizzBuzzOutput { get; set; }
        public List<String> divisions { get; set; }

        public string[] inputArray { get; set; }

        public FizzBuzz()
        {
            input = string.Empty;
            validInput = false;
            fizzBuzzOutput = string.Empty;
            divisions = new List<String>();
        }
        public FizzBuzz(string userInput)
        {
            input = userInput;
            validInput = false;
            fizzBuzzOutput = string.Empty;
            divisions = new List<String>();
        }
        

        public void InputCheck()
        {
            try
            {
                int value = Int32.Parse(input);
                if (input != "")
                {
                    validInput = true;
                }
            }
            catch (FormatException)
            {
                validInput =  false;
            }
            catch (ArgumentNullException)
            {
                validInput = false;
            }
            catch (OverflowException)
            {
                validInput = false;
            }
            return;
        }
        public void Parse()
        {
            try
            {
                int value = Int32.Parse(input);

                if (value % 3 == 0)
                {
                    fizzBuzzOutput += "Fizz";
                }
                LogDivision(3);
                if (value % 5 == 0)
                {
                    fizzBuzzOutput += "Buzz";
                }
                LogDivision(5);
                if (fizzBuzzOutput != string.Empty)
                {
                    fizzBuzzOutput += "<br />";
                }
            }
            catch (Exception ex)
            {
            }
            return;
        }

        public void LogDivision(int divisor)
        {
            this.divisions.Add("Divided " + input + " by " + divisor);
            return;
        }

        public string PrintOutput()
        {
            string output = string.Empty;
            if (!this.validInput)
            {
                output = "Invalid Item <br />";
            }
            else if (this.fizzBuzzOutput == "")
            {
                output = String.Join("<br />", divisions);
                output += "<br />";
            }
            else
            { 
                output = this.fizzBuzzOutput;
            }
            return output;
        }

    }
}
