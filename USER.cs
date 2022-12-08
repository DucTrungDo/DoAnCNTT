namespace QLNhanSuDVSX
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERS")]
    public partial class USER
    {
        [Key]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Pass { get; set; }

        public USER()
        {

        }

        public USER(string userName, string pass)
        {
            UserName = userName;
            Pass = pass;
        }

        public static void InsertNewRowsUSERS(string UserName, string Pass)
        {
            using (var nv = new QLNhanSuDVSXs())
            {
                var t = new USER(UserName, Pass);
                nv.USERS.Add(t);
                nv.SaveChanges();
            }
        }

        //Nhap du lieu USERS
        public static void InsertUSERS()
        {
            InsertNewRowsUSERS("admin", "admin");
        }
    }
}
