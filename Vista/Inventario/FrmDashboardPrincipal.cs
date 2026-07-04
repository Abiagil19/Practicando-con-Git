using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Dashboard;

namespace Vista.Inventario
{
    public partial class FrmDashboardPrincipal : Form
    {
        public FrmDashboardPrincipal()
        {
            InitializeComponent();

        }
        private Form activeForm=null;
        private void subPanel(bool estado)
        {
            pnlInventario.Visible = estado;
            pnlSalida.Visible = estado;
        }
        private void abrirForm(Form formularioAbrir)
        {
            if (activeForm!=null)
                activeForm.Close();
            //Para el formulario que vamos a traer
            // al panel contenedor
            //cambiamos algunos aspectos de su ventana 
            activeForm = formularioAbrir;
            //Es para que no se sobreponga el formulario,
            // es decir que no sea flotante
            formularioAbrir.TopLevel=false;
            //quitar el borde del formulario
            formularioAbrir.FormBorderStyle = FormBorderStyle.None;
            // que se estire en todo el papel
            formularioAbrir.Dock = DockStyle.Fill;
            //agregamos el formulario
            pnlContenedor.Controls.Add(formularioAbrir);
            formularioAbrir.BringToFront();
            formularioAbrir.Show();
        }
        private void FrmDashboardPrincipal_Load(object sender, EventArgs e)
        {
            //Vamos a iniciar los subpanles sin que se muestren
            subPanel(false);
        }
     
       
        private void ALternalPanel ( Panel panelObjetivo)
        {
            //Guardamos el estado actual del panel al que pertenece su boton princiapl
            bool actualmenteVisible = panelObjetivo.Visible;
            //Cerramos todos los subpaneles al principio
            this.subPanel(false);
            //Si el panel estaba oculto, ahora lo mostraremos, y si ya estaba visibiel se quedará oculto
            panelObjetivo.Visible =!actualmenteVisible;
        }
      
        

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            ALternalPanel(pnlInventario);
        }


        private void btnGestiondeMateriales_Click(object sender, EventArgs e)
        {
            abrirForm(new FrmGestiondeMateriales());
        }

        private void btnSalida_Click_1(object sender, EventArgs e)
        {
            ALternalPanel(pnlSalida);

        }
    }

       
    }

