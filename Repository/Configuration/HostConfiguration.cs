using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class HostConfiguration : IEntityTypeConfiguration<Host>
    {
        public void Configure(EntityTypeBuilder<Host> builder)
        {
            builder.HasData(
                
                new Host
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Name = "Win",
                    Description = "Win host is a host for deploy .net core sites",
                    Details = "CPanel control panel,Unlimited DB,High speed,Backup automaticlly",
                },
                new Host
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Name = "Linux",
                    Description = "Linux host is a host for deploy linux  sites",
                    Details = "CPanel control panel,Web application firewall(WAF),Use uptodate hardwares",
                }
            );
        }
    }
}
