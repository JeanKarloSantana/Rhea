using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities
{
    public class User
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("id_user_type")]
        public int IdUserType { get; set; }
        [Column("id_user_status")]
        public int IdUserStatus { get; set; }
        [Column("email")]
        public string Email { get; set; } = string.Empty;
        [Column("date_created")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public UserType UserType { get; set; }
        public UserStatus UserStatus { get; set; }
        public ICollection<Person> Person { get; set; }
        public ICollection<Company> Company { get; set; }
        public ICollection<Reservation> Reservation { get; set; }
    }
}
