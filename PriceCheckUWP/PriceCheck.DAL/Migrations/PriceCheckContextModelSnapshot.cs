using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PriceCheck.DAL.Context;
using PriceCheck.DAL.Enums;

namespace PriceCheck.DAL.Migrations
{
    [DbContext(typeof(PriceCheckContext))]
    partial class PriceCheckContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("PriceCheck.DAL.Entities.PriceChange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("NewPrice");

                    b.Property<double>("OldPrice");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("PriceChanges");
                });

            modelBuilder.Entity("PriceCheck.DAL.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.Property<int>("Website");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PriceCheck.DAL.Entities.PriceChange", b =>
                {
                    b.HasOne("PriceCheck.DAL.Entities.Product", "Product")
                        .WithMany("PriceChanges")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
