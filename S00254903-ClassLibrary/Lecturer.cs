using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S00254903_ClassLibrary
{
    public class Lecturer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }

        //navigation property - one to many with courses
        public ICollection<Course> Courses { get; set; }
    }
}
