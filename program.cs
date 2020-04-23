using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace Function_Maker
{
    class program : Form
    {
        public program() 
        {

        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new program());
        }
    }
}
