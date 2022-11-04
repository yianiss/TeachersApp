using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;

namespace SevStudentsApp.Pages.StudentCourses
{
    public class IndexModel : PageModel
    {
        private readonly IStudentCourseDAO StudentCourseDAO = new StudentCourseDAOImpl();

        private readonly IStudentCourseService? service;

        internal List<StudentCourse> studentcourses = new();

        public IndexModel()
        {
            service = new StudentCourseServiceImpl(StudentCourseDAO);
        }

        public IActionResult OnGet()
        {
            studentcourses = service!.GetAllStudentCourses();

            return Page();
        }
    }
}
