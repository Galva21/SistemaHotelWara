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

namespace SistemaHoteleria
{
    public partial class OlvidasteConstrasenia : Form
    {
        string respuestaCorrecta = "0";
        string idEmpleado;
        string Cargo;
        public OlvidasteConstrasenia(string id, string Empleado)
        {
            InitializeComponent();
            idEmpleado = id;
            Cargo = Empleado;
            using(var DB = new SistemaHotelWaraEntitiesV1())
            {
                if (Empleado == "R")
                {
                    Recepcionista nuevo = DB.Recepcionista.Find(id);
                    lblPregunta.Text = nuevo.preguntaRecu;
                    respuestaCorrecta = nuevo.respuestaRecu;
                }
                else if (Empleado == "G")
                {
                    Gerente nuevo = DB.Gerente.Find(id);
                    lblPregunta.Text = nuevo.preguntaRecu;
                    respuestaCorrecta = nuevo.respuestaRecu;
                }
                else if (Empleado == "L")
                {
                    Limpieza nuevo = DB.Limpieza.Find(id);
                    lblPregunta.Text = nuevo.preguntaRecu;
                    respuestaCorrecta = nuevo.respuestaRecu;
                }
                else if (Empleado == "M")
                {
                    Mantenimiento nuevo = DB.Mantenimiento.Find(id);
                    lblPregunta.Text = nuevo.preguntaRecu;
                    respuestaCorrecta = nuevo.respuestaRecu;
                }
                else
                {
                    MessageBox.Show("Error con el cargo del empleado");
                }
            }
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtRespuesta_Click(object sender, EventArgs e)
        {
            //modificacion de los elementos del usuario
            panelRespuesta.BackColor = Color.FromArgb(33, 164, 219);
            txtRespuesta.ForeColor = Color.FromArgb(33, 164, 219);
            if (txtRespuesta.Text == "Respuesta")
            {
                txtRespuesta.Text = "";
            }
        }

        private void txtRespuesta_TextChanged(object sender, EventArgs e)
        {
            if (txtRespuesta.Text == respuestaCorrecta)
            {
                buttonRecuperar.Visible = true;
                gbRespuesta.Visible = false;
                gbContrasenia.Visible = true;
            }
            else
            {
                buttonRecuperar.Visible = false;
                gbRespuesta.Visible = true;
                gbContrasenia.Visible = false;
            }
        }

        private void buttonRecuperar_Click(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == txtConfirmar.Text && txtConfirmar.Text != "" && txtContrasenia.Text != "")
            {
                using (var DB = new SistemaHotelWaraEntitiesV1())
                {
                    if (Cargo == "R")
                    {
                        Recepcionista nuevo = DB.Recepcionista.Find(idEmpleado);
                        nuevo.contrasenia = txtContrasenia.Text;
                        DB.Entry(nuevo).State = System.Data.Entity.EntityState.Modified;
                        DB.SaveChanges();
                        MessageBox.Show("La contraseña se cambio con exito!");
                        this.Close();
                    }
                    else if (Cargo == "G")
                    {
                        Gerente nuevo = DB.Gerente.Find(idEmpleado);
                        nuevo.contrasenia = txtContrasenia.Text;
                        DB.Entry(nuevo).State = System.Data.Entity.EntityState.Modified;
                        DB.SaveChanges();
                        MessageBox.Show("La contraseña se cambio con exito!");
                        this.Close();
                    }
                    else if (Cargo == "L")
                    {
                        Limpieza nuevo = DB.Limpieza.Find(idEmpleado);
                        nuevo.contrasenia = txtContrasenia.Text;
                        DB.Entry(nuevo).State = System.Data.Entity.EntityState.Modified;
                        DB.SaveChanges();
                        MessageBox.Show("La contraseña se cambio con exito!");
                        this.Close();
                    }
                    else if (Cargo == "M")
                    {
                        Mantenimiento nuevo = DB.Mantenimiento.Find(idEmpleado);
                        nuevo.contrasenia = txtContrasenia.Text;
                        DB.Entry(nuevo).State = System.Data.Entity.EntityState.Modified;
                        DB.SaveChanges();
                        MessageBox.Show("La contraseña se cambio con exito!");
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas deben coincidir en ambos campos o no estar vacios!");
            }
        }

        private void txtContrasenia_Click(object sender, EventArgs e)
        {
            //modificacion de los elementos del contrasenia
            //pictureBoxContrasenia.Image = Properties.Resources.apadlock;
            panelContrasenia.BackColor = Color.FromArgb(33, 164, 219);
            txtContrasenia.ForeColor = Color.FromArgb(33, 164, 219);
            if (txtContrasenia.Text == "Nueva Contraseña")
            {
                txtContrasenia.Text = "";
            }

            if (txtConfirmar.Text == "")
            {
                txtConfirmar.Text = "Confirme Contraseña";
            }
            //modificacion de los elementos de la usuario
            //pictureBoxUsuario.Image = Properties.Resources.aaaavatar;
            panelConfirmar.BackColor = Color.FromArgb(200, 200, 200);
            txtConfirmar.ForeColor = Color.FromArgb(200, 200, 200);
        }

        private void txtConfirmar_Click(object sender, EventArgs e)
        {
            //modificacion de los elementos del contrasenia
            //pictureBoxContrasenia.Image = Properties.Resources.apadlock;
            panelConfirmar.BackColor = Color.FromArgb(33, 164, 219);
            txtConfirmar.ForeColor = Color.FromArgb(33, 164, 219);
            if (txtConfirmar.Text == "Confirme Contraseña")
            {
                txtConfirmar.Text = "";
            }

            if (txtContrasenia.Text == "")
            {
                txtContrasenia.Text = "Nueva Contraseña";
            }
            //modificacion de los elementos de la usuario
            //pictureBoxUsuario.Image = Properties.Resources.aaaavatar;
            panelContrasenia.BackColor = Color.FromArgb(200, 200, 200);
            txtContrasenia.ForeColor = Color.FromArgb(200, 200, 200);
        }
    }
}
