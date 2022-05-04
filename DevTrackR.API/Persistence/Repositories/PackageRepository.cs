using DevTrackR.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevTrackR.API.Persistence.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly DevTrackRContext _context;

        public PackageRepository(DevTrackRContext context) => _context = context;

        public List<Package> GetAll() =>
            _context.Packages.ToList();

        public Package? GetByCode(string code) =>
            _context.Packages.Include(p => p.Updates).SingleOrDefault(p => p.Code == code);

        public void Add(Package package)
        {
            _context.Packages.Add(package);
            _context.SaveChanges();
        }

        public void Update(Package package)
        {
            _context.Entry(package).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}