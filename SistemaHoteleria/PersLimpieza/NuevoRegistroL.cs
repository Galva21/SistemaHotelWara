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

namespace SistemaHoteleria.PersLimpieza
{
    public partial class NuevoRegistroL : Form
    {
        string idEmpleadoConectado = "";
        public NuevoRegistroL(string id)
        {
            InitializeComponent();
            idEmpleadoConectado = id;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta seguro que desea agregar el nuevo registro?", "Mensaje de Confirmacion", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (lblHabitacion.Text != "ID")
                    {
                        string i = lblHabitacion.Text + DateTime.Now.ToString("s");
                        using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
                        {
                            RegistroLimpieza nuevog = new RegistroLimpieza();
                            nuevog.idRegistroLimpieza = i;
                            nuevog.fecha = DateTime.Now;
                            nuevog.hora = DateTime.Now.ToLongTimeString();
                            nuevog.informe = txtInforme.Text;
                            DB.RegistroLimpieza.Add(nuevog);
                            DB.SaveChanges();
                        }
                        using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
                        {
                            DetalleRegistroLimpiezas nuevog = new DetalleRegistroLimpiezas();
                            nuevog.idEmpleado = idEmpleadoConectado;
                            nuevog.idRegistroLimpieza = i;
                            nuevog.idHabitacion = lblHabitacion.Text;
                            DB.DetalleRegistroLimpiezas.Add(nuevog);
                            DB.SaveChanges();
                            MessageBox.Show("REGISTRO REALIZADO CON EXITO!");
                            limpiarCampos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("DEBE SELECCIONAR LA HABITACION!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR CON LA LLAVE PRIMARIA: " + ex.Message);
                }
            }
            
        }

        private void limpiarCampos()
        {
            txtInforme.Text = "INGRESE EL INFORME RESPECTIVO AQUI";
            txtFiltroId.text = "ID...";
        }

        private void txtFiltroId_OnTextChange(object sender, EventArgs e)
        {
            using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
            {
                try
                {
                    if (txtFiltroId.text == "TODOS" || txtFiltroId.text == "")
                    {
                        dgvHabitaciones.DataSource = (from h in DB.Habitaciones
                                                      join dh in DB.DetalleHabitacion on h.idHabitacion equals dh.idDetalleHabitacion
                                                      select new { h.idHabitacion, h.precio, h.nroPiso, h.nroCamas, h.estado, dh.idTipo }
                                                      ).ToList();
                    }
                    else
                    {
                        dgvHabitaciones.DataSource = (from h in DB.Habitaciones
                                                      join dh in DB.DetalleHabitacion on h.idHabitacion equals dh.idDetalleHabitacion
                                                      where h.idHabitacion.StartsWith(txtFiltroId.text) 
                                                      select new { h.idHabitacion, h.precio, h.nroPiso, h.nroCamas, h.estado, dh.idTipo }
                                                      ).ToList();
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void dgvHabitaciones_Click(object sender, EventArgs e)
        {
            lblHabitacion.Text = dgvHabitaciones.Rows[dgvHabitaciones.CurrentRow.Index].Cells[0].Value.ToString();
        }
    }
}
