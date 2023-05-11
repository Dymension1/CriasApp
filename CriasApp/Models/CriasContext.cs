using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CriasApp.Models;

public partial class CriasContext : DbContext
{
    public CriasContext()
    {
    }

    public CriasContext(DbContextOptions<CriasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<RegistroCria> RegistroCrias { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<RegistoSensores> RegistoSensores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
            "server=DEVS02; database=Crias; integrated security=true; TrustServerCertificate=True");
        }
    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=DEVS02; database=Crias; integrated security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RegistroCria>(entity =>
        {
            entity.HasKey(e => e.IdCria);

            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.Property(e => e.Contraseña)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Usuario");
        });

        modelBuilder.Entity<RegistoSensores>().ToTable("RegistroSensores");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
