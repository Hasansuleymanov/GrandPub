using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MainConfigurationService
    {
        private readonly ApplicationDbContext _context;

        public MainConfigurationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<MainConfiguration> GetAll()
        {
            return _context.MainConfigurations.Where(c => !c.IsDeleted).ToList();
        }
    }
}
