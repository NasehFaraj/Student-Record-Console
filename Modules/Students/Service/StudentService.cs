using CSharp_SOLID_Architecture.Modules.Students.DTOs;
using CSharp_SOLID_Architecture.Modules.Students.Model;
using CSharp_SOLID_Architecture.Modules.Students.Repository;

namespace CSharp_SOLID_Architecture.Modules.Students.Service;

public class StudentService
{
    private readonly JsonStudentRepository _studentRepository;

    public StudentService(JsonStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    public Student CreateStudent (CreateStudentDto student)
    {
        Student newStudent = new Student(student.Name , student.Age);

        _studentRepository.Add(newStudent);

        return newStudent;
    }

    public IReadOnlyList<Student> GetAllStudents()
    {
        return _studentRepository.GetAll();
    }

    public Student GetStudentById(Guid id)
    {
        return _studentRepository.GetById(id);
    }

    public Student UpdateStudent (Guid id , UpdateStudentDto studentData)
    {
        Student student = _studentRepository.GetById(id);

        if(studentData.Name != null)student.UpdateName(studentData.Name) ;

        if(studentData.Age.HasValue)student.UpdateAge(studentData.Age.Value) ;
        
        if(studentData.Grade.HasValue)student.UpdateGrade(studentData.Grade.Value) ;

        _studentRepository.SaveChanges();

        return student;
    }

    public void DeleteStudent(Guid id)
    {
        _studentRepository.DeleteById(id);
    }
}
