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
    public partial class Form10ClasesEmpleado : Form
    {
        EmpleadoContext contexto;

        public Form10ClasesEmpleado()
        {
            InitializeComponent();
            this.contexto = new EmpleadoContext();
            this.ComboOficios();

        }
        private void ComboOficios()
        {
            List<string> oficios = new List<string>();
            oficios = this.contexto.GetOficios();
            foreach (String oficio in oficios)
            {
                this.cmbOficios.Items.Add(oficio);
            }
        }

        private void CargarEmpleadosOficio(String oficio)
        {
            List<Empleado> empleados = this.contexto.GetEmpleadosOficio(oficio);
            this.lsvEmpleados.Items.Clear();
            foreach (Empleado emp in empleados)
            {
                ListViewItem item = new ListViewItem();
                item.Text = emp.Id.ToString();
                item.SubItems.Add(emp.Apellido);
                item.SubItems.Add(emp.Dir.ToString());
                item.SubItems.Add(emp.FechaAlta.ToShortDateString());
                item.SubItems.Add(emp.Salario.ToString());
                item.SubItems.Add(emp.Comision.ToString());
                item.SubItems.Add(emp.DepartamentoNum.ToString());
                this.lsvEmpleados.Items.Add(item);
            }
        }
        private void cmbOficios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string oficio = this.cmbOficios.SelectedItem.ToString();
            this.CargarEmpleadosOficio(oficio);

        }

        private void btnIncrementar_Click(object sender, EventArgs e)
        {
            string oficio = this.cmbOficios.SelectedItem.ToString();
            int aumento = Convert.ToInt32(this.txtIncremento.Text);
            this.contexto.AumentarSalario(oficio, aumento);
            this.CargarEmpleadosOficio(oficio);

        }
    }
}
