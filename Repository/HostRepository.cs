using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;


namespace Repository
{
    public sealed class HostRepository : RepositoryBase<Host>, IHostRepository
    {
        public HostRepository(RepositoryContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Host>> GetAllHosts(bool trackChanges) =>await FindAll(trackChanges)
            .OrderBy(x => x.Name)
            .ToListAsync();

        public async Task<Host> GetHost(Guid hostId, bool trackChanges) => 
            await FindByCondition( h => h.Id.Equals(hostId),trackChanges)
            .SingleOrDefaultAsync();

        public void CreateHost(Host host)
            => Create(host);

        public void DeleteHost(Host host) => Delete(host);
    }
}
