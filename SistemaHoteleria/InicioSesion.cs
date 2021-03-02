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
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void textBoxUsuario_Click(object sender, EventArgs e)
        {
            //modificacion de los elementos del usuario
            //pictureBoxUsuario.Image = Properties.Resources.aavatar;
            panelUsuario.BackColor = Color.FromArgb(33, 164, 219);
            textBoxUsuario.ForeColor = Color.FromArgb(33, 164, 219);
            if (textBoxUsuario.Text == "Usuario")
            {
                textBoxUsuario.Text = "";
            }

            if (textBoxContrasenia.Text == "")
            {
                textBoxContrasenia.Text = "Contraseña";
            }
            //modificacion de los elementos de la contrasenia
            //pictureBoxContrasenia.Image= Properties.Resources.aaapadlock;
            panelContrasenia.BackColor = Color.FromArgb(200, 200, 200);
            textBoxContrasenia.ForeColor = Color.FromArgb(200, 200, 200);
        }

        private void textBoxContrasenia_Click(object sender, EventArgs e)
        {

            //modificacion de los elementos del contrasenia
            //pictureBoxContrasenia.Image = Properties.Resources.apadlock;
            panelContrasenia.BackColor = Color.FromArgb(33, 164, 219);
            textBoxContrasenia.ForeColor = Color.FromArgb(33, 164, 219);
            if (textBoxContrasenia.Text == "Contraseña")
            {
                textBoxContrasenia.Text = "";
            }

            if (textBoxUsuario.Text == "")
            {
                textBoxUsuario.Text = "Usuario";
            }
            //modificacion de los elementos de la usuario
            //pictureBoxUsuario.Image = Properties.Resources.aaaavatar;
            panelUsuario.BackColor = Color.FromArgb(200, 200, 200);
            textBoxUsuario.ForeColor = Color.FromArgb(200, 200, 200);
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkLabelOlvidarContrasenia_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SesionMantenimientoR())
            {
                OlvidasteConstrasenia olvidasteConstrasenia = new OlvidasteConstrasenia(textBoxUsuario.Text, "M");
                Hide();
                DialogResult result = olvidasteConstrasenia.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    Show();
                    lblError.Visible = false;
                }
            }
            else if (SesionLimpiezaR())
            {
                OlvidasteConstrasenia olvidasteConstrasenia = new OlvidasteConstrasenia(textBoxUsuario.Text, "L");
                Hide();
                DialogResult result = olvidasteConstrasenia.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    Show();
                    lblError.Visible = false;
                }
            }
            else if (SesionGerenteR())
            {
                OlvidasteConstrasenia olvidasteConstrasenia = new OlvidasteConstrasenia(textBoxUsuario.Text, "G");
                Hide();
                DialogResult result = olvidasteConstrasenia.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    Show();
                    lblError.Visible = false;
                }
            }
            else if (SesionRecepcionistaR())
            {
                OlvidasteConstrasenia olvidasteConstrasenia = new OlvidasteConstrasenia(textBoxUsuario.Text, "R");
                Hide();
                DialogResult result = olvidasteConstrasenia.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    Show();
                    lblError.Visible = false;
                }
            }

        }

        private void textBoxContrasenia_TextChanged(object sender, EventArgs e)
        {
            if (textBoxContrasenia.Text != "Contraseña")
            {
                textBoxContrasenia.PasswordChar = '*';
            }
        }

        private void textBoxUsuario_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonInicioSesion_Click(object sender, EventArgs e)
        {
            if (SesionMantenimiento())
            {
                Hide();
                PersonalMantenimiento pm = new PersonalMantenimiento(textBoxUsuario.Text);
                DialogResult result = pm.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    Show();
                    lblError.Visible = false;
                }
            }
            else if (SesionLimpieza())
            {
                Hide();
                PersonalLimpieza pm = new PersonalLimpieza(textBoxUsuario.Text);
                DialogResult result = pm.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    Show();
                    lblError.Visible = false;
                }
            }
            else if (SesionGerente())
            {
                Hide();
                FGerente pm = new FGerente(textBoxUsuario.Text);
                DialogResult result = pm.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    try
                    {
                        Show();
                        lblError.Visible = false;
                    }
                    catch (Exception)
                    {
                        Application.Exit();
                    }
                }
            }
            else if (SesionRecepcionista())
            {
                Hide();
                FRecepcionista pm = new FRecepcionista(textBoxUsuario.Text);
                DialogResult result = pm.ShowDialog();
                if (result == DialogResult.Cancel)
                {
                    Show();
                    lblError.Visible = false;
                }
            }
            else
            {
                lblError.Visible = true;
            }
        }

        public bool SesionMantenimiento()
        {
            bool existe = false;

            using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
            {
                string usu = textBoxUsuario.Text;
                string con = textBoxContrasenia.Text;
                Mantenimiento nuevog = DB.Mantenimiento.Find(usu);
                if (nuevog == null)
                {
                    lblError.Visible = true;
                }
                else
                {
                    if (nuevog.contrasenia == con)
                    {
                        existe = true;
                    }
                    else
                    {
                        lblError.Visible = true;
                    }
                }

            }

            return existe;
        }
        public bool SesionMantenimientoR()
        {
            bool existe = false;

            using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
            {
                string usu = textBoxUsuario.Text;
                Mantenimiento nuevog = DB.Mantenimiento.Find(usu);
                if (nuevog == null)
                {
                    lblError.Visible = true;
                }
                else
                {
                    existe = true;
                }

            }

            return existe;
        }

        public bool SesionLimpieza()
        {
            bool existe = false;

            using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
            {
                string usu = textBoxUsuario.Text;
                string con = textBoxContrasenia.Text;
                Limpieza nuevog = DB.Limpieza.Find(usu);
                if (nuevog == null)
                {
                    lblError.Visible = true;
                }
                else
                {
                    if (nuevog.contrasenia == con)
                    {
                        existe = true;
                    }
                    else
                    {
                        lblError.Visible = true;
                    }
                }

            }

            return existe;
        }
        public bool SesionLimpiezaR()
        {
            bool existe = false;

            using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
            {
                string usu = textBoxUsuario.Text;
                Limpieza nuevog = DB.Limpieza.Find(usu);
                if (nuevog == null)
                {
                    lblError.Visible = true;
                }
                else
                {
                    existe = true;
                }

            }

            return existe;
        }

        public bool SesionGerente()
        {
            bool existe = false;

            using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
            {
                string usu = textBoxUsuario.Text;
                string con = textBoxContrasenia.Text;
                Gerente nuevog = DB.Gerente.Find(usu);
                if (nuevog == null)
                {
                    lblError.Visible = true;
                }
                else
                {
                    if (nuevog.contrasenia == con)
                    {
                        existe = true;
                    }
                    else
                    {
                        lblError.Visible = true;
                    }
                }

            }

            return existe;
        }
        public bool SesionGerenteR()
        {
            bool existe = false;

            using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
            {
                string usu = textBoxUsuario.Text;
                Gerente nuevog = DB.Gerente.Find(usu);
                if (nuevog == null)
                {
                    lblError.Visible = true;
                }
                else
                {
                    existe = true;
                }

            }

            return existe;
        }

        public bool SesionRecepcionista()
        {
            bool existe = false;

            using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
            {
                string usu = textBoxUsuario.Text;
                string con = textBoxContrasenia.Text;
                Recepcionista nuevog = DB.Recepcionista.Find(usu);
                if (nuevog == null)
                {
                    lblError.Visible = true;
                }
                else
                {
                    if (nuevog.contrasenia == con)
                    {
                        existe = true;
                    }
                    else
                    {
                        lblError.Visible = true;
                    }
                }

            }

            return existe;
        }
        public bool SesionRecepcionistaR()
        {
            bool existe = false;

            using (SistemaHotelWaraEntitiesV1 DB = new SistemaHotelWaraEntitiesV1())
            {
                string usu = textBoxUsuario.Text;
                Recepcionista nuevog = DB.Recepcionista.Find(usu);
                if (nuevog == null)
                {
                    lblError.Visible = true;
                }
                else
                {
                    existe = true;
                }

            }

            return existe;
        }
    }
}
