﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sertar.DataLayer.Contexts.ServerContext;

namespace Sertar.Migrations.Postgres.Migrations.PostgresServer
{
    [DbContext(typeof(PostgresServerContext))]
    partial class PostgresServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Sertar.Models.Servers.IpAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Ip")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("ServerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("IpAddress");
                });

            modelBuilder.Entity("Sertar.Models.Servers.Server", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CloudId")
                        .HasColumnType("text");

                    b.Property<string>("InstallationScriptLocation")
                        .HasColumnType("text");

                    b.Property<string>("MainIpAddress")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("Sertar.Models.Servers.IpAddress", b =>
                {
                    b.HasOne("Sertar.Models.Servers.Server", null)
                        .WithMany("IpAddresses")
                        .HasForeignKey("ServerId");
                });
#pragma warning restore 612, 618
        }
    }
}