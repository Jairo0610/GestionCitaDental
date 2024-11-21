using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestionCitaDental.Models;

public partial class DbClinicaDentalContext : DbContext
{
    public DbClinicaDentalContext()
    {
    }

    public DbClinicaDentalContext(DbContextOptions<DbClinicaDentalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCitum> TblCita { get; set; }

    public virtual DbSet<TblCorreo> TblCorreos { get; set; }

    public virtual DbSet<TblEstadoCitum> TblEstadoCita { get; set; }

    public virtual DbSet<TblOdontologo> TblOdontologos { get; set; }

    public virtual DbSet<TblPaciente> TblPacientes { get; set; }

    public virtual DbSet<TblProcedimiento> TblProcedimientos { get; set; }

    public virtual DbSet<TblTipoUsuario> TblTipoUsuarios { get; set; }

    public virtual DbSet<TblUsuario> TblUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-2ON7D3N\\SQLEXPRESS; Database=db_clinica_dental; Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCitum>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PK__tblCita__814F312609937606");

            entity.ToTable("tblCita");

            entity.Property(e => e.IdCita).HasColumnName("idCita");
            entity.Property(e => e.IdEstadoCita).HasColumnName("idEstadoCita");
            entity.Property(e => e.IdOdontologo).HasColumnName("idOdontologo");
            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.IdProcedimiento).HasColumnName("idProcedimiento");

            entity.HasOne(d => d.IdEstadoCitaNavigation).WithMany(p => p.TblCita)
                .HasForeignKey(d => d.IdEstadoCita)
                .HasConstraintName("FK__tblCita__idEstad__2EDAF651");

            entity.HasOne(d => d.IdOdontologoNavigation).WithMany(p => p.TblCita)
                .HasForeignKey(d => d.IdOdontologo)
                .HasConstraintName("FK__tblCita__idOdont__2DE6D218");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.TblCita)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__tblCita__idPacie__2BFE89A6");

            entity.HasOne(d => d.IdProcedimientoNavigation).WithMany(p => p.TblCita)
                .HasForeignKey(d => d.IdProcedimiento)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__tblCita__idProce__2CF2ADDF");
        });

        modelBuilder.Entity<TblCorreo>(entity =>
        {
            entity.HasKey(e => e.IdCorreo).HasName("PK__tblCorre__D247A9092F9F3432");

            entity.ToTable("tblCorreo");

            entity.Property(e => e.IdCorreo).HasColumnName("idCorreo");
            entity.Property(e => e.Correo).HasMaxLength(100);
        });

        modelBuilder.Entity<TblEstadoCitum>(entity =>
        {
            entity.HasKey(e => e.IdEstadoCita).HasName("PK__tblEstad__FDA623A1F728719D");

            entity.ToTable("tblEstadoCita");

            entity.Property(e => e.IdEstadoCita).HasColumnName("idEstadoCita");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<TblOdontologo>(entity =>
        {
            entity.HasKey(e => e.IdOdontologo).HasName("PK__tblOdont__48D3BA5CE81B8BD0");

            entity.ToTable("tblOdontologo");

            entity.Property(e => e.IdOdontologo).HasColumnName("idOdontologo");
            entity.Property(e => e.IdCorreo).HasColumnName("idCorreo");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(10);

            entity.HasOne(d => d.IdCorreoNavigation).WithMany(p => p.TblOdontologos)
                .HasForeignKey(d => d.IdCorreo)
                .HasConstraintName("FK__tblOdonto__idCor__29221CFB");
        });

        modelBuilder.Entity<TblPaciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__tblPacie__F48A08F25E5C33C3");

            entity.ToTable("tblPaciente");

            entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.Dui)
                .HasMaxLength(9)
                .HasColumnName("DUI");
            entity.Property(e => e.IdCorreo).HasColumnName("idCorreo");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(10);

            entity.HasOne(d => d.IdCorreoNavigation).WithMany(p => p.TblPacientes)
                .HasForeignKey(d => d.IdCorreo)
                .HasConstraintName("FK__tblPacien__idCor__5070F446");
        });

        modelBuilder.Entity<TblProcedimiento>(entity =>
        {
            entity.HasKey(e => e.IdProcedimiento).HasName("PK__tblProce__46A68D83FD0C4519");

            entity.ToTable("tblProcedimiento");

            entity.Property(e => e.IdProcedimiento).HasColumnName("idProcedimiento");
            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        modelBuilder.Entity<TblTipoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario).HasName("PK__tblTipoU__03006BFF093C00EA");

            entity.ToTable("tblTipoUsuario");

            entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<TblUsuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__tblUsuar__645723A6F1FD2AA0");

            entity.ToTable("tblUsuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Contraseña).HasMaxLength(100);
            entity.Property(e => e.IdCorreo).HasColumnName("idCorreo");
            entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");
            entity.Property(e => e.Usuario).HasMaxLength(100);

            entity.HasOne(d => d.IdCorreoNavigation).WithMany(p => p.TblUsuarios)
                .HasForeignKey(d => d.IdCorreo)
                .HasConstraintName("FK__tblUsuari__idCor__5535A963");

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.TblUsuarios)
                .HasForeignKey(d => d.IdTipoUsuario)
                .HasConstraintName("FK__tblUsuari__idTip__5629CD9C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
