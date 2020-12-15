using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoAdo.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace ProyectoAdo.Data
{


    public class PlantillaHospitalContext
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
        public PlantillaHospitalContext()
        {
            string cadena = ConfigurationManager.ConnectionStrings["ConexionHospital"].ConnectionString;
            this.conexion = new SqlConnection(cadena);
            this.comando = new SqlCommand();
            this.comando.Connection = this.conexion;
        }
        public List<Hospital> GetHospitales()
        {
            List<Hospital> hospitales = new List<Hospital>();
            this.comando.CommandType = System.Data.CommandType.Text;
            this.comando.CommandText = "SELECT * FROM HOSPITAL";
            this.conexion.Open();
            this.lector = this.comando.ExecuteReader();
            while (this.lector.Read())
            {
                Hospital hosp = new Hospital();
                hosp.Codigo = Convert.ToInt32(this.lector["HOSPITAL_COD"]);
                hosp.Nombre = this.lector["NOMBRE"].ToString();
                hospitales.Add(hosp);
            }
            this.lector.Close();
            this.conexion.Close();
            return hospitales;
        }
    }
}
