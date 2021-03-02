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
            DialogResult result = MessageBox.Show("Esta seguro de agregar el registro?", "Mensaje de Confirmacion", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    var random = new Random();
                    int j = random.Next(1000, 5000);
                    string i = j + DateTime.Now.ToString("s");
                    using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
                    {
                        RegistroMantenimiento nuevog = new RegistroMantenimiento();
                        nuevog.idRegistroMantenimiento = i;
                        nuevog.fecha = DateTime.Now;
                        nuevog.hora = DateTime.Now.ToLongTimeString();
                        nuevog.informe = txtInforme.Text;
                        DB.RegistroMantenimiento.Add(nuevog);
                        DB.SaveChanges();
                    }
                    using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
                    {
                        DetalleRegistroMantenimiento nuevog = new DetalleRegistroMantenimiento();
                        nuevog.idEmpleado = idEmpleadoConectado;
                        nuevog.idRegistroMantenimiento = i;
                        DB.DetalleRegistroMantenimiento.Add(nuevog);
                        DB.SaveChanges();
                        MessageBox.Show("REGISTRO REALIZADO CON EXITO!");
                        limpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR CON LA LLAVE PRIMARIA VUELVA A INTENTARLO: " + ex.Message);
                }
            }
            
        }

        private void limpiarCampos()
        {
            txtInforme.Text = "INGRESE EL INFORME RESPECTIVO AQUI";
        }
    }
}
