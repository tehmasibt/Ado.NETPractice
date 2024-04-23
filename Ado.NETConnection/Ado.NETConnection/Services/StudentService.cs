using Ado.NETConnection.Models;
using System.Data.SqlClient;



namespace Ado.NETConnection.Services
{
    internal class StudentService : IStudentService
    {
        public StudentService(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; set; }
        public void Create(Student student)
        {
            using var sqlConnection = OpenConnection(ConnectionString);
            string query = "insert into students (name,age,surname) values (@name,@age,@surname)";
            using SqlCommand cmd = new(query, sqlConnection);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("age", student.Age);
            cmd.Parameters.AddWithValue("@surname", student.Surname);
            int v = cmd.ExecuteNonQuery();
            if(v > 0)
            {
                Console.WriteLine("Successful added...");
            }
        }
        public void Update(int id, Student student)
        {
            using var sqlConnection = OpenConnection(ConnectionString);
            string query = "update students set name=@name, age=@age, surname=@surname where id=@id";
            using SqlCommand sqlCommand = new(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@name", student.Name);
            sqlCommand.Parameters.AddWithValue("@age", student.Age);
            sqlCommand.Parameters.AddWithValue("@surname", student.Surname);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.ExecuteNonQuery();
        }
        public void Delete(int id)
        {
            using var sqlConnection = OpenConnection(ConnectionString);
            string query = "delete from students where id=@id";
            using SqlCommand sqlCommand = new(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.ExecuteNonQuery();
        }
        public List<Student> Get()
        {
            List<Student> list = new();
            using var sqlConnection = OpenConnection(ConnectionString);
            string query = "select * from students";
            using SqlCommand sqlCommand = new(query, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int age = reader.GetInt32(2);
                string surname = reader.GetString(3);
                list.Add(new Student { Id = id, Name = name, Age = age, Surname = surname });
            }
            return list;
        }
        public Student GetOne(int id)
        {
            Student student = null;
            using var sqlConnection = OpenConnection(ConnectionString);
            string query = "select top(1)* from students where id=@id";
            using SqlCommand cmd = new(query, sqlConnection);
            cmd.Parameters.AddWithValue("id", id);
            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int stuId = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    int age = reader.GetInt32(2);
                    string surname = reader.GetString(3);
                    student = new() { Id = stuId, Name = name, Age = age, Surname = surname };
                }
            }
            return student;
        }
        private SqlConnection OpenConnection(string connectionstr)
        {
            SqlConnection sqlConnection = new(connectionstr);
            sqlConnection.Open();
            return sqlConnection;
        }
        public int GetStudentAvgAge()
        {
            using var sqlConnection = OpenConnection(ConnectionString);
            string query = "select avg(age) from students";
            using SqlCommand sqlCommand = new(query, sqlConnection);
            var result = sqlCommand.ExecuteScalar();
            if (result == null)
                return 0;
            return Convert.ToInt32(result);
        }
        public string GetStudentName(int id)
        {
            using var sqlConnection = OpenConnection(ConnectionString);
            string query = "select top(1) name from students where id=@id";
            using SqlCommand cmd = new(query, sqlConnection);
            cmd.Parameters.AddWithValue("id", id);
            return (string)cmd.ExecuteScalar();
            
           
        }

        public List<(string name, string address)> GetStuInfo()
        {
            List<(string, string)> list = new();
            using var sqlConnection = OpenConnection(ConnectionString);
            string query = "select * from stuinfo";
            using SqlCommand sqlCommand = new(query, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0);
                string address = reader.GetString(1);
                list.Add((name,address));
            }
            return list;
        }
    }
}
