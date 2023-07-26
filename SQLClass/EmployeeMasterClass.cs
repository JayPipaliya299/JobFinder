using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClass
{
    public class EmployeeMasterClass
    {
        public int EmployeeIDP { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeMobileNumber { get; set; }
        public int EmployeeGender { get; set; }
        public int CountryIDF { get; set; }
        public int StateIDF { get; set; }
        public int CityIDF { get; set; }
        public int JobExperienceIDF { get; set; }
        public string SkillIDF { get; set; }
        public string EmployeeDomain { get; set; }
        public int IsActive { get; set; }
        public int IsDelete { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }

    }
}
