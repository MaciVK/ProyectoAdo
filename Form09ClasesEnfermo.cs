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
    public partial class Form09ClasesEnfermo : Form
    {
        EnfermoContext contexto;

        public Form09ClasesEnfermo()
        {
            InitializeComponent();
            contexto = new EnfermoContext();
            this.CargarEnfermos();
        }
        private void CargarEnfermos()
        {
            List<Enfermo> enfermos = this.contexto.GetEnfermos();
            this.lsvEnfermos.Items.Clear();
            foreach(Enfermo enf in enfermos)
            {
                ListViewItem it = new ListViewItem();
                it.Text = enf.Inscripcion.ToString();
                it.SubItems.Add(enf.Apellido);
                it.SubItems.Add(enf.Direccion);
                it.SubItems.Add(enf.FechaNacimiento.ToShortDateString());
                this.lsvEnfermos.Items.Add(it);

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //SE RECUPERA EL ITEM SELECCIONADO
            ListViewItem it = lsvEnfermos.SelectedItems[0];
            int inscripcion = Convert.ToInt32(it.Text);
            this.contexto.EliminarEnfermo(inscripcion);
            this.btnEliminar.Text = "ELIMINAR";
            this.CargarEnfermos();

        }

        private void lsvEnfermos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lsvEnfermos.SelectedItems.Count!=0)
            {
                ListViewItem it = lsvEnfermos.SelectedItems[0];
                this.btnEliminar.Text = "Eliminar "+it.Text;
            }

        }
    }
}
