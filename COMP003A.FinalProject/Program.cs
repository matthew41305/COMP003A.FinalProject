/*
 * Author: Matthew Hudson
 * Course: COMP-003A
 * Purpose: Code for Final Project - BMI Calculator
 */
namespace COMP003A.FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("".PadRight(100, '*'));
            Console.WriteLine("Welcome to NutriFit, an app designed to cater your weight loss or weight gain journey!");
            Console.WriteLine("".PadRight(100, '*'));
            Console.WriteLine("We will begin by gathering some basic information: ");
            Console.WriteLine("\n");


            string firstName = GetValidatedName("Enter your first name: ");
            string lastName = GetValidatedName("Enter your last name: ");

            /// <summary>
            /// Asks user for validated first name and last name
            /// </summary>
            /// <param name="name user input"> string input</param>
            /// <returns> name not allowing null, or special characters</returns>
            static string GetValidatedName(string prompt)
            {
                string name;
                do
                {
                    Console.Write(prompt);
                    name = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(name) && IsAlpha(name)) // is alpha is for character oriented respones, is AlphaNumeric allows both character and number responses
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect user input. Please enter a character response ex. Matthew - no including special characters or null responses.");
                    }
                } while (true);

                return name;
            }
            /// <summary>
            /// Makes sure that user response is not null
            /// </summary>
            /// <param name="ValidatedName"> string input </param>
            /// <returns> validated user response not involving null</returns>

            static bool IsAlpha(string input)
            {
                foreach (char c in input)
                {
                    if (!char.IsLetter(c)) // IsLetterorDigit is for IsAlhpaNumeric
                    {
                        return false;
                    }
                }
                return true;
            }

            /// <summary>
            /// this validates that the user response does not involve special characters or numbers
            /// </summary>
            /// <param name="ValidatedName2"> string input</param>
            /// <returns> validated character string input by user</returns>
            /// 

            {
                int birthYear = GetValidatedBirthYear("Enter the year you were born: "); // asks user what year they were born in, before prompt
            }

            static int GetValidatedBirthYear(string prompt)
            {
                int birthYear;
                do
                {
                    Console.Write(prompt);
                    if (int.TryParse(Console.ReadLine(), out birthYear) && birthYear >= 1900)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect User input, please enter a character oriented age past the year 1900");
                    }
                } while (true);

                return birthYear;
            }
           

            /// <summary>
            /// Requests user input for birth year
            /// </summary>
            /// <param name="birth year"> integer input</param>
            /// <returns> returns user's birth year depending on where it is called </returns>
           
            // Get user's gender section based off parameters
            Console.WriteLine("Based on the terms M,F,O (Male, Female, Other)");
            string gender = GetValidatedGender("Enter Gender: ");
            static string GetValidatedGender(string prompt)
            {
                string gender;
                do
                {
                    Console.Write(prompt);
                    gender = Console.ReadLine().ToUpper(); // makes user forced to response with capital character

                    switch (gender)
                    {
                       case  "M":
                            gender = "Male";
                           break;
                        case "F":
                            gender = "Female";
                             break;
                         case "O":
                            gender = "Other";
                             break;
                      default:
                        Console.WriteLine("Incorrect user input, please use the following values: M, F, O");
                           break;
                    }
                    

                } while (gender != "Male" && gender != "Female" && gender != "Other");

                return gender;
            }

                /// <summary>
                /// switch statement used to swap letters for full names, used to force user to use M,F,O for their validated gender this is due 
                /// </summary>
                /// <param name="gender prompt">string input</param>
                /// <returns> Validated Gender based on parameters</returns>

            Console.WriteLine("".PadRight(100, '*'));
            Console.WriteLine("User's Profile");
            Console.WriteLine($"First Name: {firstName}");
            Console.WriteLine($"Last Name: {lastName}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Year born: {birthYear}");
            Console.WriteLine($"Age: int {yearBorn}");
            Console.WriteLine("".PadRight(100, '*'));
        }
    }
}
