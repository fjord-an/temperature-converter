using System;

namespace Mod2_TempConverter
{
    internal static class TempConverter
    {
        internal static void Main()
        {
            char tempType = ' ';
            // by assigning a value to the variable, it can be changed in the if
            // statement below, otherwise it will not be accessible outside the if statement
            
            Console.WriteLine("Enter the temperature followed by c or f to convert to its counterpart: \n(e.g. 32c or 32f)");
            
            // assign the input to a variable as a string data type, so we can iterate to find the
            // character c or f to convert:
            var tempString = Console.ReadLine();

            foreach (var c in tempString.ToLower())
                // iterate through the input string and convert each character to lowercase
            {
                if (c == 'c')
                {
                    tempType = 'c';
                    tempString = tempString.Replace("c", "");
                    // https://learn.microsoft.com/en-us/dotnet/api/system.string.replace?view=net-8.0
                    // replace the character c with an empty string, so we can convert the remaining string to a double
                    // so we can use it in the ConvertTemp method below, otherwise we will get an exception
                    break;
                    
                }
                else if (c == 'f')
                {
                    tempType = 'f';
                    tempString = tempString.Replace("f", "");
                    break;
                    // break out of the loop once we find the character f
                }
            }
            
            // convert the input string to a double data type
            // using the Convert.ToDouble method as opposed to the double.Parse method to avoid null exceptions
            // this returns 0 if the input is not a number instead of throwing an exception from double.Parse
            var temp = Convert.ToDouble(tempString);

            // try-catch block to handle the exception thrown by the ConvertTemp method below
            try // try to convert the temperature to its counterpart
            {
                // ConvertTemp method will return the temperature passed through the tempType and handled by the switch statement
                Console.WriteLine("The temperature in " + (tempType == 'c' ? 'f' : 'c') + " is " + ConvertTemp(temp, tempType));
                //using the ternary operator to display the opposite temperature type in the output string
                // (boolean ? value1 : value2) where ? is the condition, and : is the else statement
            }
            catch (ArgumentException e)
            {
                // catch the exception thrown by the ConvertTemp method
                // and display the exception message
                Console.WriteLine(e.Message);
                Console.WriteLine("Restarting Program...\n");
                // call the Main method again to allow the user to enter a valid input
                Main();
            }

            Console.WriteLine("\nPress any key to close the program...");
            Console.ReadKey();
        }

        private static double ConvertTemp(double temp, char tempType)
        {
            // convert the temperature to its counterpart based on the temperature type parameter passed
            switch (tempType)
            {
                // switch statement is more efficient/clean than using if statements in this case
                case 'c':
                    return (temp * 9/5) + 32;
                case 'f':
                    return (temp - 32) * 5/9;
                default:
                    // default case will always execute if none of the cases above are met
                    // throw an exception object if the temperature type is not c or f with a message
                    // this will be caught by the catch block in the Main method
                    throw new ArgumentException("Invalid temperature type!");
                    // https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception?view=net-8.0
            }
        }
    }
}