using Sql_Console.Services;

var mainMenu = new MenuService();
while (true)
{
    await mainMenu.MainMenuTask();
}
