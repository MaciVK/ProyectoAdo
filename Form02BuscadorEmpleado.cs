using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAdo
{
    public partial class Form02BuscadorEmpleado : Form
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
        public Form02BuscadorEmpleado()
        {
            InitializeComponent();
            string cadena = @"Data Source=LOCALHOST\SQLGabri;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2020";
            this.conexion = new SqlConnection(cadena);
            this.comando = new SqlCommand();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string deptno = this.txtDato.Text;
            string query = "select apellido, oficio from emp where dept_no=" + deptno;
            this.lstEmpleados.Items.Clear();
            //Hay que entrar-salir
            this.comando.Connection = this.conexion;
            this.comando.CommandType = CommandType.Text;
            this.comando.CommandText = query;
            this.conexion.Open();
            this.lector = this.comando.ExecuteReader();
            while (this.lector.Read())
            {
                //MEJOR PONERLE EL NOMBRE DE LA COLUMNA EN LUGAR DEL INDICE
                //string apellido = this.lector.GetString(0); -->ASI NO
                string apellido = this.lector["APELLIDO"].ToString();
                string oficio = this.lector["oficio"].ToString();
                this.lstEmpleados.Items.Add(apellido + " --> " + oficio);
            }
            this.lector.Close();
            this.conexion.Close();
        }
    }
}
