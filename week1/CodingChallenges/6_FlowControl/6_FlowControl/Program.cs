



using System;

namespace _6_FlowControl
{
    public class Program
    {
        private static string username;
        private static string password;

        static void Main(string[] args)
        {
        }

        /// <summary>
        /// This method gets a valid temperature between -40 asnd 135 inclusive from the user
        /// and returns the valid int. 
        /// </summary>
        /// <returns></returns>
        public static int GetValidTemperature()
        {
            while (true){
                Console.Write("Enter a temperature between -40 and 135: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int temp))
                {
                    if (temp >= -40 && temp <= 135)
                    {
                        return temp; // ✅ valid input, return it
                    }
                    else
                    {
                        Console.WriteLine("Error: Temperature must be between -40 and 135.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Please enter a valid number.");
                }
            }
            
        }

        /// <summary>
        /// This method has one int parameter
        /// It prints outdoor activity advice and temperature opinion to the console 
        /// based on 20 degree increments starting at -20 and ending at 135 
        /// n < -20, Console.Write("hella cold");
        /// -20 <= n < 0, Console.Write("pretty cold");
        ///  0 <= n < 20, Console.Write("cold");
        /// 20 <= n < 40, Console.Write("thawed out");
        /// 40 <= n < 60, Console.Write("feels like Autumn");
        /// 60 <= n < 80, Console.Write("perfect outdoor workout temperature");
        /// 80 <= n < 90, Console.Write("niiice");
        /// 90 <= n < 100, Console.Write("hella hot");
        /// 100 <= n < 135, Console.Write("hottest");
        /// </summary>
        /// <param name="temp"></param>
        public static void GiveActivityAdvice(int temp)
        {
            string message = temp switch
                {
                    < -20       => "hella cold",
                    >= -20 and < 0   => "pretty cold",
                    >= 0 and < 20    => "cold",
                    >= 20 and < 40   => "thawed out",
                    >= 40 and < 60   => "feels like Autumn",
                    >= 60 and < 80   => "perfect outdoor workout temperature",
                    >= 80 and < 90   => "niiice",
                    >= 90 and < 100  => "hella hot",
                    >= 100 and < 135 => "hottest",
                    _                => "invalid temperature range"
                };

            Console.Write(message);
        }

        /// <summary>
        /// This method gets a username and password from the user
        /// and stores that data in the global variables of the 
        /// names in the method.
        /// </summary>
        public static void Register()
        {
            Console.WriteLine("Please Provide a usename");
            username = Console.ReadLine();

            Console.WriteLine("Please Provide a password");
            password = Console.ReadLine();

            Console.WriteLine("User saved successfully!");
        }

        /// <summary>
        /// This method gets username and password from the user and
        /// compares them with the username and password names provided in Register().
        /// If the password and username match, the method returns true. 
        /// If they do not match, the user is reprompted for the username and password
        /// until the exact matches are inputted.
        /// </summary>
        /// <returns></returns>
        public static bool Login()
        {
            while (true)
            {
                Console.WriteLine("Please provide a username:");
                string loginUsername = Console.ReadLine();

                Console.WriteLine("Please provide a password:");
                string loginPassword = Console.ReadLine();

                if (loginUsername == username && loginPassword == password)
                {
                    return true;
                }

                Console.WriteLine("Invalid credentials, try again.");
            }
        }

        /// <summary>
        /// This method has one int parameter.
        /// It checks if the int is <=42, Console.WriteLine($"{temp} is too cold!");
        /// between 43 and 78 inclusive, Console.WriteLine($"{temp} is an ok temperature");
        /// or > 78, Console.WriteLine($"{temp} is too hot!");
        /// For each temperature range, a different advice is given. 
        /// </summary>
        /// <param name="temp"></param>
        public static void GetTemperatureTernary(int temp)
        {
            if (temp <= 42) Console.WriteLine($"{temp} is too cold!");
            else if (temp >= 43 || temp <= 78) Console.WriteLine($"{temp} is an ok temperature");
            else Console.WriteLine($"{temp} is too hot!");
        }
    }//EoP
}//EoN
