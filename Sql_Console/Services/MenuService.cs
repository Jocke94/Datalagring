using Sql_Console.Models;

namespace Sql_Console.Services;

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
        Console.WriteLine("[8] Search for specific user or employee");
        Console.WriteLine("[9] Search for specific issue");
        Console.Write("\nSelect an option: ");
        Int32.TryParse(Console.ReadLine(), out int mainMenuChoice);
        switch (mainMenuChoice)
        {
            case 1:
                await UserMenu();
                break;
            case 2:
                await EmployeeMenu();
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
                await ListAllIssues();
                break;
            case 8:
                await SearchUsersAndEmployees();
                break;
            case 9:
                await SearchIssue();
                break;
        }
    }

    public async Task UserMenu()
    {
        bool search = true;
        var currentUser = new User();
        while (search)
        {
            Console.Clear();
            Console.Write("Enter a user email: ");
            string inputEmail = Console.ReadLine() ?? "";
            currentUser = await UserService.GetUserByEmailAsync(inputEmail);
            if (currentUser != null)
            {
                search = false;
            }
            else
            {
                Console.WriteLine("\nNo user found. Please try again.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }
        }
        
        bool userMenu = true;
        while (userMenu)
        {
            Console.Clear();
            Console.WriteLine($"User menu - {currentUser.FirstName} {currentUser.LastName}");
            Console.WriteLine("\n[1] Submit issue");
            Console.WriteLine("[2] Back");
            Console.Write("\nSelect an option: ");
            Int32.TryParse(Console.ReadLine(), out int userMenuChoice);
            switch (userMenuChoice)
            {
                case 1:
                    await SubmitIssue(currentUser);
                    break;
                case 2:
                    userMenu = false;
                    break;
            }
        }
    }
    public async Task EmployeeMenu()
    {
        bool search = true;
        var currentEmployee = new Employee();
        while (search)
        {
            Console.Clear();
            Console.Write("Enter an employee email: ");
            string inputEmail = Console.ReadLine() ?? "";
            currentEmployee = await EmployeeService.GetEmployeeByEmailAsync(inputEmail);
            if (currentEmployee != null)
            {
                search = false;
            }
            else
            {
                Console.WriteLine("\nNo employee found. Please try again.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }
        }

        bool employeeMenu = true;
        while (employeeMenu)
        {
            Console.Clear();
            Console.WriteLine($"Employee menu - {currentEmployee.FirstName} {currentEmployee.LastName}");
            Console.WriteLine("\n[1] Change issue status");
            Console.WriteLine("[2] Comment on issue");
            Console.WriteLine("[3] Back");
            Console.Write("\nSelect an option: ");
            Int32.TryParse(Console.ReadLine(), out int employeeMenuChoice);
            switch (employeeMenuChoice)
            {
                case 1:
                    await ChangeIssueStatus();
                    break;
                case 2:
                    await CommentOnIssue();
                    break;
                case 3:
                    employeeMenu = false;
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
            Console.WriteLine($"Email: {userResult.Email}");
            Console.WriteLine($"Address: {userResult.Address}, {userResult.City}");
            Console.WriteLine($"Phone number: {userResult.PhoneNumber}");
        }
        else if (employeeResult != null)
        {
            Console.Clear();
            Console.WriteLine($"Name: {employeeResult.FirstName} {employeeResult.LastName}");
            Console.WriteLine($"Email: {employeeResult.Email}");
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
    public async Task SubmitIssue(User currentUser)
    {
        var newIssue = new Issue();
        bool inputLoop = true;
        while (inputLoop)
        {
            Console.Clear();
            Console.WriteLine("Submitting issue\n");
            Console.Write("Title: ");
            newIssue.Title = Console.ReadLine() ?? "";
            Console.Write("Description: ");
            newIssue.Description = Console.ReadLine() ?? "";
            if (!String.IsNullOrEmpty(newIssue.Title) && !String.IsNullOrEmpty(newIssue.Description))
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
        newIssue.DateOpened = DateTime.Now;
        newIssue.StatusId = 1;
        newIssue.UserId = currentUser.Id;
        await IssueService.SubmitIssueAsync(newIssue);
    }
    public async Task ChangeIssueStatus()
    {
        Console.Clear();
        Console.Write("Enter issue ID (guid): ");
        Guid.TryParse(Console.ReadLine(), out Guid searchGuid);
        var issueResult = await IssueService.GetIssueByIdAsync(searchGuid);
        bool inputLoop = true;
        while (inputLoop)
        {
            Console.Clear();
            if (issueResult != null)
            {
                await OutputIssue(issueResult);
                Console.WriteLine("\nChange status");
                Console.WriteLine($"\n[1] Open");
                Console.WriteLine($"[2] Ongoing");
                Console.WriteLine($"[3] Closed");
                Console.Write("\nSelect an option: ");
                Int32.TryParse(Console.ReadLine(), out int statusChoice);
                if (statusChoice >= 1 && statusChoice <= 3)
                {
                    await IssueService.ChangeIssueStatusAsync(issueResult.Id, statusChoice);
                    inputLoop = false;
                }
            }
            else
            {
                Console.WriteLine("\nNo issue found.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }
        }
    }
    public async Task CommentOnIssue()
    {
        Console.Clear();
        Console.Write("Enter issue ID (guid): ");
        Guid.TryParse(Console.ReadLine(), out Guid searchGuid);
        var issueResult = await IssueService.GetIssueByIdAsync(searchGuid);
        bool inputLoop = true;
        while (inputLoop)
        {
            Console.Clear();
            if (issueResult != null)
            {
                await OutputIssue(issueResult);
            }
            else
            {
                Console.WriteLine("\nNo issue found.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }
            var newComment = new Comment();
            Console.Write("\nComment (max 200): ");
            newComment.CommentString = Console.ReadLine() ?? "";
            if (newComment.CommentString.Length <= 200)
            {
                newComment.CommentDate = DateTime.Now;
                newComment.IssueId = issueResult.Id;
                await CommentService.SubmitCommentAsync(newComment);
                inputLoop = false;
            }
            else
            {
                Console.WriteLine("Comment too long.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
    public async Task ListAllIssues()
    {
        Console.Clear();
        Console.WriteLine("Listing all issues\n");
        Console.WriteLine("────────────────────────────────────────────────");
        var allIssues = await IssueService.GetAllIssuesAsync();
        
        foreach (var issue in allIssues)
        {
            await OutputIssue(issue);
            Console.WriteLine("────────────────────────────────────────────────");
        }
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    public async Task SearchIssue()
    {
        Console.Clear();
        Console.Write("Enter issue ID (guid): ");
        Guid.TryParse(Console.ReadLine(), out Guid searchGuid);
        var issueResult = await IssueService.GetIssueByIdAsync(searchGuid);
        Console.Clear();
        if (issueResult != null)
        {
            await OutputIssue(issueResult);
        }
        else
        {
            Console.WriteLine("No issue found.");
        }
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
    public async Task OutputIssue(Issue issue)
    {
        Console.WriteLine($"ID: {issue.Id}");
        Console.WriteLine($"Submitted by: {issue.FirstName} {issue.LastName}");
        Console.WriteLine($"At: {issue.DateOpened}");
        Console.WriteLine($"Title: {issue.Title}");
        Console.WriteLine($"Description: {issue.Description}");
        Console.WriteLine($"Status: {issue.Status}");
        var comments = await CommentService.GetAllCommentsForIssueAsync(issue.Id);
        if (comments.Count() > 0)
        {
            Console.WriteLine("\nComments:");
            foreach (var comment in comments)
            {
                Console.WriteLine($"\n{comment.CommentDate}");
                Console.WriteLine(comment.CommentString);
            }
        }
    }
}