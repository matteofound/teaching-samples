using System;
using System.Collections.Generic;

namespace project.Models
{
    public class Country
    {
        public string countryCode { get; set; }
        public string countryName { get; set; }
        public DateTime? createdAt { get; set; }
    }
}