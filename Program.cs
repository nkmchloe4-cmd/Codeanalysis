using System;

namespace Kodanalys
{
    class Program
    {
        static string[] users = new string[10];
        static int userCount = 0;

        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\nVälj ett alternativ:");
                Console.WriteLine("1. Lägg till användare");
                Console.WriteLine("2. Visa alla användare");
                Console.WriteLine("3. Ta bort användare");
                Console.WriteLine("4. Sök användare");
                Console.WriteLine("5. Avsluta");
                Console.Write("Skriv ditt val här: ");
                string choice = ReadInput();

                switch (choice)
                {
                    case "1":
                        AddUser();
                        break;

                    case "2":
                        ShowUsers();
                        break;

                    case "3":
                        RemoveUser();
                        break;

                    case "4":
                        SearchUser();
                        break;

                    case "5":
                        isRunning = false;
                        Console.WriteLine("Programmet avslutas, Hejdå!");
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val.");
                        break;
                }
            }
        }
      
        static void AddUser()
        {
            Console.Clear();
            Console.Write("Ange namn att lägga till: ");
            string newUser = ReadInput();

            if (string.IsNullOrEmpty(newUser))
            {
                Console.WriteLine("Du måste ange ett namn");
                return;
            }
            if (userCount < 10)
            {
                users[userCount] = newUser;
                userCount++;
                Console.WriteLine("Användaren har lagts till i listan!");
            }
            else
            {
                Console.WriteLine("Listan är full! Du har nått max antal användare");
            }
        }

        static void ShowUsers()
        {
            Console.Clear();
            Console.WriteLine("Användare:");
            for (int i = 0; i < userCount; i++)
            {
                Console.WriteLine(users[i]);
            }
        }

        static void RemoveUser()
        {
            Console.Clear();
            Console.Write("Ange namn att ta bort: ");
            string removeUser = ReadInput();
            int userIndex = -1;

            for (int i = 0; i < userCount; i++)
            {
                if (users[i] == removeUser)
                {
                    userIndex = i;
                    break;
                }
            }

            if (userIndex != -1)
            {
                for (int i = userIndex; i < userCount - 1; i++)
                {
                    users[i] = users[i + 1];
                }
                userCount--;
                Console.WriteLine($"Användaren {removeUser} har tagits bort från listan.");
            }
            else
            {
                Console.WriteLine("Användaren hittades inte.");
            }
        }
        
        static void SearchUser()
        {
            Console.Clear();
            Console.Write("Ange namn att söka: ");
            string searchUser = ReadInput();
            bool userFound = false;
            for (int i = 0; i < userCount; i++)
            {
                if (users[i] == searchUser)
                {
                    userFound = true;
                    break;
                }
            }
            if (userFound)
            {
                Console.WriteLine("Användaren finns i listan.");
            }
            else
            {
                Console.WriteLine("Användaren hittades inte.");
            }
        }

        static string ReadInput()
        {
           return Console.ReadLine()?.Trim().ToUpper() ?? string.Empty;
        }
    }
}
