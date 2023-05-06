using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string NormalizedFirstName { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string NormalizedLastname { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public User User { get; set; }
    }
}
