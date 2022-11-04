using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Service;

namespace SevStudentsApp.Pages.StudentCourses
{
    public class CreateModel : PageModel
    {
        private readonly IStudentCourseDAO studentcourseDAO = new StudentCourseDAOImpl();


        private readonly IStudentCourseService service;


        public CreateModel()
        {
            service = new StudentCourseServiceImpl(studentcourseDAO);
        }


        internal StudentCourseDTO studentcourseDto = new();
        internal string errorMessage = "";

        public void OnGet()
        {

        }

        public void OnPost()
        {
            studentcourseDto.StudentId = int.Parse(Request.Form["studentId"]);
            studentcourseDto.CourseId = int.Parse(Request.Form["courseId"]);

            try
            {
                service.InsertStudentCourse(studentcourseDto);
                Response.Redirect("/StudentCourses/Index");

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
    }
}
