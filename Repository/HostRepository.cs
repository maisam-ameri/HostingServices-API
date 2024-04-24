using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository
{
    public sealed class HostRepository : RepositoryBase<Host>, IHostRepository
    {
        public HostRepository(RepositoryContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Host>> GetAllHostsAsync(HostParameters hostParameters, bool trackChanges) => await FindAll(trackChanges)
            .Search(hostParameters.SearchTerm)
            .Sort(hostParameters.OrderBy)
            .ToListAsync();

        public async Task<Host> GetHostAsync(Guid hostId, bool trackChanges) =>
            await FindByCondition(h => h.Id.Equals(hostId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateHost(Host host)
            => Create(host);

        public void DeleteHost(Host host) => Delete(host);
    }
}
