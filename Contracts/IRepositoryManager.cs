using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IHostRepository Host { get; }
        IPlanRepository Plan { get; }
        IFeatureRepository Feature { get; }

        void Save();
    }
}
