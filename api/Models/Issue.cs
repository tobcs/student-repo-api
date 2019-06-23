using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Issue
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int? UpVotes { get; set; }
        public int? DownVotes { get; set; }
        public byte Show { get; set; }
        public string StatusDescription { get; set; }
        public int? Priority { get; set; }
        public int? FlaggedInappropiate { get; set; }
    }
}
