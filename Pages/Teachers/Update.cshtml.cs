using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;
using SevStudentsApp.Validator;

namespace SevStudentsApp.Pages.Teachers
{
    public class UpdateModel : PageModel
    {
        private readonly ITeacherDAO teacherDAO = new TeacherDAOImpl();

        private readonly ITeacherService service;


        public UpdateModel()
        {
            service = new TeacherServiceImpl(teacherDAO);
        }


        internal TeacherDTO teacherDto = new();
        internal string errorMessage = "";


        public void OnGet()
        {

            try
            {
                Teacher? teacher;


                int id = int.Parse(Request.Query["id"]);
                teacher = service.GetTeacher(id);

                if (teacher != null)
                {
                    teacherDto = ConvertToDto(teacher);
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
            teacherDto.Id = int.Parse(Request.Form["id"]);
            teacherDto.Firstname = Request.Form["firstname"];
            teacherDto.Lastname = Request.Form["lastname"];

            //validate
          //  errorMessage = StudentValidator.Validate(teacherDto);

            if (!errorMessage.Equals("")) return;

            try
            {
                service.UpdateTeacher(teacherDto);
                Response.Redirect("/Teachers/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }

        private TeacherDTO ConvertToDto(Teacher teacher)
        {
            return new TeacherDTO()
            {
                Id = teacher.Id,
                Firstname = teacher.Firstname,
                Lastname = teacher.Lastname
            };
        }
    }
}
