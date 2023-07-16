using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfMvvm.Model
{
    public class student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Dob { get; set; }
        public double Gpa { get; set; }
        public string Gender { get; set; }
        public string ImagePath { get; set; }

        
    }
}
