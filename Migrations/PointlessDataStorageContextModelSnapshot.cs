﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PointlessDataStorage.Models;

namespace PointlessDataStorage.Migrations
{
    [DbContext(typeof(PointlessDataStorageContext))]
    partial class PointlessDataStorageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PointlessDataStorage.Models.UselessDataBlock", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("garbageFloat");

                    b.Property<string>("name");

                    b.Property<DateTime>("randomDate");

                    b.HasKey("ID");

                    b.ToTable("UselessDataBlock");
                });
#pragma warning restore 612, 618
        }
    }
}
