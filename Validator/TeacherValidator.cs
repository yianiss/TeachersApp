using SevStudentsApp.DTO;

namespace SevStudentsApp.Validator
{
    public class TeacherValidator
    {
        /*
        * Checks DTO objects
        */

        // No instances of this class should be available
        private TeacherValidator() { }

        public static string Validate(TeacherDTO? dto)
        {
            if ((dto!.Firstname!.Length < 4) ||
               (dto!.Lastname!.Length < 4))
            {
                return "Firstname or Lastname should not be less than four characters";
            }

            return "";

        }
    }
}
