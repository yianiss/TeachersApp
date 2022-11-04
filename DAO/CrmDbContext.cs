using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SevStudentsApp.Models;
using SevStudentsApp.DTO;

namespace SevStudentsApp.DAO
{
    public class CrmDbContext : DbContext
    {
        public DbSet<Student>? Students { get; set; }

        public DbSet<Teacher>? Teachers { get; set; }

        public DbSet<Course>? Courses { get; set; }

        public DbSet<StudentCourse>? StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Data Source=localhost\\sqlexpress;Initial Catalog=SevAuebDB;Integrated Security=True");
        }
    }


}
