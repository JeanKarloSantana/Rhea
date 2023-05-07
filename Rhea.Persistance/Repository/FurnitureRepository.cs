﻿using Rhea.DAL.SQL;
using Rhea.Entities;
using Rhea.Interfaces.Generic;
using Rhea.Interfaces.Repository;
using Rhea.Persistance.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Persistance.Repository
{
    public class FurnitureRepository : BaseRepository<Furniture>, IFurnitureRepository
    {
        public RheaDbContext Context { get { return context; } }

        public FurnitureRepository(RheaDbContext dbContext) : base(dbContext)
        {
        }

        public int GetAmountOfAvailableFurniture(List<int> furnitureIds) =>
            context.Furnitures
            .Where(x => furnitureIds.Contains(x.Id) && x.IdFurnitureStatus == 1)
            .Count();
    }
}
