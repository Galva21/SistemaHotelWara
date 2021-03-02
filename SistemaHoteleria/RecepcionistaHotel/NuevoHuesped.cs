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
    public partial class NuevoHuesped : Form
    {
        public NuevoHuesped()
        {
            InitializeComponent();
            limpiarCampos();
        }

        private void UsuarioDisponible()
        {
            bool usuario = true;
            if (GenerarUsuario() != "")
            {
                while (usuario == true)
                {
                    if (ExisteUsuario(GenerarUsuario()) == false)
                    {
                        usuario = false;
                    }
                }
            }
        }

        public void limpiarCampos()
        {
            txtNombre.Text = "NOMBRE";
            txtPaterno.Text = "PATERNO";
            txtMaterno.Text = "MATERNO";
            txtDocumento.Text = "DOCUMENTO";
            txtPais.Text = "PAIS";
            dtpFechaNacimiento.Value = new DateTime(1999, 01, 01);
            lblError.Visible = false;
            lblUsuario.Text = "USUARIO";
        }

        public void verificarCampos()
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "NOMBRE";
            }
            if (txtPaterno.Text == "")
            {
                txtPaterno.Text = "PATERNO";
            }
            if (txtMaterno.Text == "")
            {
                txtMaterno.Text = "MATERNO";
            }
            if (txtDocumento.Text == "")
            {
                txtDocumento.Text = "DOCUMENTO";
            }
            if (txtPais.Text == "")
            {
                txtPais.Text = "PAIS";
            }
        }

        public bool ExisteUsuario(string usuario)
        {
            bool existe = false;
            using (var db = new SistemaHotelWaraEntitiesV1())
            {
                if (db.Huespedes.Find(usuario) != null) existe = true;
            }
            return existe;
        }

        public string GenerarUsuario()
        {
            string usuario = "";
            if (txtNombre.Text != "" && txtPaterno.Text != "" && txtMaterno.Text != "")
            {
                Random rn = new Random();
                int usuarioNumero = rn.Next(10, 99);

                usuario = "H" + txtNombre.Text[0] + txtPaterno.Text[0] + txtMaterno.Text[0] + usuarioNumero;
            }
            else usuario = "";

            lblUsuario.Text = usuario.ToUpper();

            return usuario;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta seguro que desea registrar al huesped?", "Mensaje de Confirmacion", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (txtNombre.Text != "NOMBRE" && txtPaterno.Text != "PATERNO" && txtMaterno.Text != "MATERNO" && txtDocumento.Text != "DOCUMENTO" && txtPais.Text != "PAIS")
                {

                    try
                    {

                        using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
                        {
                            Huespedes nuevog = new Huespedes();
                            nuevog.idHuesped = lblUsuario.Text;
                            nuevog.nombre = txtNombre.Text;
                            nuevog.paterno = txtPaterno.Text;
                            nuevog.materno = txtMaterno.Text;
                            nuevog.documento = txtDocumento.Text;
                            nuevog.pais = txtPais.Text;
                            nuevog.fechaNacimiento = dtpFechaNacimiento.Value;
                            DB.Huespedes.Add(nuevog);
                            DB.SaveChanges();
                            MessageBox.Show("HUESPED CREADO CON EXITO!");
                            limpiarCampos();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR CON LA LLAVE PRIMARIA: " + ex.Message);
                    }

                }
                else lblError.Visible = true;
            }
            
        }

        private void txtNombre_OnValueChanged(object sender, EventArgs e)
        {
            verificarCampos();
            UsuarioDisponible();
        }

        private void txtPaterno_OnValueChanged(object sender, EventArgs e)
        {
            verificarCampos();
            UsuarioDisponible();
        }

        private void txtMaterno_OnValueChanged(object sender, EventArgs e)
        {
            verificarCampos();
            UsuarioDisponible();
        }

        private void txtEmail_OnValueChanged(object sender, EventArgs e)
        {
            verificarCampos();
        }

        private void txtPregunta_OnValueChanged(object sender, EventArgs e)
        {
            verificarCampos();
        }

        private void txtRespuesta_OnValueChanged(object sender, EventArgs e)
        {
            verificarCampos();
        }

        private void cbTipoEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificarCampos();
            UsuarioDisponible();
        }

        private void dtpFechaNacimiento_onValueChanged(object sender, EventArgs e)
        {
            verificarCampos();
        }

        private void txtTelefono_OnValueChanged(object sender, EventArgs e)
        {
            verificarCampos();
        }
    }
}
