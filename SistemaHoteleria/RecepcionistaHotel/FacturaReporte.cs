using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHoteleria.RecepcionistaHotel
{
    public partial class FacturaReporte : Form
    {
        public FacturaReporte(string idReserva)
        {
            InitializeComponent();
            bunifuTextbox1.text = idReserva;
        }

        private void FACTURA_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'facturaBD.DataTable1' Puede moverla o quitarla según sea necesario.
            // TODO: esta línea de código carga datos en la tabla 'facturaBD.DataTable2' Puede moverla o quitarla según sea necesario.
            // TODO: esta línea de código carga datos en la tabla 'facturaBD.DataTable1' Puede moverla o quitarla según sea necesario.

        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            try
            {
                int id = -1;
                id = int.Parse(bunifuTextbox1.text);
                this.DataTable1TableAdapter.Fill(this.facturaBD.DataTable1, id);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {
            }
        }
    }
}
