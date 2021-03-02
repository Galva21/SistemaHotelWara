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
    public partial class ModificarHuesped : Form
    {
        public ModificarHuesped()
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
            DialogResult result = MessageBox.Show("Esta seguro que desea modificar el huesped?", "Mensaje de Confirmacion", MessageBoxButtons.YesNo);
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
                            DB.Entry(nuevog).State = System.Data.Entity.EntityState.Modified;
                            DB.SaveChanges();
                            MessageBox.Show("HUESPED MODIFICADO CON EXITO!");

                            dgvEmpleados.DataSource = (from d in DB.Huespedes
                                                       where d.idHuesped == lblUsuario.Text
                                                       select d).ToList();

                            limpiarCampos();
                            txtNombre.Focus();
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
        }

        private void txtPaterno_OnValueChanged(object sender, EventArgs e)
        {
            verificarCampos();
        }

        private void txtMaterno_OnValueChanged(object sender, EventArgs e)
        {
            verificarCampos();
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

        private void dgvEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                lblUsuario.Text = dgvEmpleados.Rows[dgvEmpleados.CurrentRow.Index].Cells[0].Value.ToString();
                txtNombre.Text = dgvEmpleados.Rows[dgvEmpleados.CurrentRow.Index].Cells[1].Value.ToString();
                txtPaterno.Text = dgvEmpleados.Rows[dgvEmpleados.CurrentRow.Index].Cells[2].Value.ToString();
                txtMaterno.Text = dgvEmpleados.Rows[dgvEmpleados.CurrentRow.Index].Cells[3].Value.ToString();
                txtDocumento.Text = dgvEmpleados.Rows[dgvEmpleados.CurrentRow.Index].Cells[4].Value.ToString();
                txtPais.Text = dgvEmpleados.Rows[dgvEmpleados.CurrentRow.Index].Cells[5].Value.ToString();
                dtpFechaNacimiento.Value = DateTime.Parse(dgvEmpleados.Rows[dgvEmpleados.CurrentRow.Index].Cells[6].Value.ToString());
            }
            catch (Exception)
            {
            }
        }

        private void txtFiltroApellido_OnTextChange(object sender, EventArgs e)
        {
            using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
            {
                try
                {
                    if (txtFiltroApellido.text == "" || txtFiltroApellido.text == "APELLIDO..." || txtFiltroApellido.text == "TODOS")
                    {
                        dgvEmpleados.DataSource = (from d in DB.Huespedes
                                                   select d).ToList();
                    }
                    else
                    {
                        dgvEmpleados.DataSource = (from d in DB.Huespedes
                                                   where d.paterno.StartsWith(txtFiltroApellido.text) || d.materno.StartsWith(txtFiltroApellido.text) || d.documento.StartsWith(txtFiltroApellido.text)
                                                   select d).ToList();
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR EN LA CONSULTA");
                }
            }
        }
    }
}
