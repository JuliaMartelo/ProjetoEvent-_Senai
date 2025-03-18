﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto_Event_.Context;

#nullable disable

namespace Projeto_Event_.Migrations
{
    [DbContext(typeof(Event_Context))]
    [Migration("20250318163544_DbEventos")]
    partial class DbEventos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Projeto_Event_.Domain.TiposEventos", b =>
                {
                    b.Property<Guid>("IdTipoEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TituloTipoEvento")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.HasKey("IdTipoEvento");

                    b.ToTable("TiposEventos");
                });

            modelBuilder.Entity("Projeto_Event_.Domains.ComentariosEventos", b =>
                {
                    b.Property<Guid>("IdComentarioEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descrição")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<bool>("Exibe")
                        .HasColumnType("BIT");

                    b.Property<Guid>("IdEvento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdComentarioEvento");

                    b.HasIndex("IdEvento");

                    b.HasIndex("IdUsuario");

                    b.ToTable("ComentariosEventos");
                });

            modelBuilder.Entity("Projeto_Event_.Domains.Eventos", b =>
                {
                    b.Property<Guid>("IdEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataEvento")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("InstituicoesID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeEvento")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("TipoEventoID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdEvento");

                    b.HasIndex("InstituicoesID");

                    b.HasIndex("TipoEventoID");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("Projeto_Event_.Domains.Instituicoes", b =>
                {
                    b.Property<Guid>("IdInstituicao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Endereço")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdInstituicao");

                    b.HasIndex("CNPJ")
                        .IsUnique();

                    b.ToTable("Instituicoes");
                });

            modelBuilder.Entity("Projeto_Event_.Domains.Presencas", b =>
                {
                    b.Property<Guid>("IdPresença")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EventosID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdEvento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Situacao")
                        .HasColumnType("BIT");

                    b.HasKey("IdPresença");

                    b.HasIndex("IdEvento")
                        .IsUnique()
                        .HasFilter("[IdEvento] IS NOT NULL");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Presencas");
                });

            modelBuilder.Entity("Projeto_Event_.Domains.TiposUsuarios", b =>
                {
                    b.Property<Guid>("IdTipoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TituloTipoUsuario")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.HasKey("IdTipoUsuario");

                    b.ToTable("TiposUsuarios");
                });

            modelBuilder.Entity("Projeto_Event_.Domains.Usuarios", b =>
                {
                    b.Property<Guid>("IdUsuarios")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<Guid?>("IdTipoUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdTipoUsuarios")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR(60)");

                    b.HasKey("IdUsuarios");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IdTipoUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Projeto_Event_.Domains.ComentariosEventos", b =>
                {
                    b.HasOne("Projeto_Event_.Domains.Eventos", "Eventos")
                        .WithMany()
                        .HasForeignKey("IdEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto_Event_.Domains.Usuarios", "Usuarios")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Eventos");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Projeto_Event_.Domains.Eventos", b =>
                {
                    b.HasOne("Projeto_Event_.Domains.Instituicoes", "instituicao")
                        .WithMany()
                        .HasForeignKey("InstituicoesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto_Event_.Domain.TiposEventos", "tipoevento")
                        .WithMany()
                        .HasForeignKey("TipoEventoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("instituicao");

                    b.Navigation("tipoevento");
                });

            modelBuilder.Entity("Projeto_Event_.Domains.Presencas", b =>
                {
                    b.HasOne("Projeto_Event_.Domains.Eventos", "eventos")
                        .WithOne("presencas")
                        .HasForeignKey("Projeto_Event_.Domains.Presencas", "IdEvento");

                    b.HasOne("Projeto_Event_.Domains.Usuarios", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");

                    b.Navigation("eventos");
                });

            modelBuilder.Entity("Projeto_Event_.Domains.Usuarios", b =>
                {
                    b.HasOne("Projeto_Event_.Domains.TiposUsuarios", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("IdTipoUsuario");

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("Projeto_Event_.Domains.Eventos", b =>
                {
                    b.Navigation("presencas");
                });
#pragma warning restore 612, 618
        }
    }
}
