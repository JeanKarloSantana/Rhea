﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities
{
    public class ReservationStatus : BaseTypeEntity
    {
        public ICollection<Reservation> Reservation { get; set; }
    }
}
