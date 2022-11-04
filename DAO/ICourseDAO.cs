using SevStudentsApp.Models;

namespace SevStudentsApp.DAO
{
    public interface ICourseDAO
    {
        void Insert(Course? course);

        void Update(Course? course);

        Course? Delete(Course? course);

        Course? GetCourse(int id);   

        List<Course> GetAll();
    }
}
