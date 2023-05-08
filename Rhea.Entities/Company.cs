using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities
{
    public class Company
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("normalized_name")]
        public string NormalizedName { get; set; } = string.Empty;
        public User User { get; set; }
    }
}
