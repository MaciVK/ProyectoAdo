using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

#region PROCEDIMIENTOS ALMACENADOS
/*
    CREATE PROCEDURE EMPLEADOSDEPTOUT
    (@NOMBRE NVARCHAR(30), @SUMA INT OUT)
    AS
	    DECLARE @DEPTNO INT
	    SELECT @DEPTNO=DEPT_NO FROM DEPT WHERE DNOMBRE=@NOMBRE
	    SELECT * FROM EMP WHERE DEPT_NO=@DEPTNO
	    SELECT @SUMA=SUM(SALARIO) FROM EMP WHERE DEPT_NO=@DEPTNO
    GO
*/

#endregion

namespace ProyectoAdo
{
    public partial class Form07ParametrosSalida : Form
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;

        public Form07ParametrosSalida()
        {
            InitializeComponent();
            string cadena = ConfigurationManager.ConnectionStrings["ConexionHospital"].ConnectionString;
            this.conexion = new SqlConnection(cadena);
            this.comando = new SqlCommand();
            this.comando.Connection = this.conexion;
            this.comando.CommandType = CommandType.StoredProcedure;
            this.comando.CommandText = "CARGARDEPARTAMENTOS";
            this.conexion.Open();
            this.lector = this.comando.ExecuteReader();
            while (this.lector.Read())
            {
                this.cmbDepartamentos.Items.Add(this.lector["DNOMBRE"]);
            }
            this.lector.Close();
            this.conexion.Close();
        }

        private void cmbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            String nombre = this.cmbDepartamentos.SelectedItem.ToString();
            this.comando.Parameters.AddWithValue("@NOMBRE", nombre);
            SqlParameter paramsuma = new SqlParameter();
            paramsuma.ParameterName = "@SUMA";
            paramsuma.Direction = ParameterDirection.Output;
            paramsuma.Value = 0;
            this.comando.Parameters.Add(paramsuma);
            this.comando.CommandType = CommandType.StoredProcedure;
            this.comando.CommandText = "EMPLEADOSDEPTOUT";
            this.conexion.Open();
            this.lector = this.comando.ExecuteReader();
            this.lstEmpleados.Items.Clear();
            while (this.lector.Read())
            {
                this.lstEmpleados.Items.Add(this.lector["APELLIDO"]);
            }
            this.lector.Close();
            this.txtSumaSalarial.Text = paramsuma.Value.ToString();
            this.conexion.Close();
            this.comando.Parameters.Clear();
        }
    }
}
