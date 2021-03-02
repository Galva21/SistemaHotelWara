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
using SistemaHoteleria.Datos;
using System.Data.SqlClient;

namespace SistemaHoteleria.GerenteGeneral
{
    public partial class Mensual : Form
    {
        SqlConnection conexion = new SqlConnection("Server=.;DataBase=SistemaHotelWara;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public Mensual()
        {
            InitializeComponent();
        }

        private void inicializarCampos()
        {
            btnHuespedEstrella.LabelText = "N/A";
            btnIngresos.LabelText = "N/A";
            btnNroReservaCancelada.LabelText = "N/A";
            btnNroReservas.LabelText = "N/A";
            btnTipoPreferido.LabelText = "N/A";
            lblDocumento.Text = "N/A";
            lblFechaNac.Text = "N/A";
            lblNombreCompleto.Text = "N/A";
            lblPais.Text = "N/A";
        }

        private void Mensual_Load(object sender, EventArgs e)
        {
            recargar(DateTime.Now.Month);
        }

        private void recargar(int mes)
        {
            inicializarCampos();
            Top5ClienteMensual(mes);
            Top5HabitacionMensual(mes);
            Top5PisoMensual(mes);
            IngresoMensual(mes);
            NroReservas(mes);
            NroReservasCanceladas(mes);
        }

        private void Top5ClienteMensual(int mes)
        {
            ArrayList cantidadReservas = new ArrayList();
            ArrayList idCliente = new ArrayList();

            cmd = new SqlCommand("Top5ClienteMensual", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parametro = new SqlParameter("@mes", mes);
            parametro.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parametro);

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
                try
                {
                    string id = idCliente[0].ToString();
                    btnHuespedEstrella.LabelText = id;
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
        private void Top5HabitacionMensual(int mes)
        {
            ArrayList cantidadReservas = new ArrayList();
            ArrayList idHabitacion = new ArrayList();

            cmd = new SqlCommand("Top5HabitacionMensual", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parametro = new SqlParameter("@mes", mes);
            parametro.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parametro);

            conexion.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cantidadReservas.Add(dr.GetInt32(0));
                idHabitacion.Add(dr.GetString(1));
            }
            chHabitacionReservas.Series[0].Points.DataBindXY(idHabitacion, cantidadReservas);
            dr.Close();
            conexion.Close();

            using (var DB = new SistemaHotelWaraEntitiesV1())
            {
                try
                {
                    string id = idHabitacion[0].ToString();
                    var informe = (from h in DB.Habitaciones
                                   join dh in DB.DetalleHabitacion on h.idHabitacion equals dh.idDetalleHabitacion
                                   where h.idHabitacion == id
                                   select new { dh.idTipo }
                                                          ).ToList().First();
                    btnTipoPreferido.LabelText = informe.idTipo;
                }
                catch (Exception)
                {
                }
            }

        }
        private void Top5PisoMensual(int mes)
        {
            ArrayList cantidadReservas = new ArrayList();
            ArrayList Piso = new ArrayList();

            cmd = new SqlCommand("Top5PisoMensual", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parametro = new SqlParameter("@mes", mes);
            parametro.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parametro);

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
        private void IngresoMensual(int mes)
        {
            decimal ingreso = 0;
            cmd = new SqlCommand("IngresoMensual", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parametro = new SqlParameter("@mes", mes);
            parametro.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parametro);

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
        private void NroReservas(int mes)
        {
            cmd = new SqlCommand("NroReservasMensual", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parametro = new SqlParameter("@mes", mes);
            parametro.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parametro);

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
        private void NroReservasCanceladas(int mes)
        {
            cmd = new SqlCommand("NroReservasCanceladaMensual", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parametro = new SqlParameter("@mes", mes);
            parametro.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(parametro);

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

        private void cbMeses_onItemSelected(object sender, EventArgs e)
        {
            recargar(cbMeses.selectedIndex+1);
        }
    }
}
