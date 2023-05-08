using Microsoft.EntityFrameworkCore;
using Rhea.DAL.SQL;

namespace Rhea.NUnitTest
{
    public class TestRheaDbContext : IDisposable
    {
        private readonly RheaDbContext _context;

        public TestRheaDbContext()
        {
            var options = new DbContextOptionsBuilder<RheaDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new RheaDbContext(options);

            _context.Database.EnsureCreated();
        }

        public RheaDbContext GetTestDbContext() => _context;

        public void Dispose()
        {
            _context.Database.EnsureDeleted();

            _context.Dispose();
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}