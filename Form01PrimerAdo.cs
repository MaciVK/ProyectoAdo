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
    public partial class Form01PrimerAdo : Form
    {
        string CadenaConexion;
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;

        public Form01PrimerAdo()
        {
            InitializeComponent();
            this.CadenaConexion = @"Data Source=LOCALHOST\SQLGabri;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2020";
            this.conexion = new SqlConnection(this.CadenaConexion);
            this.comando = new SqlCommand();
            this.conexion.StateChange += Conexion_StateChange;

        }

        private void Conexion_StateChange(object sender, StateChangeEventArgs e)
        {
            this.lblEstado.Text = "Connection pasando de " + e.OriginalState + " a " + e.CurrentState;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (this.conexion.State == ConnectionState.Closed)
            {
                this.conexion.Open();
                this.lblEstado.ForeColor = Color.Black;
                this.lblEstado.BackColor = Color.LightGreen;

            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            this.conexion.Close();
            this.lblEstado.ForeColor = Color.White;
            this.lblEstado.BackColor = Color.DarkRed;
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            //Indicar comando a la conexion
            this.comando.Connection = this.conexion;
            //Tipo de consulta a realizar->comando.CommandType
            this.comando.CommandType = CommandType.Text;
            this.comando.CommandText = "SELECT * FROM EMP";
            //Ejecutamos el comando (con la conexion abierta)
            //Devuelve un SqlDataReader
            this.lector=this.comando.ExecuteReader();

            for(int i = 0; i < this.lector.FieldCount; i++)
            {

                string columna = this.lector.GetName(i);
                string tipo = this.lector.GetDataTypeName(i);
                this.lstColumnas.Items.Add(columna);
                this.lstTipos.Items.Add(tipo);

            }
            while (this.lector.Read())
            {
                string apellido = this.lector.GetString(1);
                this.lstApellidos.Items.Add(apellido);
            }
            this.lector.Close();
        }
    }
}
