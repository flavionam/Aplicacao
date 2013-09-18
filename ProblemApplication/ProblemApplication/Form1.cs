using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BO;

namespace ProblemApplication
{
     

    public partial class Form1 : Form
    {
        BO_Usuario bo_usuario = new BO_Usuario();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnResolver_Click(object sender, EventArgs e)
        {
            try
            {
                //a camada de apresentação não enxerga a DAL.
                //Para uma aplicação mais elaborada, provavelmente teria utilizado o MVC
                bo_usuario.preencherDataGrid(ref dgUsuarios);     
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro na aplicação, favor entrar em contato com suporte.", "ERRO");
            }
                
            
        }
    
    }
}
