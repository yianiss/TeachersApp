using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;

namespace SevStudentsApp.Pages.StudentCourses
{
    public class UpdateModel : PageModel
    {
        private readonly IStudentCourseDAO studentcourseDAO = new StudentCourseDAOImpl();

        private readonly IStudentCourseService service;


        public UpdateModel()
        {
            service = new StudentCourseServiceImpl(studentcourseDAO);
        }


        internal StudentCourseDTO studentcourseDto = new();
        internal string errorMessage = "";


        public void OnGet()
        {

            try
            {
                StudentCourse studentcourse;


                int id = int.Parse(Request.Query["id"]);
                studentcourse = service.GetStudentCourse(id);

                if (studentcourse != null)
                {
                    studentcourseDto = ConvertToDto(studentcourse);
                }
            }
            catch (Exception e)
            {

                errorMessage = e.Message;
                return;
            }

        }

        public void OnPost()
        {
            errorMessage = "";
            //Get DTO
            studentcourseDto.Id = int.Parse(Request.Form["id"]);
            studentcourseDto.StudentId = int.Parse(Request.Form["studentid"]);
            studentcourseDto.CourseId = int.Parse(Request.Form["courseid"]);

            try
            {
                service.UpdateStudentCourse(studentcourseDto);
                Response.Redirect("/StudentCourse/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }

        private StudentCourseDTO ConvertToDto(StudentCourse studentcourse)
        {
            return new StudentCourseDTO()
            {
                Id = studentcourse.Id,
                StudentId = studentcourse.StudentId,
                CourseId = studentcourse.CourseId
            };
        }
    }
}
