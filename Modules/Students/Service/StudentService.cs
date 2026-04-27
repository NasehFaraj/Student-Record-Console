using CSharp_SOLID_Architecture.Modules.Students.DTOs;
using CSharp_SOLID_Architecture.Modules.Students.Model;

namespace CSharp_SOLID_Architecture.Modules.Students.Service;
class StudentService
{
    
    public Student CreateStudent (CreateStudentDto student)
    {
        return new Student(student.Name , student.Age);
    }

    public Student UpdateStudent (Student student , UpdateStudentDto studentData)
    {
        if(studentData.Name != null)student.UpdateName(studentData.Name) ;

        if(studentData.Age.HasValue)student.UpdateAge(studentData.Age.Value) ;
        
        if(studentData.Grade.HasValue)student.UpdateGrade(studentData.Grade.Value) ;

        return student;
    }


}
