﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sertar.DataLayer.Contexts.ServerContext;

namespace Sertar.Migrations.Mysql.Migrations.MysqlServer
{
    [DbContext(typeof(MysqlServerContext))]
    partial class MysqlServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Sertar.Models.Servers.IpAddress", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Ip")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("ServerId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("IpAddress");
                });

            modelBuilder.Entity("Sertar.Models.Servers.Server", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CloudId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("InstallationScriptLocation")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MainIpAddress")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RootUser")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("Sertar.Models.Ssh.SshKey", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Format")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PrivateKey")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PublicKey")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("SshKeys");
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
