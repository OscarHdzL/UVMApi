using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Datos.ModelosDBSIAC.Entities;

public partial class AppSIACDbContext : DbContext
{
    public AppSIACDbContext()
    {
    }

    public AppSIACDbContext(DbContextOptions<AppSIACDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acreditadora> Acreditadoras { get; set; }

    public virtual DbSet<CatCampus> CatCampuses { get; set; }

    public virtual DbSet<CatNivelModalidad> CatNivelModalidads { get; set; }

    public virtual DbSet<CatRegion> CatRegions { get; set; }

    public virtual DbSet<CatSede> CatSedes { get; set; }

    public virtual DbSet<Perfil> Perfils { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PL-790;Initial Catalog=DBSIAC-Desa-UVM;Persist Security Info=False;User ID=ohl;Password=Passw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acreditadora>(entity =>
        {
            entity.ToTable("Acreditadora", tb => tb.HasComment("Listado de Acreditadoras"));

            entity.Property(e => e.AcreditadoraId)
                .HasMaxLength(50)
                .HasComment("Siglas de identificación única para la acreditadora.")
                .HasColumnName("AcreditadoraID");
            entity.Property(e => e.Activo).HasComment("Indicador de activo/inactivo para el registro.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha de creación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre de la acreditadora.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario que realizó la última modificación sobre el registro.");
        });

        modelBuilder.Entity<CatCampus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cat_Camp__3214EC0701C6912F");

            entity.ToTable("cat_Campus", tb => tb.HasComment("Catálogo de campus."));

            entity.Property(e => e.Id).HasComment("Clave única del campus. ");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre del campus.");
            entity.Property(e => e.RegionId).HasComment("Región a la que pertenece este campus.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.Region).WithMany(p => p.CatCampuses)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK_cat_Campus_cat_Region");
        });

        modelBuilder.Entity<CatNivelModalidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cat_Nive__3214EC07420E54E7");

            entity.ToTable("cat_NivelModalidad");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Modalidad).HasMaxLength(100);
            entity.Property(e => e.Nivel).HasMaxLength(100);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<CatRegion>(entity =>
        {
            entity.ToTable("cat_Region", tb => tb.HasComment("Catálogo de regiones."));

            entity.Property(e => e.Id).HasComment("Clave única del región. ");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre del región.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<CatSede>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cat_Sede__3214EC07B3E1B397");

            entity.ToTable("cat_Sede", tb => tb.HasComment("Catálogo de sedes."));

            entity.Property(e => e.Id).HasComment("Clave única de la sede. ");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre de la sede.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<Perfil>(entity =>
        {
            entity.ToTable("Perfil");

            entity.Property(e => e.PerfilId).HasColumnName("PerfilID");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
            entity.Property(e => e.VistaInicial).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
