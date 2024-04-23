
namespace Ado.NETConnection.Models
{
    internal class Student
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $" {Id} {Name} {Surname} {Age}";
        }
        

    }
}
