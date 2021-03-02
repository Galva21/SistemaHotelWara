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
    public partial class VerRegistros : Form
    {
        public VerRegistros()
        {
            InitializeComponent();
            using (var DB = new SistemaHotelWaraEntitiesV1())
            {
                dgvRegistro.DataSource = (from rm in DB.RegistroMantenimiento
                                          join drm in DB.DetalleRegistroMantenimiento on rm.idRegistroMantenimiento equals drm.idRegistroMantenimiento
                                          join e in DB.Mantenimiento on drm.idEmpleado equals e.idEmpleado
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

        private void cbFiltroRegistro_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFiltroRegistro.SelectedIndex)
            {
                case 0:
                    try
                    {
                    }
                    catch (Exception)
                    {
                    }
                    break;
                case 1:
                    break;
                case 2:
                    break;

            }
        }
    }
}
