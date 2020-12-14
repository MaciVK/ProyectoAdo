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
    public partial class Form06MensajesServidor : Form
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
        public Form06MensajesServidor()
        {
            InitializeComponent();
            string cadena = "Data Source=LOCALHOST;Initial Catalog=HOSPITAL;User ID=SA;Password=MCSD2020";
            this.conexion = new SqlConnection(cadena);
            this.comando = new SqlCommand();
            this.comando.Connection = this.conexion;
            this.conexion.InfoMessage += Conexion_InfoMessage;
            this.CargarDepartamentos();
        }

        private void Conexion_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            this.lblMensajes.ForeColor = Color.Red;
            this.lblMensajes.Text=e.Message;
        }

        private void CargarDepartamentos()
        {

            this.comando.CommandType = CommandType.StoredProcedure;
            this.comando.CommandText = "CARGARDEPARTAMENTOS";
            this.lstDepartamentos.Items.Clear();
            this.conexion.Open();
            this.lector = this.comando.ExecuteReader();
            while (this.lector.Read())
            {
                this.lstDepartamentos.Items.Add
                    ("(" + this.lector["DEPT_NO"].ToString() + ")" + this.lector["DNOMBRE"].ToString() + " -->" + this.lector["LOC"].ToString());
            }
            this.lector.Close();
            this.conexion.Close();

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            this.lblMensajes.ForeColor = Color.Black;
            this.lblMensajes.Text = "";
            if (this.txtNumero.Text != "" && this.txtNombre.Text != "" && this.txtLocalidad.Text != "")
            {
                int numero = int.Parse(this.txtNumero.Text);
                string nombre = this.txtNombre.Text;
                string localidad = this.txtLocalidad.Text;
                this.comando.CommandType = CommandType.StoredProcedure;
                this.comando.Parameters.AddWithValue("@NOMBRE", nombre);
                this.comando.Parameters.AddWithValue("@NUMERO", numero);
                this.comando.Parameters.AddWithValue("@LOCALIDAD", localidad);
                this.comando.CommandText = "INSERTARDEPARTAMENTO";
                this.conexion.Open();
                this.comando.ExecuteNonQuery();
                this.comando.Parameters.Clear();
                this.conexion.Close();
                this.CargarDepartamentos();
            }
            else
            {
                MessageBox.Show("COMPLETE TODOS LOS CAMPOS");
            }
        }
    }
}
