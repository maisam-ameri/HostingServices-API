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
                    PlanId = new Guid("2db809a9-0e14-4cb1-a641-5582d3a78d41")
                },
                new Feature
                {
                    Id = new Guid("3d490a90-94ce-4d15-9494-5248280c2cd4"),
                    DbCount = 1,
                    MySql = false,
                    Storage = 300,
                    Traffic = 400,
                    PlanId = new Guid("f5ea2b27-ddc6-465a-86db-66c2673d6bd3")
                },
                new Feature
                {
                    Id = new Guid("3d490a90-94ce-4d15-9494-5248280c2ab2"),
                    DbCount = 2,
                    MySql = true,
                    Storage = 500,
                    Traffic = 400,
                    PlanId = new Guid("6f588d66-c351-42a5-969b-3f6354269c2e")
                },
                new Feature
                {
                    Id = new Guid("3d490a90-94ce-4d15-9494-5248280c2ac1"),
                    DbCount = 2,
                    MySql = true,
                    Storage = 600,
                    Traffic = 500,
                    PlanId = new Guid("94c2e095-2a52-4102-9e39-c225c39afc9d")
                }
            );
        }
    }
}
