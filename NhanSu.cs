namespace QLNhanSuDVSX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanSu")]
    public partial class NhanSu
    {
        [Key]
        [StringLength(4)]
        public string MaNS { get; set; }

        [Required]
        [StringLength(30)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(3)]
        public string GioiTinh { get; set; }

        [StringLength(15)]
        public string QueQuan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgSinh { get; set; }

        [StringLength(10)]
        public string TrinhĐoHV { get; set; }

        [StringLength(10)]
        public string SĐT { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        public virtual ChamCong ChamCong { get; set; }

        public virtual TrinhDo TrinhDo { get; set; }

        public NhanSu()
        {

        }

        public NhanSu(string maNS, string hoTen, string gioiTinh, string queQuan, DateTime? ngSinh, string trinhĐoHV, string sĐT, string diaChi)
        {
            MaNS = maNS;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            QueQuan = queQuan;
            NgSinh = ngSinh;
            TrinhĐoHV = trinhĐoHV;
            SĐT = sĐT;
            DiaChi = diaChi;
        }

        public static void InsertNewRowsNhanSu(string MaNS, string HoTen, string GioiTinh, string QueQuan, string NgSinh, string TrinhĐoHV, string SĐT, string DiaChi)
        {
            using (var nv = new QLNhanSuDVSXs())
            {
                var t = new NhanSu(MaNS, HoTen, GioiTinh, QueQuan, Convert.ToDateTime(NgSinh), TrinhĐoHV, SĐT, DiaChi);
                nv.NhanSus.Add(t);
                nv.SaveChanges();
            }
        }
    }
}
