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

namespace SistemaHoteleria.GerenteGeneral
{
    public partial class AdministrarTipos : Form
    {
        public AdministrarTipos()
        {
            InitializeComponent();
            cargarTipos();
            limpiarCampos();
        }

        public void limpiarCampos()
        {
            cbAccion.SelectedIndex = 0;
            txtId.Text = "ID";
            txtDescripcion.Text = "DESCRIPCION";
            cargarTipos();
        }

        public void validarCampos()
        {
            if (txtId.Text == "")
            {
                txtId.Text = "ID";
            }
            if (txtDescripcion.Text == "")
            {
                txtDescripcion.Text = "DESCRIPCION";
            }
        }

        private void cargarTipos()
        {
            using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
            {
                try
                {
                    dgvTipos.DataSource = (from t in DB.Tipo
                                           select new
                                           {
                                               ID = t.idTipo,
                                               DESCRIPCION = t.descripcion,
                                           }).ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR EN LA CONSULTA");
                }
            }
        }

        private void dgvTipos_Click(object sender, EventArgs e)
        {
            txtId.Text = dgvTipos.Rows[dgvTipos.CurrentRow.Index].Cells[0].Value.ToString();
            txtDescripcion.Text = dgvTipos.Rows[dgvTipos.CurrentRow.Index].Cells[1].Value.ToString();
        }

        private void btnRealizar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta seguro que desea realizar la accion?", "Mensaje de Confirmacion", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (txtId.Text != "ID" && txtDescripcion.Text != "DESCRIPCION")
                {
                    switch (cbAccion.SelectedItem.ToString())
                    {
                        case "AGREGAR":
                            try
                            {
                                using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
                                {
                                    Tipo nuevo = new Tipo();
                                    nuevo.idTipo = txtId.Text;
                                    nuevo.descripcion = txtDescripcion.Text;
                                    DB.Tipo.Add(nuevo);
                                    DB.SaveChanges();
                                    limpiarCampos();
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("El tipo de habitacion que desea agregar ya se encuentra registrada!");
                            }
                            break;
                        case "MODIFICAR":
                            try
                            {
                                using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
                                {
                                    Tipo nuevo = new Tipo();
                                    nuevo.idTipo = txtId.Text;
                                    nuevo.descripcion = txtDescripcion.Text;
                                    DB.Entry(nuevo).State = System.Data.Entity.EntityState.Modified;
                                    DB.SaveChanges();
                                    limpiarCampos();
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("El tipo de habitacion que desea modificar no se encuentra registrado!");
                            }
                            break;
                        default:
                            try
                            {
                                using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
                                {
                                    Tipo nuevo = DB.Tipo.Find(txtId.Text);
                                    DB.Tipo.Remove(nuevo);
                                    DB.SaveChanges();
                                    limpiarCampos();
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("El tipo de habitacion que desea eliminar no se encuentra registrado!");
                            }
                            break;
                    }
                }
                else
                {
                    lblError.Visible = true;
                }
            }
            
        }

        private void cbAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAccion.SelectedIndex == 0)
            {
                txtId.Enabled = true;
            }
            else
            {
                txtId.Enabled = false;
                txtId.Text = "ID";
                txtDescripcion.Text = "DESCRIPCION";
            }
        }

        private void txtId_OnValueChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void txtCaracteristica_OnValueChanged(object sender, EventArgs e)
        {
            validarCampos();
        }
    }
}
