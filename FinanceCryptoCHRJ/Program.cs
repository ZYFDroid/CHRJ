using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceCryptoCHRJ
{
    static class Program
    {

        public const string appid = "com.zyfdroid.financeCHRJ.v100000000";
        public static String rootpath = Path.Combine(Path.GetTempPath(), appid);

        public static void makeFileExists(byte[] data, String filename)
        {
            if (!Directory.Exists(Path.GetDirectoryName(filename)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filename));
            }
            if (!File.Exists(filename))
            {
                File.WriteAllBytes(filename + ".tmp", data);
                File.Move(filename + ".tmp", filename);
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            makeFileExists(Properties.Resources.BGM45515, Path.Combine(rootpath, "BGM45515.mp3"));
            execMain();
        }

        static void execMain() {
            

            Environment.CurrentDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
