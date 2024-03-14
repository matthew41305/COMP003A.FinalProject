/*
 * Author: Matthew Hudson
 * Course: COMP-003A
 * Purpose: Code for Final Project - BMI Calculator
 */
// TODO: missing exception handling - Done
namespace COMP003A.FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
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

                ///<summary>
                /// gets user's responses in relation to the array 
                /// </summary>
                /// <param name="QuestionResponses"> string input of questions</param>
                /// <returns> user's responses in the form of a list (question - answer)</returns>

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
                    // TODO: move this code block in a method -Done
                    string response = GatherResponse(questions[i]); // created method under name as CollectResponse
                    activityLevelResponse.Add(response);
                }
                ///<summary>
                /// Get user's responses as long as they aren't null
                /// </summary>
                /// <param name="GatherResponse"> string input for questions</param>
                /// <returns> question and the answer</returns>
                static string GatherResponse(string question)
                {
                    string response;
                    do
                    {
                        Console.Write($"{question}");
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

                    return response;
                }

                // Done
                // TODO: what is the purpose of this for loop? The purpose of this loop is to show the question to the user, get their response, and display
                // both the question and the response together.
                // TODO: what is the purpose of activityLevelResponse.Count? The purpose of activityLevelResponse is to get all the elements within the list and
                // count the user responses.
                // TODO: why is i initialized to 0? I is initialized to 0 because when working with an array, to start from the very beginning you must set i to 0.
                Console.WriteLine("".PadRight(100, '*'));
                for (int i = 0; i < activityLevelResponse.Count; i++)
                {
                    Console.WriteLine($"{questions[i]} {activityLevelResponse[i]}");
                }
                Console.WriteLine("".PadRight(100, '*'));

                Console.WriteLine($"BMI: {bmi:F2}"); // gives calculated value to user
                Console.WriteLine($"BMI Index: {GetBMICategory(bmi)}");
                // TODO: consider putting these BMI note in a method - Done
            }
            catch ( Exception ex )
            {
                Console.WriteLine($"Our team apologizes, an error has occurred with our system... Please try again later!");
            }

        }

        // TODO: add xml comments - Done
        // Get user's age, age calculator section
        /// <summary>
        /// Gets user's input for their birth year and subtracts the current year
        /// </summary>
        /// <param name="CalculateAge">integer input</param>
        /// <returns> User's age</returns>
        static int CalculateAge(int birthYear)
        {
            int currentYear = DateTime.Now.Year; //establishes int for current year
            return currentYear - birthYear; // subtracts current year from given year to get age
        }

        /// Done
        /// <summary>
        /// prompts the user to input a character value and will not accept integer, special characters, or a null response
        /// </summary>
        /// <param name="GetValidatedName"> integer input and output</param>
        /// <returns> the user's name</returns>
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
        /// Done
        /// <summary>
        /// Get's user's name without allowing special character responses or integers, but it is not case sensitive
        /// </summary>
        /// <param name="IsAlpha"> string response for the user's name</param>
        /// <returns> user's name, not case sensitive but doesn't involve special characters</returns>
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

        ///Done
        /// <summary>
        /// gets user's input for their birth year but doesn't allow years before 1900 or past the year 2024 (current year)
        /// </summary>
        /// <param name="GetValidatedBirthYear"> string input</param>
        /// <returns>User's birthyear</returns>
        static int GetValidatedBirthYear(string prompt)
        {
            int birthYear;
            do
            {
                Console.Write(prompt);
                // Done
                // TODO: add a condition so it also doest not accept future years - added "&& birthYear <= 2024
                // TODO: what is the purpose of int.Tryparse()? - The purpose of int.Tryparse is to store the user's input and parses it as an integer
                // TODO: what is the purpose of the out keyword? The purpose of the out keyword is to 
                if (int.TryParse(Console.ReadLine(), out birthYear) && birthYear >= 1900 && birthYear <= 2024) // set the year range choice to 1900-2024
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

        // TODO: revise this xml comment for GetValidatedHeight - Done
        /// <summary>
        /// get's the user's height in the form (x x, feet and inches) doesn't accept values 0 0, stores for later calculation (BMI)
        /// </summary>
        /// <param name="GetValidatedHeight"> integer input</param>
        /// <returns>the user's heigh in feet and inches separated by a space</returns>
        static double[] GetValidatedHeight(string prompt)
        {
            double[] heightArray;
            // TODO: add a condition not to allow height 0 0 - Done
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

        // TODO: add xml comments - Done
        /// <summary>
        /// array for user's input in feet and inches (parses user response), doesn't allow responses such as 0 0
        /// </summary>
        /// <param name="input"> integer input for height</param>
        /// <param name="heightArray"> array for parsed height values</param>
        /// <param name="TryParseHeight">checks if entered value is parsable</param>
        /// <returns> User's height separated by a single space (ex. 5 8 )</returns>
        static bool TryParseHeight(string input, out double[] heightArray)
        {
            heightArray = new double[2];
            string[] parts = input.Split(' '); // this allows the feet and inches to be separated by the space
            // Done
            // TODO: what is the purpose of this if statement? The purpose is to take a validated height from the user based on the conditions that it the entered response
            // can be split via feet and inches and doesn't allow responses like 0 0.
            // TODO: what is the purpose of double.TryParse()? Parses the user's input from a string to a double value, if true it will execute, failure to parse means the entered value is not a parasable input
            // TODO: what is the purpose of the out keyword? The purpose of double.TryParse() is to pass and reference the double parsed value to 'heightArray'
            // TODO: what is the purpose of && operator? The purpose of && in this context is to connect added conditions within the array, for example not allowing values such as 0 0,
            if (parts.Length == 2 && double.TryParse(parts[0], out heightArray[0]) && double.TryParse(parts[1], out heightArray[1]) && (heightArray[0] != 0 || heightArray[1] != 0))
                
             /// (heightArray[0] != 0 || heightArray[1] != 0)) condition that doesn't allow user input to be 0, 0, ends off with a double )) to close it

            {
                return true;
            }
            return false;
        }

        // TODO: revise this xml comment for GetValidatedDouble
        /// <summary>
        /// gets User's input for for weight greater than 50 lbs, but less than 1000 lbs stores for later calculation (BMI)
        /// </summary>
        /// <param name="GetValidatedDouble"> integer input for weight</param>
        /// <returns> User's weight based on the following parameters</returns>
        static double GetValidatedDouble(string prompt)
        {
            double value;
            // TODO: add a condition not to allow 0 lbs input - Done
            do
            {
                Console.Write(prompt);
                // Done
                // TODO: what is the purpose of double.TryParse()? The purpose of double.TryParse() is it parses the user's input for their weight converting a string value to a double value.
                // depending on if it's true or not the code will execute properly or the code will be false.
                // TODO: what is the purpose of the out keyword? The purpose of 'out' in this context is to reference the parsed double value to the values 50 and 1000
                // assinging the response to the value variables
                // TODO: what is the purpose of && operator? The && operator allows for combining conditions that only execute if all parameters mark out to be true making
                // making sure that the parsed double value is within the range of 50 lbs to 1000 lbs
                if (double.TryParse(Console.ReadLine(), out value) && value >= 50 && value <= 1000)
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

        // TODO: revise this xml comment for CalculatBMI - Done
        ///<summary>
        /// calulates the user's bmi by taking previous information (height, weight) 
        /// the double first converts the feet into inches and adds the other inches
        /// calulates final Bmi
        /// </summary>
        /// <param name="CalculateBMI"> integer output</param>
        /// <returns>User's Bmi based on gathered info</returns>

        static double CalculateBMI(double heightFeet, double heightInches, double weightPounds)
        {
            double heightInInches = heightFeet * 12 + heightInches;

            return (weightPounds / (heightInInches * heightInInches)) * 703;
        }

        // TODO: add xml comments - Done
        // Get user's gender, gender section
        /// <summary>
        /// get's user's gender through M,F,O and returns Male, Female, or Other
        /// </summary>
        /// <param name="GetValidatedGender">string input</param>
        /// <returns>User's Gender in name form, m = male, f = female, o = other</returns>
        
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

        // TODO: revise this xml comment for GetBMICategory - Done
        /// <summary>
        /// After the bmi is outputted, the following executes deciding user's subject weight class
        /// </summary>
        /// <param name="GetBMICategory">integer and string output</param>
        /// <returns> Underweight, Normal Weight, Overweight or obese, and the adjustments to their daily caloric intake</returns>
        static string GetBMICategory(double bmi)
        {
            if (bmi < 18.5)
                return "Underweight; increase daily caloric intake by 200-500 calories (caloric surplus)";
            else if (bmi < 24.9)
                return "Normal Weight; continue eating maintence calories";
            else if (bmi < 29.9)
                return "Overweight; reduce daily caloric intake by 300 calories (caloric deficit)";
            else
                return "Obese; reduce daily caloric intake by 300-500 calories (caloric deficit)";
        }
    }
}
