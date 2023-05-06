using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
