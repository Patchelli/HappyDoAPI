using HappyDo.Domain.Entities.UserScope;
using HappyDo.Domain.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Infrastructure.ORM.Context
{
    public sealed class DbInitializer
    {
        private readonly ApplicationContext _context;

        public DbInitializer(
            ApplicationContext context)
        {
            _context = context;
        }

        private void SaveInDb() => _context.SaveChanges();
        private void AddRangeInDb<T>(List<T> entities) where T : class => _context.Set<T>().AddRange(entities);

        public void Seeding()
        {
            CreateApplicationRole();
        }

        private void CreateApplicationRole()
        {
            if (_context.Set<ApplicationRole>().Any()) return;

            var seeding = new ApplicationRoleSeeding();
            AddRangeInDb(seeding.CreateRoles());

            SaveInDb();
        }
    }

}
