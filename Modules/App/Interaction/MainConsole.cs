using CSharp_SOLID_Architecture.Modules.Students.Interaction;

namespace CSharp_SOLID_Architecture.Modules.App.Interaction;

public class MainConsole
{
    private readonly StudentConsole _studentConsole;

    public MainConsole(StudentConsole studentConsole)
    {
        _studentConsole = studentConsole;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("=== Main Menu ===");
            Console.WriteLine("1. Students");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();

            if (choice == null)
                return;

            switch (choice)
            {
                case "1":
                    _studentConsole.Run();
                    break;

                case "0":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
