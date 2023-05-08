using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities
{
    public class BaseTypeEntity : BaseEntity
    {
        [Required]
        [Column("name")]
        public string Name { get; set; } = string.Empty;
    }
}
