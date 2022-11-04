using SevStudentsApp.DAO.DBUtil;
using SevStudentsApp.Models;
using System.Data.SqlClient;

namespace SevStudentsApp.DAO
{
    public class TeacherDAOImpl : ITeacherDAO
    {
        /*private readonly CrmDbContext dbContext;

        public TeacherDAOImpl(CrmDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Teacher? Delete(Teacher? teacher)
        {
            Teacher dbTeacher = dbContext.Teachers.Find(teacher);

            if (dbTeacher == null) return null;

            dbContext.Teachers.Remove(dbTeacher);

            return teacher;
        }

        public List<Teacher> GetAll()
        {
            List<Teacher> teachers = dbContext.Teachers.ToList();
           

            teachers.ForEach(teacher => teachers.Add(new Teacher()
            {
                Id = teacher.Id,
                Firstname = teacher.Firstname,
                Lastname = teacher.Lastname
            }));

            return teachers;

        }

        public Teacher? GetTeacher(int id)
        {
            Teacher teacher = dbContext.Teachers.Find(id);
            return new Teacher();
        }

        public void Insert(Teacher? teacher)
        {
            if (teacher == null) return;

            dbContext.Teachers?.Add(teacher);
            dbContext.SaveChanges();
        }

        public void Update(Teacher? teacher)
        {
            Teacher dbTeacher = dbContext.Teachers.Find(teacher);
            
            if (dbTeacher == null) return;

            dbTeacher.Firstname = teacher.Firstname;
            dbTeacher.Lastname = teacher.Lastname;

            dbContext.SaveChanges();
        }*/

        public Teacher? Delete(Teacher? teacher)
        {
            if (teacher == null) return null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn != null)
                {
                    conn.Open();
                }
                else
                {
                    return null;
                }

                string sql = "DELETE FROM TEACHERS WHERE ID = @id";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@id", teacher.Id);

                int rowsAffected = command.ExecuteNonQuery();

                return (rowsAffected > 0) ? teacher : null;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<Teacher> GetAll()
        {
            List<Teacher> teachers = new List<Teacher>();

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn != null) conn.Open();

                string sql = "SELECT * FROM TEACHERS";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Teacher teacher = new Teacher()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2)
                    };
                    teachers.Add(teacher);
                }
               
                return teachers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Teacher? GetTeacher(int id)
        {
            Teacher? teacher = null;
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn != null) conn.Open();

                string sql = "SELECT * FROM TEACHERS WHERE ID = @id";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    teacher = new Teacher()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2)
                    };
                }

                return teacher;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Insert(Teacher teacher)
        {
            if (teacher == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn != null)
                {
                    conn.Open();

                }
                else
                {
                    return;
                }

                string sql = "INSERT INTO TEACHERS " +
                    "(FIRSTNAME, LASTNAME) VALUES " +
                    "(@firstname, @lastname)";

                using SqlCommand command = new SqlCommand(sql, conn);


                command.Parameters.AddWithValue("@firstname", teacher.Firstname);
                command.Parameters.AddWithValue("@lastname", teacher.Lastname);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Update(Teacher? teacher)
        {
            if (teacher == null) return;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn != null)
                {
                    conn.Open();
                }
                else
                {
                    return;
                }

                string sql = "UPDATE TEACHERS SET FIRSTNAME = @firstname, " +
                            "LASTNAME = @lastname WHERE ID = @id";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@firstname", teacher.Firstname);
                command.Parameters.AddWithValue("@lastname", teacher.Lastname);
                command.Parameters.AddWithValue("@id", teacher.Id);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}
