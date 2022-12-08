namespace QLNhanSuDVSX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DangKyDaoTaoKySu")]
    public partial class DangKyDaoTaoKySu
    {
        [Key]
        [StringLength(4)]
        public string MaNS { get; set; }

        [Required]
        [StringLength(30)]
        public string HoTen { get; set; }

        [StringLength(150)]
        public string CT_DaoTao { get; set; }

        public virtual DaoTaoKySu DaoTaoKySu { get; set; }

        public virtual KySu KySu { get; set; }

        public DangKyDaoTaoKySu()
        {

        }
        public DangKyDaoTaoKySu(string maNS, string hoTen, string cT_DaoTao)
        {
            MaNS = maNS;
            HoTen = hoTen;
            CT_DaoTao = cT_DaoTao;
        }
        public static void InsertNewRowsDangKyDaoTaoKySu(string MaNS, string HoTen, string CT_DaoTao)
        {
            using (var nv = new QLNhanSuDVSXs())
            {
                var t = new DangKyDaoTaoKySu(MaNS, HoTen, CT_DaoTao);
                nv.DangKyDaoTaoKySus.Add(t);
                nv.SaveChanges();
            }
        }

        //Nhap du lieu DangKyDaoTaoKySu
        public static void InsertDangKyDaoTaoKySu()
        {
            InsertNewRowsDangKyDaoTaoKySu("1100", "Nguyen Thuy Tien", "Thiet ke he thong day chuyen san xuat");
            InsertNewRowsDangKyDaoTaoKySu("1123", "Le Thi Ngoc", "Chuyen vien tu van va phan tich chuoi cung ung");
            InsertNewRowsDangKyDaoTaoKySu("1129", "Nguyen Bao Hoang", "Quan tri nguyen vat lieu");
            InsertNewRowsDangKyDaoTaoKySu("1126", "Truong Anh Kiet", "Thiet ke, lap dat cac he thong tu dong va dam bao qua trinh van hanh cua day chuyen");
            InsertNewRowsDangKyDaoTaoKySu("1120", "Nguyen Thanh Phu", "Kiem tra chat luong va lap bao cao chat luong san pham theo quy trinh, tieu chuan");
        }
    }
}
