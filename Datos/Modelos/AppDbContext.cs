using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Datos.Modelos;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acreditadora> Acreditadoras { get; set; }

    public virtual DbSet<AcreditadoraProceso> AcreditadoraProcesos { get; set; }

    public virtual DbSet<Apartado> Apartados { get; set; }

    public virtual DbSet<AreaResponsabilidad> AreaResponsabilidads { get; set; }

    public virtual DbSet<Campus> Campuses { get; set; }

    public virtual DbSet<Capitulo> Capitulos { get; set; }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<Ciclo> Ciclos { get; set; }

    public virtual DbSet<ComentarioSeguimiento> ComentarioSeguimientos { get; set; }

    public virtual DbSet<ConfiguracionSistema> ConfiguracionSistemas { get; set; }

    public virtual DbSet<Criterio> Criterios { get; set; }

    public virtual DbSet<EvidenciaAnio> EvidenciaAnios { get; set; }

    public virtual DbSet<Evidencium> Evidencia { get; set; }

    public virtual DbSet<NivelAtencion> NivelAtencions { get; set; }

    public virtual DbSet<NivelOrganizacional> NivelOrganizacionals { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<RegistroEvidenciaArchivo> RegistroEvidenciaArchivos { get; set; }

    public virtual DbSet<RegistroEvidencium> RegistroEvidencia { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolProceso> RolProcesos { get; set; }

    public virtual DbSet<RolProcesoVistaTipoAcceso> RolProcesoVistaTipoAccesos { get; set; }

    public virtual DbSet<RolProcesoVistum> RolProcesoVista { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<Subarea> Subareas { get; set; }

    public virtual DbSet<TipoAcceso> TipoAccesos { get; set; }

    public virtual DbSet<TipoEvidencium> TipoEvidencia { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRolProceso> UsuarioRolProcesos { get; set; }

    public virtual DbSet<UsuarioRolProcesoCapitulo> UsuarioRolProcesoCapitulos { get; set; }

    public virtual DbSet<UsuarioRolProcesoCriterio> UsuarioRolProcesoCriterios { get; set; }

    public virtual DbSet<Vistum> Vista { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=tcp:dbsql-sgapi-qa-uvm.database.windows.net,1433;Initial Catalog=DBSIAC-Dev-UVM;Persist Security Info=False;User ID=appUser;Password=AdminM4n$pp5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

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

        modelBuilder.Entity<AcreditadoraProceso>(entity =>
        {
            entity.ToTable("AcreditadoraProceso", tb => tb.HasComment("Listado de procesos por acreditadora."));

            entity.HasIndex(e => e.AcreditadoraProcesoId, "IX_AcreditadoraProceso");

            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador único del proceso.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.AcreditadoraId)
                .HasMaxLength(50)
                .HasComment("Identificador de la acreditadora a la que perteneces este proceso.")
                .HasColumnName("AcreditadoraID");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha de creación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaFin)
                .HasComment("Fecha de fin del proceso. Limite para generar y documentar evidencias.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaInicio)
                .HasComment("Fecha de inicio del proceso.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre del proceso. Usualmente es un año seguido de un ciclo.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario que realizó la última modificación sobre el registro.");

            entity.HasOne(d => d.Acreditadora).WithMany(p => p.AcreditadoraProcesos)
                .HasForeignKey(d => d.AcreditadoraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AcreditadoraProceso_Acreditadora");
        });

        modelBuilder.Entity<Apartado>(entity =>
        {
            entity.ToTable("Apartado", tb => tb.HasComment("Apartados del libro electrónico."));

            entity.HasIndex(e => new { e.AcreditadoraProcesoId, e.CarreraId }, "CL_APARTADO");

            entity.Property(e => e.ApartadoId)
                .HasComment("Identificador único del apartado.")
                .HasColumnName("ApartadoID");
            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso al que pertenece este apartado.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.ApartadoPadre).HasComment("Identificador del padre de este apartado. NULL en caso de ser un apartado de primer nivel.");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasComment("Identificador de la carrera a la que se asocia este apartado.")
                .HasColumnName("CarreraID");
            entity.Property(e => e.CriterioId)
                .HasMaxLength(50)
                .HasComment("Identificador del criterio al que se asocia este apartado.")
                .HasColumnName("CriterioID");
            entity.Property(e => e.Especificaciones).HasComment("Contenido en HTML del apartado.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Orden).HasComment("Indica el orden de despliegue de los apartados. Se ordenan de menor a mayor, agrupados por niveles herárquicos.");
            entity.Property(e => e.Titulo)
                .HasMaxLength(500)
                .HasComment("Titulo del apartado.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.ApartadoPadreNavigation).WithMany(p => p.InverseApartadoPadreNavigation)
                .HasForeignKey(d => d.ApartadoPadre)
                .HasConstraintName("FK_Apartado_Apartado");

            entity.HasOne(d => d.Carrera).WithMany(p => p.Apartados)
                .HasForeignKey(d => d.CarreraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Apartado_Carrera");

            entity.HasOne(d => d.Criterio).WithMany(p => p.Apartados)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.CriterioId, d.CarreraId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Apartado_Criterio");
        });

        modelBuilder.Entity<AreaResponsabilidad>(entity =>
        {
            entity.HasKey(e => new { e.AcreditadoraProcesoId, e.AreaResponsabilidadId });

            entity.ToTable("AreaResponsabilidad", tb => tb.HasComment("Listado de áreas de reponsabilidad."));

            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso al que pertenece esta área.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.AreaResponsabilidadId)
                .HasMaxLength(50)
                .HasComment("Siglas de la área de responsabilidad dentro del proceso.")
                .HasColumnName("AreaResponsabilidadID");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.NivelAtencionId)
                .HasMaxLength(50)
                .HasComment("Identificador del nivel de atención asociado a esta área.")
                .HasColumnName("NivelAtencionID");
            entity.Property(e => e.NivelOrganizacionalId)
                .HasMaxLength(50)
                .HasComment("Identificador del nivel de organizacional asociado a esta área.")
                .HasColumnName("NivelOrganizacionalID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre del área de responsabilidad.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.AcreditadoraProceso).WithMany(p => p.AreaResponsabilidads)
                .HasForeignKey(d => d.AcreditadoraProcesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AreaResponsabilidad_AcreditadoraProceso");

            entity.HasOne(d => d.NivelAtencion).WithMany(p => p.AreaResponsabilidads)
                .HasForeignKey(d => d.NivelAtencionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AreaResponsabilidad_NivelAtencion");

            entity.HasOne(d => d.NivelOrganizacional).WithMany(p => p.AreaResponsabilidads)
                .HasForeignKey(d => d.NivelOrganizacionalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AreaResponsabilidad_NivelOrganizacional");
        });

        modelBuilder.Entity<Campus>(entity =>
        {
            entity.HasKey(e => e.CampusId).HasName("PK__Campus__FD598D36C9246EB0");

            entity.ToTable("Campus", tb => tb.HasComment("Catálogo de campus."));

            entity.Property(e => e.CampusId)
                .HasMaxLength(50)
                .HasComment("Clave única del campus. ")
                .HasColumnName("CampusID");
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
            entity.Property(e => e.RegionId)
                .HasMaxLength(50)
                .HasComment("Región a la que pertenece este campus.")
                .HasColumnName("RegionID");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.Region).WithMany(p => p.Campuses)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Campus_Region");
        });

        modelBuilder.Entity<Capitulo>(entity =>
        {
            entity.HasKey(e => new { e.AcreditadoraProcesoId, e.CapituloId });

            entity.ToTable("Capitulo", tb => tb.HasComment("Listado de cápitulos."));

            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso al que pertenece este cápitulo.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.CapituloId)
                .HasMaxLength(50)
                .HasComment("Número del cápitulo dentro del proceso.")
                .HasColumnName("CapituloID");
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

            entity.HasOne(d => d.AcreditadoraProceso).WithMany(p => p.Capitulos)
                .HasForeignKey(d => d.AcreditadoraProcesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Capitulo_AcreditadoraProceso");
        });

        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.CarreraId).HasName("PK__Carrera__3E43B18105464057");

            entity.ToTable("Carrera", tb => tb.HasComment("Catálogo de carreras."));

            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasComment("Siglas de identificación única para la carrera.")
                .HasColumnName("CarreraID");
            entity.Property(e => e.Activo).HasComment("Indicador de activo/inactivo para el registro.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha de creación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre descriptivo de la carrera.");
            entity.Property(e => e.Plan)
                .HasMaxLength(15)
                .HasComment("Plan de la carrera.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario que realizó la última modificación sobre el registro.");
        });

        modelBuilder.Entity<Ciclo>(entity =>
        {
            entity.HasKey(e => e.CicloId).HasName("PK__Ciclo");

            entity.ToTable("Ciclo", tb => tb.HasComment("Catálogo de ciclos."));

            entity.Property(e => e.CicloId)
                .HasMaxLength(50)
                .HasComment("Clave única del ciclo.")
                .HasColumnName("CicloID");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasComment("Nombre del ciclo.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<ComentarioSeguimiento>(entity =>
        {
            entity.ToTable("ComentarioSeguimiento", tb => tb.HasComment("Comentarios de seguimiento sobre un proceso de acreditación."));

            entity.Property(e => e.ComentarioSeguimientoId)
                .HasComment("Identificador único del comentario de seguimiento.")
                .HasColumnName("ComentarioSeguimientoID");
            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso al que pertenece este comentario.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasComment("Identificador de la carrera a la que se asocia este comentario.")
                .HasColumnName("CarreraID");
            entity.Property(e => e.Contenido).HasComment("Contenido del comentario. Texto abierto.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Titulo)
                .HasMaxLength(500)
                .HasComment("Titulo del comentario.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.AcreditadoraProceso).WithMany(p => p.ComentarioSeguimientos)
                .HasForeignKey(d => d.AcreditadoraProcesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComentarioSeguimiento_AcreditadoraProceso");

            entity.HasOne(d => d.Carrera).WithMany(p => p.ComentarioSeguimientos)
                .HasForeignKey(d => d.CarreraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComentarioSeguimiento_Carrera");
        });

        modelBuilder.Entity<ConfiguracionSistema>(entity =>
        {
            entity.ToTable("ConfiguracionSistema", tb => tb.HasComment("Configuración de mensaje de mensaje de bienvenida."));

            entity.Property(e => e.ConfiguracionSistemaId)
                .HasComment("Identificador del registro de configuración.")
                .HasColumnName("ConfiguracionSistemaID");
            entity.Property(e => e.MensajeBienvenida)
                .HasMaxLength(4000)
                .HasComment("Mensaje de bienvenida en el portal FIMPES");
            entity.Property(e => e.UrlManual)
                .HasMaxLength(400)
                .HasComment("URL donde se puedes descargar el manual de la plataforma FIMPES");
        });

        modelBuilder.Entity<Criterio>(entity =>
        {
            entity.HasKey(e => new { e.AcreditadoraProcesoId, e.CriterioId, e.CarreraId });

            entity.ToTable("Criterio", tb => tb.HasComment("Listado de Criterios por Proceso"));

            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso al que pertenece este criterio.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.CriterioId)
                .HasMaxLength(50)
                .HasComment("Número del criterio dentro del proceso.")
                .HasColumnName("CriterioID");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasComment("Identificador de la carrera a la que se asocia este criterio. Null significa que no aplica.")
                .HasColumnName("CarreraID");
            entity.Property(e => e.CapituloId)
                .HasMaxLength(50)
                .HasComment("Identificador del cápitulo al que se asocia este criterio.")
                .HasColumnName("CapituloID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1500)
                .HasComment("Descripción larga del criterio.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.TipoEvidenciaId)
                .HasMaxLength(50)
                .HasComment("Identificador del tipo de evidencia que se usará para este criterio.")
                .HasColumnName("TipoEvidenciaID");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.AcreditadoraProceso).WithMany(p => p.Criterios)
                .HasForeignKey(d => d.AcreditadoraProcesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Criterio_AcreditadoraProceso");

            entity.HasOne(d => d.Carrera).WithMany(p => p.Criterios)
                .HasForeignKey(d => d.CarreraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Criterio_Carrera");

            entity.HasOne(d => d.Capitulo).WithMany(p => p.Criterios)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.CapituloId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Criterio_Capitulo");

            entity.HasOne(d => d.TipoEvidencium).WithMany(p => p.Criterios)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.TipoEvidenciaId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Criterio_TipoEvidencia");
        });

        modelBuilder.Entity<EvidenciaAnio>(entity =>
        {
            entity.HasKey(e => new { e.AnioId, e.EvidenciaId, e.AcreditadoraProcesoId, e.CarreraId, e.CriterioId });

            entity.ToTable("EvidenciaAnio", tb => tb.HasComment("Relación entre evidencias y años"));

            entity.Property(e => e.AnioId).HasColumnName("AnioID");
            entity.Property(e => e.EvidenciaId).HasColumnName("EvidenciaID");
            entity.Property(e => e.AcreditadoraProcesoId).HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasColumnName("CarreraID");
            entity.Property(e => e.CriterioId)
                .HasMaxLength(50)
                .HasColumnName("CriterioID");

            entity.HasOne(d => d.Evidencium).WithMany(p => p.EvidenciaAnios)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.CarreraId, d.CriterioId, d.EvidenciaId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EvidenciaAnio_Evidencia");
        });

        modelBuilder.Entity<Evidencium>(entity =>
        {
            entity.HasKey(e => new { e.AcreditadoraProcesoId, e.CarreraId, e.CriterioId, e.EvidenciaId });

            entity.ToTable(tb => tb.HasComment("Indice de evidencias por proceso y carrera."));

            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso al que pertenece esta evidencia.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasComment("Identificador de la carrera a la que se asocia esta evidencia. Null significa que no aplica.")
                .HasColumnName("CarreraID");
            entity.Property(e => e.CriterioId)
                .HasMaxLength(50)
                .HasComment("Identificador del criterio al que se asocia esta evidencia. El criterio también relaciona el capitulo.")
                .HasColumnName("CriterioID");
            entity.Property(e => e.EvidenciaId)
                .HasComment("Número del evidencia dentro del proceso.")
                .HasColumnName("EvidenciaID");
            entity.Property(e => e.AreaResponsabilidadId)
                .HasMaxLength(50)
                .HasColumnName("AreaResponsabilidadID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1500)
                .HasComment("Descripción larga de la evidencia.");
            entity.Property(e => e.Especificaciones)
                .HasMaxLength(4000)
                .HasComment("Especificaciones para capturar la evidencia.");
            entity.Property(e => e.FechaCompromiso)
                .HasComment("Fecha compromiso para el registro de las evidencias. Debe ser inferior a la fecha de fin del proceso.")
                .HasColumnType("date");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.NivelOrganizacionalId)
                .HasMaxLength(50)
                .HasColumnName("NivelOrganizacionalID");
            entity.Property(e => e.Responsable).HasComment("Identificador del responsable general de estas evidencias.");
            entity.Property(e => e.SedeId)
                .HasMaxLength(50)
                .HasColumnName("SedeID");
            entity.Property(e => e.TipoEvidenciaId)
                .HasMaxLength(50)
                .HasColumnName("TipoEvidenciaID");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.AcreditadoraProceso).WithMany(p => p.Evidencia)
                .HasForeignKey(d => d.AcreditadoraProcesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evidencia_AcreditadoraProceso");

            entity.HasOne(d => d.Carrera).WithMany(p => p.Evidencia)
                .HasForeignKey(d => d.CarreraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evidencia_Carrera");

            entity.HasOne(d => d.NivelOrganizacional).WithMany(p => p.Evidencia)
                .HasForeignKey(d => d.NivelOrganizacionalId)
                .HasConstraintName("FK_Evidencia_NivelOrganizacional");

            entity.HasOne(d => d.ResponsableNavigation).WithMany(p => p.Evidencia)
                .HasForeignKey(d => d.Responsable)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evidencia_Usuario");

            entity.HasOne(d => d.Sede).WithMany(p => p.Evidencia)
                .HasForeignKey(d => d.SedeId)
                .HasConstraintName("FK_Evidencia_Sede");

            entity.HasOne(d => d.A).WithMany(p => p.Evidencia)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.AreaResponsabilidadId })
                .HasConstraintName("FK_Evidencia_AreaResponsabilidad");

            entity.HasOne(d => d.TipoEvidencium).WithMany(p => p.Evidencia)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.TipoEvidenciaId })
                .HasConstraintName("FK_Evidencia_TipoEvidencia");

            entity.HasOne(d => d.Criterio).WithMany(p => p.Evidencia)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.CriterioId, d.CarreraId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evidencia_Criterio");

            entity.HasMany(d => d.Campuses).WithMany(p => p.Evidencia)
                .UsingEntity<Dictionary<string, object>>(
                    "EvidenciaCampus",
                    r => r.HasOne<Campus>().WithMany()
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EvidenciaCampus_Campus"),
                    l => l.HasOne<Evidencium>().WithMany()
                        .HasForeignKey("AcreditadoraProcesoId", "CarreraId", "CriterioId", "EvidenciaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EvidenciaCampus_Evidencia"),
                    j =>
                    {
                        j.HasKey("AcreditadoraProcesoId", "CarreraId", "CriterioId", "EvidenciaId", "CampusId");
                        j.ToTable("EvidenciaCampus", tb => tb.HasComment("Relación entre evidencias y campuses."));
                        j.IndexerProperty<int>("AcreditadoraProcesoId")
                            .HasComment("Identificador del proceso al que pertenece esta evidencia.")
                            .HasColumnName("AcreditadoraProcesoID");
                        j.IndexerProperty<string>("CarreraId")
                            .HasMaxLength(50)
                            .HasComment("Identificador de la carrera a la que se asocia esta evidencia. Null significa que no aplica.")
                            .HasColumnName("CarreraID");
                        j.IndexerProperty<string>("CriterioId")
                            .HasMaxLength(50)
                            .HasComment("Identificador del criterio al que se asocia esta evidencia. El criterio también relaciona el capitulo.")
                            .HasColumnName("CriterioID");
                        j.IndexerProperty<int>("EvidenciaId")
                            .HasComment("Número del evidencia dentro del proceso.")
                            .HasColumnName("EvidenciaID");
                        j.IndexerProperty<string>("CampusId")
                            .HasMaxLength(50)
                            .HasColumnName("CampusID");
                    });

            entity.HasMany(d => d.Ciclos).WithMany(p => p.Evidencia)
                .UsingEntity<Dictionary<string, object>>(
                    "EvidenciaCiclo",
                    r => r.HasOne<Ciclo>().WithMany()
                        .HasForeignKey("CicloId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EvidenciaCiclo_Ciclo"),
                    l => l.HasOne<Evidencium>().WithMany()
                        .HasForeignKey("AcreditadoraProcesoId", "CarreraId", "CriterioId", "EvidenciaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EvidenciaCiclo_Evidencia"),
                    j =>
                    {
                        j.HasKey("EvidenciaId", "CicloId", "AcreditadoraProcesoId", "CriterioId", "CarreraId");
                        j.ToTable("EvidenciaCiclo", tb => tb.HasComment("Relación entre evidencias y ciclos"));
                        j.IndexerProperty<int>("EvidenciaId").HasColumnName("EvidenciaID");
                        j.IndexerProperty<string>("CicloId")
                            .HasMaxLength(50)
                            .HasColumnName("CicloID");
                        j.IndexerProperty<int>("AcreditadoraProcesoId").HasColumnName("AcreditadoraProcesoID");
                        j.IndexerProperty<string>("CriterioId")
                            .HasMaxLength(50)
                            .HasColumnName("CriterioID");
                        j.IndexerProperty<string>("CarreraId")
                            .HasMaxLength(50)
                            .HasColumnName("CarreraID");
                    });

            entity.HasMany(d => d.Subareas).WithMany(p => p.Evidencia)
                .UsingEntity<Dictionary<string, object>>(
                    "EvidenciaSubarea",
                    r => r.HasOne<Subarea>().WithMany()
                        .HasForeignKey("SubareaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EvidenciaSubarea_Subarea"),
                    l => l.HasOne<Evidencium>().WithMany()
                        .HasForeignKey("AcreditadoraProcesoId", "CarreraId", "CriterioId", "EvidenciaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_EvidenciaSubarea_Evidencia"),
                    j =>
                    {
                        j.HasKey("AcreditadoraProcesoId", "CarreraId", "CriterioId", "EvidenciaId", "SubareaId");
                        j.ToTable("EvidenciaSubarea", tb => tb.HasComment("Relación entre evidencias y subáreas."));
                        j.IndexerProperty<int>("AcreditadoraProcesoId")
                            .HasComment("Identificador del proceso al que pertenece esta evidencia.")
                            .HasColumnName("AcreditadoraProcesoID");
                        j.IndexerProperty<string>("CarreraId")
                            .HasMaxLength(50)
                            .HasComment("Identificador de la carrera a la que se asocia esta evidencia. Null significa que no aplica.")
                            .HasColumnName("CarreraID");
                        j.IndexerProperty<string>("CriterioId")
                            .HasMaxLength(50)
                            .HasComment("Identificador del criterio al que se asocia esta evidencia. El criterio también relaciona el capitulo.")
                            .HasColumnName("CriterioID");
                        j.IndexerProperty<int>("EvidenciaId")
                            .HasComment("Número del evidencia dentro del proceso.")
                            .HasColumnName("EvidenciaID");
                        j.IndexerProperty<string>("SubareaId")
                            .HasMaxLength(50)
                            .HasColumnName("SubareaID");
                    });
        });

        modelBuilder.Entity<NivelAtencion>(entity =>
        {
            entity.HasKey(e => e.NivelAtencionId).HasName("PK__NivelAte__70133C66BBE3C88C");

            entity.ToTable("NivelAtencion", tb => tb.HasComment("Catálogo de niveles de atención."));

            entity.Property(e => e.NivelAtencionId)
                .HasMaxLength(50)
                .HasComment("Clave única del nivel de atención. ")
                .HasColumnName("NivelAtencionID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre del nivel de atención.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<NivelOrganizacional>(entity =>
        {
            entity.HasKey(e => e.NivelOrganizacionalId).HasName("PK__NivelOrg__DBFF4C5119D2531C");

            entity.ToTable("NivelOrganizacional", tb => tb.HasComment("Catálogo de niveles organizacionales."));

            entity.Property(e => e.NivelOrganizacionalId)
                .HasMaxLength(50)
                .HasComment("Clave única del nivel organizacional. ")
                .HasColumnName("NivelOrganizacionalID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre del nivel organizacional.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("PK__Region__ACD84443B0DB16B6");

            entity.ToTable("Region", tb => tb.HasComment("Catálogo de regiones."));

            entity.Property(e => e.RegionId)
                .HasMaxLength(50)
                .HasComment("Clave única del región. ")
                .HasColumnName("RegionID");
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

        modelBuilder.Entity<RegistroEvidenciaArchivo>(entity =>
        {
            entity.ToTable("RegistroEvidenciaArchivo", tb => tb.HasComment("Listado de archivos registrados como evidencia."));

            entity.Property(e => e.RegistroEvidenciaArchivoId)
                .HasComment("Identificador único del archivo registrado.")
                .HasColumnName("RegistroEvidenciaArchivoID");
            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso al que pertenece este archivo de evidencia.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.CampusId)
                .HasMaxLength(50)
                .HasComment("Identificador del campus al que pertenece este archivo de evidencia.")
                .HasColumnName("CampusID");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasComment("Identificador de la carrera a la que se asocia este archivo de evidencia.")
                .HasColumnName("CarreraID");
            entity.Property(e => e.CriterioId)
                .HasMaxLength(50)
                .HasComment("Identificador del criterio al que se asocia este archivo de evidencia.")
                .HasColumnName("CriterioID");
            entity.Property(e => e.EsUrl).HasComment("Indicador de si el registro es un archivo o una URL.");
            entity.Property(e => e.EvidenciaId)
                .HasComment("Número del evidencia dentro del proceso al que pertence este archivo.")
                .HasColumnName("EvidenciaID");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Mime)
                .HasMaxLength(500)
                .HasComment("En el caso de archivos, el mime type del tipo de archivo.");
            entity.Property(e => e.NombreArchivo)
                .HasMaxLength(500)
                .HasComment("En el caso de archivos, el nombre físico del archivo.");
            entity.Property(e => e.RegistroEvidenciaId)
                .HasComment("Identificador del registro de evidencia.")
                .HasColumnName("RegistroEvidenciaID");
            entity.Property(e => e.SubareaId)
                .HasMaxLength(50)
                .HasComment("Identificador de la subárea a la que pertence este archivo de evidencia.")
                .HasColumnName("SubareaID");
            entity.Property(e => e.Url)
                .HasMaxLength(1500)
                .HasComment("En caso de ser URL, esta es la dirección de la evidencia.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.RegistroEvidencium).WithMany(p => p.RegistroEvidenciaArchivos)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.CarreraId, d.CriterioId, d.EvidenciaId, d.SubareaId, d.CampusId, d.RegistroEvidenciaId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistroEvidenciaArchivo_RegistroEvidencia");
        });

        modelBuilder.Entity<RegistroEvidencium>(entity =>
        {
            entity.HasKey(e => new { e.AcreditadoraProcesoId, e.CarreraId, e.CriterioId, e.EvidenciaId, e.SubareaId, e.CampusId, e.RegistroEvidenciaId });

            entity.ToTable(tb => tb.HasComment("Tabla donde se generan los registros de evidencia en base los indices."));

            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso al que pertenece esta evidencia.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasComment("Identificador de la carrera a la que se asocia esta evidencia. Null significa que no aplica.")
                .HasColumnName("CarreraID");
            entity.Property(e => e.CriterioId)
                .HasMaxLength(50)
                .HasComment("Identificador del criterio al que se asocia esta evidencia. El criterio también relaciona el capitulo.")
                .HasColumnName("CriterioID");
            entity.Property(e => e.EvidenciaId)
                .HasComment("Número del evidencia dentro del proceso.")
                .HasColumnName("EvidenciaID");
            entity.Property(e => e.SubareaId)
                .HasMaxLength(50)
                .HasComment("Clave de subárea a la cual se asocia este registro de evidencia.")
                .HasColumnName("SubareaID");
            entity.Property(e => e.CampusId)
                .HasMaxLength(50)
                .HasComment("Clave de campus a la cual se asocia este registro de evidencia.")
                .HasColumnName("CampusID");
            entity.Property(e => e.RegistroEvidenciaId)
                .ValueGeneratedOnAdd()
                .HasComment("Identificador unico del registro de evidencia.")
                .HasColumnName("RegistroEvidenciaID");
            entity.Property(e => e.AnioId)
                .HasComment("Año asignado a este registro de evidencia.")
                .HasColumnName("AnioID");
            entity.Property(e => e.CicloId)
                .HasMaxLength(50)
                .HasComment("Ciclo asignado a este registro de evidencia.")
                .HasColumnName("CicloID");
            entity.Property(e => e.EsAceptada).HasComment("Indica si la evidencia fue aceptada y ya solo puede ser editada por el validador.");
            entity.Property(e => e.EsCargada).HasComment("Indica si la evidencia ya fue registrada y esta lista para ser validada.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.AcreditadoraProceso).WithMany(p => p.RegistroEvidencia)
                .HasForeignKey(d => d.AcreditadoraProcesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistroEvidencia_AcreditadoraProceso");

            entity.HasOne(d => d.Campus).WithMany(p => p.RegistroEvidencia)
                .HasForeignKey(d => d.CampusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistroEvidencia_Campus");

            entity.HasOne(d => d.Ciclo).WithMany(p => p.RegistroEvidencia)
                .HasForeignKey(d => d.CicloId)
                .HasConstraintName("FK_RegistroEvidencia_Ciclo");

            entity.HasOne(d => d.Subarea).WithMany(p => p.RegistroEvidencia)
                .HasForeignKey(d => d.SubareaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistroEvidencia_Subarea");

            entity.HasOne(d => d.Criterio).WithMany(p => p.RegistroEvidencia)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.CriterioId, d.CarreraId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistroEvidencia_Criterio");

            entity.HasOne(d => d.Evidencium).WithMany(p => p.RegistroEvidencia)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.CarreraId, d.CriterioId, d.EvidenciaId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistroEvidencia_Evidencia");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Rol__F92302D12D711E53");

            entity.ToTable("Rol", tb => tb.HasComment("Catálogo de roles del sistema."));

            entity.Property(e => e.RolId)
                .ValueGeneratedNever()
                .HasComment("Identificador único del rol.")
                .HasColumnName("RolID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.Descripción)
                .HasMaxLength(500)
                .HasComment("Descripción del rol.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasComment("Nombre del rol.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasMany(d => d.Usuarios).WithMany(p => p.Rols)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioRol",
                    r => r.HasOne<Usuario>().WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsuarioRol_Usuario"),
                    l => l.HasOne<Rol>().WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsuarioRol_Rol"),
                    j =>
                    {
                        j.HasKey("RolId", "UsuarioId").HasName("PK__UsuarioR__6B90DCA8DF136C71");
                        j.ToTable("UsuarioRol", tb => tb.HasComment("Asociación entre usuarios y roles del sistema."));
                        j.IndexerProperty<int>("RolId").HasColumnName("RolID");
                        j.IndexerProperty<Guid>("UsuarioId").HasColumnName("UsuarioID");
                    });
        });

        modelBuilder.Entity<RolProceso>(entity =>
        {
            entity.HasKey(e => new { e.AcreditadoraProcesoId, e.RolProcesoId });

            entity.ToTable("RolProceso", tb => tb.HasComment("Listado de Roles por Proceso."));

            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso al que pertenece este rol.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.RolProcesoId)
                .HasMaxLength(50)
                .HasComment("Identificador del rol para el proceso.")
                .HasColumnName("RolProcesoID");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre del rol.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
            entity.Property(e => e.VistaInicial).HasMaxLength(50);

            entity.HasOne(d => d.AcreditadoraProceso).WithMany(p => p.RolProcesos)
                .HasForeignKey(d => d.AcreditadoraProcesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolProceso_AcreditadoraProceso");

            entity.HasOne(d => d.VistaInicialNavigation).WithMany(p => p.RolProcesos)
                .HasForeignKey(d => d.VistaInicial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolProceso_Vista");

            entity.HasMany(d => d.Vista).WithMany(p => p.RolProcesosNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "VistaRolProceso",
                    r => r.HasOne<Vistum>().WithMany()
                        .HasForeignKey("VistaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_VistaRolProceso_Vista"),
                    l => l.HasOne<RolProceso>().WithMany()
                        .HasForeignKey("AcreditadoraProcesoId", "RolProcesoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_VistaRolProceso_RolProceso"),
                    j =>
                    {
                        j.HasKey("AcreditadoraProcesoId", "RolProcesoId", "VistaId");
                        j.ToTable("VistaRolProceso", tb => tb.HasComment("Asociación entre vistas y roles."));
                        j.IndexerProperty<int>("AcreditadoraProcesoId")
                            .HasComment("Identificador del proceso al que pertenece este rol.")
                            .HasColumnName("AcreditadoraProcesoID");
                        j.IndexerProperty<string>("RolProcesoId")
                            .HasMaxLength(50)
                            .HasComment("Identificador del rol para el proceso.")
                            .HasColumnName("RolProcesoID");
                        j.IndexerProperty<string>("VistaId")
                            .HasMaxLength(50)
                            .HasColumnName("VistaID");
                    });
        });

        modelBuilder.Entity<RolProcesoVistaTipoAcceso>(entity =>
        {
            entity.HasKey(e => e.RolProcesoVistaTipoAccesoId).HasName("PK_RolVistaTipoAcceso");

            entity.ToTable("RolProcesoVistaTipoAcceso", tb => tb.HasComment("Asociación entre rol, vista y tipo de acceso."));

            entity.Property(e => e.RolProcesoVistaTipoAccesoId).HasColumnName("RolProcesoVistaTipoAccesoID");
            entity.Property(e => e.RolProcesoVistaId).HasColumnName("RolProcesoVistaID");
            entity.Property(e => e.TipoAccesoId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TipoAccesoID");

            entity.HasOne(d => d.RolProcesoVista).WithMany(p => p.RolProcesoVistaTipoAccesos)
                .HasForeignKey(d => d.RolProcesoVistaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolProcesoVistaTipoAcceso_RolProcesoVista");

            entity.HasOne(d => d.TipoAcceso).WithMany(p => p.RolProcesoVistaTipoAccesos)
                .HasForeignKey(d => d.TipoAccesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolProcesoVistaTipoAcceso_TipoAcceso");
        });

        modelBuilder.Entity<RolProcesoVistum>(entity =>
        {
            entity.HasKey(e => e.RolProcesoVistaId);

            entity.ToTable(tb => tb.HasComment("Listado de Vistas por Rol."));

            entity.Property(e => e.RolProcesoVistaId)
                .HasComment("Identificador único de la relación rol y vista.")
                .HasColumnName("RolProcesoVistaID");
            entity.Property(e => e.AcreditadoraProcesoId).HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.RolProcesoId)
                .HasMaxLength(50)
                .HasComment("Identificador del rol.")
                .HasColumnName("RolProcesoID");
            entity.Property(e => e.VistaId)
                .HasMaxLength(50)
                .HasComment("Identificador de la vista.")
                .HasColumnName("VistaID");

            entity.HasOne(d => d.Vista).WithMany(p => p.RolProcesoVista)
                .HasForeignKey(d => d.VistaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolProcesoVista_Vista");

            entity.HasOne(d => d.RolProceso).WithMany(p => p.RolProcesoVista)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.RolProcesoId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolProcesoVista_RolProceso");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.SedeId).HasName("PK__Sede__FD76DFFB31AA57B8");

            entity.ToTable("Sede", tb => tb.HasComment("Catálogo de sedes."));

            entity.Property(e => e.SedeId)
                .HasMaxLength(50)
                .HasComment("Clave única de la sede. ")
                .HasColumnName("SedeID");
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

        modelBuilder.Entity<Subarea>(entity =>
        {
            entity.HasKey(e => e.SubareaId).HasName("PK__Subarea__FCB946D3653132ED");

            entity.ToTable("Subarea", tb => tb.HasComment("Catálogo de subareas."));

            entity.Property(e => e.SubareaId)
                .HasMaxLength(50)
                .HasComment("Clave única de la subarea. ")
                .HasColumnName("SubareaID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.NivelAtencionId)
                .HasMaxLength(50)
                .HasComment("Nivel de atención al que pertence esta subarea.")
                .HasColumnName("NivelAtencionID");
            entity.Property(e => e.NivelOrganizacionalId)
                .HasMaxLength(50)
                .HasComment("Nivel organizacional al que pertence esta subarea.")
                .HasColumnName("NivelOrganizacionalID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre de la subarea.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.NivelAtencion).WithMany(p => p.Subareas)
                .HasForeignKey(d => d.NivelAtencionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subarea_NivelAtencion");

            entity.HasOne(d => d.NivelOrganizacional).WithMany(p => p.Subareas)
                .HasForeignKey(d => d.NivelOrganizacionalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Subarea_NivelOrganizacional");
        });

        modelBuilder.Entity<TipoAcceso>(entity =>
        {
            entity.ToTable("TipoAcceso", tb => tb.HasComment("Catálogo de tipo de acceso del sistema."));

            entity.Property(e => e.TipoAccesoId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("Identificador único del tipo de acceso.")
                .HasColumnName("TipoAccesoID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Descripción del tipo acceso.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Nombre del tipo acceso.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<TipoEvidencium>(entity =>
        {
            entity.HasKey(e => new { e.AcreditadoraProcesoId, e.TipoEvidenciaId });

            entity.ToTable(tb => tb.HasComment("Catálogo de tipo de evidencias."));

            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso al que pertenece este tipo de evidencia.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.TipoEvidenciaId)
                .HasMaxLength(50)
                .HasComment("Clave única del tipo de evidencia. ")
                .HasColumnName("TipoEvidenciaID");
            entity.Property(e => e.Activo).HasComment("Indica si el registro se encuentra activo en el sistema.");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre del tipo de evidencia.");
            entity.Property(e => e.RegionId)
                .HasMaxLength(50)
                .HasComment("Región a la que pertenece este tipo de evidencia.")
                .HasColumnName("RegionID");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");

            entity.HasOne(d => d.AcreditadoraProceso).WithMany(p => p.TipoEvidencia)
                .HasForeignKey(d => d.AcreditadoraProcesoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoEvidencia_AcreditadoraProces");

            entity.HasOne(d => d.Region).WithMany(p => p.TipoEvidencia)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TipoEvidencia_Region");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE798895CF517");

            entity.ToTable("Usuario", tb => tb.HasComment("Listado de usaurios del sistema."));

            entity.HasIndex(e => e.Correo, "IX_Usuario_Correo").IsUnique();

            entity.Property(e => e.UsuarioId)
                .ValueGeneratedNever()
                .HasComment("Identificador único del usuario en el directorio activo.")
                .HasColumnName("UsuarioID");
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
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        modelBuilder.Entity<UsuarioRolProceso>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioId, e.AcreditadoraProcesoId, e.RolProcesoId, e.CarreraId });

            entity.ToTable("UsuarioRolProceso", tb => tb.HasComment("Asociación entre usuarios y roles por proceso."));

            entity.Property(e => e.UsuarioId)
                .HasComment("Identificador del usuario.")
                .HasColumnName("UsuarioID");
            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso de acreditación.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.RolProcesoId)
                .HasMaxLength(50)
                .HasComment("Identificador del rol asociado.")
                .HasColumnName("RolProcesoID");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasColumnName("CarreraID");
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha de creación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que creó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario que realizó la última modificación del registro.");

            entity.HasOne(d => d.Carrera).WithMany(p => p.UsuarioRolProcesos)
                .HasForeignKey(d => d.CarreraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRolProceso_Carrera");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioRolProcesos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRolProceso_Usuario");

            entity.HasOne(d => d.RolProceso).WithMany(p => p.UsuarioRolProcesos)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.RolProcesoId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRolProceso_RolProceso");

            entity.HasMany(d => d.Campuses).WithMany(p => p.UsuarioRolProcesos)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioRolProcesoCampus",
                    r => r.HasOne<Campus>().WithMany()
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsuarioRolProcesoCampus_Campus"),
                    l => l.HasOne<UsuarioRolProceso>().WithMany()
                        .HasForeignKey("UsuarioId", "AcreditadoraProcesoId", "RolProcesoId", "CarreraId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsuarioRolProcesoCampus_UsuarioRolProceso"),
                    j =>
                    {
                        j.HasKey("UsuarioId", "AcreditadoraProcesoId", "RolProcesoId", "CarreraId", "CampusId");
                        j.ToTable("UsuarioRolProcesoCampus", tb => tb.HasComment("Asociación entre usuario, rol y campus."));
                        j.IndexerProperty<Guid>("UsuarioId")
                            .HasComment("Identificador del usuario.")
                            .HasColumnName("UsuarioID");
                        j.IndexerProperty<int>("AcreditadoraProcesoId")
                            .HasComment("Identificador del proceso de acreditación.")
                            .HasColumnName("AcreditadoraProcesoID");
                        j.IndexerProperty<string>("RolProcesoId")
                            .HasMaxLength(50)
                            .HasComment("Identificador del rol asociado.")
                            .HasColumnName("RolProcesoID");
                        j.IndexerProperty<string>("CarreraId")
                            .HasMaxLength(50)
                            .HasColumnName("CarreraID");
                        j.IndexerProperty<string>("CampusId")
                            .HasMaxLength(50)
                            .HasComment("Identificador del campus.")
                            .HasColumnName("CampusID");
                    });
        });

        modelBuilder.Entity<UsuarioRolProcesoCapitulo>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioId, e.AcreditadoraProcesoId, e.RolProcesoId, e.CarreraId, e.CapituloId });

            entity.ToTable("UsuarioRolProcesoCapitulo", tb => tb.HasComment("Asociación entre usaurio, rol y captíulos."));

            entity.Property(e => e.UsuarioId)
                .HasComment("Identificador del usuario.")
                .HasColumnName("UsuarioID");
            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso de acreditación.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.RolProcesoId)
                .HasMaxLength(50)
                .HasComment("Identificador del rol asociado.")
                .HasColumnName("RolProcesoID");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasColumnName("CarreraID");
            entity.Property(e => e.CapituloId)
                .HasMaxLength(50)
                .HasComment("Identificador del capitulo.")
                .HasColumnName("CapituloID");

            entity.HasOne(d => d.Capitulo).WithMany(p => p.UsuarioRolProcesoCapitulos)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.CapituloId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRolProcesoCapitulo_Capitulo");

            entity.HasOne(d => d.UsuarioRolProceso).WithMany(p => p.UsuarioRolProcesoCapitulos)
                .HasForeignKey(d => new { d.UsuarioId, d.AcreditadoraProcesoId, d.RolProcesoId, d.CarreraId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRolProcesoCapitulo_UsuarioRolProceso");
        });

        modelBuilder.Entity<UsuarioRolProcesoCriterio>(entity =>
        {
            entity.HasKey(e => new { e.UsuarioId, e.AcreditadoraProcesoId, e.RolProcesoId, e.CarreraId, e.CriterioId });

            entity.ToTable("UsuarioRolProcesoCriterio", tb => tb.HasComment("Asociación entre usaurio, rol y captíulos."));

            entity.Property(e => e.UsuarioId)
                .HasComment("Identificador del usuario.")
                .HasColumnName("UsuarioID");
            entity.Property(e => e.AcreditadoraProcesoId)
                .HasComment("Identificador del proceso de acreditación.")
                .HasColumnName("AcreditadoraProcesoID");
            entity.Property(e => e.RolProcesoId)
                .HasMaxLength(50)
                .HasComment("Identificador del rol asociado.")
                .HasColumnName("RolProcesoID");
            entity.Property(e => e.CarreraId)
                .HasMaxLength(50)
                .HasColumnName("CarreraID");
            entity.Property(e => e.CriterioId)
                .HasMaxLength(50)
                .HasComment("Identificador del criterio")
                .HasColumnName("CriterioID");

            entity.HasOne(d => d.Criterio).WithMany(p => p.UsuarioRolProcesoCriterios)
                .HasForeignKey(d => new { d.AcreditadoraProcesoId, d.CriterioId, d.CarreraId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRolProcesoCriterio_Criterio");

            entity.HasOne(d => d.UsuarioRolProceso).WithMany(p => p.UsuarioRolProcesoCriterios)
                .HasForeignKey(d => new { d.UsuarioId, d.AcreditadoraProcesoId, d.RolProcesoId, d.CarreraId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRolProcesoCriterio_UsuarioRolProceso");
        });

        modelBuilder.Entity<Vistum>(entity =>
        {
            entity.HasKey(e => e.VistaId);

            entity.ToTable(tb => tb.HasComment("Listado de vistas existentes en la plataforma."));

            entity.Property(e => e.VistaId)
                .HasMaxLength(50)
                .HasComment("Identificador interno de la vista.")
                .HasColumnName("VistaID");
            entity.Property(e => e.Clave).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion)
                .HasComment("Fecha en la que fue creado el registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasComment("Fecha de última modificación del registro.")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .HasComment("Nombre público de la vista.");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasComment("Usuario que generó el registro.");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .HasComment("Usuario de última modificación del registro.");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
