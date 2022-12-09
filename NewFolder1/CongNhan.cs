namespace QLNhanSuDVSX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CongNhan")]
    public partial class CongNhan : NhanSu
    {
        public int Bac { get; set; }

        [StringLength(2)]
        public string To_Nhom { get; set; }

        [StringLength(5)]
        public string To_Truong { get; set; }

        public int? Luong { get; set; }

        public bool Thuong { get; set; }

        public virtual DanhGiaTo DanhGiaTo { get; set; }

        public CongNhan()
        {

        }

        public CongNhan(string maNS, string hoTen, string gioiTinh, string queQuan, DateTime? ngSinh, string trinhĐoHV, string sĐT, string diaChi,
            int bac, string to_Nhom, string to_Truong, int? luong, bool thuong) : base(maNS, hoTen, gioiTinh, queQuan, ngSinh, trinhĐoHV, sĐT, diaChi)
        {
            Bac = bac;
            To_Nhom = to_Nhom;
            To_Truong = to_Truong;
            Luong = luong;
            Thuong = thuong;
        }

        public static void InsertNewRowsCongNhan(string MaNS, string HoTen, string GioiTinh, string QueQuan, string NgSinh, string TrinhĐoHV, string SĐT, string DiaChi,
            int Bac, string To_Nhom, string To_Truong, int? Luong, bool Thuong)
        {
            using (var nv = new QLNhanSuDVSXs())
            {
                var t = new CongNhan(MaNS, HoTen, GioiTinh, QueQuan, Convert.ToDateTime(NgSinh), TrinhĐoHV, SĐT, DiaChi, Bac, To_Nhom, To_Truong, Luong, Thuong);
                nv.CongNhans.Add(t);
                nv.SaveChanges();
            }
        }

        //Nhap du lieu cong nhan
        public static void InsertCongNhan()
        {
            InsertNewRowsCongNhan("1102", "Duong The Hung", "Nam", "Dong Thap", "1992-01-29", "Dai hoc", "0329872118", "225/2 Le Van Chi",  1, "1", "Khong", null, true);
            InsertNewRowsCongNhan("1106", "Ngo Lan Anh", "Nu", "TP Ho Chi Minh", "1988-03-16", "Dai hoc", "0386790238", "290/4 Vo Van Ngan",  1, "1", "Co", null, false);
            InsertNewRowsCongNhan("1108", "Tran Thanh Phong", "Nam", "Binh Duong", "1991-10-16", "Cao dang", "0873437899", "285/8 Le Van Viet",  1, "1", "Khong", null, true);
            InsertNewRowsCongNhan("1114", "Nguyen Tuong Van", "Nu", "Phu Yen", "1990-04-27", "Dai hoc", "0336756293", "389/9 Nguyen Thi Minh Khai",  2, "2", "Khong", null, true);
            InsertNewRowsCongNhan("1115", "Ngo Thanh Hai", "Nam", "Khanh Hoa", "1989-02-28", "Cao dang", "0357908831", "547/46 Le Van Chi",  2, "2", "Co", null, false);
            InsertNewRowsCongNhan("1116", "Ta Hoang Phu", "Nam", "Tra Vinh", "1989-07-15", "Trung Cap", "0743568099", "942/2 Kha Van Can",  2, "2", "Khong", null, false);
            InsertNewRowsCongNhan("1118", "Tran Thi Ngoc Quyen", "Nu", "Binh Duong", "1997-06-20", "Dai hoc", "0265837923", "01 Vo Van Ngan",  3, "3", "Khong", null, false);
            InsertNewRowsCongNhan("1119", "Le Thi Ngoc Thu", "Nu", "Binh Thuan", "1992-03-17", "Cao dang", "0336888953", "586 Le Lai",  3, "3", "Co", null, true);
            InsertNewRowsCongNhan("1124", "Le Ngoc Hoang", "Nam", "Ca Mau", "1982-08-18", "Dai hoc", "0379135001", "111 Le Van Duyet",  4, "3", "Khong", null, true);
            InsertNewRowsCongNhan("1128", "Nguyen Bao Hung", "Nam", "Ben Tre", "1978-08-23", "Dai hoc", "0338627990", "10 Tran Hung Dao",  3, "4", "Khong", null, false);
            InsertNewRowsCongNhan("1132", "Dinh Tan Phuc Huy", "Nam", "Khanh Hoa", "2002-07-02", "Dai Hoc", "0144444444", "11 Nguyen Duy Trinh",  4, "4", "Co", null, true);
            InsertNewRowsCongNhan("1134", "Do Trung Duc", "Nam", "Dong Nai", "2002-10-06", "Dai hoc", "0111111111", "11 Le Van Thinh",  4, "4", "Khong", null, true);
        }
    }
}
