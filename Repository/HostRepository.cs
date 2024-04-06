using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class HostRepository : RepositoryBase<Host>, IHostRepository
    {
        public HostRepository(RepositoryContext context) : base(context)
        {
        }

        public IEnumerable<Host> GetAllHosts(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(x => x.Name)
            .ToList();

        public Host GetHost(Guid hostId, bool trackChanges) =>
            FindByCondition( h => h.Id.Equals(hostId),trackChanges)
            .SingleOrDefault();

    }
}
