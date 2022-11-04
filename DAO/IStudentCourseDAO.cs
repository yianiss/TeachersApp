using SevStudentsApp.Models;

namespace SevStudentsApp.DAO
{

    public interface IStudentCourseDAO
    {
        void Insert(StudentCourse? studentcourse);

        void Update(StudentCourse? studentcourse);

        StudentCourse? Delete(StudentCourse? studentcourse);

        StudentCourse? GetStudentCourse(int id);

        List<StudentCourse> GetAll();
    }

}
