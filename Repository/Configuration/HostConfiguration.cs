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
                    Id = new Guid("ab34857f-6107-4411-b34a-f9d8951957f9"),
                    Name = "Win",
                    Description = "Win host is a host for deploy .net core sites",
                    Details = "CPanel control panel,Unlimited DB,High speed,Backup automaticlly",
                },
                new Host
                {
                    Id = new Guid("4d3070b4-a516-4b1c-b641-973b53353f7c"),
                    Name = "Linux",
                    Description = "Linux host is a host for deploy linux  sites",
                    Details = "CPanel control panel,Web application firewall(WAF),Use uptodate hardwares",
                }
            );
        }
    }
}
