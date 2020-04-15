using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonInit_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
        }

        private void buttonInstrucciones_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El objetivo del de la simulacion es llegar a la tierra, parando por los asteroides sin que \n la nave se vaya al infinito y mas alla, pasar por cristales te dará puntos\n\n  Instrucciones son:\ni. Tecla W: desplazar la nave hacia arriba hasta que un objeto la detenga \nii.Tecla S: desplazar la nave hacia abajo hasta que un objeto la detenga\niii.Tecla D: desplazar la nave hacia la derecha hasta que un objeto la detenga\niv.Tecla A: desplazar la nave hacia ala izquierda hasta que un objeto la detenga");
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
