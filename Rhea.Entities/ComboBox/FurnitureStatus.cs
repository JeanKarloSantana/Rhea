﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities.ComboBox
{
    public class FurnitureStatus : BaseTypeEntity
    {
        public ICollection<Furniture> Furniture { get; set; }
    }
}
