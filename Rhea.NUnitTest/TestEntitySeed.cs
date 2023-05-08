using Rhea.DAL.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.NUnitTest
{
    public class TestEntitySeed<TEntity> where TEntity : class
    {
        public TestEntitySeed(RheaDbContext context, TEntity[] predicate)
        {
            context.Set<TEntity>().AddRange(predicate);
            context.SaveChanges();
        }
    }
}

