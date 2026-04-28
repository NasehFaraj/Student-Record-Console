using CSharp_SOLID_Architecture.Modules.Students.DTOs;
using CSharp_SOLID_Architecture.Modules.Students.Model;
using CSharp_SOLID_Architecture.Modules.Students.Service;

namespace CSharp_SOLID_Architecture.Modules.Students.Interaction;

public class StudentConsole
{
    private readonly StudentService _studentService;

    public StudentConsole(StudentService studentService)
    {
        _studentService = studentService;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("=== Students Menu ===");
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. View students");
            Console.WriteLine("3. Find student by id");
            Console.WriteLine("4. Delete student");
            Console.WriteLine("0. Back");
            Console.Write("Choose an option: ");

            string? choice = Console.ReadLine();

            if (choice == null)
                return;

            Console.WriteLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;

                    case "2":
                        ViewStudents();
                        break;

                    case "3":
                        FindStudentById();
                        break;

                    case "4":
                        DeleteStudent();
                        break;

                    case "0":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }
    }

    private void AddStudent()
    {
        string name = ReadRequiredText("Name: ");
        int age = ReadRequiredInt("Age: ");

        Student student = _studentService.CreateStudent(new CreateStudentDto
        {
            Name = name,
            Age = age
        });

        Console.WriteLine($"Student added. Id: {student.Id}");
    }

    private void ViewStudents()
    {
        IReadOnlyList<Student> students = _studentService.GetAllStudents();

        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        foreach (Student student in students)
        {
            PrintStudent(student);
        }
    }

    private void FindStudentById()
    {
        Guid id = ReadRequiredGuid("Student id: ");
        Student student = _studentService.GetStudentById(id);

        PrintStudent(student);
    }

    private void DeleteStudent()
    {
        Guid id = ReadRequiredGuid("Student id: ");

        _studentService.DeleteStudent(id);

        Console.WriteLine("Student deleted.");
    }

    private static string ReadRequiredText(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? value = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(value))
                return value;

            Console.WriteLine("Value is required.");
        }
    }

    private static int ReadRequiredInt(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? value = Console.ReadLine();

            if (int.TryParse(value, out int number))
                return number;

            Console.WriteLine("Please enter a valid number.");
        }
    }

    private static Guid ReadRequiredGuid(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? value = Console.ReadLine();

            if (Guid.TryParse(value, out Guid id))
                return id;

            Console.WriteLine("Please enter a valid id.");
        }
    }

    private static void PrintStudent(Student student)
    {
        Console.WriteLine($"Id: {student.Id}");
        Console.WriteLine($"Name: {student.Name}");
        Console.WriteLine($"Age: {student.Age}");
        Console.WriteLine($"Grade: {student.Grade}");
        Console.WriteLine();
    }
}
