using Ado.NETConnection.Models;
using Ado.NETConnection.Services;

namespace Ado.NETConnection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GetStudentAvgAge
            //StudentService studentService = new StudentService(connectionStrIng);
            //Console.WriteLine($"Total Averadge: {studentService.GetStudentAvgAge()}");


            //GetStudentName
            //StudentService studentService = new StudentService(connectionStrIng);
            //Console.WriteLine(studentService.GetStudentName(5));


            string connectionStrIng = "Server=DESKTOP-HPCK2O7;Database=Academy;Trusted_Connection=true;";
            //IStudentService studentService = new StudentService(connectionStrIng);
            //foreach (var item in studentService.GetStuInfo())
            //{
            //    Console.WriteLine(item);
            //}


            //CREATE
            //StudentService studentService = new(connectionStrIng);
            //studentService.Create(new() { Name = "Araz",Age=20, Surname = "Hummetov" });


            //GET
            //StudentService studentService = new(connectionStrIng);
            //foreach (var item in studentService.Get())
            //{
            //    Console.WriteLine(item);
            //}


            //GETONE
            //StudentService studentService = new StudentService(connectionStrIng);
            //Console.WriteLine(studentService.GetOne(1));


            //DELETE
            //StudentService studentService = new StudentService();
            //studentService.Delete(4);


            //UPDATE
            //StudentService studentService = new (connectionStrIng);
            //studentService.Update(1, new() { Name = "Emillll", Age = 25, Surname = "Abbasova" });





        }
    }
}
