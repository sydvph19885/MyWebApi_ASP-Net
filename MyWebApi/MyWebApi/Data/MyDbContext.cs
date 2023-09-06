using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;

namespace MyWebApi.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }
        //neu trong entity khong dinh nghia => su dung fluent API 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                // xac dinh tn table
                e.ToTable("DonHang");
                // xac dinh khoa chinh
                e.HasKey(dh => dh.MaDH);
                // dat value mac dinh cho thuoc tinh
                e.Property(dh => dh.NgDat).HasDefaultValueSql("GETUTCDATE()");
                // them cac rang buoc 
                e.Property(dh => dh.NguoiNhanHang).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<DonHangChiTiet>(entity =>
            {
                entity.ToTable("ChiTietDonHang");
                // bang co 2 khoa chinh
                entity.HasKey(e => new
                {
                    e.MaHH,
                    e.MaDH
                });
                 // xac dinh tung khoa ngoai
                entity.HasOne(e => e.DonHang)
                // la khoa ngoai cua bang nao
                .WithMany(e => e.donHangChiTiets)
                // khoa ngoai la cai gi
                .HasForeignKey(e => e.MaDH)
                .HasConstraintName("FK_DONHANGCT_DonHang");
                entity.HasOne(e => e.HangHoa)
                .WithMany(e => e.donHangChiTiets)
                .HasForeignKey(e => e.MaHH)
                .HasConstraintName("FK_DONHANGCT_HangHoa");
            });
        }
    }
}
