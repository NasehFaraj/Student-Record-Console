namespace CSharp_SOLID_Architecture.Modules.Students.Model;

public class Student
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public int Age { get; private set; }
    public float Grade { get; private set; } = 0;
    public Guid? ClassroomId { get; private set; }


    public Student(string name, int age)
    {

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");

        if (age <= 0)
            throw new ArgumentException("Age must be greater than 0.");

        this.Name = name;
        this.Age = age;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");
        
        this.Name = name;
    }

    public void UpdateAge(int age)
    {
          
        if (age <= 0)
            throw new ArgumentException("Age must be greater than 0.");
        
        this.Age = age;
    }

    public void UpdateGrade(float grade)
    {
        if (grade < 0 || grade > 100)
            throw new ArgumentException("Grade must be between 0 and 100.");

        this.Grade = grade;
    }


    public void AddToStudentClass(Guid classroomId)
    {
        if (this.ClassroomId != null)
            throw new ArgumentException("Student is already assigned to a class.");

        this.ClassroomId = classroomId;
    }

    public void RemoveFromStudentClass()
    {
        if (this.ClassroomId == null)
            throw new ArgumentException("Student is not assigned to any class.");

        this.ClassroomId = null;
    }

    
}
