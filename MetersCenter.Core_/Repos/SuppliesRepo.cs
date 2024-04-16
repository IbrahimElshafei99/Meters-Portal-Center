using MetersCenter.Core_.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetersCenter.Core_.Repos
{
    public class SuppliesRepo
    {
        private readonly ApplicationDbContext _context;
        public SuppliesRepo(ApplicationDbContext context)
        {
            _context = context;
        }


    }
}
