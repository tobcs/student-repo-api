using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public string Issue { get; set; }
        public string Feedback1 { get; set; }
        public int Votes { get; set; }
        public string Following { get; set; }
    }
}
