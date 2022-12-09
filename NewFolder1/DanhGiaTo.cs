namespace QLNhanSuDVSX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhGiaTo")]
    public partial class DanhGiaTo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhGiaTo()
        {

        }

        [Key]
        [StringLength(2)]
        public string To_Nhom { get; set; }

        [StringLength(100)]
        public string DanhGia_GD { get; set; }

        [StringLength(100)]
        public string DanhGia_PGD { get; set; }

        [StringLength(100)]
        public string DanhGia_KSPT { get; set; }

        public int? Diem_GD { get; set; }

        public int? Diem_PGD { get; set; }

        public int? Diem_KSPT { get; set; }

        public int? DiemTB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongNhan> CongNhans { get; set; }

        public DanhGiaTo(string to_Nhom, string danhGia_GD, string danhGia_PGD, string danhGia_KSPT, int? diem_GD, int? diem_PGD, int? diem_KSPT, int? diemTB)
        {
            To_Nhom = to_Nhom;
            DanhGia_GD = danhGia_GD;
            DanhGia_PGD = danhGia_PGD;
            DanhGia_KSPT = danhGia_KSPT;
            Diem_GD = diem_GD;
            Diem_PGD = diem_PGD;
            Diem_KSPT = diem_KSPT;
            DiemTB = diemTB;
        }

        public static void InsertNewRowsDanhGiaTo(string To_Nhom, string DanhGia_GD, string DanhGia_PGD, string DanhGia_KSPT, int? Diem_GD, int? Diem_PGD, int? Diem_KSPT, int? DiemTB)
        {
            using (var nv = new QLNhanSuDVSXs())
            {
                var t = new DanhGiaTo(To_Nhom, DanhGia_GD, DanhGia_PGD, DanhGia_KSPT, Diem_GD, Diem_PGD, Diem_KSPT, DiemTB);
                nv.DanhGiaToes.Add(t);
                nv.SaveChanges();
            }
        }

        //Nhap du lieu DanhGiaTo
        public static void InsertDanhGiaTo()
        {
            InsertNewRowsDanhGiaTo("1", "Tot", "Tot", "Tot", 8, 8, 9, null);
            InsertNewRowsDanhGiaTo("2", "Kha", "Tot", "Tot", 7, 8, 8, null);
            InsertNewRowsDanhGiaTo("3", "Suat xac", "Tot", "Tot", 10, 8, 9, null);
            InsertNewRowsDanhGiaTo("4", "Kha", "Trung Binh", "Kha", 7, 6, 7, null);
            InsertNewRowsDanhGiaTo("5", "Trung Binh", "Kha", "Kha", 6, 7, 7, null);
        }
    }
}
