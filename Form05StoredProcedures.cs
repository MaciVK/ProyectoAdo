using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ProyectoAdo
{
    public partial class Form05StoredProcedures : Form
    {
        SqlConnection conexion;
        SqlDataReader lector;
        SqlCommand comando;
        public Form05StoredProcedures()
        {
            InitializeComponent();
            string cadena = "Data Source=LOCALHOST;Initial Catalog=HOSPITAL;User ID=SA;Password=MCSD2020";
            this.comando = new SqlCommand();
            this.conexion = new SqlConnection(cadena);
            this.comando.Connection = this.conexion;
            this.comando.CommandType = CommandType.StoredProcedure;
            this.comando.CommandText = "TODOSEMPLEADOS";
            this.conexion.Open();
            this.lector=this.comando.ExecuteReader();
            while (this.lector.Read())
            {
                this.lstEmpleados.Items.Add(this.lector["APELLIDO"].ToString());
            }
            this.lector.Close();
            this.conexion.Close();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string apellido = this.txtNombre.Text;
            this.comando.Parameters.AddWithValue("@APELLIDO", apellido);
            this.comando.CommandType = CommandType.StoredProcedure;
            this.comando.CommandText = "BUSCAREMPLEADO";
            this.conexion.Open();
            this.lector = this.comando.ExecuteReader();
            this.lstEmpleados.Items.Clear();
            while (this.lector.Read())
            {
                this.lstEmpleados.Items.Add(this.lector["APELLIDO"].ToString());
            }
            this.lector.Close();
            this.comando.Parameters.Clear();
            this.conexion.Close();
        }
    }
}
