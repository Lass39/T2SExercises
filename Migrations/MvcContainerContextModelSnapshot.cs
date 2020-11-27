﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcContainer.Data;

namespace T2SExercises.Migrations
{
    [DbContext(typeof(MvcContainerContext))]
    partial class MvcContainerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MvcContainer.Models.CategoriaContainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoriaName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CategoriaContainer");
                });

            modelBuilder.Entity("MvcContainer.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome_cliente")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("MvcContainer.Models.Container", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaContainerId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Nmr_control")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusContainerId")
                        .HasColumnType("int");

                    b.Property<int>("TipoContainerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaContainerId");

                    b.HasIndex("ClientId");

                    b.HasIndex("StatusContainerId");

                    b.HasIndex("TipoContainerId");

                    b.ToTable("Container");
                });

            modelBuilder.Entity("MvcContainer.Models.Movimentacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Containerid")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("Navioid")
                        .HasColumnType("int");

                    b.Property<int>("TipoMovimentacaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Containerid");

                    b.HasIndex("Navioid");

                    b.HasIndex("TipoMovimentacaoId");

                    b.ToTable("Movimentacao");
                });

            modelBuilder.Entity("MvcContainer.Models.Navio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome_navio")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Navio");
                });

            modelBuilder.Entity("MvcContainer.Models.StatusContainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StatusContainer");
                });

            modelBuilder.Entity("MvcContainer.Models.TipoContainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Tipo_container")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TipoContainer");
                });

            modelBuilder.Entity("MvcContainer.Models.TipoMovimentacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo_movimentacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoMovimentacao");
                });

            modelBuilder.Entity("MvcContainer.Models.Container", b =>
                {
                    b.HasOne("MvcContainer.Models.CategoriaContainer", "CategoriaContainer")
                        .WithMany()
                        .HasForeignKey("CategoriaContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcContainer.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcContainer.Models.StatusContainer", "StatusContainer")
                        .WithMany()
                        .HasForeignKey("StatusContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcContainer.Models.TipoContainer", "TipoContainer")
                        .WithMany()
                        .HasForeignKey("TipoContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MvcContainer.Models.Movimentacao", b =>
                {
                    b.HasOne("MvcContainer.Models.Container", "Container")
                        .WithMany()
                        .HasForeignKey("Containerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcContainer.Models.Navio", "Navio")
                        .WithMany()
                        .HasForeignKey("Navioid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcContainer.Models.TipoMovimentacao", "TipoMovimentacao")
                        .WithMany()
                        .HasForeignKey("TipoMovimentacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
