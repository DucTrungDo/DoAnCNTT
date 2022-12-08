namespace QLNhanSuDVSX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DangKy_TeamBuilding
    {
        [Key]
        [StringLength(4)]
        public string MaNS { get; set; }

        [Required]
        [StringLength(30)]
        public string HoTen { get; set; }

        public int? ChiPhi { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public DangKy_TeamBuilding()
        {

        }

        public DangKy_TeamBuilding(string maNS, string hoTen, int? chiPhi)
        {
            MaNS = maNS;
            HoTen = hoTen;
            ChiPhi = chiPhi;
        }

        public static void InsertNewRowDangKy_TeamBuilding(string MaNS, string HoTen, int? ChiPhi)
        {
            using (var nv = new QLNhanSuDVSXs())
            {
                var t = new DangKy_TeamBuilding(MaNS, HoTen, ChiPhi);
                nv.DangKy_TeamBuildings.Add(t);
                nv.SaveChanges();
            }
        }
        //Nhap du lieu DangKy_TeamBuilding
        public static void InsertDangKy_TeamBuilding()
        {
            InsertNewRowDangKy_TeamBuilding("1101", "Ngo Hoang Hai", null);
            InsertNewRowDangKy_TeamBuilding("1103", "Duong Anh Ngoc", null);
            InsertNewRowDangKy_TeamBuilding("1105", "Tran Van Nam", null);
            InsertNewRowDangKy_TeamBuilding("1109", "Tran Thanh Thuy", null);
            InsertNewRowDangKy_TeamBuilding("1110", "Nguyen Thuy Tien", null);
            InsertNewRowDangKy_TeamBuilding("1112", "Phung The Anh", null);
            InsertNewRowDangKy_TeamBuilding("1121", "Nguyen Ngoc Hoang", null);
            InsertNewRowDangKy_TeamBuilding("1122", "Nguyen Thi Ngoc", null);
            InsertNewRowDangKy_TeamBuilding("1125", "Nguyen Quang Ngoc", null);
            //InsertNewRowDangKy_TeamBuilding("1127", "Le Phung Hieu", null);
            //InsertNewRowDangKy_TeamBuilding("1130", "Le Hoang Ngoc", null);
            //InsertNewRowDangKy_TeamBuilding("1133", "Nguyen Vinh Thien", null);
        }
    }
}
