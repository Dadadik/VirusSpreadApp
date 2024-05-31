using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViruseSpreadApp.Entities
{
    public partial class VirusSpreadEntities
    {
        private static VirusSpreadEntities _context;
        public static VirusSpreadEntities GetContext()
        {
            if (_context == null)
                _context = new VirusSpreadEntities();
            return _context;
        }
    }
}
