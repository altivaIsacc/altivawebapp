using System;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AltivaWebApp.Context
{
    public partial class GrupoEmpresarialContext : DbContext
    {       

       
        public GrupoEmpresarialContext(DbContextOptions<GrupoEmpresarialContext> options)
            : base(options)
        {
        }
        public virtual DbSet<TbFdUsuarioCosto> TbFdUsuarioCosto { get; set; }
        public virtual DbSet<TbGeEmpresa> TbGeEmpresa { get; set; }
        public virtual DbSet<TbGeGrupoEmpresarial> TbGeGrupoEmpresarial { get; set; }
        public virtual DbSet<TbSeAdjunto> TbSeAdjunto { get; set; }
        public virtual DbSet<TbSeBitacora> TbSeBitacora { get; set; }
        public virtual DbSet<TbSeEmpresaUsuario> TbSeEmpresaUsuario { get; set; }
        public virtual DbSet<TbSeHistorialMoneda> TbSeHistorialMoneda { get; set; }
        public virtual DbSet<TbSeMensaje> TbSeMensaje { get; set; }
        public virtual DbSet<TbSeMensajeReceptor> TbSeMensajeReceptor { get; set; }
        public virtual DbSet<TbSeModulo> TbSeModulo { get; set; }
        public virtual DbSet<TbSeMoneda> TbSeMoneda { get; set; }
        public virtual DbSet<TbSePais> TbSePais { get; set; }
        public virtual DbSet<TbSePerfil> TbSePerfil { get; set; }
        public virtual DbSet<TbSePerfilModulo> TbSePerfilModulo { get; set; }
        public virtual DbSet<TbSePerfilUsuario> TbSePerfilUsuario { get; set; }
        public virtual DbSet<TbSeUsuario> TbSeUsuario { get; set; }
        public virtual DbSet<TbSeUsuarioConfiguraion> TbSeUsuarioConfiguraion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //StringFactory.StringGE
                optionsBuilder.UseSqlServer(StringProvider.StringGE);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");
            modelBuilder.Entity<TbFdUsuarioCosto>(entity =>
            {
                entity.ToTable("tb_FD_UsuarioCosto");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TbFdUsuarioCosto)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_tb_FD_UsuarioCosto_tb_SE_Usuario");
            });


            modelBuilder.Entity<TbGeEmpresa>(entity =>
            {
                entity.ToTable("tb_GE_Empresa");

                entity.Property(e => e.Bd)
                    .IsRequired()
                    .HasColumnName("BD")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CedJuridica)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaMod).HasColumnType("datetime");

                entity.Property(e => e.Foto)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdGrupoEmpresarial).HasColumnName("Id_GrupoEmpresarial");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono1)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono2)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGrupoEmpresarialNavigation)
                    .WithMany(p => p.TbGeEmpresa)
                    .HasForeignKey(d => d.IdGrupoEmpresarial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_GE_Empresa_tb_GE_GrupoEmpresarial");
            });

            modelBuilder.Entity<TbGeGrupoEmpresarial>(entity =>
            {
                entity.ToTable("tb_GE_GrupoEmpresarial");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaMod).HasColumnType("datetime");

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono2)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TbGeGrupoEmpresarial)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_GE_GrupoEmpresarial_tb_GE_Usuario");
            });

            modelBuilder.Entity<TbSeAdjunto>(entity =>
            {
                entity.ToTable("tb_SE_Adjunto");

                entity.Property(e => e.Ruta).HasMaxLength(1000);

                entity.HasOne(d => d.IdMensajeNavigation)
                    .WithMany(p => p.TbSeAdjunto)
                    .HasForeignKey(d => d.IdMensaje)
                    .HasConstraintName("FK_Adjunto_Mensaje");
            });

            modelBuilder.Entity<TbSeBitacora>(entity =>
            {
                entity.ToTable("tb_SE_Bitacora");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.TipoReferencia).HasMaxLength(10);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.TbSeBitacora)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK_tb_SE_Bitacora_tb_GE_Empresa");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TbSeBitacora)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_SE_Bitacora_tb_SE_Usuario");
            });

            modelBuilder.Entity<TbSeEmpresaUsuario>(entity =>
            {
                entity.ToTable("tb_SE_EmpresaUsuario");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.TbSeEmpresaUsuario)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_GE_EmpresaUsuario_tb_GE_Empresa");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TbSeEmpresaUsuario)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_GE_EmpresaUsuario_tb_GE_Usuario1");
            });

            modelBuilder.Entity<TbSeHistorialMoneda>(entity =>
            {
                entity.ToTable("tb_SE_HistorialMoneda");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CodigoMonedaNavigation)
                    .WithMany(p => p.TbSeHistorialMoneda)
                    .HasForeignKey(d => d.CodigoMoneda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_SE_HistorialMoneda_tb_SE_Moneda");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TbSeHistorialMoneda)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_SE_HistorialMoneda_tb_SE_Usuario");
            });

            modelBuilder.Entity<TbSeMensaje>(entity =>
            {
                entity.ToTable("tb_SE_Mensaje");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mensaje)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.TipoReferencia).HasMaxLength(50);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TbSeMensaje)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Mensaje_Usuario");
            });

            modelBuilder.Entity<TbSeMensajeReceptor>(entity =>
            {
                entity.ToTable("tb_SE.MensajeReceptor");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMensajeNavigation)
                    .WithMany(p => p.TbSeMensajeReceptor)
                    .HasForeignKey(d => d.IdMensaje)
                    .HasConstraintName("FK_MensajeReceptor_Mensaje");

                entity.HasOne(d => d.IdReceptorNavigation)
                    .WithMany(p => p.TbSeMensajeReceptor)
                    .HasForeignKey(d => d.IdReceptor)
                    .HasConstraintName("FK_MensajeReceptor_Usuario");
            });

            modelBuilder.Entity<TbSeModulo>(entity =>
            {
                entity.ToTable("tb_SE_Modulo");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Grupos)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NombreExterno)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NombreInterno)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotaOpcion1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotaOpcion2)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbSeMoneda>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("tb_SE_Moneda");

                entity.Property(e => e.Codigo).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Simbolo)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbSePais>(entity =>
            {
                entity.ToTable("tb_SE_Pais");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GentilicioEn)
                    .IsRequired()
                    .HasColumnName("GentilicioEN")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GentilicioEs)
                    .IsRequired()
                    .HasColumnName("GentilicioES")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Iniciales)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NombreEn)
                    .IsRequired()
                    .HasColumnName("NombreEN")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NombreEs)
                    .IsRequired()
                    .HasColumnName("NombreES")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbSePerfil>(entity =>
            {
                entity.ToTable("tb_SE_Perfil");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<TbSePerfilModulo>(entity =>
            {
                entity.ToTable("tb_SE_PerfilModulo");

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.TbSePerfilModulo)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_SE_PerfilModulo_tb_SE_Modulo1");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.TbSePerfilModulo)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_SE_PerfilModulo_tb_SE_Perfil1");
            });

            modelBuilder.Entity<TbSePerfilUsuario>(entity =>
            {
                entity.ToTable("tb_SE_PerfilUsuario");

                entity.Property(e => e.IdPerfil).HasColumnName("Id_Perfil");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.TbSePerfilUsuario)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_SE_PerfilUsuario_tb_SE_Perfil1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TbSePerfilUsuario)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_SE_PerfilUsuario_tb_SE_Usuario");
            });

            modelBuilder.Entity<TbSeUsuario>(entity =>
            {
                entity.ToTable("tb_SE_Usuario");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaMod).HasColumnType("datetime");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Iniciales)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbSeUsuarioConfiguraion>(entity =>
            {
                entity.ToTable("tb_SE_UsuarioConfiguraion");

                entity.Property(e => e.Idioma).HasMaxLength(2);

                entity.Property(e => e.Tema)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TbSeUsuarioConfiguraion)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_GE_UsuarioConfiguraion_tb_GE_Usuario");
            });
        }
    }
}
