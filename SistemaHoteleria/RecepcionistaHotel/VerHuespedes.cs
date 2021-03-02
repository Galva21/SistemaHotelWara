using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaHoteleria.Datos;

namespace SistemaHoteleria.RecepcionistaHotel
{
    public partial class VerHuespedes : Form
    {
        public VerHuespedes()
        {
            InitializeComponent();
            limpiarCampos();
        }

        public void limpiarCampos()
        {
            CargarGerentes("");
        }

        public void CargarGerentes(string apellido)
        {
            using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
            {
                try
                {
                    if (apellido == "" || apellido == "APELLIDO...")
                    {
                        dgvEmpleados.DataSource = (from d in DB.Huespedes
                                                   select d).ToList();
                    }
                    else
                    {
                        dgvEmpleados.DataSource = (from d in DB.Huespedes
                                                   where d.paterno.StartsWith(apellido) || d.materno.StartsWith(apellido)
                                                   select d).ToList();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR EN LA CONSULTA");
                }
            }
        }

        public void CargarRecepcionista(string apellido)
        {
            DataTable dt = new DataTable();
            using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
            {
                try
                {
                    if (apellido == "" || apellido == "APELLIDO...")
                    {
                        dgvEmpleados.DataSource = (from d in DB.Recepcionista
                                                   select d).ToList();
                    }
                    else
                    {
                        dgvEmpleados.DataSource = (from d in DB.Recepcionista
                                                   where d.paterno.StartsWith(apellido) || d.materno.StartsWith(apellido)
                                                   select d).ToList();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR EN LA CONSULTA");
                }
            }
        }

        public void CargarLimpieza(string apellido)
        {
            DataTable dt = new DataTable();
            using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
            {
                try
                {
                    if (apellido == "" || apellido == "APELLIDO...")
                    {
                        dgvEmpleados.DataSource = (from d in DB.Limpieza
                                                   select d).ToList();
                    }
                    else
                    {
                        dgvEmpleados.DataSource = (from d in DB.Limpieza
                                                   where d.paterno.StartsWith(apellido) || d.materno.StartsWith(apellido)
                                                   select d).ToList();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR EN LA CONSULTA");
                }
            }
        }

        public void CargarMantenimiento(string apellido)
        {
            DataTable dt = new DataTable();
            using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
            {
                try
                {
                    if (apellido == "" || apellido == "APELLIDO...")
                    {
                        dgvEmpleados.DataSource = (from d in DB.Mantenimiento
                                                   select d).ToList();
                    }
                    else
                    {
                        dgvEmpleados.DataSource = (from d in DB.Mantenimiento
                                                   where d.paterno.StartsWith(apellido) || d.materno.StartsWith(apellido)
                                                   select d).ToList();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR EN LA CONSULTA");
                }
            }
        }

        private void txtFiltroApellido_OnTextChange(object sender, EventArgs e)
        {
            using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
            {
                try
                {
                    if (txtFiltroApellido.text == "" || txtFiltroApellido.text == "APELLIDO..." || txtFiltroApellido.text == "TODOS")
                    {
                        dgvEmpleados.DataSource = (from d in DB.Huespedes
                                                   select d).ToList();
                    }
                    else
                    {
                        dgvEmpleados.DataSource = (from d in DB.Huespedes
                                                   where d.paterno.StartsWith(txtFiltroApellido.text) || d.materno.StartsWith(txtFiltroApellido.text) || d.documento.StartsWith(txtFiltroApellido.text)
                                                   select d).ToList();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR EN LA CONSULTA");
                }
            }
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvEmpleados_Click(object sender, EventArgs e)
        {

        }
    }
}
