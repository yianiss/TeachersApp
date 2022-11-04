using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;

namespace SevStudentsApp.Pages.Teachers
{
    public class IndexModel : PageModel
    {
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();

        private readonly ITeacherService? service;

        internal List<Teacher> teachers = new();

        public IndexModel()
        {
            service = new TeacherServiceImpl(teacherDAO);
        }

        public IActionResult OnGet()
        {

            teachers = service!.GetAllTeachers();
            return Page();
        }
    }
}
