using PracticaFinal.Models;
using PracticaFinal.Repositories;
using System.Runtime.CompilerServices;

namespace PracticaFinal
{
    public partial class Form1 : Form
    {
        DepartamentosRepository repo;

        public Form1()
        {
            InitializeComponent();

            this.repo = new DepartamentosRepository();
            this.LoadDepartamentos();
        }

        private async void LoadDepartamentos()
        {
            List<string> departamentos = await this.repo.GetDepartamentosAsync();

            this.cmbDepartamentos.Items.Clear();

            foreach (string departmento in departamentos)
            {
                this.cmbDepartamentos.Items.Add(departmento);
            }
        }

        private async void btnInsertar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text);
            string nombre = this.txtNombre.Text;
            string localidad = this.txtLocalidad.Text;

            int registros = await this.repo.InsertDepartamentoAsync(id, nombre, localidad);

            MessageBox.Show("Registros insertados: " + registros);

            this.LoadDepartamentos();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado();
            empleado.Apellido = this.txtApellido.Text;
            empleado.Oficio = this.txtOficio.Text;
            empleado.Salario = int.Parse(this.txtSalario.Text);

            int registros = await this.repo.UpdateDepartamentoAsync(empleado);

            MessageBox.Show("Registros actualizados: " + registros);

            string nombre = this.cmbDepartamentos.SelectedItem.ToString();

            this.GetEmpleadosByDepartamento(nombre);
        }

        private async void cmbDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDepartamentos.SelectedIndex == -1)
                return;

            string nombre = this.cmbDepartamentos.SelectedItem.ToString();

            Departamento departamento = await this.repo.GetDepartamentoByNombreAsync(nombre);

            this.txtId.Text = departamento.Id.ToString();
            this.txtNombre.Text = departamento.Nombre;
            this.txtLocalidad.Text = departamento.Localidad;

            this.GetEmpleadosByDepartamento(nombre);
        }

        private async void GetEmpleadosByDepartamento(string nombre)
        {
            List<Empleado> empleados = await this.repo.GetEmpleadosDepartamentoAsync(nombre);

            this.lstEmpleados.Items.Clear();

            foreach (Empleado empleado in empleados)
            {
                this.lstEmpleados.Items.Add(empleado.Apellido + " - " + empleado.Oficio + " - " + empleado.Salario);
            }
        }

        private void lstEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string datos = this.lstEmpleados.SelectedItem.ToString();

            this.txtApellido.Text = datos.Split('-')[0].Trim();
            this.txtOficio.Text = datos.Split('-')[1].Trim();
            this.txtSalario.Text = datos.Split('-')[2].Trim();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string nombre = this.cmbDepartamentos.SelectedItem.ToString();

            int registros = await this.repo.DeleteDepartamentoAsync(nombre);

            MessageBox.Show("Registros eliminados: " + registros);

            this.LoadDepartamentos();
            this.cmbDepartamentos.SelectedIndex = -1;

            this.txtId.Text = "";
            this.txtNombre.Text = "";
            this.txtLocalidad.Text = "";
        }
    }
}