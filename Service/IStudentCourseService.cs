using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public interface IStudentCourseService
    {
        public List<StudentCourse> GetAllStudentCourses();

        public void InsertStudentCourse(StudentCourseDTO? dto);

        public void UpdateStudentCourse(StudentCourseDTO? dto);

        public StudentCourse? DeleteStudentCourse(StudentCourseDTO? dto);

        public StudentCourse? GetStudentCourse(int id);
    }
}
