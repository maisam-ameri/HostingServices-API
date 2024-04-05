using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _context;
        private Lazy<IHostRepository> _hostRepository;
        private Lazy<IPlanRepository> _planRepository;
        private Lazy<IFeatureRepository> _featureRepository;
        
        public IHostRepository Host => _hostRepository.Value;
        public IPlanRepository Plan => _planRepository.Value;
        public IFeatureRepository Feature => _featureRepository.Value;


        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
                
            _hostRepository = new Lazy<IHostRepository>(() => new HostRepository(context));

            _planRepository = new Lazy<IPlanRepository>(() => new PlanRepository(context));

            _featureRepository = new Lazy<IFeatureRepository>(() => new FeatureRepository(context));
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
