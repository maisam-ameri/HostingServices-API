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
        Task<IEnumerable<Host>> GetAllHosts(bool trackChanges);
        Task<Host> GetHost(Guid hostId, bool trackChanges);
        void CreateHost(Host host);
        void DeleteHost(Host host);
    }
}
