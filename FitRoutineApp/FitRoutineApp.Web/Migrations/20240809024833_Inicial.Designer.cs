﻿// <auto-generated />
using System;
using FitRoutineApp.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FitRoutineApp.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240809024833_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FitRoutineApp.Web.Models.Entrenador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Especialidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Entrenadores");
                });

            modelBuilder.Entity("FitRoutineApp.Web.Models.HistorialDeActividades", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("FechaActividad")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observaciones")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("HistorialDeActividades");
                });

            modelBuilder.Entity("FitRoutineApp.Web.Models.Pago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("MetodoPago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SesionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SesionId");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("FitRoutineApp.Web.Models.Sesion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("EntrenadorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaSesion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraSesion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntrenadorId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Sesiones");
                });

            modelBuilder.Entity("FitRoutineApp.Web.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("FitRoutineApp.Web.Models.HistorialDeActividades", b =>
                {
                    b.HasOne("FitRoutineApp.Web.Models.Usuario", "Usuario")
                        .WithMany("HistorialDeActividades")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FitRoutineApp.Web.Models.Pago", b =>
                {
                    b.HasOne("FitRoutineApp.Web.Models.Sesion", "Sesion")
                        .WithMany()
                        .HasForeignKey("SesionId");

                    b.Navigation("Sesion");
                });

            modelBuilder.Entity("FitRoutineApp.Web.Models.Sesion", b =>
                {
                    b.HasOne("FitRoutineApp.Web.Models.Entrenador", "Entrenador")
                        .WithMany()
                        .HasForeignKey("EntrenadorId");

                    b.HasOne("FitRoutineApp.Web.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Entrenador");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("FitRoutineApp.Web.Models.Usuario", b =>
                {
                    b.Navigation("HistorialDeActividades");
                });
#pragma warning restore 612, 618
        }
    }
}
