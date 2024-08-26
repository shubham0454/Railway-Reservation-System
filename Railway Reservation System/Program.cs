using System;

namespace RailwayReservationSystem
{
    public class TrainBookingSystem
    {
        public static string registeredName;
        public static string registeredEmail;
        public static string registeredPassword;
        public static string registeredPhone;
        public static string registeredAge;
        public static string station;
        public static string destination;
        public static string traindate;
        public static int numberOfPeople;
        public static string[] peopleName;
        public static int count = 0;
        public static bool loggedIn = false;

        public class LoginSection
        {
            public void ChoiceSection()
            {
                while (loggedIn  == false)
                {
                    Console.WriteLine("1. Register");
                    Console.WriteLine("2. Login...");
                    Console.WriteLine("3. Exit....");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        count++;
                        Register();
                    }
                    else if (choice == 2)
                    {
                        if (count == 1)
                        {
                            Login();
                        }
                        else
                        {
                            Console.WriteLine("Register first....");
                        }
                    }
                    else if (choice == 3)
                    {
                        Console.WriteLine("Successfully exited....");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Choose the correct option.");
                    }
                }
            }

            public void Register()
            {
                Console.WriteLine("Enter your name: ");
                registeredName = Console.ReadLine();
                Console.WriteLine("Enter your email: ");
                registeredEmail = Console.ReadLine();
                Console.WriteLine("Enter your password: ");
                registeredPassword = Console.ReadLine();
                Console.WriteLine("Enter your phone number: ");
                registeredPhone = Console.ReadLine();
                Console.WriteLine("Enter your age: ");
                registeredAge = Console.ReadLine();
                Console.WriteLine("Registered successfully. Now login.");
                /*count = 1;*/
            }

            public void Login()
            {
                Console.WriteLine("Enter your login email: ");
                string loginEmail = Console.ReadLine();

                if (loginEmail == registeredEmail)
                {
                    Console.WriteLine("Enter your login password: ");
                    string loginPassword = Console.ReadLine();

                    if (loginPassword == registeredPassword)
                    {
                        Console.WriteLine("Login successful...");
                        loggedIn = true;
                        ShowMainMenu();
                    }
                    else
                    {
                        Console.WriteLine("Invalid password.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid email.");
                }
            }

            public void ShowMainMenu()
            {
                while (true)
                {
                    Console.WriteLine("\nEnter your choice: ");
                    Console.WriteLine("1. Book Train");
                    Console.WriteLine("2. Cancel Train");
                    Console.WriteLine("3. Exit");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    TrainBooking obj1 = new TrainBooking();

                    switch (choice)
                    {
                        case 1:
                            obj1.Booking();
                            break;
                        case 2:
                            obj1.CancelTicket();
                            break;
                        case 3:
                            Console.WriteLine("Exiting the Railway Reservation System. Visit again!");
                            return; 
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }

        public class TrainBooking
        {
            public void Booking()
            {
                Console.WriteLine("Enter the station name: ");
                station = Console.ReadLine();
                Console.WriteLine("Enter the destination station: ");
                destination = Console.ReadLine();
                Console.WriteLine("Enter the train date (yyyy:MM:DD): ");
                traindate = Console.ReadLine();
                Console.WriteLine("Enter the number of tickets to book: ");
                numberOfPeople = Convert.ToInt32(Console.ReadLine());
                peopleName = new string[numberOfPeople];

                for (int i = 0; i < numberOfPeople; i++)
                {
                    Console.WriteLine("Enter the name of passenger " + (i + 1) + ": ");
                    peopleName[i] = Console.ReadLine();
                }
                Console.WriteLine("Available train are select any one :");
                Console.WriteLine("1. "+station +","+ destination + ":" +traindate +" 12.50 Pm");                
                Console.WriteLine("2. "+station +","+ destination + ":" +traindate +" 4.50 Am");                
                Console.WriteLine("3. "+station +","+ destination + ":" +traindate +" 8.12 Am"); 

                int train = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("train select :" + train +"\n Total coast :" + (numberOfPeople*87));
                Console.WriteLine("Tickets booked successfully.");

            }

            public void CancelTicket()
            {
                Console.WriteLine("Ticket cancellation  vist again.");
                return;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TrainBookingSystem.LoginSection obj = new TrainBookingSystem.LoginSection();
            obj.ChoiceSection();
            Thread th = new Thread(obj.ChoiceSection);
            th.Start();
            th.Join();
           

        }
    }
}
