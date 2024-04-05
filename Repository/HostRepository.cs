using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class HostRepository : RepositoryBase<Host>, IHostRepository
    {
        public HostRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
