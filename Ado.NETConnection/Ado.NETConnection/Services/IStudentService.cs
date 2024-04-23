using Ado.NETConnection.Models;

namespace Ado.NETConnection.Services
{
    internal interface IStudentService
    {
        void Create(Student student);
        void Delete(int id);
        List<Student> Get();
        Student GetOne(int id);
        void Update(int id, Student student);
        int GetStudentAvgAge();
        string GetStudentName(int id);
        List<(string name, string address)> GetStuInfo();
    }
}