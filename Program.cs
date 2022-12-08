using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations.Schema;
namespace QLNhanSuDVSX
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Database.SetInitializer<QLNhanSuDVSXs>(new DropCreateDatabaseIfModelChanges<QLNhanSuDVSXs>());
            var t = new QLNhanSuDVSXs();
            t.Insert();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
