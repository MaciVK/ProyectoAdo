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
    public partial class Form03EliminarEnfermo : Form
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
        
        public Form03EliminarEnfermo()
        {
            InitializeComponent();
            string cadena = @"Data Source=LOCALHOST\SQLGabri;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2020";
            this.conexion = new SqlConnection(cadena);
            this.comando = new SqlCommand();
            
            this.CargarPacientes();
        }
        private void CargarPacientes()
        {
            this.lstPacientes.Items.Clear();
            this.comando.Connection = this.conexion;
            this.comando.CommandType = CommandType.Text;
            this.comando.CommandText = "select * from enfermo";
            this.conexion.Open();
            this.lector = this.comando.ExecuteReader();
            while (this.lector.Read())
            {
                string apellido = this.lector["apellido"].ToString();
                string inscripcion = this.lector["inscripcion"].ToString();
                this.lstPacientes.Items.Add(apellido + " ---> " + inscripcion);
            }
            this.lector.Close();
            this.conexion.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.comando.Parameters.AddWithValue("@INSCRIPCION", this.txtInscripcion.Text);
            string query="delete from enfermo where inscripcion=@INSCRIPCION";
            this.comando.CommandType = CommandType.Text;
            this.comando.CommandText = query;
            this.conexion.Open();
            int afectados = this.comando.ExecuteNonQuery();
            MessageBox.Show(afectados.ToString() + " fila(s) afectada(s)");
            this.conexion.Close();
            this.CargarPacientes();
        }
    }
}
