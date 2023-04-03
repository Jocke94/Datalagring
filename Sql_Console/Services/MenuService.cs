using Sql_Console.Models;

namespace Sql_Console.Services
{
    internal class MenuService
    {
        public async Task MainMenuTask()
        {
            Console.Clear();
            Console.WriteLine("Jockes Sql Db");
            Console.WriteLine("\n[1] Log in as user");
            Console.WriteLine("[2] Log in as employee");
            Console.WriteLine("[3] Register new user");
            Console.WriteLine("[4] Register new employee");
            Console.WriteLine("[5] List all users");
            Console.WriteLine("[6] List all employees");
            Console.WriteLine("[7] List all issues");
            Console.WriteLine("[8] Find user or employee");
            Console.Write("\nSelect an option: ");
            Int32.TryParse(Console.ReadLine(), out int mainMenuChoice);
            switch (mainMenuChoice)
            {
                case 1:
                    UserMenu();
                    break;
                case 2:
                    EmployeeMenu();
                    break;
                case 3:
                    await RegisterNewUser();
                    break;
                case 4:
                    await RegisterNewEmployee();
                    break;
                case 5:
                    await ListAllUsers();
                    break;
                case 6:
                    await ListAllEmployees();
                    break;
                case 7:
                    ListAllIssues();
                    break;
                case 8:
                    await SearchUsersAndEmployees();
                    break;
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
        static void EmployeeMenu()
        {
            bool adminMenu = true;
            while (adminMenu)
            {
                Console.Clear();
                Console.WriteLine("Employee menu - ************current employee");
                Console.WriteLine("\n[1] Handle issue"); //????
                Console.WriteLine("[2] Back");
                Console.Write("\nSelect an option: ");
                Int32.TryParse(Console.ReadLine(), out int adminMenuChoice);
                switch (adminMenuChoice)
                {
                    case 1:
                        HandleIssue();
                        break;
                    case 2:
                        adminMenu = false;
                        break;
                }
            }
        }

        public async Task ListAllUsers()
        {
            Console.Clear();
            Console.WriteLine("Listing all users \n");
            Console.WriteLine("────────────────────────────────────");
            var allUsers = await UserService.GetAllUsersAsync();
            foreach (var user in allUsers)
            {
                Console.WriteLine($"Name: {user.FirstName} {user.LastName}");
                Console.WriteLine($"Address: {user.Address}, {user.City}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Phone number: {user.PhoneNumber}");
                Console.WriteLine("────────────────────────────────────");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public async Task ListAllEmployees()
        {
            Console.Clear();
            Console.WriteLine("Listing all employees \n");
            Console.WriteLine("────────────────────────────────────");
            var allEmployees = await EmployeeService.GetAllEmployeesAsync();
            foreach (var employee in allEmployees)
            {
                Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}");
                Console.WriteLine($"Address: {employee.Address}, {employee.City}");
                Console.WriteLine($"Email: {employee.Email}");
                Console.WriteLine($"Phone number: {employee.PhoneNumber}");
                Console.WriteLine("────────────────────────────────────");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        public async Task SearchUsersAndEmployees()
        {
            Console.Clear();
            Console.Write("Enter a user or employee email: ");
            string searchString = Console.ReadLine() ?? "";
            
            var userResult = await UserService.GetUserByEmailAsync(searchString);
            var employeeResult = await EmployeeService.GetEmployeeByEmailAsync(searchString);
            if (userResult != null)
            {
                Console.Clear();
                Console.WriteLine($"Name: {userResult.FirstName} {userResult.LastName}");
                Console.WriteLine($"Address: {userResult.Address}, {userResult.City}");
                Console.WriteLine($"Phone number: {userResult.PhoneNumber}");
            }
            else if (employeeResult != null)
            {
                Console.Clear();
                Console.WriteLine($"Name: {employeeResult.FirstName} {employeeResult.LastName}");
                Console.WriteLine($"Address: {employeeResult.Address}, {employeeResult.City}");
                Console.WriteLine($"Phone number: {employeeResult.PhoneNumber}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No user or employee found.");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        public async Task RegisterNewUser()
        {
            var newUser = new User();
            bool inputLoop = true;
            while (inputLoop)
            {
                Console.Clear();
                Console.WriteLine("Registering new user\n");
                Console.Write("First name: ");
                newUser.FirstName = Console.ReadLine() ?? "";
                Console.Write("Last name: ");
                newUser.LastName = Console.ReadLine() ?? "";
                Console.Write("Email: ");
                newUser.Email = Console.ReadLine() ?? "";
                Console.Write("Phone number: ");
                newUser.PhoneNumber = Console.ReadLine() ?? "";
                Console.Write("City: ");
                newUser.City = Console.ReadLine() ?? "";
                Console.Write("Address: ");
                newUser.Address = Console.ReadLine() ?? "";
                if (!String.IsNullOrEmpty(newUser.FirstName) &&
                    !String.IsNullOrEmpty(newUser.LastName) &&
                    !String.IsNullOrEmpty(newUser.Email) &&
                    !String.IsNullOrEmpty(newUser.PhoneNumber) &&
                    !String.IsNullOrEmpty(newUser.City) &&
                    !String.IsNullOrEmpty(newUser.Address))
                {
                    inputLoop = false;
                } 
                else
                {
                    Console.WriteLine("\nOne or more fields are empty. Please try again.");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
            await UserService.AddUser(newUser);
        }
        public async Task RegisterNewEmployee()
        {
            var newEmployee = new Employee();
            bool inputLoop = true;
            while (inputLoop)
            {
                Console.Clear();
                Console.WriteLine("Registering new employee\n");
                Console.Write("First name: ");
                newEmployee.FirstName = Console.ReadLine() ?? "";
                Console.Write("Last name: ");
                newEmployee.LastName = Console.ReadLine() ?? "";
                Console.Write("Email: ");
                newEmployee.Email = Console.ReadLine() ?? "";
                Console.Write("Phone number: ");
                newEmployee.PhoneNumber = Console.ReadLine() ?? "";
                Console.Write("City: ");
                newEmployee.City = Console.ReadLine() ?? "";
                Console.Write("Address: ");
                newEmployee.Address = Console.ReadLine() ?? "";
                if (!String.IsNullOrEmpty(newEmployee.FirstName) &&
                    !String.IsNullOrEmpty(newEmployee.LastName) &&
                    !String.IsNullOrEmpty(newEmployee.Email) &&
                    !String.IsNullOrEmpty(newEmployee.PhoneNumber) &&
                    !String.IsNullOrEmpty(newEmployee.City) &&
                    !String.IsNullOrEmpty(newEmployee.Address))
                {
                    inputLoop = false;
                }
                else
                {
                    Console.WriteLine("\nOne or more fields are empty. Please try again.");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
            await EmployeeService.AddEmployee(newEmployee);
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
    }
}
