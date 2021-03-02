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
    public partial class Facturar : Form
    {
        public Facturar()
        {
            InitializeComponent();
        }

        public void incializar()
        {
            txtFiltroId.text = "TODOS";
            lblFechaIngreso.Text = "N/A";
            lblIdReserva.Text = "N/A";
            lblFechaSalida.Text = "N/A";
            lblAtencionRecepcionista.Text = "N/A";
            lblIdHabitacion.Text = "N/A";
            lblPrecioHabitacion.Text = "N/A";
            lblTipoHabitacion.Text = "N/A";
            lblNroCamas.Text = "N/A";
            lblNroPiso.Text = "N/A";
            lblEstadoReserva.Text = "N/A";
            lblTotal.Text = "N/A";
            cbEstadoNuevo.SelectedIndex = -1;
            swAireAcondicionado.Value = false;
            swAlberca.Value = false;
            swBarHotel.Value = false;
            swEstacionamiento.Value = false;
            swGym.Value = false;
            swMascotas.Value = false;
            swRestaurante.Value = false;
            swSpa.Value = false;
            swWifiHabitacion.Value = false;
            swWifiLobby.Value = false;
            DataTable dt = (DataTable)dgvHuespedes.DataSource;
            dt.Clear();
            dgvHuespedes.DataSource = dt;
            DataTable dst = (DataTable)dgvReservas.DataSource;
            dst.Clear();
            dgvReservas.DataSource = dst;
        }

        private void txtFiltroId_OnTextChange(object sender, EventArgs e)
        {
            using (var DB = new SistemaHotelWaraEntitiesV1())
            {
                try
                {

                    if (txtFiltroId.text == "TODOS" || txtFiltroId.text == "" || txtFiltroId.text == "ID...")
                    {
                        dgvReservas.DataSource = (from dr in DB.DetalleReservas
                                                  join res in DB.Reservas on dr.idDetalleReservas equals res.idReserva
                                                  join f in DB.Factura on dr.idDetalleReservas equals f.idFactura
                                                  join r in DB.Recepcionista on dr.idEmpleado equals r.idEmpleado
                                                  join h in DB.Habitaciones on dr.idHabitacion equals h.idHabitacion
                                                  join dh in DB.DetalleHabitacion on h.idHabitacion equals dh.idDetalleHabitacion
                                                  where res.estado == "SIN PAGAR"
                                                  orderby res.idReserva descending
                                                  select new { ID_RESERVA = dr.idDetalleReservas, ESTADO = res.estado, RECEPCIONISTA = (r.nombre + " " + r.paterno + " " + r.materno), ID_HABITACION = h.idHabitacion, PISO = h.nroPiso, CAMAS = h.nroCamas, TIPO = dh.idTipo }
                                                              ).ToList();
                    }
                    //else if (txtFiltroId.text != "" || txtFiltroId.text != "ID...")
                    //{
                    //    int i = int.Parse(txtFiltroId.text);
                    //    dgvReservas.DataSource = (from dr in DB.DetalleReservas
                    //                              join res in DB.Reservas on dr.idDetalleReservas equals res.idReserva
                    //                              join f in DB.Factura on dr.idDetalleReservas equals f.idFactura
                    //                              join r in DB.Recepcionista on dr.idEmpleado equals r.idEmpleado
                    //                              join h in DB.Habitaciones on dr.idHabitacion equals h.idHabitacion
                    //                              join dh in DB.DetalleHabitacion on h.idHabitacion equals dh.idDetalleHabitacion
                    //                              where dr.idDetalleReservas == i && res.estado == "SIN PAGAR"
                    //                              orderby res.idReserva descending
                    //                              select new { ID_RESERVA = dr.idDetalleReservas, ESTADO = res.estado, RECEPCIONISTA = (r.nombre + " " + r.paterno + " " + r.materno), ID_HABITACION = h.idHabitacion, PISO = h.nroPiso, CAMAS = h.nroCamas, TIPO = dh.idTipo }
                    //                                          ).ToList();
                    //}
                    else
                    {
                        int i = int.Parse(txtFiltroId.text);
                        dgvReservas.DataSource = (from dr in DB.DetalleReservas
                                                  join res in DB.Reservas on dr.idDetalleReservas equals res.idReserva
                                                  join f in DB.Factura on dr.idDetalleReservas equals f.idFactura
                                                  join r in DB.Recepcionista on dr.idEmpleado equals r.idEmpleado
                                                  join h in DB.Habitaciones on dr.idHabitacion equals h.idHabitacion
                                                  join dh in DB.DetalleHabitacion on h.idHabitacion equals dh.idDetalleHabitacion
                                                  where dr.idDetalleReservas == i && res.estado == "SIN PAGAR"
                                                  orderby res.idReserva descending
                                                  select new { ID_RESERVA = dr.idDetalleReservas, ESTADO = res.estado, RECEPCIONISTA = (r.nombre + " " + r.paterno + " " + r.materno), ID_HABITACION = h.idHabitacion, PISO = h.nroPiso, CAMAS = h.nroCamas, TIPO = dh.idTipo }
                                                              ).ToList();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void txtFiltroApellido_OnTextChange(object sender, EventArgs e)
        {
            using (var DB = new SistemaHotelWaraEntitiesV1())
            {
                dgvReservas.DataSource = (from dr in DB.DetalleReservas
                                          join res in DB.Reservas on dr.idDetalleReservas equals res.idReserva
                                          join f in DB.Factura on dr.idDetalleReservas equals f.idFactura
                                          join rh in DB.RegistroHuespedes on dr.idDetalleReservas equals rh.idReserva
                                          join hu in DB.Huespedes on rh.idHuespedes equals hu.idHuesped
                                          join r in DB.Recepcionista on dr.idEmpleado equals r.idEmpleado
                                          join h in DB.Habitaciones on dr.idHabitacion equals h.idHabitacion
                                          join dh in DB.DetalleHabitacion on h.idHabitacion equals dh.idDetalleHabitacion
                                          where (hu.paterno.StartsWith(txtFiltroApellido.text) || hu.materno.StartsWith(txtFiltroApellido.text)) && res.estado == "SIN PAGAR"
                                                  orderby res.idReserva descending
                                          select new { ID_RESERVA = dr.idDetalleReservas, ESTADO = res.estado, RECEPCIONISTA = (r.nombre + " " + r.paterno + " " + r.materno), ID_HABITACION = h.idHabitacion, PISO = h.nroPiso, CAMAS = h.nroCamas, TIPO = dh.idTipo }
                                                                  ).Distinct().ToList();
            }
        }

        private void dgvReservas_Click(object sender, EventArgs e)
        {
            try
            {
                int idReserva = int.Parse(dgvReservas.Rows[dgvReservas.CurrentRow.Index].Cells[0].Value.ToString());
                lblIdReserva.Text = idReserva.ToString();
                string idHabitacion = dgvReservas.Rows[dgvReservas.CurrentRow.Index].Cells[3].Value.ToString();

                CargarServicios(idHabitacion);

                using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
                {
                    dgvHuespedes.DataSource = (from r in DB.RegistroHuespedes
                                               join hu in DB.Huespedes on r.idHuespedes equals hu.idHuesped
                                               where r.idReserva == idReserva
                                               select new { hu.idHuesped, hu.nombre, hu.paterno, hu.materno }
                                                          ).ToList();
                }

                using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
                {
                    var datosFactura = (from r in DB.Reservas
                                        join f in DB.Factura on r.idReserva equals f.idFactura
                                        join dr in DB.DetalleReservas on r.idReserva equals dr.idDetalleReservas
                                        join h in DB.Habitaciones on dr.idHabitacion equals h.idHabitacion
                                        join dh in DB.DetalleHabitacion on h.idHabitacion equals dh.idDetalleHabitacion
                                        join rec in DB.Recepcionista on dr.idEmpleado equals rec.idEmpleado
                                        where r.idReserva == idReserva
                                        select new { r.ingreso, r.salida, REC = (rec.nombre+" "+rec.paterno+" "+rec.materno), h.idHabitacion, h.precio, dh.idTipo, h.nroCamas, h.nroPiso, r.estado, f.total}
                                                          ).ToList().First();

                    lblFechaIngreso.Text = datosFactura.ingreso.Value.ToLongDateString();
                    lblFechaSalida.Text = datosFactura.salida.Value.ToLongDateString();
                    lblAtencionRecepcionista.Text = datosFactura.REC.ToString();
                    lblIdHabitacion.Text = datosFactura.idHabitacion.ToString();
                    lblPrecioHabitacion.Text = datosFactura.precio.ToString();
                    lblTipoHabitacion.Text = datosFactura.idTipo.ToString();
                    lblNroCamas.Text = datosFactura.nroCamas.ToString();
                    lblNroPiso.Text = datosFactura.nroPiso.ToString();
                    lblEstadoReserva.Text = datosFactura.estado.ToString();
                    lblTotal.Text = datosFactura.total.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        public void CargarServicios(string idHabitacion)
        {
            using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
            {
                Servicios s = DB.Servicios.Find(idHabitacion);
                swAireAcondicionado.Value = (bool)s.aireAcondicionado;
                swAlberca.Value = (bool)s.alberca;
                swBarHotel.Value = (bool)s.barHotel;
                swEstacionamiento.Value = (bool)s.estacionamiento;
                swGym.Value = (bool)s.gym;
                swMascotas.Value = (bool)s.mascotas;
                swRestaurante.Value = (bool)s.restaurante;
                swSpa.Value = (bool)s.spa;
                swWifiHabitacion.Value = (bool)s.wifiHabitacion;
                swWifiLobby.Value = (bool)s.wifiLobby;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta seguro que desea facturar esta reserva?", "Mensaje de Confirmacion", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int i = int.Parse(dgvReservas.Rows[dgvReservas.CurrentRow.Index].Cells[0].Value.ToString());
                    using (var DB = new SistemaHotelWaraEntitiesV1())
                    {
                        Reservas nuevo = DB.Reservas.Find(i);
                        nuevo.estado = cbEstadoNuevo.SelectedItem.ToString();
                        DB.Entry(nuevo).State = System.Data.Entity.EntityState.Modified;
                        DB.SaveChanges();
                        FacturaReporte facturaReporte = new FacturaReporte(lblIdReserva.Text);
                        facturaReporte.ShowDialog();
                        MessageBox.Show("FACTURA ACTUALIZADA!");
                        incializar();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("SELECCIONE ALGUNA RESERVA HA FACTURAR!");
                    txtFiltroApellido.text = "APELLIDO...";
                    txtFiltroId.text = "ID...";
                }
            }
            
        }
    }
}
