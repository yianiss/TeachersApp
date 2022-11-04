using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public class StudentCourseServiceImpl : IStudentCourseService
    {
        private readonly IStudentCourseDAO dao;

        public StudentCourseServiceImpl(IStudentCourseDAO dao)
        {
            this.dao = dao;
        }

        public StudentCourse? DeleteStudentCourse(StudentCourseDTO? dto)
        {
            if (dto == null) return null;

            try
            {
                StudentCourse? studentcourse = Convert(dto);
                return dao.Delete(studentcourse);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<StudentCourse> GetAllStudentCourses()
        {
            try
            {
                return dao.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<StudentCourse>();
            }
        }

        public StudentCourse? GetStudentCourse(int id)
        {
            try
            {
                return dao.GetStudentCourse(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void InsertStudentCourse(StudentCourseDTO? dto)
        {
            if (dto == null) return;

            try
            {
                StudentCourse? studentcourse = Convert(dto);

                dao.Insert(studentcourse);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateStudentCourse(StudentCourseDTO? dto)
        {
            if (dto == null) return;

            try
            {
                StudentCourse? studentcourse = Convert(dto);
                dao.Update(studentcourse);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private StudentCourse? Convert(StudentCourseDTO dto)
        {
            if (dto == null) return null;

            return new StudentCourse()
            {
                Id = dto.Id,
                StudentId = dto.StudentId,
                CourseId = dto.CourseId
            };

        }
    }
}
