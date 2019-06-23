using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Students
    {
        public int StudentNumber { get; set; }
        public string Password { get; set; }
        public byte IsStudentRep { get; set; }
    }
}
