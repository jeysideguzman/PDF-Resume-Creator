using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Resume_Creator
{
    internal class ResumeInfo
    {
        public string Name { get; set; }
        public string School { get; set; }
        public int Age { get; set; }
        public string Date_of_Birth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Contact_No { get; set; }
        public List<string> Language { get; set; }
        public string Profile { get; set; }
        public string PrimaryEducation_History { get; set; }
        public string SecondaryEducation_History { get; set; }
        public List<string> Achievement { get; set; }
        public List<string> PersonalSkills { get; set; }
    }
}
