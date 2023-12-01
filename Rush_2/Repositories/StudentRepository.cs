using Dapper;
using Rush_2.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Rush_2.Repositories
{
    public class StudentRepository
    {
        private readonly IDbConnection _dbConnection;

        public StudentRepository()
        {
            string connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=School;User Id=Raul2;Password=sa2;";
            _dbConnection = new SqlConnection(connectionString);
        }


        /// <summary>
        /// This method is useful to create a new User.
        /// </summary>
        /// <param name="student"></param>
        public void InsertStudent(Student student)
        {
            string sql = "INSERT INTO Student (Name, Email, Gender, CreationDate) VALUES (@Name, @Email, @Gender, @CreationDate);";
            _dbConnection.Execute(sql, student);
        }

        public IDbConnection Get_dbConnection()
        {
            return _dbConnection;
        }

        public Student GetStudentById(int studentId)
        {
            string sql = "SELECT * FROM Students WHERE StudentId = @StudentId;";
            return _dbConnection.QuerySingleOrDefault<Student>(sql, new { StudentId = studentId });
        }

        public void UpdateStudent(Student student)
        {
            string sql = "UPDATE Students SET Name = @Name, Email = @Email, Gender = @Gender, CreationDate = @CreationDate WHERE StudentId = @StudentId;";
            _dbConnection.Execute(sql, student);
        }      
    }

}
