using pensiones.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pensiones
{
    public partial class MENU : Form
    {
        conexion CN = new conexion();
        string tps;
        public MENU(string s, string usu)
        {
            InitializeComponent();
            tps = s;
            verificar_usu();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public void verificar_usu()
        {
            if (tps == "administrador")
            {
                button4.Visible = true;
            }
            else if (tps == "general")
            {
                button4.Visible = false;
            }
        }
        private void abrirforms(object forms)
        {
            if (this.panelcontenedor.Controls.Count > 0)
                this.panelcontenedor.Controls.RemoveAt(0);
            Form fm = forms as Form;
            fm.TopLevel = false;
            fm.Dock = DockStyle.Fill;
            this.panelcontenedor.Controls.Add(fm);
            this.panelcontenedor.Tag = fm;
            fm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (menuvertical.Width == 200)
            {
                menuvertical.Width = 50;
            }
            else
            {
                menuvertical.Width = 200;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                pictureBox3.Image = Resources._068minimize_100011;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                pictureBox3.Image = Resources._073maximize_99951;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("D");
            label2.Text = DateTime.Now.ToString("T");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirforms(new ENTRADAS());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            abrirforms(new SALIDAS());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            abrirforms(new REPORTES());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            REGISTRO reg = new REGISTRO();
            reg.Show();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
