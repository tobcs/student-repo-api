using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public string EmailAddress { get; set; }
    }
}
