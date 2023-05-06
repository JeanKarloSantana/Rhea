using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int IdUserType { get; set; }
        public int IdUserStatus { get; set; }
        public string Email { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public UserType UserType { get; set; }
        public UserStatus UserStatus { get; set; }
        public ICollection<Person> Person { get; set; }
        public ICollection<Company> Company { get; set; }
        public ICollection<Reservation> Reservation { get; set; }
    }
}
