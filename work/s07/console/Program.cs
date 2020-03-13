using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. View accounts");
                Console.WriteLine("2. View account by number");
                Console.WriteLine("3. Search");
                Console.WriteLine("4. Move");
                Console.WriteLine("5. New account");
                Console.WriteLine("6. Exit");
                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        ViewAccounts();
                        break;
                    case "2":
                        ViewAccountByNumber();
                        break;
                    case "3":
                        Search();
                        break;
                    case "4":
                        Move();
                        break;
                    case "5":
                        NewAccount();
                        break;
                    case "6":
                        running = false;
                        break;
                }
            }
        }

        private static List<Account> GetJson()
        {
            List<Account> getJson;
            using (StreamReader r = new StreamReader("C:/Users/user/Desktop/WebSoft/websoft/work/account.json"))
            {
                string file = r.ReadToEnd();
                getJson = JsonConvert.DeserializeObject<List<Account>>(file);
            }

            return getJson;
        }

        private static void ViewAccounts()
        {
            //Loading the JSON file from the specified path using a JSON.NET library
            List<Account> file = GetJson();

            foreach (var account in file)
            {
                Console.WriteLine("Number\tOwner\tBalance\tLabel");
                Console.WriteLine($"{account.number}\t{account.owner}\t{account.balance}\t{account.label}");
            }
        }

        private static void ViewAccountByNumber()
        {
            Console.Write("Please enter the number of the account:");
            var number = Console.ReadLine();

            List<Account> file = GetJson();

            foreach (var account in file)
            {
                if (account.number.ToString() == number)
                {
                    Console.WriteLine("Number: " + account.number);
                    Console.WriteLine("Balance: " + account.balance);
                    Console.WriteLine("Label: " + account.label);
                    Console.WriteLine("Owner: " + account.owner);
                    break;
                }
            }
        }

        private static void Search()
        {
            Console.WriteLine("Enter your search term:");
            var search = Console.ReadLine();

            List<Account> file = GetJson();

            List<Account> searchLabel = file.FindAll(
                delegate(Account account) { return account.label.Contains(search); }
            );
            List<Account> searchNumber = file.FindAll(
                delegate(Account account) { return account.number.ToString().Contains(search); }
            );
            List<Account> searchOwner = file.FindAll(
                delegate(Account account) { return account.owner.ToString().Contains(search); }
            );

            var searchResults = searchLabel.Union(searchNumber).Union(searchOwner).ToList();
            if (searchResults.Count() != 0)
            {
                Console.WriteLine("+--------+---------+-----------+-------+");
                Console.WriteLine("| Number | Balance |   Label   | Owner |");

                foreach (var account in searchResults)
                {
                    Console.WriteLine("+--------+---------+-----------+-------+");
                    Console.Write("|");
                    for (int i = 0; i < 8 - account.number.ToString().Length; i++)
                    {
                        Console.Write(" ");
                    }

                    Console.Write(account.number);

                    Console.Write("|");
                    for (int i = 0; i < 9 - account.balance.ToString().Length; i++)
                    {
                        Console.Write(" ");
                    }

                    Console.Write(account.balance);

                    Console.Write("|");
                    for (int i = 0; i < 11 - account.label.Length; i++)
                    {
                        Console.Write(" ");
                    }

                    Console.Write(account.label);

                    Console.Write("|");
                    for (int i = 0; i < 7 - account.owner.ToString().Length; i++)
                    {
                        Console.Write(" ");
                    }

                    Console.Write(account.owner);
                    Console.WriteLine("|");
                }

                Console.WriteLine("+--------+---------+-----------+-------+");
            }
        }

        private static void Move()
        {
            Console.WriteLine("Enter the account number to send from:");
            var sender = Console.ReadLine();
            Console.WriteLine("Enter the receiver number:");
            var receiver = Console.ReadLine();
            Console.WriteLine("Enter the amount to move:");
            var amount = Console.ReadLine();
            var amountToMoveInt32 = Convert.ToInt32(amount);

            List<Account> file = GetJson();

            int accountToMoveTo = -1;
            int accountToMoveFrom = -1;

            for (int i = 0; i < file.Count; i++)
            {
                if (sender == file[i].number.ToString())
                {
                    accountToMoveFrom = i;
                }

                if (receiver == file[i].number.ToString())
                {
                    accountToMoveTo = i;
                }

                if (accountToMoveFrom != -1 && accountToMoveTo != -1)
                {
                    file[accountToMoveFrom].balance -= amountToMoveInt32;
                    file[accountToMoveTo].balance += amountToMoveInt32;
                    //update json file

                    string output = JsonConvert.SerializeObject(file);
                    File.WriteAllText(@"C:/Users/user/Desktop/WebSoft/websoft/work/account.json",
                        output);

                    break;
                }
            }
        }


        private static void NewAccount()
        {
            Console.WriteLine("Write the account number for the new account:");
            var accountNumber = Console.ReadLine();
            Console.WriteLine("Write the account label for the new account:");
            var accountLabel = Console.ReadLine();
            Console.WriteLine("Write the account owner for the new account:");
            var accountOwner = Console.ReadLine();

            List<Account> file = GetJson();

            Account newAccount = new Account
            {
                number = Convert.ToInt32(accountNumber),
                balance = 0,
                label = accountLabel,
                owner = Convert.ToInt32(accountOwner)
            };

            file.Add(newAccount);

            string output = JsonConvert.SerializeObject(file);
            File.WriteAllText(@"C:/Users/user/Desktop/WebSoft/websoft/work/account.json",
                output);
        }
    }
}