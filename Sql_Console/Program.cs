using Sql_Console.Contexts;
using Sql_Console.Services;

namespace Sql_Console;

internal class Program
{
    static void Main(string[] args)
    {
        Test();
    }
    static async void Test()
    {
        var mainMenu = new MenuService();
        await mainMenu.MainMenuTask();
    }







}