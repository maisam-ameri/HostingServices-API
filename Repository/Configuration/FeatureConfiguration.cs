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
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasData(

                new Feature
                {
                    Id = new Guid("3d490a90-94ce-4d15-9494-5248280c2ce3"),
                    DbCount = 1,
                    MySql = true,
                    Storage = 200,
                    Traffic = 100,
                    PlanId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a")
                },
                new Feature
                {
                    Id = new Guid("3d490a90-94ce-4d15-9494-5248280c2cd4"),
                    DbCount = 1,
                    MySql = false,
                    Storage = 300,
                    Traffic = 400,
                    PlanId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a")
                },
                new Feature
                {
                    Id = new Guid("3d490a90-94ce-4d15-9494-5248280c2ce3"),
                    DbCount = 2,
                    MySql = true,
                    Storage = 500,
                    Traffic = 400,
                    PlanId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811")
                },
                new Feature
                {
                    Id = new Guid("3d490a90-94ce-4d15-9494-5248280c2cd4"),
                    DbCount = 2,
                    MySql = true,
                    Storage = 600,
                    Traffic = 500,
                    PlanId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb53a")
                }
            );
        }
    }
}
