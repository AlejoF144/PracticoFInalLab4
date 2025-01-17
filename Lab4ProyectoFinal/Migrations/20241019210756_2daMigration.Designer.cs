﻿// <auto-generated />
using System;
using Lab4ProyectoFinal.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab4ProyectoFinal.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241019210756_2daMigration")]
    partial class _2daMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lab4ProyectoFinal.Models.Domicilio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Calle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Domicilio");
                });

            modelBuilder.Entity("Lab4ProyectoFinal.Models.MetodoDePago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Expiracion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarcaDeTarjeta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroDeTarjeta")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MetodoDePagos");
                });

            modelBuilder.Entity("Lab4ProyectoFinal.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagenCarpeta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tamaño")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Lab4ProyectoFinal.Models.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CantidadVentas")
                        .HasColumnType("int");

                    b.Property<string>("Empresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("Lab4ProyectoFinal.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DomicilioId")
                        .HasColumnType("int");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("ImagenCarpeta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nivel")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TarjetaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DomicilioId");

                    b.HasIndex("TarjetaId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Lab4ProyectoFinal.Models.Usuario", b =>
                {
                    b.HasOne("Lab4ProyectoFinal.Models.Domicilio", "Domicilio")
                        .WithMany()
                        .HasForeignKey("DomicilioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lab4ProyectoFinal.Models.MetodoDePago", "Tarjeta")
                        .WithMany()
                        .HasForeignKey("TarjetaId");

                    b.Navigation("Domicilio");

                    b.Navigation("Tarjeta");
                });
#pragma warning restore 612, 618
        }
    }
}
