using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IHostRepository
    {
        IEnumerable<Host> GetAllHosts(bool trackChanges);
        Host GetHost(Guid hostId, bool trackChanges);
        void CreateHost(Host host);
        void DeleteHost(Host host);
    }
}
