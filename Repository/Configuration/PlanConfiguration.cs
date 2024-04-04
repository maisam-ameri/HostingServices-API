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
    public class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.HasData(

                new Plan
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    Name = "Web host",
                    Price = 235,
                    HostId = new Guid("c9d4c053-49b6-410c-b5de-2d54a9991870"),
                },
                new Plan
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    Name = "Business host",
                    Price = 400,
                    HostId = new Guid("c9d4c053-49b6-410c-b5de-2d54a9991870"),
                },
                new Plan
                {
                    Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                    Name = "Reseller host",
                    Price = 3000,
                    HostId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                },
                new Plan
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb53a"),
                    Name = "VPS host",
                    Price = 7500,
                    HostId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                }
                );
        }
    }
}
