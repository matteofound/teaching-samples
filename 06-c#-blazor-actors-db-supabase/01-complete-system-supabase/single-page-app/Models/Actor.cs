using System;
using System.Collections.Generic;

namespace project.Models
{
    public partial class Actor
    {
        public long actorId { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string countryCode { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public DateTime? createdAt { get; set; }
    }
}