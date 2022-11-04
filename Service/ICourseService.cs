using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public interface ICourseService
    {
        public List<Course> GetAllCourses();

        public void InsertCourse(CourseDTO? dto);

        public void UpdateCourse(CourseDTO? dto);

        public Course? DeleteCourse(CourseDTO? dto);

        public Course? GetCourse(int id);
    }
}
