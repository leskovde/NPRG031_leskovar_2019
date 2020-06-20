/* 
     CodeWars 
  	 Denis Leskovar, I. ročník
  	 letní semestr 2018/19 
  	 Programování II NPRG031
*/
using System;
using System.Windows.Forms;

namespace CodeWars.Forms
{
    internal static class Program
    {
        public static CwMenu menu;
        public static CwForm form;
        public static double DegreeToRad(int degree)
        {
            return Math.PI * degree / 180.0;
        }
        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            menu = new CwMenu();
            Application.Run(menu);

        }
    }
}
