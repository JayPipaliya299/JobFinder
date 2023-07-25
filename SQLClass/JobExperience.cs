using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLClass
{
    public class JobExperience
    {
        public int JobExperienceIDP { get; set; }
        public string JobExperienceName { get; set; }
        public int IsActive { get; set; }
        public int IsDelete { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }

    public class JobExperienceEmployeeClass
    {
        public int JobExperienceIDP { get; set; }
        public string JobExperienceName { get; set; }
    }
}
