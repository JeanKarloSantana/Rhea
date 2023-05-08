using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities
{
    public class Person
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; } = string.Empty;
        [Column("normalized_first_name")]
        public string NormalizedFirstName { get; set; } = string.Empty;
        [Column("last_name")]
        public string Lastname { get; set; } = string.Empty;
        [Column("normalized_last_name")]
        public string NormalizedLastname { get; set; } = string.Empty;
        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
        public User User { get; set; }
    }
}
