using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pensiones
{
    class conexion
    {
        public MySqlConnection cn = new MySqlConnection
            ("server = 127.0.0.1; database=prueba; Uid=root;pwd=kakashi9");
        public MySqlDataReader rs;  //resulset lectura
        public void abrir()
        {
            cn.Open();
        }
        public void cerrar()
        {
            cn.Close();
        }
        public void mov(string q)
        {
            MySqlCommand cmd = new MySqlCommand(q, cn);  //altas bajas cambios;
            cmd.ExecuteNonQuery();
        }
        public void con(string q)
        {
            MySqlCommand cmd = new MySqlCommand(q, cn); //consultas;
            rs = cmd.ExecuteReader();
        }
    }
}
