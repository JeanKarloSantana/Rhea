﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities
{
    public class UserType : BaseTypeEntity
    {
        public ICollection<User> User { get; set; }
    }
}
