using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

    public virtual DbSet<CatTipoAcceso> CatTipoAccesos { get; set; }

    public virtual DbSet<CatVistum> CatVista { get; set; }

    public virtual DbSet<RelPerfilcampus> RelPerfilcampuses { get; set; }

    public virtual DbSet<RelPerfilvistatipoacceso> RelPerfilvistatipoaccesos { get; set; }

    public virtual DbSet<RelPerfilvistum> RelPerfilvista { get; set; }

    public virtual DbSet<TblPerfil> TblPerfils { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot Configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                               .AddJsonFile("appsettings.json", optional: false).Build();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("LibroFimpes"));
        }
    }
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

        modelBuilder.Entity<CatTipoAcceso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cat_Tipo__3214EC07CB781B2B");

            entity.ToTable("Cat_TipoAcceso");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<CatVistum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cat_Vist__3214EC07F071B372");

            entity.ToTable("Cat_Vista");

            entity.Property(e => e.Clave).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<RelPerfilcampus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rel_perf__3214EC07E908BEAB");

            entity.ToTable("rel_perfilcampus");

            entity.HasOne(d => d.CatCampus).WithMany(p => p.RelPerfilcampuses)
                .HasForeignKey(d => d.CatCampusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_perfi__CatCa__1209AD79");

            entity.HasOne(d => d.Perfil).WithMany(p => p.RelPerfilcampuses)
                .HasForeignKey(d => d.PerfilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_perfi__CatCa__11158940");
        });

        modelBuilder.Entity<RelPerfilvistatipoacceso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rel_perf__3214EC0736FD7883");

            entity.ToTable("rel_perfilvistatipoacceso");

            entity.HasOne(d => d.CatTipoAcceso).WithMany(p => p.RelPerfilvistatipoaccesos)
                .HasForeignKey(d => d.CatTipoAccesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_perfi__CatTi__0E391C95");

            entity.HasOne(d => d.PerfilVista).WithMany(p => p.RelPerfilvistatipoaccesos)
                .HasForeignKey(d => d.PerfilVistaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_perfi__CatTi__0D44F85C");
        });

        modelBuilder.Entity<RelPerfilvistum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rel_perf__3214EC077CBCC26F");

            entity.ToTable("rel_perfilvista");

            entity.HasOne(d => d.Perfil).WithMany(p => p.RelPerfilvista)
                .HasForeignKey(d => d.PerfilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_perfi__Vista__09746778");

            entity.HasOne(d => d.Vista).WithMany(p => p.RelPerfilvista)
                .HasForeignKey(d => d.VistaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_perfi__Vista__0A688BB1");
        });

        modelBuilder.Entity<TblPerfil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_perf__3214EC079489D165");

            entity.ToTable("tbl_perfil");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.VistaInicialNavigation).WithMany(p => p.TblPerfils)
                .HasForeignKey(d => d.VistaInicial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbl_perfi__Usuar__0697FACD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
