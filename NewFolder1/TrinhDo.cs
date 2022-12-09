namespace QLNhanSuDVSX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrinhDo")]
    public partial class TrinhDo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrinhDo()
        {
            NhanSus = new HashSet<NhanSu>();
        }

        [Key]
        [StringLength(10)]
        public string TrinhDoHV { get; set; }

        public int? SoLuongNS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanSu> NhanSus { get; set; }

        public TrinhDo(string trinhDoHV, int? soLuongNS)
        {
            TrinhDoHV = trinhDoHV;
            SoLuongNS = soLuongNS;
        }
        public static void InsertNewRowTrinhDo(string TrinhDoHV, int? soLuongNS)
        {
            using (var nv = new QLNhanSuDVSXs())
            {
                var t = new TrinhDo(TrinhDoHV, soLuongNS);
                nv.TrinhDoes.Add(t);
                nv.SaveChanges();
            }
        }
        //Nhap du lieu TrinhDo
        public static void InsertTrinhDo()
        {
            InsertNewRowTrinhDo("Dai Hoc", null);
            InsertNewRowTrinhDo("Cao Dang", null);
            InsertNewRowTrinhDo("Trung Cap", null);
        }
    }
}
