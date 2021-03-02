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
    public partial class ModificarRegistro : Form
    {
        string idEmpleadoConectado = "";
        public ModificarRegistro(string idEmpleado)
        {
            InitializeComponent();
            idEmpleadoConectado = idEmpleado;
        }

        private void txtFiltroId_OnTextChange(object sender, EventArgs e)
        {
            using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
            {
                try
                {
                    if (txtFiltroId.text == "TODOS" || txtFiltroId.text == "")
                    {
                        dgvHabitacion.DataSource = (from h in DB.Habitaciones
                                                    join dh in DB.DetalleHabitacion on h.idHabitacion equals dh.idDetalleHabitacion
                                                    select new { h.idHabitacion, h.estado, h.nroPiso, h.nroCamas, dh.idTipo }
                                                      ).ToList();
                    }
                    else
                    {
                        dgvHabitacion.DataSource = (from h in DB.Habitaciones
                                                    join dh in DB.DetalleHabitacion on h.idHabitacion equals dh.idDetalleHabitacion
                                                    where h.idHabitacion.StartsWith(txtFiltroId.text)
                                                    select new { h.idHabitacion, h.estado, h.nroPiso, h.nroCamas, dh.idTipo }
                                                      ).ToList();
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void dgvHabitacion_Click(object sender, EventArgs e)
        {
            try
            {
                string i = dgvHabitacion.Rows[dgvHabitacion.CurrentRow.Index].Cells[0].Value.ToString();
                using (var DB = new SistemaHotelWaraEntitiesV1())
                {
                    dgvRegistro.DataSource = (from h in DB.Habitaciones
                                              join dh in DB.DetalleRegistroLimpiezas on h.idHabitacion equals dh.idHabitacion
                                              join rl in DB.RegistroLimpieza on dh.idRegistroLimpieza equals rl.idRegistroLimpieza
                                              join l in DB.Limpieza on dh.idEmpleado equals l.idEmpleado
                                              where h.idHabitacion == i && l.idEmpleado == idEmpleadoConectado
                                              orderby rl.fecha.Value descending 
                                              select new { l.idEmpleado, rl.informe, rl.fecha, rl.hora, rl.idRegistroLimpieza}
                                                          ).ToList();
                }
            }
            catch (Exception)
            {
            }
        }

        private void dgvRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                string i = dgvRegistro.Rows[dgvRegistro.CurrentRow.Index].Cells[4].Value.ToString();
                using (var DB = new SistemaHotelWaraEntitiesV1())
                {
                    var informe = (from h in DB.Habitaciones
                             join dh in DB.DetalleRegistroLimpiezas on h.idHabitacion equals dh.idHabitacion
                             join rl in DB.RegistroLimpieza on dh.idRegistroLimpieza equals rl.idRegistroLimpieza
                             where dh.idRegistroLimpieza == i
                             select new { rl.informe }
                                                          ).ToList().First();

                    txtInforme.Text = informe.informe;
                }
            }
            catch (Exception)
            {
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (txtInforme.Text != "")
            {
                DialogResult result = MessageBox.Show("Esta seguro que desea modificar el registro?", "Mensaje de Confirmacion", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string i = dgvRegistro.Rows[dgvRegistro.CurrentRow.Index].Cells[4].Value.ToString();
                        using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
                        {
                            RegistroLimpieza nuevog = DB.RegistroLimpieza.Find(i);
                            nuevog.informe = txtInforme.Text;
                            DB.Entry(nuevog).State = System.Data.Entity.EntityState.Modified;
                            DB.SaveChanges();
                        }

                        string ii = dgvHabitacion.Rows[dgvHabitacion.CurrentRow.Index].Cells[0].Value.ToString();
                        using (var DB = new SistemaHotelWaraEntitiesV1())
                        {
                            dgvRegistro.DataSource = (from h in DB.Habitaciones
                                                      join dh in DB.DetalleRegistroLimpiezas on h.idHabitacion equals dh.idHabitacion
                                                      join rl in DB.RegistroLimpieza on dh.idRegistroLimpieza equals rl.idRegistroLimpieza
                                                      join l in DB.Limpieza on dh.idEmpleado equals l.idEmpleado
                                                      where h.idHabitacion == ii && l.idEmpleado == idEmpleadoConectado
                                                      orderby rl.fecha.Value descending
                                                      select new { l.idEmpleado, rl.informe, rl.fecha, rl.hora, rl.idRegistroLimpieza }
                                                                  ).ToList();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error con la modificacion!");
                    }
                }
            }
            else
            {
                MessageBox.Show("No puede modificar a un registro vacío! Por favor ingrese su registro!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFiltroPeriodo.SelectedIndex)
            {
                case 0:
                    try
                    {
                        string i = dgvHabitacion.Rows[dgvHabitacion.CurrentRow.Index].Cells[0].Value.ToString();
                        using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
                        {
                            dgvRegistro.DataSource = (from h in DB.Habitaciones
                                                      join dh in DB.DetalleRegistroLimpiezas on h.idHabitacion equals dh.idHabitacion
                                                      join rl in DB.RegistroLimpieza on dh.idRegistroLimpieza equals rl.idRegistroLimpieza
                                                      where h.idHabitacion == i && rl.fecha.Value == DateTime.Now
                                                      orderby rl.fecha.Value, rl.hora ascending
                                                      select new { h.idHabitacion, h.nroCamas, rl.fecha, rl.hora, rl.idRegistroLimpieza }
                                                                  ).ToList();

                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error con el dia!");
                    }
                    break;
                case 1:
                    try
                    {
                        string i = dgvHabitacion.Rows[dgvHabitacion.CurrentRow.Index].Cells[0].Value.ToString();
                        using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
                        {
                            dgvRegistro.DataSource = (from h in DB.Habitaciones
                                                      join dh in DB.DetalleRegistroLimpiezas on h.idHabitacion equals dh.idHabitacion
                                                      join rl in DB.RegistroLimpieza on dh.idRegistroLimpieza equals rl.idRegistroLimpieza
                                                      where h.idHabitacion == i && rl.fecha.Value >= DateTime.Now.AddDays(-7)
                                                      orderby rl.fecha.Value, rl.hora ascending
                                                      select new { h.idHabitacion, h.nroCamas, rl.fecha, rl.hora, rl.idRegistroLimpieza }
                                                                  ).ToList();

                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error con la semana!");
                    }
                    break;
                case 2:
                    try
                    {
                        string i = dgvHabitacion.Rows[dgvHabitacion.CurrentRow.Index].Cells[0].Value.ToString();
                        using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
                        {
                            dgvRegistro.DataSource = (from h in DB.Habitaciones
                                                      join dh in DB.DetalleRegistroLimpiezas on h.idHabitacion equals dh.idHabitacion
                                                      join rl in DB.RegistroLimpieza on dh.idRegistroLimpieza equals rl.idRegistroLimpieza
                                                      where h.idHabitacion == i && rl.fecha.Value >= DateTime.Now.AddDays(-31)
                                                      orderby rl.fecha.Value, rl.hora ascending
                                                      select new { h.idHabitacion, h.nroCamas, rl.fecha, rl.hora, rl.idRegistroLimpieza }
                                                                  ).ToList();

                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error con el mes!");
                    }
                    break;
            }
        }
    }
}
