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
    public partial class LOGIN : Form
    {
        conexion CN = new conexion();
        string usu,s,tu;

        public LOGIN()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("ninguno de los campos puede estar vacio...");
            }
            else
            {
                try
                {
                    CN.abrir();
                    CN.con("select * from usuarios where nombre=('" + textBox1.Text + "')and password=('" + textBox2.Text + "')");
                    if (CN.rs.Read())
                    {
                        tu = Convert.ToString(CN.rs["tipouss"]);
                        if (tu == "admin")
                        {
                            s = "admin";
                            usu = textBox1.Text;
                            MENU mn = new MENU(s, usu);
                            mn.Show();
                            this.Hide();
                        }
                        else if (tu == "general")
                        {
                            s = "general";
                            usu = textBox1.Text;
                            MENU mn = new MENU(s, usu);
                            mn.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("usuario y/o contrseña incorrectas...");
                    }
                    CN.cerrar();
                }
                catch (Exception z1)
                {
                    MessageBox.Show(z1.ToString());
                }
                //try
                //{
                //    CN.abrir();
                //    CN.con("select nombre from usuarios where nombre='" + textBox1.Text + "'");
                //    if(CN.rs.Read())
                //    {
                //        CN.con("select password from usuarios where password ='" + textBox2.Text + "'");
                //        if(CN.rs.Read())
                //        {
                //            tu = Convert.ToString(CN.rs["tipouss"]);
                //            if (tu == "admin")
                //            {
                //                s = "admin";
                //                usu = textBox1.Text;
                //                MENU mn = new MENU(s, usu);
                //                mn.Show();
                //                this.Hide();
                //            }
                //            else if (tu == "general")
                //            {
                //                s = "general";
                //                usu = textBox1.Text;
                //                MENU mn = new MENU(s, usu);
                //                mn.Show();
                //                this.Hide();
                //            }
                //            CN.cerrar();
                //        }
                //        else
                //        {
                //            MessageBox.Show("contraseña incorrecta...");
                //        }
                //    }
                //    else
                //    {
                //        MessageBox.Show("usuario incorrecto...");
                //    }
                //}
                //catch(Exception e1)
                //{
                //    MessageBox.Show(e1.ToString());
                //}
            }

        }
    }
}
