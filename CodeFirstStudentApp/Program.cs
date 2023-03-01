using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;

namespace CodeFirstStudentApp
{
    internal class Program
    {
        static void Main()
        {
            using (var db = new StudentContext())
            {
                Console.WriteLine("Enter your name:");
                var name = Console.ReadLine();
                Console.WriteLine("Enter your last name:");
                var lname = Console.ReadLine();

                var Student = new Student() { Name = name, LastName = lname };
                db.Students.Add(Student);
                db.SaveChanges();
                var query = from c in db.Students
                            orderby c.Id
                            select c;

                foreach (var item in query)
                {
                    Console.WriteLine(item.Id + " " + item.Name + " " + item.LastName);
                }
                Console.ReadLine();

            }

        }

    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public virtual List<Student> Students { get; set; }
    }
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

    }
}

