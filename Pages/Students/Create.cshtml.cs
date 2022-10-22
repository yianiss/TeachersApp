using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;
using SevStudentsApp.Validator;

namespace SevStudentsApp.Pages.Students
{
    public class CreateModel : PageModel
    {
      
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();

        private readonly IStudentService service;


        public CreateModel()
        {
            service = new StudentServiceImpl(studentDAO);
        }


        internal StudentDTO studentDto = new();
        internal string errorMessage = "";

        public void OnGet()
        {
                
        }

        public void OnPost()
        {
            studentDto.Firstname = Request.Form["firstname"];
            studentDto.Lastname = Request.Form["lastname"];

        
            errorMessage = StudentValidator.Validate(studentDto);

            if (!errorMessage.Equals("")) return;

            try
            {
                service.InsertStudent(studentDto);
                Response.Redirect("/Students/Index");
                
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }
        
    }
}
