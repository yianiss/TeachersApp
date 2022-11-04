using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Service;

namespace SevStudentsApp.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();


        private readonly ICourseService service;


        public CreateModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }


        internal CourseDTO courseDto = new();
        internal string errorMessage = "";

        public void OnGet()
        {

        }

        public void OnPost()
        {
            courseDto.Description = Request.Form["description"];
            courseDto.TeacherId = int.Parse(Request.Form["teacherId"]);

            try
            {
                service.InsertCourse(courseDto);
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
