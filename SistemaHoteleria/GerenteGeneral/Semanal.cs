using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SistemaHoteleria.Datos;

namespace SistemaHoteleria.GerenteGeneral
{
    public partial class Semanal : Form
    {
        SqlConnection conexion = new SqlConnection("Server=.;DataBase=SistemaHotelWara;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public Semanal()
        {
            InitializeComponent();
        }

        private void Semanal_Load(object sender, EventArgs e)
        {
            Top5ClienteSemanal();
            Top5HabitacionSemanal();
            Top5PisoSemanal();
            IngresoSemanal();
            NroReservas();
            NroReservasCanceladas();
        }

        private void Top5ClienteSemanal()
        {
            ArrayList cantidadReservas = new ArrayList();
            ArrayList idCliente = new ArrayList();

            cmd = new SqlCommand("Top5ClienteSemanal", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    cantidadReservas.Add(dr.GetInt32(0));
                    idCliente.Add(dr.GetString(1));
                }
                chClientesReservas.Series[0].Points.DataBindXY(idCliente, cantidadReservas);
            }
            catch (Exception)
            {
            }
            dr.Close();
            conexion.Close();

            using (var DB = new SistemaHotelWaraEntitiesV1())
            {
                string id = idCliente[0].ToString();
                btnHuespedEstrella.LabelText = id;
                try
                {
                    Huespedes h = DB.Huespedes.Find(id);
                    lblNombreCompleto.Text = h.nombre + " " + h.paterno + " " + h.materno;
                    lblPais.Text = h.pais;
                    lblDocumento.Text = h.documento;
                    lblFechaNac.Text = h.fechaNacimiento.Value.ToLongDateString();
                }
                catch (Exception)
                {
                }
            }
        }
        private void Top5HabitacionSemanal()
        {
            ArrayList cantidadReservas = new ArrayList();
            ArrayList idHabitacion = new ArrayList();

            cmd = new SqlCommand("Top5HabitacionSemanal", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    cantidadReservas.Add(dr.GetInt32(0));
                    idHabitacion.Add(dr.GetString(1));
                }
                chHabitacionReservas.Series[0].Points.DataBindXY(idHabitacion, cantidadReservas);
            }
            catch (Exception)
            {
            }
            dr.Close();
            conexion.Close();

            using (var DB = new SistemaHotelWaraEntitiesV1())
            {
                string id = idHabitacion[0].ToString();
                try
                {
                    var informe = (from h in DB.Habitaciones
                                   join dh in DB.DetalleHabitacion on h.idHabitacion equals dh.idDetalleHabitacion
                                   where h.idHabitacion == id
                                   select new {dh.idTipo}
                                                          ).ToList().First();
                    btnTipoPreferido.LabelText = informe.idTipo;
                }
                catch (Exception)
                {
                }
            }

        }
        private void Top5PisoSemanal()
        {
            ArrayList cantidadReservas = new ArrayList();
            ArrayList Piso = new ArrayList();

            cmd = new SqlCommand("Top5PisoSemanal", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    cantidadReservas.Add(dr.GetInt32(0));
                    Piso.Add("Piso: " + dr.GetInt32(1));
                }
                chPisoReservados.Series[0].Points.DataBindXY(Piso, cantidadReservas);
            }
            catch (Exception)
            {
            }
            dr.Close();
            conexion.Close();            
        }
        private void IngresoSemanal()
        {
            decimal ingreso = 0;
            cmd = new SqlCommand("IngresoSemanal", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();    
            dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    ingreso = dr.GetDecimal(0);
                }
                btnIngresos.LabelText = ingreso + " Bs.";
            }
            catch (Exception)
            {
            }
            dr.Close();
            conexion.Close();
        }
        private void NroReservas()
        {
            cmd = new SqlCommand("NroReservas", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            dr = cmd.ExecuteReader();
            int nro = 0;
            try
            {
                while (dr.Read())
                {
                    nro = dr.GetInt32(0);
                }
            }
            catch (Exception)
            {
            }
            dr.Close();
            conexion.Close();
            btnNroReservas.LabelText = "" + nro;
        }
        private void NroReservasCanceladas()
        {
            cmd = new SqlCommand("NroReservasCancelada", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            dr = cmd.ExecuteReader();
            int nro = 0;
            try
            {
                while (dr.Read())
                {
                    nro = dr.GetInt32(0);
                }
            }
            catch (Exception)
            {
            }
            dr.Close();
            conexion.Close();
            btnNroReservaCancelada.LabelText = "" + nro;
        }
    }
}
