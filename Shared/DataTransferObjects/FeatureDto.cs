using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record FeatureDto(Guid Id,int Storage, int Traffic, int DbCount, bool MySql);
}
