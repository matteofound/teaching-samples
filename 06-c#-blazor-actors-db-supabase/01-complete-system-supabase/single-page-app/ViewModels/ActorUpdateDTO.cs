using System;
using System.Collections.Generic;

namespace project.ViewModels
{
    public class ActorUpdateDTO
    {
        public long Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}