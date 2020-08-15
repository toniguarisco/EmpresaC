using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiRestDesarrollo.Models
{
    public partial class postgresContext : DbContext
    {
        public postgresContext()
        {
        }

        public postgresContext(DbContextOptions<postgresContext> opt) : base(opt)
        {
        }

        public bool saveChanges()
        {
            return SaveChanges() >= 0;
        }

        public virtual DbSet<Aplicacion> Aplicacion { get; set; }
        public virtual DbSet<Banco> Banco { get; set; }
        public virtual DbSet<Bitacora> Bitacora { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Comercio> Comercio { get; set; }
        public virtual DbSet<Contrasena> Contrasena { get; set; }
        public virtual DbSet<Cuenta> Cuenta { get; set; }
        public virtual DbSet<EstadoCivil> EstadoCivil { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Frecuencia> Frecuencia { get; set; }
        public virtual DbSet<OpcionMenu> OpcionMenu { get; set; }
        public virtual DbSet<OperacionCuenta> OperacionCuenta { get; set; }
        public virtual DbSet<OperacionTarjeta> OperacionTarjeta { get; set; }
        public virtual DbSet<OperacionesMonedero> OperacionesMonedero { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Parametro> Parametro { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Reintegro> Reintegro { get; set; }
        public virtual DbSet<Tarjeta> Tarjeta { get; set; }
        public virtual DbSet<TipoCuenta> TipoCuenta { get; set; }
        public virtual DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }
        public virtual DbSet<TipoOperacion> TipoOperacion { get; set; }
        public virtual DbSet<TipoParametro> TipoParametro { get; set; }
        public virtual DbSet<TipoTarjeta> TipoTarjeta { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioOpcionMenu> UsuarioOpcionMenu { get; set; }
        public virtual DbSet<UsuarioParametro> UsuarioParametro { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseNpgsql("Host=ec2-52-90-180-87.compute-1.amazonaws.com;Database=postgres;Username=postgres;Password=gustavo");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aplicacion>(entity =>
            {
                entity.HasKey(e => e.IdAplicacion)
                    .HasName("pk_id_aplicacion");

                entity.ToTable("aplicacion");

                entity.Property(e => e.IdAplicacion)
                    .HasColumnName("id_aplicacion")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(45);

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasColumnName("estatus")
                    .HasMaxLength(45);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Banco>(entity =>
            {
                entity.HasKey(e => e.IdBanco)
                    .HasName("pk_id_banco");

                entity.ToTable("banco");

                entity.Property(e => e.IdBanco)
                    .HasColumnName("id_banco")
                    .ValueGeneratedNever();

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.HasKey(e => e.IdAuditoria)
                    .HasName("pk_id_auditoria");

                entity.ToTable("bitacora");

                entity.Property(e => e.IdAuditoria)
                    .HasColumnName("id_auditoria")
                    .ValueGeneratedNever();

                entity.Property(e => e.CausaError)
                    .HasColumnName("causa_error")
                    .HasMaxLength(2500);

                entity.Property(e => e.DatosOperacion)
                    .IsRequired()
                    .HasColumnName("datos_operacion")
                    .HasMaxLength(2500);

                entity.Property(e => e.FechaBitacora)
                    .HasColumnName("fecha_bitacora")
                    .HasColumnType("date");

                entity.Property(e => e.IdEvento).HasColumnName("id_evento");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Bitacora)
                    .HasForeignKey(d => d.IdEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_evento");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Bitacora)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usuario");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Clave)
                    .HasColumnName("clave")
                    .HasMaxLength(30);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Comercio>(entity =>
            {
                entity.HasKey(e => e.IdComercio)
                    .HasName("pk_id_comercio");

                entity.ToTable("comercio");

                entity.Property(e => e.IdComercio)
                    .HasColumnName("id_comercio")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApellidoRepresentante)
                    .IsRequired()
                    .HasColumnName("apellido_representante")
                    .HasMaxLength(45);

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.NombreRepresentante)
                    .IsRequired()
                    .HasColumnName("nombre_representante")
                    .HasMaxLength(45);

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasColumnName("razon_social")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Comercio)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usuario");
            });

            modelBuilder.Entity<Contrasena>(entity =>
            {
                entity.HasKey(e => e.IdContrasena)
                    .HasName("pk_id_contrasena");

                entity.ToTable("contrasena");

                entity.Property(e => e.IdContrasena)
                    .HasColumnName("id_contrasena")
                    .ValueGeneratedNever();

                entity.Property(e => e.Contrasena1)
                    .IsRequired()
                    .HasColumnName("contrasena")
                    .HasMaxLength(20);

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.IntentosFallidos).HasColumnName("intentos_fallidos");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Contrasena)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usuario");
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasKey(e => e.IdCuenta)
                    .HasName("pk_id_cuenta");

                entity.ToTable("cuenta");

                entity.Property(e => e.IdCuenta)
                    .HasColumnName("id_cuenta")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdBanco).HasColumnName("id_banco");

                entity.Property(e => e.IdTipoCuenta).HasColumnName("id_tipo_cuenta");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.NumeroCuenta)
                    .IsRequired()
                    .HasColumnName("numero_cuenta")
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdBancoNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdBanco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_banco");

                entity.HasOne(d => d.IdTipoCuentaNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdTipoCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_tipo_cuenta");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usuario");
            });

            modelBuilder.Entity<EstadoCivil>(entity =>
            {
                entity.HasKey(e => e.IdEstadoCivil)
                    .HasName("pk_id_estado_civil");

                entity.ToTable("estado_civil");

                entity.Property(e => e.IdEstadoCivil)
                    .HasColumnName("id_estado_civil")
                    .ValueGeneratedNever();

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(45);

                entity.Property(e => e.Estatus).HasColumnName("estatus");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.HasKey(e => e.IdEvento)
                    .HasName("pk_id_evento");

                entity.ToTable("evento");

                entity.Property(e => e.IdEvento)
                    .HasColumnName("id_evento")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodigoEvento)
                    .IsRequired()
                    .HasColumnName("codigo_evento")
                    .HasMaxLength(4);

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.Evento1)
                    .IsRequired()
                    .HasColumnName("evento")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Frecuencia>(entity =>
            {
                entity.HasKey(e => e.IdFrecuencia)
                    .HasName("pk_id_frecuencia");

                entity.ToTable("frecuencia");

                entity.Property(e => e.IdFrecuencia)
                    .HasColumnName("id_frecuencia")
                    .ValueGeneratedNever();

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(45);

                entity.Property(e => e.Estatus).HasColumnName("estatus");
            });

            modelBuilder.Entity<OpcionMenu>(entity =>
            {
                entity.HasKey(e => e.IdOpcionMenu)
                    .HasName("pk_id_opcion_menu");

                entity.ToTable("opcion_menu");

                entity.Property(e => e.IdOpcionMenu)
                    .HasColumnName("id_opcion_menu")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(45);

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.IdAplicacion).HasColumnName("id_aplicacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(45);

                entity.Property(e => e.Posicion).HasColumnName("posicion");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdAplicacionNavigation)
                    .WithMany(p => p.OpcionMenu)
                    .HasForeignKey(d => d.IdAplicacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_aplicacion");
            });

            modelBuilder.Entity<OperacionCuenta>(entity =>
            {
                entity.HasKey(e => e.IdOperacionCuenta)
                    .HasName("pk_id_operacion_cuenta");

                entity.ToTable("operacion_cuenta");

                entity.Property(e => e.IdOperacionCuenta)
                    .HasColumnName("id_operacion_cuenta")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Hora)
                    .HasColumnName("hora")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");

                entity.Property(e => e.IdUsuarioReceptor).HasColumnName("id_usuario_receptor");

                entity.Property(e => e.Monto)
                    .HasColumnName("monto")
                    .HasColumnType("numeric");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasColumnName("referencia")
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.OperacionCuenta)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_cuenta");

                entity.HasOne(d => d.IdUsuarioReceptorNavigation)
                    .WithMany(p => p.OperacionCuenta)
                    .HasForeignKey(d => d.IdUsuarioReceptor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usuario_receptor");
            });

            modelBuilder.Entity<OperacionTarjeta>(entity =>
            {
                entity.HasKey(e => e.IdOperacionTarjeta)
                    .HasName("pk_id_operacion_tarjeta");

                entity.ToTable("operacion_tarjeta");

                entity.Property(e => e.IdOperacionTarjeta)
                    .HasColumnName("id_operacion_tarjeta")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Hora)
                    .HasColumnName("hora")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.IdTarjeta).HasColumnName("id_tarjeta");

                entity.Property(e => e.IdUsuarioReceptor).HasColumnName("id_usuario_receptor");

                entity.Property(e => e.Monto)
                    .HasColumnName("monto")
                    .HasColumnType("numeric");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasColumnName("referencia")
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdTarjetaNavigation)
                    .WithMany(p => p.OperacionTarjeta)
                    .HasForeignKey(d => d.IdTarjeta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_tarjeta");

                entity.HasOne(d => d.IdUsuarioReceptorNavigation)
                    .WithMany(p => p.OperacionTarjeta)
                    .HasForeignKey(d => d.IdUsuarioReceptor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usuario_receptor");
            });

            modelBuilder.Entity<OperacionesMonedero>(entity =>
            {
                entity.HasKey(e => e.IdOperacionesMonedero)
                    .HasName("pk_id_operaciones_monedero");

                entity.ToTable("operaciones_monedero");

                entity.Property(e => e.IdOperacionesMonedero)
                    .HasColumnName("id_operaciones_monedero")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Hora)
                    .HasColumnName("hora")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.IdTipoOperacion).HasColumnName("id_tipo_operacion");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.Referencia)
                    .HasColumnName("referencia")
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdTipoOperacionNavigation)
                    .WithMany(p => p.OperacionesMonedero)
                    .HasForeignKey(d => d.IdTipoOperacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_tipo_operacion");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.OperacionesMonedero)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usuario");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("pk_id_pago");

                entity.ToTable("pago");

                entity.Property(e => e.IdPago)
                    .HasColumnName("id_pago")
                    .ValueGeneratedNever();

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasColumnName("estatus")
                    .HasMaxLength(45);

                entity.Property(e => e.FechaSolicitud)
                    .HasColumnName("fecha_solicitud")
                    .HasColumnType("date");

                entity.Property(e => e.IdUsuarioReceptor).HasColumnName("id_usuario_receptor");

                entity.Property(e => e.IdUsuarioSolicitante).HasColumnName("id_usuario_solicitante");

                entity.Property(e => e.Monto)
                    .HasColumnName("monto")
                    .HasColumnType("numeric");

                entity.Property(e => e.Referencia)
                    .HasColumnName("referencia")
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdUsuarioReceptorNavigation)
                    .WithMany(p => p.PagoIdUsuarioReceptorNavigation)
                    .HasForeignKey(d => d.IdUsuarioReceptor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usuario_receptor");

                entity.HasOne(d => d.IdUsuarioSolicitanteNavigation)
                    .WithMany(p => p.PagoIdUsuarioSolicitanteNavigation)
                    .HasForeignKey(d => d.IdUsuarioSolicitante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usuario_solicitante");
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.HasKey(e => e.IdParametro)
                    .HasName("pk_id_parametro");

                entity.ToTable("parametro");

                entity.Property(e => e.IdParametro)
                    .HasColumnName("id_parametro")
                    .ValueGeneratedNever();

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.IdFrecuencia).HasColumnName("id_frecuencia");

                entity.Property(e => e.IdTipoParametro).HasColumnName("id_tipo_parametro");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(45);

                entity.Property(e => e.comision)
                    .IsRequired()
                    .HasColumnType("comision");

                entity.HasOne(d => d.IdFrecuenciaNavigation)
                    .WithMany(p => p.Parametro)
                    .HasForeignKey(d => d.IdFrecuencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_frecuencia");

                entity.HasOne(d => d.IdTipoParametroNavigation)
                    .WithMany(p => p.Parametro)
                    .HasForeignKey(d => d.IdTipoParametro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_tipo_parametro");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                .HasName("pk_id_persona");

                entity.ToTable("persona");

                entity.Property(e => e.IdPersona)
                    .HasColumnName("id_persona")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(45);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fecha_nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.IdEstadoCivil).HasColumnName("id_estado_civil");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(45);

                entity.Property(e => e.SegundoNombre)
                    .HasColumnName("segundo_nombre")
                    .HasMaxLength(45);

                entity.Property(e => e.SegundoApellido)
                    .IsRequired()
                    .HasColumnName("segundo_apellido")
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdEstadoCivilNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdEstadoCivil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_estado_civil");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usuario");
            });

            modelBuilder.Entity<Reintegro>(entity =>
            {
                entity.HasKey(e => e.IdReintegro)
                    .HasName("pk_id_reintegro");

                entity.ToTable("reintegro");

                entity.Property(e => e.IdReintegro)
                    .HasColumnName("id_reintegro")
                    .ValueGeneratedNever();

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasColumnName("estatus")
                    .HasMaxLength(45);

                entity.Property(e => e.FechaSolicitud)
                    .IsRequired()
                    .HasColumnName("fecha_solicitud")
                    .HasMaxLength(45);

                entity.Property(e => e.IdUsuarioReceptor).HasColumnName("id_usuario_receptor");

                entity.Property(e => e.IdUsuarioSolicitante).HasColumnName("id_usuario_solicitante");

                entity.Property(e => e.Referencia)
                    .IsRequired()
                    .HasColumnName("referencia")
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdUsuarioReceptorNavigation)
                    .WithMany(p => p.ReintegroIdUsuarioReceptorNavigation)
                    .HasForeignKey(d => d.IdUsuarioReceptor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usuario_receptor");

                entity.HasOne(d => d.IdUsuarioSolicitanteNavigation)
                    .WithMany(p => p.ReintegroIdUsuarioSolicitanteNavigation)
                    .HasForeignKey(d => d.IdUsuarioSolicitante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usuario_solicitante");
            });

            modelBuilder.Entity<Tarjeta>(entity =>
            {
                entity.HasKey(e => e.IdTarjeta)
                    .HasName("pk_id_tarjeta");

                entity.ToTable("tarjeta");

                entity.Property(e => e.IdTarjeta)
                    .HasColumnName("id_tarjeta")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cvc).HasColumnName("cvc");

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnName("fecha_vencimiento")
                    .HasColumnType("date");

                entity.Property(e => e.IdBanco).HasColumnName("id_banco");

                entity.Property(e => e.IdTipoTarjeta).HasColumnName("id_tipo_tarjeta");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.NumeroTarjeta).HasColumnName("numero_tarjeta");

                entity.HasOne(d => d.IdBancoNavigation)
                    .WithMany(p => p.Tarjeta)
                    .HasForeignKey(d => d.IdBanco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_banco");

                entity.HasOne(d => d.IdTipoTarjetaNavigation)
                    .WithMany(p => p.Tarjeta)
                    .HasForeignKey(d => d.IdTipoTarjeta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_tipo_tarjeta");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Tarjeta)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usuario");
            });

            modelBuilder.Entity<TipoCuenta>(entity =>
            {
                entity.HasKey(e => e.IdTipoCuenta)
                    .HasName("pk_id_tipo_cuenta");

                entity.ToTable("tipo_cuenta");

                entity.Property(e => e.IdTipoCuenta)
                    .HasColumnName("id_tipo_cuenta")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(45);

                entity.Property(e => e.Estatus).HasColumnName("estatus");
            });

            modelBuilder.Entity<TipoIdentificacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoIdentificacion)
                    .HasName("pk_id_tipo_identificacion");

                entity.ToTable("tipo_identificacion");

                entity.Property(e => e.IdTipoIdentificacion)
                    .HasColumnName("id_tipo_identificacion")
                    .ValueGeneratedNever();

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(45);

                entity.Property(e => e.Estatus).HasColumnName("estatus");
            });

            modelBuilder.Entity<TipoOperacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoOperacion)
                    .HasName("pk_id_operacion");

                entity.ToTable("tipo_operacion");

                entity.Property(e => e.IdTipoOperacion)
                    .HasColumnName("id_tipo_operacion")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(45);

                entity.Property(e => e.Estatus).HasColumnName("estatus");
            });

            modelBuilder.Entity<TipoParametro>(entity =>
            {
                entity.HasKey(e => e.IdTipoParametro)
                    .HasName("pk_id_tipo_parametro");

                entity.ToTable("tipo_parametro");

                entity.Property(e => e.IdTipoParametro)
                    .HasColumnName("id_tipo_parametro")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(45);

                entity.Property(e => e.Estatus).HasColumnName("estatus");
            });

            modelBuilder.Entity<TipoTarjeta>(entity =>
            {
                entity.HasKey(e => e.IdTipoTarjeta)
                    .HasName("pk_id_tipo_tarjeta");

                entity.ToTable("tipo_tarjeta");

                entity.Property(e => e.IdTipoTarjeta)
                    .HasColumnName("id_tipo_tarjeta")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(45);

                entity.Property(e => e.Estatus).HasColumnName("estatus");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("pk_id_tipo_usuario");

                entity.ToTable("tipo_usuario");

                entity.Property(e => e.IdTipoUsuario)
                    .HasColumnName("id_tipo_usuario")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(45);

                entity.Property(e => e.Estatus).HasColumnName("estatus");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("pk_id_usuario");

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .ValueGeneratedNever();

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(500);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(200);

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("fecha_registro")
                    .HasColumnType("date");

                entity.Property(e => e.IdTipoIdentificacion).HasColumnName("id_tipo_identificacion");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("id_tipo_usuario");

                entity.Property(e => e.NumIdentificacion).HasColumnName("num_identificacion");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(12);

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdTipoIdentificacionNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoIdentificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_tipo_identificacion");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_tipo_usuario");
            });

            modelBuilder.Entity<UsuarioOpcionMenu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("usuario_opcion_menu");

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.IdOpcionMenu).HasColumnName("id_opcion_menu");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdOpcionMenuNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdOpcionMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_opcion_menu");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usuario");
            });

            modelBuilder.Entity<UsuarioParametro>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("usuario_parametro");

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.IdParametros).HasColumnName("id_parametros");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Validacion)
                    .IsRequired()
                    .HasColumnName("validacion")
                    .HasMaxLength(45);

                entity.HasOne(d => d.IdParametrosNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdParametros)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_parametros");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_id_usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
