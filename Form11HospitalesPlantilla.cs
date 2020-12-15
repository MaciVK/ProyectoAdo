using ProyectoAdo.Data;
using ProyectoAdo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAdo
{
    public partial class Form11HospitalesPlantilla : Form
    {
        List<int> CodigosHospitales;
        PlantillaHospitalContext contexto;
        public Form11HospitalesPlantilla()
        {
            InitializeComponent();
            this.contexto = new PlantillaHospitalContext();
            CodigosHospitales = new List<int>();
            this.CargarHospitales();
        }
        public void CargarHospitales()
        {
            List<Hospital> hospitales = this.contexto.GetHospitales();
            CheckBox check;
            for (int i = 0; i < hospitales.Count; i++)
            {
                check = new CheckBox();
                check.Name = hospitales[i].Codigo.ToString();
                check.Text = hospitales[i].Nombre;
                check.AutoSize = true;
                check.Location = new Point(10, i * 50);
                check.CheckedChanged += Check_CheckedChanged;
                this.panel1.Controls.Add(check);
            }

        }


        private void Check_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;

            if (this.CodigosHospitales.Contains(Convert.ToInt32(chk.Name)))
            {
                this.CodigosHospitales.Remove(Convert.ToInt32(chk.Name));
            }
            else
            {
                this.CodigosHospitales.Add(Convert.ToInt32(chk.Name));
            }
            this.label1.Text = this.CodigosHospitales.Count.ToString();

        }
    }
}
