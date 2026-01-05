using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S00254903_ClassLibrary
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int QQILevel { get; set; }
        public string Description { get; set; }

        //foreign key
        public int LecturerID { get; set; }

        //navigation properties
        public Lecturer Lecturer { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
