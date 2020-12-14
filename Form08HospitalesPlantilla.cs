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
using System.Configuration;

namespace ProyectoAdo
{
    public partial class Form08HospitalesPlantilla : Form
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
        public Form08HospitalesPlantilla()
        {
            InitializeComponent();
            string cadena = ConfigurationManager.ConnectionStrings["ConexionHospital"].ConnectionString;
            this.conexion = new SqlConnection(cadena);
            this.comando = new SqlCommand();
            this.comando.Connection = this.conexion;
            this.CargarHospitales();
        }
        private void CargarHospitales()
        {
            this.comando.CommandType = CommandType.StoredProcedure;
            this.comando.CommandText = "TODOSHOSPITALES";
            this.conexion.Open();
            this.lector = this.comando.ExecuteReader();
            while (this.lector.Read())
            {
                this.cmbHospitales.Items.Add(this.lector["NOMBRE"]);

            }
            this.lector.Close();
            this.conexion.Close();
        }

        private void cmbHospitales_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombre = this.cmbHospitales.SelectedItem.ToString();
            this.comando.Parameters.AddWithValue("@NOMBRE", nombre);
            SqlParameter paramsuma = new SqlParameter("@SUMA", 0);
            SqlParameter parammedia = new SqlParameter("@MEDIA", 0);
            SqlParameter parampersonas = new SqlParameter("@PERSONAS", 0);
            paramsuma.Direction = ParameterDirection.Output;
            parammedia.Direction = ParameterDirection.Output;
            parampersonas.Direction = ParameterDirection.Output;
            this.comando.Parameters.Add(paramsuma);
            this.comando.Parameters.Add(parammedia);
            this.comando.Parameters.Add(parampersonas);
            this.comando.CommandType = CommandType.StoredProcedure;
            this.comando.CommandText = "DATOSHOSPITALES";
            this.conexion.Open();
            this.lector = this.comando.ExecuteReader();
            this.lstEmpleados.Items.Clear();
            while (this.lector.Read())
            {
                this.lstEmpleados.Items.Add(this.lector["APELLIDO"]);

            }
            this.lector.Close();
            
            this.txtMedia.Text = parammedia.Value.ToString();
            this.txtSumaSalarial.Text = paramsuma.Value.ToString();
            this.txtPersonas.Text = parampersonas.Value.ToString();
            this.conexion.Close();
            this.comando.Parameters.Clear();
        }
        
    }
}
