using Sql_Console.Contexts;

namespace Sql_Console;

internal class Program
{
    static void Main(string[] args)
    {
        var context = new DataContext();
        MainMenu();
    }
    static void MainMenu()
    {
        bool mainMenu = true;
        while (mainMenu)
        {
            Console.Clear();   
            Console.WriteLine("Jockes Sql Db");
            Console.WriteLine("\n[1] Log in as user");
            Console.WriteLine("[2] Log in as employee");
            Console.WriteLine("[3] Exit");
            Console.Write("\nSelect an option: ");
            Int32.TryParse(Console.ReadLine(), out int mainMenuChoice);
            switch (mainMenuChoice)
            {
                case 1:
                    UserMenu();
                    break;
                case 2:
                    AdminMenu();
                    break;
                case 3:
                    mainMenu = false;
                    break;
            }
        }
    }
    static void UserMenu()
    {
        int currentUser = 1; //????
        bool userMenu = true;
        while (userMenu)
        {
            Console.Clear();
            Console.WriteLine($"User menu - {currentUser}");
            Console.WriteLine("\n[1] Submit issue");
            Console.WriteLine("[2] View your issues");
            Console.WriteLine("[3] Back");
            Console.Write("\nSelect an option: ");
            Int32.TryParse(Console.ReadLine(), out int userMenuChoice);
            switch (userMenuChoice)
            {
                case 1:
                    SubmitIssue();
                    break;
                case 2:
                    ListUserIssues(currentUser); //ListUserIssues(currentUser??????)
                    break;
                case 3:
                    userMenu = false;
                    break;
            }
        }
    }
    static void AdminMenu()
    {
        bool adminMenu = true;
        while (adminMenu)
        {
            Console.Clear();
            Console.WriteLine("Admin menu");
            Console.WriteLine("\n[1] Handle issue"); //????
            Console.WriteLine("[2] List all issues");
            Console.WriteLine("[3] List issues by user");
            Console.WriteLine("[4] List users");
            Console.WriteLine("[5] Back");
            Console.Write("\nSelect an option: ");
            Int32.TryParse(Console.ReadLine(), out int adminMenuChoice);
            switch (adminMenuChoice)
            {
                case 1:
                    HandleIssue();
                    break;
                case 2:
                    ListAllIssues();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("List issues by user");
                    Console.Write("\nUser ID: ");
                    Int32.TryParse(Console.ReadLine(), out int userId);
                    ListUserIssues(userId);
                    break;
                case 4:
                    ListUsers();
                    break;
                case 5:
                    adminMenu = false;
                    break;
            }
        }
    }
    static void SubmitIssue()
    {
        Console.Clear();
        Console.WriteLine("Submit issue");
        Console.ReadLine();
    }
    static void ListUserIssues(int userId) //ska ta input
    {
        Console.Clear();
        Console.WriteLine($"Viewing issues by {userId}");
        Console.ReadLine();
    }
    static void HandleIssue()
    {
        Console.Clear();
        Console.WriteLine("Edit issue");
        Console.ReadLine();
    }
    static void ListAllIssues()
    {
        Console.Clear();
        Console.WriteLine("Viewing all issues");
        Console.ReadLine();
    }
    static void ListUsers()
    {
        Console.Clear();
        Console.WriteLine("Viewing all users");
        Console.ReadLine();
    }
}