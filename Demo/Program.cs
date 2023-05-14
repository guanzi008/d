using System;
using System.Windows.Forms;

namespace DigitalPulseAnalyzer_Demo
{ 
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmMain frmMain = new FrmMain();
            frmMain.FormClosed += FrmMain_FormClosed;
            Application.Run(frmMain);
        }

        private static void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Environment.Exit(0);
            }
            catch (Exception)
            {

            }
        }
    }
}
