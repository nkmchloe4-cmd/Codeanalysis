using System;
using System.Collections.Generic;
using System.Linq;

namespace Kodanalys
{
    class Program
    {
        static List<User> userList = new List<User>();

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Välj ett alternativ:");
                Console.WriteLine("1. Lägg till användare");
                Console.WriteLine("2. Visa alla användare");
                Console.WriteLine("3. Ta bort användare");
                Console.WriteLine("4. Sök användare");
                Console.WriteLine("5. Avsluta");
                string input = Console.ReadLine();

                switch (input)
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
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void AddUser()
        {
            Console.Write("Ange namn: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                userList.Add(new User { Name = name });
                Console.WriteLine($"{name} har lagts till.");
            }
            else
            {
                Console.WriteLine("Namnet kan inte vara tomt.");
            }
        }

        static void ShowUsers()
        {
            Console.WriteLine("Användare:");
            if (userList.Any())
            {
                foreach (var user in userList)
                {
                    Console.WriteLine(user.Name);
                }
            }
            else
            {
                Console.WriteLine("Listan är tom.");
            }
        }

        static void RemoveUser()
        {
            Console.Write("Ange namn att ta bort: ");
            string name = Console.ReadLine();
            var userToRemove = FindUserByName(name);

            if (userToRemove != null)
            {
                userList.Remove(userToRemove);
                Console.WriteLine($"{name} har tagits bort.");
            }
            else
            {
                Console.WriteLine("Användaren hittades inte.");
            }
        }

        static void SearchUser()
        {
            Console.Write("Ange namn att söka: ");
            string name = Console.ReadLine();
            var user = FindUserByName(name);

            if (user != null)
            {
                Console.WriteLine("Användaren finns i listan.");
            }
            else
            {
                Console.WriteLine("Användaren hittades inte.");
            }
        }

        static User FindUserByName(string name)
        {
            return userList.FirstOrDefault(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
