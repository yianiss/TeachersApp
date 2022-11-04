using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;

namespace SevStudentsApp.Pages.Teachers
{
    public class DeleteModel : PageModel
    {

        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();

        private readonly ITeacherService service;

        internal string errorMessage = "";


        public DeleteModel()
        {
            service = new TeacherServiceImpl(teacherDAO);
        }

        public void OnGet()
        {
            TeacherDTO teacherDTO = new();

            try
            {
                Teacher? teacher;


                int id = int.Parse(Request.Query["id"]);
                teacherDTO.Id = id;

                teacher = service.DeleteTeacher(teacherDTO);

                Response.Redirect("/Teachers/Index");

            }
            catch (Exception e)
            {

                errorMessage = e.Message;
                return;
            }

        }
    }
}
