﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("date_created")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
