using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PriceCheck.Data.Context;
using PriceCheck.Data.Enums;

namespace PriceCheck.Core.Migrations
{
    [DbContext(typeof(PriceCheckContext))]
    partial class PriceCheckContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("PriceCheck.Data.Entities.PriceChange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<double>("NewPrice");

                    b.Property<double>("OldPrice");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("PriceChanges");
                });

            modelBuilder.Entity("PriceCheck.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.Property<int>("Website");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PriceCheck.Data.Entities.PriceChange", b =>
                {
                    b.HasOne("PriceCheck.Data.Entities.Product", "Product")
                        .WithMany("PriceChanges")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
