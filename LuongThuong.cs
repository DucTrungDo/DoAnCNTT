namespace QLNhanSuDVSX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LuongThuong")]
    public partial class LuongThuong
    {
        [Key]
        [StringLength(20)]
        public string LoaiThuong { get; set; }

        public int MucTienThuong { get; set; }

        public LuongThuong(string loaiThuong, int mucTienThuong)
        {
            LoaiThuong = loaiThuong;
            MucTienThuong = mucTienThuong;
        }
        public static void InsertNewRowsLuongThuong(string LoaiThuong, int MucTienThuong)
        {
            using (var nv = new QLNhanSuDVSXs())
            {
                var t = new LuongThuong(LoaiThuong, MucTienThuong);
                nv.LuongThuongs.Add(t);
                nv.SaveChanges();
            }
        }
        //Nhap du lieu luong thuong
        public static void InsertLuongThuong()
        {
            InsertNewRowsLuongThuong("Thuong Ky Su", 200000);
            InsertNewRowsLuongThuong("Thuong Nhan Vien", 500000);
            InsertNewRowsLuongThuong("Thuong Cong Nhan", 500000);
        }
    }
}
