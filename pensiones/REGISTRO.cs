using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pensiones
{
    public partial class REGISTRO : Form
    {
        conexion CN = new conexion();
        bool lib;
        public REGISTRO()
        {
            InitializeComponent();
        }
        public void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedItem = "";
        }
        public void verificar()
        {
            try
            {
                CN.abrir();
                CN.con("select nombre from usuarios where nombre='" + textBox1.Text + "'");
                if(CN.rs.Read())
                {
                    lib = true;
                }
                else
                {
                    lib = false;
                }
                CN.cerrar();
            }
            catch(Exception e3)
            {
                MessageBox.Show(e3.ToString());
            }
        }
        private void REGISTRO_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("los campos de usuario y contraseña no pueden estar vacios..");
            }
            else
            {
                verificar();
                if(lib==true)
                {
                    MessageBox.Show("El nombre de  '" + textBox1.Text + "' ya esta registrado en la base de datos..");
                }
                else if(lib==false)
                {
                    try
                    {
                        CN.abrir();
                        CN.mov("insert into usuarios (nombre,password,tipouss) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedItem + "')");
                        MessageBox.Show("usuario'" + textBox1.Text + "'guardado correctamente..");
                        CN.cerrar();
                        limpiar();
                    }
                    catch (Exception e2)
                    {
                        MessageBox.Show(e2.ToString());
                    }
                }
            }
        }
    }
}
