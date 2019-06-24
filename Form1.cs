using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            FtpWebRequest conexion = (FtpWebRequest)FtpWebRequest.Create("ftp://files.000webhost.com/public_html/" + "/" + Path.GetFileName(@"C:\\Users\\aleja\\OneDrive\\Escritorio\\a20144688.txt"));
            conexion.Method = WebRequestMethods.Ftp.UploadFile;
            conexion.Credentials = new NetworkCredential("test1pweb", "computadora321");
            conexion.UsePassive = true;
            conexion.UseBinary = true;
            conexion.KeepAlive = false;
            
            FileStream stream = File.OpenRead(@"C:\\Users\\aleja\\OneDrive\\Escritorio\\a20144688.txt");
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream.Close();
            
            Stream reqStream = conexion.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();
        }
    }
}
