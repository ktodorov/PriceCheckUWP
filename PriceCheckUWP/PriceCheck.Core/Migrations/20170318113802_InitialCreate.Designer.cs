﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PriceCheck.Core.Context;
using PriceCheck.Core.Enums;

namespace PriceCheck.Core.Migrations
{
    [DbContext(typeof(PriceCheckContext))]
    [Migration("20170318113802_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("PriceCheck.Core.Entities.PriceChange", b =>
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

            modelBuilder.Entity("PriceCheck.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Url");

                    b.Property<int>("Website");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PriceCheck.Core.Entities.PriceChange", b =>
                {
                    b.HasOne("PriceCheck.Core.Entities.Product", "Product")
                        .WithMany("PriceChanges")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
