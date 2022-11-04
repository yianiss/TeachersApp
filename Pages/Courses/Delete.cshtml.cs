using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;
using SevStudentsApp.Validator;

namespace SevStudentsApp.Pages.Courses
{
    public class DeleteModel : PageModel
    {

        private readonly ICourseDAO courseDAO = new CourseDAOImpl();

        private readonly ICourseService service;

        internal string errorMessage = "";


        public DeleteModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }

        public void OnGet()
        {
            CourseDTO courseDTO = new();

            try
            {
                Course? course;


                int id = int.Parse(Request.Query["id"]);
                courseDTO.Id = id;

                course = service.DeleteCourse(courseDTO);

                Response.Redirect("/Courses/Index");

            }
            catch (Exception e)
            {

                errorMessage = e.Message;
                return;
            }

        }
    }
}
