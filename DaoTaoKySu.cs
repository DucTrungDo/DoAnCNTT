namespace QLNhanSuDVSX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DaoTaoKySu")]
    public partial class DaoTaoKySu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DaoTaoKySu()
        {
            DangKyDaoTaoKySus = new HashSet<DangKyDaoTaoKySu>();
        }

        [Key]
        [StringLength(150)]
        public string ChuongTrinhDaoTao { get; set; }

        [StringLength(35)]
        public string YeuCau_NganhDT { get; set; }

        [StringLength(25)]
        public string YeuCau_BoPhan { get; set; }

        public int SoLuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangKyDaoTaoKySu> DangKyDaoTaoKySus { get; set; }

        public DaoTaoKySu(string chuongTrinhDaoTao, string yeuCau_NganhDT, string yeuCau_BoPhan, int soLuong)
        {
            ChuongTrinhDaoTao = chuongTrinhDaoTao;
            YeuCau_NganhDT = yeuCau_NganhDT;
            YeuCau_BoPhan = yeuCau_BoPhan;
            SoLuong = soLuong;
        }

        public static void InsertNewRowsDaoTaoKySu(string ChuongTrinhDaoTao, string YeuCau_NganhDT, string YeuCau_BoPhan, int SoLuong)
        {
            using (var nv = new QLNhanSuDVSXs())
            {
                var t = new DaoTaoKySu(ChuongTrinhDaoTao, YeuCau_NganhDT, YeuCau_BoPhan, SoLuong);
                nv.DaoTaoKySus.Add(t);
                nv.SaveChanges();
            }
        }

        //Nhap du lieu DaoTaoKySu
        public static void InsertDaoTaoKySu()
        {
            InsertNewRowsDaoTaoKySu("Thiet ke he thong day chuyen san xuat", "Cong Nghe Thong Tin", "Thiet Ke", 3);
            InsertNewRowsDaoTaoKySu("Chuyen vien tu van va phan tich chuoi cung ung", "Logistic Va Quan Ly Chuoi Cung Ung", "Thiet Ke", 3);
            InsertNewRowsDaoTaoKySu("Quan tri nguyen vat lieu", "Cong Nghe Vat Lieu", "Thiet Ke", 5);
            InsertNewRowsDaoTaoKySu("Thiet ke, lap dat cac he thong tu dong va dam bao qua trinh van hanh cua day chuyen", "Dieu Khien Va Tu Dong Hoa", "Thi Cong", 4);
            InsertNewRowsDaoTaoKySu("Kiem tra chat luong va lap bao cao chat luong san pham theo quy trinh, tieu chuan", "Ky Thuat Cong Nghiep", "Kiem Soat Chat Luong", 2);
        }
    }
}
