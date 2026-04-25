using StudentRecordConsole.Modules.Students.Model;

namespace StudentRecordConsole.Modules.Classroom.Model;
public class Classroom
{
    
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public List<Student> Students { get; private set; } = new();


    public Classroom(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");

        this.Name = name;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");
        
        this.Name = name;
    }

    public void AddStudent(Student s)
    {   

        s.AddToStudentClass(this.Id);
        this.Students.Add(s);
    }

    public void RemoveStudent(Student s)
    {
        s.RemoveFromStudentClass();
        this.Students.Remove(s);
    }

    
    public int GetNumberOfStudent()
    {
        return this.Students.Count;
    }

}
