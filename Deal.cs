using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center_education
{
    public class Deal
    {
        public string surname { get; set; }
        public string first_name { get; set; }
        public string patronymic { get; set; }
        public DateTime date_birth { get; set; }
        public string passport { get; set; }
        public string place_residence { get; set; }
        public string phone { get; set; }
        public List<EducationProgram> educationProgram { get; set; }
        public Deal() { }
        public Deal ( string surname, string first_name, string patronymic, DateTime date_birth, string passport, string place_residence, string phone, List<EducationProgram> educationProgram)
        {
            this.surname = surname;
            this.first_name = first_name;
            this.patronymic = patronymic;
            this.date_birth = date_birth;
            this.passport = passport;
            this.place_residence = place_residence;
            this.phone = phone;
            this.educationProgram = educationProgram;
        }
    }
}
