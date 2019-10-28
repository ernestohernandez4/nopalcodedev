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
    public partial class LOAD : Form
    {
        conexion CN = new conexion();
        bool bd;
        public LOAD()
        {
            InitializeComponent();
            probar_conx();
        }
        public void probar_conx()
        {
            try
            {
                CN.abrir();
                CN.cerrar();
                //MessageBox.Show("conexion exitosa");
                bd = true;
                if(bd==true)
                {
                    timer1.Enabled = true;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
                //bd = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            if(panel2.Width>=800)
            { 
                timer1.Stop();
                LOGIN lg = new LOGIN();
                lg.Show();
                this.Hide();
            }
        }
    }
}
