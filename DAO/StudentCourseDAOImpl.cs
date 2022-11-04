using SevStudentsApp.DAO.DBUtil;
using SevStudentsApp.Models;
using System.Data.SqlClient;

namespace SevStudentsApp.DAO
{
    public class StudentCourseDAOImpl : IStudentCourseDAO
    {
        public StudentCourse? Delete(StudentCourse? studentcourse)
        {
            if (studentcourse == null) return null;

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

                string sql = "DELETE FROM STUDENTCOURSES WHERE ID = @id";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@id", studentcourse.Id);

                int rowsAffected = command.ExecuteNonQuery();

                return (rowsAffected > 0) ? studentcourse : null;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<StudentCourse> GetAll()
        {
            List<StudentCourse> studentcourses = new List<StudentCourse>();

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn != null) conn.Open();

                /*string sql = "SELECT DESCRIPTION, FIRSTNAME || ' ' || LASTNAME FROM COURSES" +
                    "INNER JOIN TEACHERS ON TEACHERS.ID = COURSES.TEACHERID";*/

                string sql = "SELECT * FROM STUDENTCOURSES";


                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    StudentCourse studentcourse = new StudentCourse()
                    {
                        Id = reader.GetInt32(0),
                        StudentId = reader.GetInt32(1),
                        CourseId = reader.GetInt32(2)
                    };
                    studentcourses.Add(studentcourse);


                }

                return studentcourses;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public StudentCourse? GetStudentCourse(int id)
        {
            StudentCourse? studentcourse = null;
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn != null) conn.Open();

                string sql = "SELECT * FROM STUDENTCOURSES WHERE ID = @id";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    studentcourse = new StudentCourse()
                    {
                        Id = reader.GetInt32(0),
                        StudentId = reader.GetInt32(1),
                        CourseId = reader.GetInt32(2)
                    };
                }

                return studentcourse;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Insert(StudentCourse? studentcourse)
        {
            if (studentcourse == null) return;

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

                string sql = "INSERT INTO STUDENTCOURSES " +
                    "(STUDENTID, COURSEID) VALUES " +
                    "(@StudentId, @CourseId)";

                using SqlCommand command = new SqlCommand(sql, conn);


                command.Parameters.AddWithValue("@StudentId", studentcourse.StudentId);
                command.Parameters.AddWithValue("@CourseId", studentcourse.CourseId);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Update(StudentCourse? studentcourse)
        {
            if (studentcourse == null) return;

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

                string sql = "UPDATE STUDENTCOURSES SET STUDENTID = @StudentId, " +
                            "COURSEID = @CourseId WHERE ID = @id";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@Id", studentcourse.Id);
                command.Parameters.AddWithValue("@StudentId", studentcourse.StudentId);
                command.Parameters.AddWithValue("@CourseId", studentcourse.CourseId);

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
