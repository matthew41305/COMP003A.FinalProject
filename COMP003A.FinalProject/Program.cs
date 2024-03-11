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
            Console.WriteLine("".PadRight(100, '*'));

            string firstName = GetValidatedName("Enter your first name: ");
            string lastName = GetValidatedName("Enter your last name: ");

            ///<summary>
            ///asks user to input their first and last name
            /// </summary>
            /// <param name="name input"> string input</param>

            int birthYear = GetValidatedBirthYear("Enter the year you were born: ");
            int age = CalculateAge(birthYear);

            // Get user input for gender section based on parameters
            Console.WriteLine("Based on the terms M,F,O (Male, Female, Other)");
            string gender = GetValidatedGender("Enter Gender: ");

            // Bmi calculator requesting user inputs
            double[] heightArray = GetValidatedHeight("Enter your height (ex. 5 8 --> feet, inches): ");
            double weightPounds = GetValidatedDouble("Enter your weight in pounds (example 165lbs --> 165): ");

  

            // Bmi calculator
            double bmi = CalculateBMI(heightArray[0], heightArray[1], weightPounds);

            Console.WriteLine("".PadRight(100, '*')); // used to separated via astrics, can also use a separator
            Console.WriteLine("User's Profile");
            Console.WriteLine($"First Name: {firstName}");
            Console.WriteLine($"Last Name: {lastName}");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Height: {heightArray[0]} feet {heightArray[1]} inches"); // pulls from array 0 to give feet, and array 1 for the inches
            Console.WriteLine($"Weight: {weightPounds} pounds"); // gets weight after input

            Console.WriteLine("".PadRight(100, '*'));
            Console.WriteLine("BMI Calculator Section");
            Console.WriteLine("".PadRight(100, '*'));

            List<string> activityLevelResponse = new List<string>();

            Console.WriteLine("Activity Level Responses: "); //added line

            string[] questions = {
                "What is your activity level on a scale from 1-10 per week: ",
                "Goal to lose or gain weight: ",
                "Do you play any sports: ",
                "Do you eat fast food: ",
                "How much water do you drink in a day: ",
                "Do you have a gym membership: ",
                "Do you do calisthenics/workout at home: ",
                "Do you have a job that requires you to stand for long periods of time: ",
                "Do you have extra time on your hands to prepare your own meals: ",
                "How many hours of sleep do you get on average: ",
                "Do you take supplements (ex. Vitamins, Protein Powder, Creatine): "
            };

            // Loop to get non-null responses
            for (int i = 0; i < questions.Length; i++)
            {
                string response;
                do
                {
                    Console.Write($"{questions[i]}");
                    response = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(response))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect user input. Please enter a valid response.");
                    }
                } while (true);

                activityLevelResponse.Add(response);
            }

            // Display responses
            Console.WriteLine("".PadRight(100, '*'));
            for (int i = 0; i < activityLevelResponse.Count; i++)
            {
                Console.WriteLine($"{questions[i]} {activityLevelResponse[i]}");
            }
            Console.WriteLine("".PadRight(100, '*'));

            Console.WriteLine($"BMI: {bmi:F2}"); // gives calculated value to user
            Console.WriteLine($"BMI Index: {GetBMICategory(bmi)}");
            Console.WriteLine("".PadRight(100, '*'));
            Console.WriteLine("Based on your BMI refer to the following chart: ");
            Console.WriteLine("Standard weight; continue eating maintence calories");
            Console.WriteLine("Overweight; reduce daily caloric intake by 300 calories (caloric deficit)");
            Console.WriteLine("Underweight; increase daily caloric intake by 300 calories (caloric surplus)");
            Console.WriteLine("".PadRight(100, '*'));


        }

        // Get user's age, age calculator section
        static int CalculateAge(int birthYear)
        {
            int currentYear = DateTime.Now.Year;
            return currentYear - birthYear;
        }

        /// <summary>
        /// Age calculator that takes the current the are the user inputed age and subtracts them
        /// </summary>
        /// <param name="CalculateAge"> integer input and output</param>
        /// <returns> the user's age</returns>

        static string GetValidatedName(string prompt)
        {
            string name;
            do
            {
                Console.Write(prompt);
                name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name) && IsAlpha(name))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect user input. Please enter a character response, excluding special characters or null responses.");
                }
            } while (true);

            return name;
        }
        /// <summary>
        /// loop that makes the User unable to type in null responses 
        /// </summary>
        /// <param name="GetValidatedName"> string response for the user's name</param>
        /// <returns> name, not case sensitive but doesn't involve special characters</returns>

        static bool IsAlpha(string input) //IsAlpha is used for just character responses
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))  // clarified here by IsLetter not IsLetterNumber
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// allows the user to only use character inputs
        /// </summary>
        /// <param name="Name section"> string input</param>
        /// <returns> name restricted to only character oriented responses</returns>

        static int GetValidatedBirthYear(string prompt)
        {
            int birthYear;
            do
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out birthYear) && birthYear >= 1900) // sets year to be greater than or equal to the year 1900
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect User input, please enter a character-oriented age past the year 1900");
                }
            } while (true);

            return birthYear;
        }
        /// <summary>
        /// gets the user's birth year and stores the value allowing it to be used the age calculator
        /// </summary>
        /// <param name="GetValidatedBirthYear"> integer input</param>
        /// <returns>the user's birth year allowing only integer related responses</returns>

        static double[] GetValidatedHeight(string prompt)
        {
            double[] heightArray;
            do
            {
                Console.Write(prompt);
                string heightInput = Console.ReadLine();

                if (TryParseHeight(heightInput, out heightArray))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect user input, please use the following parameters (Feet inches) ");
                }
            } while (true);

            return heightArray;
        }

        static bool TryParseHeight(string input, out double[] heightArray)
        {
            heightArray = new double[2];
            string[] parts = input.Split(' '); // this allows the feet and inches to be separated by the '

            if (parts.Length == 2 && double.TryParse(parts[0], out heightArray[0]) && double.TryParse(parts[1], out heightArray[1]))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// get user's input for feet an inches and separates them by '
        /// </summary>
        /// <param name="heightArray"> integer input</param>
        /// <returns> height separated by a ' ex. 5'8</returns>



        static double GetValidatedDouble(string prompt)
        {
            double value;
            do
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out value) && value >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect user input, please enter a number great than 0");

                }
            } while (true);

            return value;
        }
        ///<summary>
        /// Causes the user to enter a value greater than 0, no negative values
        /// </summary>
        /// <param name="heightArray"> integer input</param>
        /// <returns> integer value that is greater than 0</returns>

        static double CalculateBMI(double heightFeet, double heightInches, double weightPounds)
        {
            double heightInInches = heightFeet * 12 + heightInches;

            return (weightPounds / (heightInInches * heightInInches)) * 703;
        }

        // Get user's gender, gender section
        static string GetValidatedGender(string prompt)
        {
            string gender;
            do
            {
                Console.Write(prompt);
                gender = Console.ReadLine().ToUpper();

                switch (gender)
                {
                    case "M":
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
            /// requests users for their gender, inputing a case sensitive M,F,O that later coverts to Male, Female, or Other
            /// </summary>
            /// <param name="GetValidatedGender">string input</param>
            /// <returns> User's Gender in name form, m = male, f = female, o = other</returns>
            
            static string GetBMICategory(double bmi)
            {
                if (bmi < 18.5)
                    return "Underweight";
                else if (bmi < 24.9)
                    return "Normal Weight";
                else if (bmi < 29.9)
                    return "Overweight";
                else
                    return "Obese";
            }
        }
    }
