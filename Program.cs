using CSharp_SOLID_Architecture.Modules.App.Interaction;
using CSharp_SOLID_Architecture.Modules.Students.Interaction;
using CSharp_SOLID_Architecture.Modules.Students.Repository;
using CSharp_SOLID_Architecture.Modules.Students.Service;

JsonStudentRepository studentRepository = new JsonStudentRepository();
StudentService studentService = new StudentService(studentRepository);
StudentConsole studentConsole = new StudentConsole(studentService);
MainConsole mainConsole = new MainConsole(studentConsole);

mainConsole.Run();
