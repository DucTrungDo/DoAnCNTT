using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLNhanSuDVSX
{
    public partial class QLNhanSuDVSXs : DbContext
    {
        public QLNhanSuDVSXs()
            : base("name=QLNhanSuDVSXs")
        {

        }
        public virtual DbSet<CongNhan> CongNhans { get; set; }
        public virtual DbSet<ChamCong> ChamCongs { get; set; }
        public virtual DbSet<DangKy_TeamBuilding> DangKy_TeamBuildings { get; set; }
        public virtual DbSet<DangKyDaoTaoKySu> DangKyDaoTaoKySus { get; set; }
        public virtual DbSet<DanhGiaTo> DanhGiaToes { get; set; }
        public virtual DbSet<DaoTaoKySu> DaoTaoKySus { get; set; }
        public virtual DbSet<KySu> KySus { get; set; }
        public virtual DbSet<LuongThuong> LuongThuongs { get; set; }
        public virtual DbSet<NhanSu> NhanSus { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<TrinhDo> TrinhDoes { get; set; }
        public virtual DbSet<USER> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CongNhan>()
                .Property(e => e.MaNS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CongNhan>()
                .Property(e => e.To_Nhom)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CongNhan>()
                .Property(e => e.To_Truong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChamCong>()
                .Property(e => e.MaNS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChamCong>()
                .Property(e => e.HoTen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DangKy_TeamBuilding>()
                .Property(e => e.MaNS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DangKy_TeamBuilding>()
                .Property(e => e.HoTen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DangKyDaoTaoKySu>()
                .Property(e => e.MaNS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DangKyDaoTaoKySu>()
                .Property(e => e.HoTen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DangKyDaoTaoKySu>()
                .Property(e => e.CT_DaoTao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DanhGiaTo>()
                .Property(e => e.To_Nhom)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DanhGiaTo>()
                .Property(e => e.DanhGia_GD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DanhGiaTo>()
                .Property(e => e.DanhGia_PGD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DanhGiaTo>()
                .Property(e => e.DanhGia_KSPT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DaoTaoKySu>()
                .Property(e => e.ChuongTrinhDaoTao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DaoTaoKySu>()
                .Property(e => e.YeuCau_NganhDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DaoTaoKySu>()
                .Property(e => e.YeuCau_BoPhan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DaoTaoKySu>()
                .HasMany(e => e.DangKyDaoTaoKySus)
                .WithOptional(e => e.DaoTaoKySu)
                .HasForeignKey(e => e.CT_DaoTao);

            modelBuilder.Entity<KySu>()
                .Property(e => e.MaNS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KySu>()
                .Property(e => e.NganhDaoTao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KySu>()
                .Property(e => e.BoPhan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KySu>()
                .Property(e => e.PhuTrachTo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KySu>()
                .HasOptional(e => e.DangKyDaoTaoKySu)
                .WithRequired(e => e.KySu);

            modelBuilder.Entity<LuongThuong>()
                .Property(e => e.LoaiThuong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanSu>()
                .Property(e => e.MaNS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanSu>()
                .Property(e => e.HoTen)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanSu>()
                .Property(e => e.GioiTinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanSu>()
                .Property(e => e.QueQuan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanSu>()
                .Property(e => e.TrinhĐoHV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanSu>()
                .Property(e => e.SĐT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanSu>()
                .Property(e => e.DiaChi)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanSu>()
                .HasOptional(e => e.ChamCong)
                .WithRequired(e => e.NhanSu);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.CongViecDamNhiem)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.ChucVuNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.PhongBan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasOptional(e => e.DangKy_TeamBuilding)
                .WithRequired(e => e.NhanVien);

            modelBuilder.Entity<TrinhDo>()
                .Property(e => e.TrinhDoHV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TrinhDo>()
                .HasMany(e => e.NhanSus)
                .WithOptional(e => e.TrinhDo)
                .HasForeignKey(e => e.TrinhĐoHV);

            modelBuilder.Entity<USER>()
                .Property(e => e.UserName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.Pass)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<TrinhDo>().ToTable("TrinhDo");
            modelBuilder.Entity<NhanSu>().ToTable("NhanSu");
            modelBuilder.Entity<LuongThuong>().ToTable("Luongthuong");
            modelBuilder.Entity<KySu>().ToTable("KySu");
            modelBuilder.Entity<CongNhan>().ToTable("CongNhan");
            modelBuilder.Entity<NhanVien>().ToTable("NhanVien");
            modelBuilder.Entity<ChamCong>().ToTable("ChamCong");
            modelBuilder.Entity<DanhGiaTo>().ToTable("DanhGiaTo");
            modelBuilder.Entity<DangKy_TeamBuilding>().ToTable("DangKy_TeamBuilding");
            modelBuilder.Entity<DaoTaoKySu>().ToTable("DaoTaoKySu");
            modelBuilder.Entity<DangKyDaoTaoKySu>().ToTable("DangKyDaoTaoKySu");
            modelBuilder.Entity<USER>().ToTable("USERS");
        }
        public void Insert()
        {
            
            using (var QLNSDVSX = new QLNhanSuDVSXs())
            {
                //Database.SetInitializer<QLNhanSuDVSXs>(new DropCreateDatabaseAlways<QLNhanSuDVSXs>());
                using (var Transaction = QLNSDVSX.Database.BeginTransaction())
                {
                    try
                    {
                        TrinhDo.InsertTrinhDo();
                        LuongThuong.InsertLuongThuong();
                        KySu.InsertKySu();
                        DanhGiaTo.InsertDanhGiaTo();
                        CongNhan.InsertCongNhan();
                        NhanVien.InsertNhanVien();
                        ChamCong.InsertChamCong();
                        DangKy_TeamBuilding.InsertDangKy_TeamBuilding();
                        DaoTaoKySu.InsertDaoTaoKySu();
                        DangKyDaoTaoKySu.InsertDangKyDaoTaoKySu();
                        USER.InsertUSERS();
                        QLNSDVSX.SaveChanges();
                        Transaction.Commit();
                    }
                    catch
                    {
                        Transaction.Rollback();
                    }
            }
            }
        }
    }
}
