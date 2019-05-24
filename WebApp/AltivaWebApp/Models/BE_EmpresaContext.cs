using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AltivaWebApp.Models
{
    public partial class BE_EmpresaContext : DbContext
    {
        public BE_EmpresaContext()
        {
        }

        public BE_EmpresaContext(DbContextOptions<BE_EmpresaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbPrInventario> TbPrInventario { get; set; }
        public virtual DbSet<TbPrRequisicion> TbPrRequisicion { get; set; }
        public virtual DbSet<TbPrRequisicionDetalle> TbPrRequisicionDetalle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CENTRAL-PC\\FDPRUEBAS;Database=BE_Empresa;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<TbPrInventario>(entity =>
            {
                entity.HasKey(e => e.IdInventario);

                entity.ToTable("tb_PR_Inventario");

                entity.Property(e => e.AbreviacionFacturas)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('''')");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('''')");

                entity.Property(e => e.CodigoMoneda).HasDefaultValueSql("((1))");

                entity.Property(e => e.CodigoMonedaVenta).HasDefaultValueSql("((2))");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('''')");

                entity.Property(e => e.DescripcionVenta)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdMonedaVentaOnline).HasDefaultValueSql("((1))");

                entity.Property(e => e.NombreCarrito)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('''')");

                entity.Property(e => e.Notas)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(' ')");

                entity.Property(e => e.SkuOnline)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('''')");
            });

            modelBuilder.Entity<TbPrRequisicion>(entity =>
            {
                entity.ToTable("tb_PR_Requisicion");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbPrRequisicionDetalle>(entity =>
            {
                entity.ToTable("tb_PR_RequisicionDetalle");

                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.TbPrRequisicionDetalle)
                    .HasForeignKey(d => d.IdInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_RequisicionDetalle_tb_PR_Inventario");

                entity.HasOne(d => d.IdRequisicionNavigation)
                    .WithMany(p => p.TbPrRequisicionDetalle)
                    .HasForeignKey(d => d.IdRequisicion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_PR_RequisicionInventario_tb_PR_Requisiciones1");
            });
        }
    }
}
