using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using ProyectoAdo.Models;
namespace ProyectoAdo.Data
{
    public class EmpleadoContext
    {

        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
        public EmpleadoContext()
        {
            string cadena = ConfigurationManager.ConnectionStrings["ConexionHospital"].ConnectionString;
            this.conexion = new SqlConnection(cadena);
            this.comando = new SqlCommand();
            this.comando.Connection = this.conexion;
        }
        public List<String> GetOficios()
        {
            List<String> oficios = new List<String>();
            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.CommandText = "SELECT DISTINCT OFICIO FROM EMP";
            this.conexion.Open();
            this.lector = this.comando.ExecuteReader();
            while (this.lector.Read())
            {
                oficios.Add(this.lector["OFICIO"].ToString());
            }
            this.lector.Close();
            this.conexion.Close();
            return oficios;
        }
        public List<Empleado> GetEmpleadosOficio(string oficio)
        {
            List<Empleado> empleados = new List<Empleado>();
            this.comando.Parameters.AddWithValue("@OFICIO", oficio);
            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.CommandText = "SELECT * FROM EMP WHERE OFICIO=@OFICIO";
            this.conexion.Open();
            this.lector = this.comando.ExecuteReader();
            while (this.lector.Read())
            {
                Empleado emp = new Empleado();
                emp.Id = Convert.ToInt32(this.lector["EMP_NO"]);
                emp.Apellido = this.lector["APELLIDO"].ToString();
                emp.Dir = Convert.ToInt32(this.lector["DIR"]);
                emp.FechaAlta = Convert.ToDateTime(this.lector["FECHA_ALT"]);
                emp.Salario = Convert.ToInt32(this.lector["SALARIO"]);
                emp.Comision = Convert.ToInt32(this.lector["COMISION"]);
                emp.DepartamentoNum = Convert.ToInt32(this.lector["DEPT_NO"]);
                empleados.Add(emp);
            }
            this.comando.Parameters.Clear();
            this.lector.Close();
            this.conexion.Close();
            return empleados;
        }
        public void AumentarSalario(String oficio, int aumento)
        {
            this.comando.Parameters.AddWithValue("@OFICIO", oficio);
            this.comando.Parameters.AddWithValue("@AUMENTO", aumento);
            this.comando.CommandType = System.Data.CommandType.StoredProcedure;
            this.comando.CommandText = "AUMENTARSALARIOSPOROFICIO";
            this.conexion.Open();
            this.comando.ExecuteNonQuery();
            this.comando.Parameters.Clear();
            this.lector.Close();
            this.conexion.Close();
            
        }
    }
}
