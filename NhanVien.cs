namespace QLNhanSuDVSX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien : NhanSu
    {
        [StringLength(150)]
        public string CongViecDamNhiem { get; set; }

        [StringLength(50)]
        public string ChucVuNV { get; set; }

        [StringLength(50)]
        public string PhongBan { get; set; }

        public int? Luong { get; set; }

        public int? SoLanThuong { get; set; }

        public virtual DangKy_TeamBuilding DangKy_TeamBuilding { get; set; }

        public NhanVien()
        {

        }

        public NhanVien(string maNS, string hoTen, string gioiTinh, string queQuan, DateTime? ngSinh, string trinhĐoHV, string sĐT, string diaChi,
            string congViecDamNhiem, string chucVuNV, string phongBan, int? luong, int? soLanThuong) : base(maNS, hoTen, gioiTinh, queQuan, ngSinh, trinhĐoHV, sĐT, diaChi)
        {
            CongViecDamNhiem = congViecDamNhiem;
            ChucVuNV = chucVuNV;
            PhongBan = phongBan;
            Luong = luong;
            SoLanThuong = soLanThuong;
        }
        public static void InsertNewRowsNhanVien(string MaNS, string HoTen, string GioiTinh, string QueQuan, string NgSinh, string TrinhĐoHV, string SĐT, string DiaChi, string CongViecDamNhiem, string ChucVuNV, string PhongBan, int? Luong, int? SoLanThuong)
        {
            using (var nv = new QLNhanSuDVSXs())
            {
                var t = new NhanVien(MaNS, HoTen, GioiTinh, QueQuan, Convert.ToDateTime(NgSinh), TrinhĐoHV, SĐT, DiaChi, CongViecDamNhiem, ChucVuNV, PhongBan, Luong, SoLanThuong);
                nv.NhanViens.Add(t);
                nv.SaveChanges();
            }
        }

        //Nhap du lieu Nhan Vien
        public static void InsertNhanVien()
        {
            InsertNewRowsNhanVien("1101", "Ngo Hoang Hai", "Nam", "TP Ho Chi Minh", "1988-07-16", "Dai hoc", "0289685129", "129 Vo Van Ngan", "Chi dao cong nhan thuc hien quy trinh san xuat", "Giam doc", "Phong San Xuat", null, 1);
            InsertNewRowsNhanVien("1103", "Duong Anh Ngoc", "Nu", "Ca Mau", "1995-02-02", "Dai hoc", "0379135581", "672/8 Mac Dinh Chi", "Bao cao tien do san xuat", "Nhan vien", "Phong San Xuat", null, 2);
            InsertNewRowsNhanVien("1105", "Tran Van Nam", "Nam", "Dong Nai", "1990-09-25", "Dai hoc", "0815278993", "121 Tran Hung Dao", "Bao cao cac su co ve may moc trong qua trinh san xuat", "Nhan vien", "Phong San Xuat", null, 3);
            InsertNewRowsNhanVien("1109", "Tran Thanh Thuy", "Nu", " Vinh Long", "1996-04-23", "Cao dang", "0986743228", "432 Tran Hung Dao", "Kiem soat chat luong san pham", "Nhan vien", "Phong Chat Luong", null, 2);
            InsertNewRowsNhanVien("1110", "Nguyen Thuy Tien", "Nu", "Tra Vinh", "1990-08-16", "Dai hoc", "0345781900", "135/9/2 Ho Van Tu", "Thiet ke va lap dat day chuyen san xuat moi", "Nhan vien", "Phong Ky Thuat", null, 1);
            InsertNewRowsNhanVien("1112", "Phung The Anh", "Nam", "Long An", "1988-04-23", "Dai hoc", "0318925132", "921 Vo Thi Sau", "Cai tien cong doan nham toi uu hoa qua trinh san xuat, tang chat luong san pham", "Pho giam doc", "Phong Chat Luong", null, 1);
            InsertNewRowsNhanVien("1121", "Nguyen Ngoc Hoang", "Nam", "TP Ho Chi Minh", "1972-08-13", "Dai hoc", "0366432890", "111 Vo Van Ngan", "Van hanh may moc, lap rap linh kien", "Nhan vien", "Phong Ky Thuat", null, 0);
            InsertNewRowsNhanVien("1122", "Nguyen Quang Ngoc", "Nam", "TP Ho Chi Minh", "1975-08-23", "Dai hoc", "0222685129", "111 Nguyen Van Troi", "Hoan thien san pham, dong goi dan nhan san pham", "Nhan vien", "Phong Chat Luong", null, 0);
            InsertNewRowsNhanVien("1125", "Nguyen Thi Ngoc", "Nu", "Hai Phong", "1992-08-13", "Dai hoc", "0279122380", "108 Vo Van Ngan", "Lam sach thiet bi, ve sinh sach se khu vuc lam viec", "Nhan vien", "Phong Ky Thuat", null, 2);
            InsertNewRowsNhanVien("1127", "Le Phung Hieu", "Nam", "TP Ho Chi Minh", "1972-08-13", "Dai hoc", "0381690238", "11 Hau Giang", "Ho tro van chuyen hang hoa", "Nhan vien", "Phong Kho Van", null, 0);
            InsertNewRowsNhanVien("1130", "Le Hoang Ngoc", "Nu", " Vinh Long", "1972-08-13", "Cao dang", "0986563228", "11 Lac Long Quan", "To chuc thuc hien cong tac giao nhan, van chuyen hang hoa theo ke hoach giao hang", "Nhan vien", "Phong Kho Van", null, 1);
            InsertNewRowsNhanVien("1133", "Nguyen Vinh Thien", "Nam", "Tra Vinh", "2002-5-1", "Dai hoc", "0188888888", "10 Ly Chinh Thang", "Kiem soat day chuyen, xu ly loi xay ra trong qua trinh van hanh", "Nhan vien", "Phong Ky Thuat", null, 1);
        }
    }
}
