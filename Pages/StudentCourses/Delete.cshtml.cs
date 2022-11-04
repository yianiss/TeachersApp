using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;

namespace SevStudentsApp.Pages.StudentCourses
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentCourseDAO studentcourseDAO = new StudentCourseDAOImpl();

        private readonly IStudentCourseService service;

        internal string errorMessage = "";


        public DeleteModel()
        {
            service = new StudentCourseServiceImpl(studentcourseDAO);
        }

        public void OnGet()
        {
            StudentCourseDTO studentcourseDTO = new();

            try
            {
                StudentCourse? studentcourse;


                int id = int.Parse(Request.Query["id"]);
                studentcourseDTO.Id = id;

                studentcourse = service.DeleteStudentCourse(studentcourseDTO);

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
