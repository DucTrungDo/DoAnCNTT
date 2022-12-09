namespace QLNhanSuDVSX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KySu")]
    public partial class KySu : NhanSu
    {

        [StringLength(35)]
        public string NganhDaoTao { get; set; }

        [StringLength(25)]
        public string BoPhan { get; set; }

        public bool TruongBoPhan { get; set; }

        [StringLength(2)]
        public string PhuTrachTo { get; set; }

        public int? Luong { get; set; }

        public int? SoLanThuong { get; set; }

        public virtual DangKyDaoTaoKySu DangKyDaoTaoKySu { get; set; }

        public KySu()
        {

        }
        public KySu(string maNS, string hoTen, string gioiTinh, string queQuan, DateTime? ngSinh, string trinhĐoHV, string sĐT, string diaChi, string nganhDaoTao, string boPhan, bool truongBoPhan, string phuTrachTo, int? luong, int? soLanThuong) : base(maNS, hoTen, gioiTinh, queQuan, ngSinh, trinhĐoHV, sĐT, diaChi)
        {
            NganhDaoTao = nganhDaoTao;
            BoPhan = boPhan;
            TruongBoPhan = truongBoPhan;
            PhuTrachTo = phuTrachTo;
            Luong = luong;
            SoLanThuong = soLanThuong;
        }
        public static void InsertNewRowsKySu(string MaNS, string HoTen, string GioiTinh, string QueQuan, string NgSinh, string TrinhĐoHV, string SĐT, string DiaChi,
            string NganhDaoTao, string BoPhan, bool TruongBoPhan, string PhuTrachTo, int? Luong, int? SoLanThuong)
        {
            using (var nv = new QLNhanSuDVSXs())
            {
                var t = new KySu(MaNS, HoTen, GioiTinh, QueQuan, Convert.ToDateTime(NgSinh), TrinhĐoHV, SĐT, DiaChi, NganhDaoTao, BoPhan, TruongBoPhan ,PhuTrachTo, Luong, SoLanThuong);
                nv.KySus.Add(t);
                nv.SaveChanges();
            }
        }

        //Nhap du lieu KySu
        public static void InsertKySu()
        {
            InsertNewRowsKySu("1100", "Tran Hai Anh", "Nam", "TP Ho Chi Minh", "1990-10-05", "Dai hoc", "0375432890", "921 Kha Van Can", "Cong Nghe Thong Tin", "Thiet Ke", true,"1", null, 3);
            InsertNewRowsKySu("1104", "Nguyen Cam Nhung", "Nu", "Hai Phong", "1994-07-08", "Dai hoc", "0279125880", "172 Le Lai", "Dien, Dien Tu", "Thi Cong", false,"1", null, 1);
            InsertNewRowsKySu("1107", "Ly Thanh Nhan", "Nam", "Ben Tre", "1991-07-25", "Dai hoc", "0338627070", "735 Vo Van Ngan", "Che Tao May", "Thi Cong", false,"1", null, 0);
            InsertNewRowsKySu("1111", "Dinh Van An", "Nam", "TP Ho Chi Minh", "1998-05-18", "Cao Dang", "0325818790", "942/2/2 Vo Van Ngan", "Co Dien Tu", "Thi Cong", true,"2", null, 2);
            InsertNewRowsKySu("1113", "Nguyen Thanh Lam", "Nu", "Kien Giang", "1989-05-07", "Dai hoc", "0336846733", "278/5 Vo Thi Sau", "Quan Ly Cong Nghiep", "Hanh Chinh, Nhan Su", true,"2", null, 2);
            InsertNewRowsKySu("1117", "Truong Tuan Kiet", "Nam", "Kien Giang", "1996-08-07", "Dai hoc", "0879668001", "1385/8 Dang Van Bi", "Co Khi", "Thi Cong", false,"2", null, 1);
            InsertNewRowsKySu("1120", "Nguyen Thanh Phu", "Nam", "Dong Nai", "1993-09-11", "Dai hoc", "0285667900", "793/12 Ly Thuong Kiet", "Ky Thuat Cong Nghiep", "Kiem Soat Chat Luong", true,"3", null, 0);
            InsertNewRowsKySu("1123", "Le Thi Ngoc", "Nu", "Dong Thap", "1980-08-13", "Dai hoc", "0329878518", "111 Duong 3/2", "Logistic Va Quan Ly Chuoi Cung Ung", "Thiet ke", false,"4", null, 4);
            InsertNewRowsKySu("1126", "Truong Anh Kiet", "Nam", "Dong Nai", "1960-12-13", "Dai hoc", "0815278963", "11 Hai Ba Trung", "Dieu Khien Va Tu Dong Hoa", "Thi Cong", false,"3", null, 2);
            InsertNewRowsKySu("1129", "Nguyen Bao Hoang", "Nam", "Binh Duong", "1972-08-13", "Cao dang", "0878437899", "111 Tran Hung Dao", "Cong Nghe Vat Lieu", "Thiet Ke", false,"3", null, 1);
            InsertNewRowsKySu("1131", "Nguyen Bao Ngoc", "Nu", "Tra Vinh", "1972-08-13", "Dai hoc", "0345781200", "111 Minh Phung", "Dieu Khien Va Tu Dong Hoa", "Thi Cong", false,"4", null, 1);
            InsertNewRowsKySu("1135", "Nguyen Viet Nguyen", "Nam", "Ha Tinh", "2002-06-17", "Dai hoc", "0777777777", "23 Vo Van Ngan", "Dieu Khien Va Tu Dong Hoa", "Thi Cong", false,"4", null, 0);
        }
    }
}
