using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public interface ITeacherService
    {
        public List<Teacher> GetAllTeachers();

        public void InsertTeacher(TeacherDTO? dto);

        public void UpdateTeacher(TeacherDTO? dto);

        public Teacher? DeleteTeacher(TeacherDTO? dto);

        public Teacher? GetTeacher(int id);
    }
}
