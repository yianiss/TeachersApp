 using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public interface IStudentService
    {
        public List<Student> GetAllStudents();

        public void InsertStudent(StudentDTO? dto);

        public void UpdateStudent(StudentDTO? dto);

        public Student? DeleteStudent(StudentDTO? dto);

        public Student? GetStudent(int id);
    }
}
