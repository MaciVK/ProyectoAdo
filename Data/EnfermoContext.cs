using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using ProyectoAdo.Models;

namespace ProyectoAdo.Data
{
    public class EnfermoContext
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
        public EnfermoContext()
        {
            string cadena = ConfigurationManager.ConnectionStrings["ConexionHospital"].ToString();
            this.conexion = new SqlConnection(cadena);
            this.comando = new SqlCommand();
            this.comando.Connection = this.conexion;
        }
        public List<Enfermo> GetEnfermos()
        {
            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.CommandText = "SELECT * FROM ENFERMO";
            this.conexion.Open();
            this.lector = this.comando.ExecuteReader();
            List<Enfermo> lista = new List<Enfermo>();
            while (this.lector.Read())
            {
                Enfermo enf = new Enfermo();
                enf.Inscripcion = Convert.ToInt32(this.lector["INSCRIPCION"]);
                enf.Apellido = this.lector["APELLIDO"].ToString();
                enf.Direccion = this.lector["DIRECCION"].ToString();
                enf.FechaNacimiento = Convert.ToDateTime(this.lector["FECHA_NAC"]);
                lista.Add(enf);

            }
            this.lector.Close();
            this.conexion.Close();
            return lista;
        }
        public int EliminarEnfermo(int inscripcion)
        {
            this.comando.Parameters.AddWithValue("@INSCRIPCION", inscripcion);
            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.CommandText = "DELETE FROM ENFERMO WHERE INSCRIPCION=@INSCRIPCION";
            this.conexion.Open();
            int eliminados = this.comando.ExecuteNonQuery();
            this.conexion.Close();
            this.comando.Parameters.Clear();
            return eliminados;
        }
    }
}
