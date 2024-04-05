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
                    Id = new Guid("2db809a9-0e14-4cb1-a641-5582d3a78d41"),
                    Name = "Web host",
                    Price = 235,
                    HostId = new Guid("ab34857f-6107-4411-b34a-f9d8951957f9"),
                },
                new Plan
                {
                    Id = new Guid("f5ea2b27-ddc6-465a-86db-66c2673d6bd3"),
                    Name = "Business host",
                    Price = 400,
                    HostId = new Guid("ab34857f-6107-4411-b34a-f9d8951957f9"),
                },
                new Plan
                {
                    Id = new Guid("6f588d66-c351-42a5-969b-3f6354269c2e"),
                    Name = "Reseller host",
                    Price = 3000,
                    HostId = new Guid("4d3070b4-a516-4b1c-b641-973b53353f7c"),
                },
                new Plan
                {
                    Id = new Guid("94c2e095-2a52-4102-9e39-c225c39afc9d"),
                    Name = "VPS host",
                    Price = 7500,
                    HostId = new Guid("4d3070b4-a516-4b1c-b641-973b53353f7c"),
                }
                );
        }
    }
}
