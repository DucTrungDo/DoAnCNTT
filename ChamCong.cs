namespace QLNhanSuDVSX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChamCong")]
    public partial class ChamCong
    {
        [Key]
        [StringLength(4)]
        public string MaNS { get; set; }

        [StringLength(30)]
        public string HoTen { get; set; }

        public int? SoLanChamCong { get; set; }

        public virtual NhanSu NhanSu { get; set; }

        public ChamCong()
        {

        }

        public ChamCong(string maNS, string hoTen, int? soLanChamCong)
        {
            MaNS = maNS;
            HoTen = hoTen;
            SoLanChamCong = soLanChamCong;
        }
        public static void InsertNewRowChamCong(string MaNS, string HoTen, int? SoLanChamCong)
        {
            using (var nv = new QLNhanSuDVSXs())
            {
                var t = new ChamCong(MaNS, HoTen, SoLanChamCong);
                nv.ChamCongs.Add(t);
                nv.SaveChanges();
            }
        }
        //Nhap du lieu ChamCong
        public static void InsertChamCong()
        {
            InsertNewRowChamCong("1100", "Tran Hai Anh", 26);
            InsertNewRowChamCong("1101", "Ngo Hoang Hai ", 26);
            InsertNewRowChamCong("1102", "Duong The Hung", 25);
            InsertNewRowChamCong("1103", "Duong Anh Ngoc", 26);
            InsertNewRowChamCong("1104", "Nguyen Cam Nhung", 26);
            InsertNewRowChamCong("1105", "Tran Van Nam", 23);
            InsertNewRowChamCong("1106", "Ngo Lan Anh", 24);
            InsertNewRowChamCong("1107", "Ly Thanh Nhan", 26);
            InsertNewRowChamCong("1108", "Tran Thanh Phong", 25);
            InsertNewRowChamCong("1109", "Tran Thanh Thuy", 25);
            InsertNewRowChamCong("1110", "Nguyen Thuy Tien", 24);
            InsertNewRowChamCong("1111", "Dinh Van An", 21);
            InsertNewRowChamCong("1112", "Phung The Anh", 26);
            InsertNewRowChamCong("1113", "Nguyen Thanh Lam", 22);
            InsertNewRowChamCong("1114", "Nguyen Tuong Van", 26);
            InsertNewRowChamCong("1115", "Ngo Thanh Hai", 26);
            InsertNewRowChamCong("1116", "Ta Hoang Phu", 22);
            InsertNewRowChamCong("1117", "Truong Tuan Kiet", 26);
            InsertNewRowChamCong("1118", "Tran Thi Ngoc Quyen", 26);
            InsertNewRowChamCong("1119", "Le Thi Ngoc Thu", 26);
            InsertNewRowChamCong("1120", "Nguyen Thanh Phu", 26);
            InsertNewRowChamCong("1121", "Nguyen Ngoc Hoang", 26);
            InsertNewRowChamCong("1122", "Nguyen Quang Ngoc", 26);
            InsertNewRowChamCong("1123", "Le Thi Ngoc", 25);
            InsertNewRowChamCong("1124", "Le Ngoc Hoang", 25);
            InsertNewRowChamCong("1125", "Nguyen Thi Ngoc", 25);
            InsertNewRowChamCong("1126", "Truong Anh Kiet", 25);
            InsertNewRowChamCong("1127", "Le Phung Hieu", 26);
            InsertNewRowChamCong("1128", "Nguyen Bao Hung", 24);
            InsertNewRowChamCong("1129", "Nguyen Bao Hoang", 24);
            InsertNewRowChamCong("1130", "Le Hoang Ngoc", 24);
            InsertNewRowChamCong("1131", "Nguyen Bao Ngoc", 24);
            InsertNewRowChamCong("1132", "Dinh Tan Phuc Huy", 26);
            InsertNewRowChamCong("1133", "Nguyen Vinh Thien", 26);
            InsertNewRowChamCong("1134", "Do Trung Duc", 26);
            InsertNewRowChamCong("1135", "Nguyen Viet Nguyen", 26);
        }
    }
}
