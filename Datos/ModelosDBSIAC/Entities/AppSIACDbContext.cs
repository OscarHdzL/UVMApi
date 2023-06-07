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

    public virtual DbSet<AcreditadoraProceso> AcreditadoraProcesos { get; set; }

    public virtual DbSet<CatAcreditadora> CatAcreditadoras { get; set; }

    public virtual DbSet<CatAreaCorporativa> CatAreaCorporativas { get; set; }

    public virtual DbSet<CatAreaResponsable> CatAreaResponsables { get; set; }

    public virtual DbSet<CatCampus> CatCampuses { get; set; }

    public virtual DbSet<CatCapitulo> CatCapitulos { get; set; }

    public virtual DbSet<CatComponente> CatComponentes { get; set; }

    public virtual DbSet<CatNivelModalidad> CatNivelModalidads { get; set; }

    public virtual DbSet<CatNivelRevision> CatNivelRevisions { get; set; }

    public virtual DbSet<CatNormativa> CatNormativas { get; set; }

    public virtual DbSet<CatPeriodo> CatPeriodos { get; set; }

    public virtual DbSet<CatPeriodoEvaluacion> CatPeriodoEvaluacions { get; set; }

    public virtual DbSet<CatPonderacion> CatPonderacions { get; set; }

    public virtual DbSet<CatRegion> CatRegions { get; set; }

    public virtual DbSet<CatSede> CatSedes { get; set; }

    public virtual DbSet<CatTipoAcceso> CatTipoAccesos { get; set; }

    public virtual DbSet<CatTipoVistum> CatTipoVista { get; set; }

    public virtual DbSet<CatUsuario> CatUsuarios { get; set; }

    public virtual DbSet<CatVistum> CatVista { get; set; }

    public virtual DbSet<Ciclo> Ciclos { get; set; }

    public virtual DbSet<RelPerfilvistatipoacceso> RelPerfilvistatipoaccesos { get; set; }

    public virtual DbSet<RelPerfilvistum> RelPerfilvista { get; set; }

    public virtual DbSet<RelUsuarioareacorporativa> RelUsuarioareacorporativas { get; set; }

    public virtual DbSet<RelUsuarioarearesponsable> RelUsuarioarearesponsables { get; set; }

    public virtual DbSet<RelUsuariocampus> RelUsuariocampuses { get; set; }

    public virtual DbSet<RelUsuarionivelmodalidad> RelUsuarionivelmodalidads { get; set; }

    public virtual DbSet<RelUsuarioregion> RelUsuarioregions { get; set; }

    public virtual DbSet<TblPerfil> TblPerfils { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

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
        modelBuilder.Entity<AcreditadoraProceso>(entity =>
        {
            entity.ToTable("AcreditadoraProceso");
        });

        modelBuilder.Entity<CatAcreditadora>(entity =>
        {
            entity.ToTable("cat_Acreditadora", tb => tb.HasComment("Listado de Acreditadoras"));

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

        modelBuilder.Entity<CatAreaCorporativa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AreaCorporativa");

            entity.ToTable("cat_AreaCorporativa", tb => tb.HasComment("Catálogo de la área corporativa."));

            entity.Property(e => e.Id).HasComment("Clave única de la área corporativa.");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasComment("Nombre de la área corporativa.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<CatAreaResponsable>(entity =>
        {
            entity.ToTable("cat_AreaResponsable");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.AreaResponsablePadreNavigation).WithMany(p => p.InverseAreaResponsablePadreNavigation)
                .HasForeignKey(d => d.AreaResponsablePadre)
                .HasConstraintName("FK_AreaResponsable_AreaResponsable1");
        });

        modelBuilder.Entity<CatCampus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cat_Camp__3214EC072A5611D5");

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

        modelBuilder.Entity<CatCapitulo>(entity =>
        {
            entity.HasKey(e => new { e.AcreditadoraProcesoId, e.Id }).HasName("PK_Capitulo");

            entity.ToTable("cat_Capitulo", tb => tb.HasComment("Listado de cápitulos."));

            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso al que pertenece este cápitulo.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasComment("Número del cápitulo dentro del proceso.");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1500)
                .HasComment("Descripción larga del cápitulo.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre del cápitulo.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.AcreditadoraProceso).WithMany(p => p.CatCapitulos)
                .HasForeignKey(d => d.AcreditadoraProcesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Capitulo_AcreditadoraProceso");
        });

        modelBuilder.Entity<CatComponente>(entity =>
        {
            entity.ToTable("cat_Componente");

            entity.Property(e => e.Clave).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<CatNivelModalidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_NivelModalidad");

            entity.ToTable("cat_NivelModalidad", tb => tb.HasComment("Listado de Nivel/Modalidad"));

            entity.HasIndex(e => e.Id, "PK__NivelModalidad").IsUnique();

            entity.Property(e => e.Id).HasComment("Siglas de identificación única para la Nivel/Modalidad.");
            entity.Property(e => e.Activo).HasComment("Indicador de activo/inactivo para el registro.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha de creación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Modalidad)
                .HasMaxLength(100)
                .HasComment("Modalidad de Nivel/Modalidad.");
            entity.Property(e => e.Nivel)
                .HasMaxLength(100)
                .HasComment("Nivel  de Nivel/Modalidad.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario que realizó la última modificación sobre el registro.");
        });

        modelBuilder.Entity<CatNivelRevision>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cat_Nive__3214EC0757F8CD3A");

            entity.ToTable("cat_NivelRevision");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<CatNormativa>(entity =>
        {
            entity.ToTable("cat_Normativa");

            entity.Property(e => e.Clave).HasMaxLength(10);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<CatPeriodo>(entity =>
        {
            entity.ToTable("cat_Periodo");

            entity.Property(e => e.Etapa).HasMaxLength(100);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaFinal).HasColumnType("datetime");
            entity.Property(e => e.FechaInicial).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<CatPeriodoEvaluacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PeriodoEvaluacion");

            entity.ToTable("cat_PeriodoEvaluacion", tb => tb.HasComment("Catálogo de periodo de evaluación."));

            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.AnioId).HasColumnName("AnioID");
            entity.Property(e => e.CicloId)
                .HasMaxLength(50)
                .HasColumnName("CicloID");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaFinAuditoria)
                .HasComment("Fecha fin del proceso Auditoría .")
                .HasColumnType("date");
            entity.Property(e => e.FechaFinAutoEvaluacion)
                .HasComment("Fecha fin del proceso Autoevaluación.")
                .HasColumnType("date");
            entity.Property(e => e.FechaFinCapturaResultados)
                .HasComment("Fecha fin del proceso Captura de resultados.")
                .HasColumnType("date");
            entity.Property(e => e.FechaFinCargaEvidencia)
                .HasComment("Fecha fin del proceso Carga de evidencias.")
                .HasColumnType("date");
            entity.Property(e => e.FechaFinMeta)
                .HasComment("Fecha fin del proceso Meta.")
                .HasColumnType("date");
            entity.Property(e => e.FechaFinPlanMejora)
                .HasComment("Fecha fin del proceso Plan mejora.")
                .HasColumnType("date");
            entity.Property(e => e.FechaFinRevision)
                .HasComment("Fecha fin del proceso de Revisión.")
                .HasColumnType("date");
            entity.Property(e => e.FechaInicialAuditoria)
                .HasComment("Fecha inicial del proceso Auditoría.")
                .HasColumnType("date");
            entity.Property(e => e.FechaInicialAutoEvaluacion)
                .HasComment("Fecha inicial del proceso Autoevaluación.")
                .HasColumnType("date");
            entity.Property(e => e.FechaInicialCapturaResultados)
                .HasComment("Fecha inicial del proceso Captura de resultados.")
                .HasColumnType("date");
            entity.Property(e => e.FechaInicialCargaEvidencia)
                .HasComment("Fecha inicial del proceso Carga de evidencias.")
                .HasColumnType("date");
            entity.Property(e => e.FechaInicialMeta)
                .HasComment("Fecha inicial del proceso Meta.")
                .HasColumnType("date");
            entity.Property(e => e.FechaInicialPlanMejora)
                .HasComment("Fecha inicial del proceso Plan mejora.")
                .HasColumnType("date");
            entity.Property(e => e.FechaInicialRevision)
                .HasComment("Fecha inicial del proceso de Revisión.")
                .HasColumnType("date");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.Ciclo).WithMany(p => p.CatPeriodoEvaluacions)
                .HasForeignKey(d => d.CicloId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PeriodoEvaluacion_Ciclo");
        });

        modelBuilder.Entity<CatPonderacion>(entity =>
        {
            entity.HasKey(e => new { e.ComponenteId, e.NivelModalidadId }).HasName("PK_cat_Ponderacion_1");

            entity.ToTable("cat_Ponderacion");

            entity.Property(e => e.ComponenteId).HasColumnName("Componente_Id");
            entity.Property(e => e.NivelModalidadId).HasColumnName("NivelModalidad_Id");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.Componente).WithMany(p => p.CatPonderacions)
                .HasForeignKey(d => d.ComponenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cat_Ponderacion_cat_Componente");

            entity.HasOne(d => d.NivelModalidad).WithMany(p => p.CatPonderacions)
                .HasForeignKey(d => d.NivelModalidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cat_Ponderacion_cat_NivelModalidad");
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
            entity.HasKey(e => e.Id).HasName("PK__Cat_Tipo__3214EC0735A7F38E");

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

        modelBuilder.Entity<CatTipoVistum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cat_Tipo__3214EC07680A7D5A");

            entity.ToTable("Cat_TipoVista");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<CatUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__2B3DE798895CF517");

            entity.ToTable("cat_Usuario", tb => tb.HasComment("Listado de usaurios del sistema."));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("Identificador único del usuario en el directorio activo.");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(150)
                .HasComment("Apellido paterno del usaurio.");
            entity.Property(e => e.Correo)
                .HasMaxLength(500)
                .HasComment("Correo electrónico del usuario.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasComment("Nombre(s) del usuario.");
            entity.Property(e => e.PerfilId).HasColumnName("PerfilID");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.Perfil).WithMany(p => p.CatUsuarios)
                .HasForeignKey(d => d.PerfilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Perfil");
        });

        modelBuilder.Entity<CatVistum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cat_Vist__3214EC07FDCA5691");

            entity.ToTable("Cat_Vista");

            entity.Property(e => e.CatTipoVistaId).HasDefaultValueSql("((1))");
            entity.Property(e => e.Clave).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(500);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.CatTipoVista).WithMany(p => p.CatVista)
                .HasForeignKey(d => d.CatTipoVistaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cat_Vista__CatTi__16CE6296");
        });

        modelBuilder.Entity<Ciclo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ciclo");

            entity.ToTable("Ciclo");

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<RelPerfilvistatipoacceso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rel_perf__3214EC079C7A5463");

            entity.ToTable("rel_perfilvistatipoacceso");

            entity.HasOne(d => d.CatTipoAcceso).WithMany(p => p.RelPerfilvistatipoaccesos)
                .HasForeignKey(d => d.CatTipoAccesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_perfi__CatTi__7D0E9093");

            entity.HasOne(d => d.PerfilVista).WithMany(p => p.RelPerfilvistatipoaccesos)
                .HasForeignKey(d => d.PerfilVistaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_perfi__CatTi__7C1A6C5A");
        });

        modelBuilder.Entity<RelPerfilvistum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rel_perf__3214EC07E36B7BD2");

            entity.ToTable("rel_perfilvista");

            entity.HasOne(d => d.Perfil).WithMany(p => p.RelPerfilvista)
                .HasForeignKey(d => d.PerfilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_perfi__Vista__6BE40491");

            entity.HasOne(d => d.Vista).WithMany(p => p.RelPerfilvista)
                .HasForeignKey(d => d.VistaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_perfi__Vista__6CD828CA");
        });

        modelBuilder.Entity<RelUsuarioareacorporativa>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rel_usuarioareacorporativa");

            entity.HasOne(d => d.CatAreaCorporativa).WithMany()
                .HasForeignKey(d => d.CatAreaCorporativaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatAr__2F9A1060");

            entity.HasOne(d => d.Usuario).WithMany()
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatAr__2EA5EC27");
        });

        modelBuilder.Entity<RelUsuarioarearesponsable>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rel_usuarioarearesponsable");

            entity.HasOne(d => d.CatAreaResponsable).WithMany()
                .HasForeignKey(d => d.CatAreaResponsableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatAr__32767D0B");

            entity.HasOne(d => d.Usuario).WithMany()
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatAr__318258D2");
        });

        modelBuilder.Entity<RelUsuariocampus>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rel_usuariocampus");

            entity.HasOne(d => d.CatCampus).WithMany()
                .HasForeignKey(d => d.CatCampusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatCa__29E1370A");

            entity.HasOne(d => d.Usuario).WithMany()
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatCa__28ED12D1");
        });

        modelBuilder.Entity<RelUsuarionivelmodalidad>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rel_usuarionivelmodalidad");

            entity.HasOne(d => d.CatNivelModalidad).WithMany()
                .HasForeignKey(d => d.CatNivelModalidadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatNi__2CBDA3B5");

            entity.HasOne(d => d.Usuario).WithMany()
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatNi__2BC97F7C");
        });

        modelBuilder.Entity<RelUsuarioregion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rel_usuarioregion");

            entity.HasOne(d => d.CatRegion).WithMany()
                .HasForeignKey(d => d.CatRegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatRe__2704CA5F");

            entity.HasOne(d => d.Usuario).WithMany()
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rel_usuar__CatRe__2610A626");
        });

        modelBuilder.Entity<TblPerfil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_perf__3214EC07FD1C6907");

            entity.ToTable("tbl_perfil");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC071EF477D5");

            entity.ToTable("Usuario");

            entity.Property(e => e.Apellidos).HasMaxLength(150);
            entity.Property(e => e.Correo).HasMaxLength(500);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(50);

            entity.HasOne(d => d.CatNivelRevision).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.CatNivelRevisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__CatNive__2334397B");

            entity.HasOne(d => d.TblPerfil).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.TblPerfilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__Usuario__22401542");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
