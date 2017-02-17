using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATPDL.DB.Model;

namespace ATPDL.DB
{
    public class ATPDLContext : DbContext
    {
        public ATPDLContext() : base("ATPDLConnection") { }

        public DbSet<Player> Players { get; set; }
    }
}
