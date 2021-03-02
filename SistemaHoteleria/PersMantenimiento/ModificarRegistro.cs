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

namespace SistemaHoteleria.PersMantenimiento
{
    public partial class ModificarRegistro : Form
    {
        string idEmpleadoConectado = "";
        public ModificarRegistro(string id)
        {
            InitializeComponent();
            idEmpleadoConectado = id;
            using (var DB = new SistemaHotelWaraEntitiesV1())
            {
                dgvRegistro.DataSource = (from rm in DB.RegistroMantenimiento
                                          join drm in DB.DetalleRegistroMantenimiento on rm.idRegistroMantenimiento equals drm.idRegistroMantenimiento
                                          join e in DB.Mantenimiento on drm.idEmpleado equals e.idEmpleado
                                          where drm.idEmpleado == idEmpleadoConectado
                                          orderby rm.fecha descending
                                          select new { e.idEmpleado, rm.fecha, rm.hora, drm.idRegistroMantenimiento }
                                                      ).ToList();
            }
        }

        private void dgvRegistro_Click(object sender, EventArgs e)
        {
            try
            {
                string i = dgvRegistro.Rows[dgvRegistro.CurrentRow.Index].Cells[3].Value.ToString();
                using (var DB = new SistemaHotelWaraEntitiesV1())
                {
                    var informe = (from rm in DB.RegistroMantenimiento
                                   where rm.idRegistroMantenimiento == i
                                   select new { rm.informe }
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
                        string i = dgvRegistro.Rows[dgvRegistro.CurrentRow.Index].Cells[3].Value.ToString();
                        using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
                        {
                            RegistroMantenimiento nuevog = DB.RegistroMantenimiento.Find(i);
                            nuevog.informe = txtInforme.Text;
                            DB.Entry(nuevog).State = System.Data.Entity.EntityState.Modified;
                            DB.SaveChanges();
                        }

                        using (var DB = new SistemaHotelWaraEntitiesV1())
                        {
                            var informe = (from rm in DB.RegistroMantenimiento
                                           where rm.idRegistroMantenimiento == i
                                           select new { rm.informe }
                                                                  ).ToList().First();

                            txtInforme.Text = informe.informe;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {
                MessageBox.Show("No puede modificar a un registro vacio! Por favor complete su registro!");
            }
        }
    }
}
