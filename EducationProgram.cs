using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_education
{
    public class EducationProgram
    {
        public int id { get; set; }
        public string title { get; set; }
        public string qualifications { get; set; }
        public decimal cost { get; set; }
        public string duration_training { get; set; }
        public EducationProgram() { }
        public EducationProgram(int id, string title, string qualifications, decimal cost, string duration_training)
        { 
            this.id = id;
            this.title = title;
            this.qualifications = qualifications;
            this.cost = cost;
            this.duration_training = duration_training;
        }
    }
}
