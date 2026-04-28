using CSharp_SOLID_Architecture.Modules.Students.Model;
using System.Text.Json;

namespace CSharp_SOLID_Architecture.Modules.Students.Repository;

public class JsonStudentRepository
{
    private readonly string _filePath = "Data/students.json";
    private readonly List<Student> _students;


    public JsonStudentRepository()
    {
        _students = LoadStudents();
    }   


    private List<Student> LoadStudents()
    {
        if(!File.Exists(_filePath)) return new List<Student>();

        string file = File.ReadAllText(_filePath);

        if (string.IsNullOrWhiteSpace(file)) return new List<Student>();
        
        return JsonSerializer.Deserialize<List<Student>>(file) ?? new List<Student>();

    }


    public void SaveChanges()
    {
        Directory.CreateDirectory("Data");

        string json = JsonSerializer.Serialize(_students, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(_filePath, json);
    }

    public void Add(Student student) 
    {
        _students.Add(student) ;
        SaveChanges();
    }

    public IReadOnlyList<Student> GetAll()
    {
        return _students;
    }

    public Student GetById(Guid Id)
    {
        Student? student = _students.Find(student => student.Id == Id);
        
        if(student == null)
        {
            throw new ArgumentException("Student not found.") ;
        }
        
        return student;
    }

    public void DeleteById (Guid Id)
    {   
        Student? student = _students.Find(student => student.Id == Id);
        
        if(student == null)
        {
            throw new ArgumentException("Student not found.") ;
        }
        
        _students.Remove(student) ;
        SaveChanges();
    }


   

}
