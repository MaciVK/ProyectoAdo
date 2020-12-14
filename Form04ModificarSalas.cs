using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoAdo
{
    public partial class Form04ModificarSalas : Form
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
        public Form04ModificarSalas()
        {
            InitializeComponent();
            string cadena = "Data Source=LOCALHOST;Initial Catalog=HOSPITAL;User ID=SA;Password=MCSD2020";
            this.conexion = new SqlConnection(cadena);
            this.comando = new SqlCommand();
        }

        private void CargarSalas() {
            this.lstSalas.Items.Clear();
            this.comando.Connection = this.conexion;
            this.comando.CommandType = CommandType.Text;
            this.comando.CommandText = "SELECT DISTINCT NOMBRE FROM SALA";
            this.conexion.Open();
            this.lector = this.comando.ExecuteReader();
            while (this.lector.Read())
            {
                String nombre = this.lector["NOMBRE"].ToString();
                this.lstSalas.Items.Add(nombre);
            }
            this.lector.Close();
            this.conexion.Close();



        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string consulta = "UPDATE SALA SET NOMBRE = @NUEVO WHERE NOMBRE = @VIEJO";
            string nuevo = this.txtNuevoNombre.Text;
            string viejo = this.lstSalas.SelectedItem.ToString();
            this.comando.Parameters.AddWithValue("@NUEVO", nuevo);
            this.comando.Parameters.AddWithValue("@VIEJO", viejo);
            this.comando.CommandType = CommandType.Text;
            this.comando.CommandText = consulta;
            this.conexion.Open();
            int update = this.comando.ExecuteNonQuery();
            this.conexion.Close();
            this.comando.Parameters.Clear();
            this.lblResultado.Text = "Salas modificadas: " + update;
            this.CargarSalas();

        }
    }
}
