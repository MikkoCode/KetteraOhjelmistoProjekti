// See https://aka.ms/new-console-template for more information
using Gym_management_project.gym_management;
using Gym_management_project.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


class Program
{
    static void Main(string[] args)
    {
        ConsoleHelper.Clear();
        ConsoleHelper.WriteLine("GYM CONSOLE APP", ConsoleColor.DarkMagenta);
        ConsoleHelper.WriteLine();

        GymManagementContext? context = GetDatabaseContext();

        ProductModule productModule = new ProductModule(context);
        CustomerModule customerModule = new CustomerModule(context);
        MembershipModule membershipModule = new MembershipModule(context);

        var runAgain = true;
        while (runAgain) {
            var command = ShowMenu();
            switch (command) {
                case "1":
                    productModule.SearchProducts();
                    break;
                case "2":
                    productModule.AddProducts();
                    break;
                case "3":
                    customerModule.SearchCustomers();
                    break;
                case "NM":
                    membershipModule.StartMembership();
                    break;
                case "EM":
                    membershipModule.EndMembership();
                    break;
                case "x":
                case "X":
                    runAgain = false;
                    break;
                default:
                    ConsoleHelper.WriteLine($"Invalid command '{command}'. Try again!", ConsoleColor.DarkRed);
                    break;
            }
        }

        ConsoleHelper.WriteLine();
        ConsoleHelper.WriteLine("READY.");
        ConsoleHelper.WriteLine();
    }


    private static string ShowMenu()
    {
        var separtorLine = new string('-', 50);
        // ConsoleHelper.Clear();
        ConsoleHelper.WriteLine();
        ConsoleHelper.WriteLine();
        ConsoleHelper.WriteLine("MENU", ConsoleColor.DarkCyan);
        ConsoleHelper.WriteLine(separtorLine);
        ConsoleHelper.WriteLine();
        ConsoleHelper.WriteLine($"1 .... search products");
        ConsoleHelper.WriteLine($"2 .... add products");
        ConsoleHelper.WriteLine($"3 .... search customers");
        ConsoleHelper.WriteLine($"NM ... new membership");
        ConsoleHelper.WriteLine($"EM ... end membership");
        ConsoleHelper.WriteLine($"x ... exit");
        ConsoleHelper.WriteLine();
        var command = ConsoleHelper.Prompt("Command");
        return command;
    }


    private static GymManagementContext? GetDatabaseContext()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        var configuration = builder.Build();

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IConfiguration>(configuration);
        serviceCollection.AddDbContext<GymManagementContext>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var context = serviceProvider.GetService<GymManagementContext>();
        return context;
    }

}
