using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JVELHA
{
    public partial class JVelha : Form
    {
        bool xis = true;
        public JVelha()
        {
            InitializeComponent();
        }

        private void JVelha_Load(object sender, EventArgs e)
        {

            BL1C1.Click += new EventHandler(BClick);
            BL1C2.Click += new EventHandler(BClick);
            BL1C3.Click += new EventHandler(BClick);
            BL2C1.Click += new EventHandler(BClick);
            BL2C2.Click += new EventHandler(BClick);
            BL2C3.Click += new EventHandler(BClick);
            BL3C1.Click += new EventHandler(BClick);
            BL3C2.Click += new EventHandler(BClick);
            BL3C3.Click += new EventHandler(BClick);

            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    item.TabStop = false;
                }
            }
        }
        private void BClick(object sender, EventArgs e)
        {
            ((Button)sender).Text = this.xis ? "x" : "o";
            ((Button)sender).Enabled = false;
            VerificarGanhador();
            xis = !xis;
            label1.Text = String.Format("{0}, É a sua vez", this.xis ? "x" : "o");

        }
        private void VerificarGanhador()
        {
            if (
                    BL1C1.Text != String.Empty && BL1C1.Text == BL1C2.Text && BL1C2.Text == BL1C3.Text || //linha 1
                    BL2C1.Text != String.Empty && BL2C1.Text == BL2C2.Text && BL2C2.Text == BL2C3.Text || //linha 2
                    BL3C1.Text != String.Empty && BL3C1.Text == BL3C2.Text && BL3C2.Text == BL3C3.Text || //linha 3

                    BL1C1.Text != String.Empty && BL1C1.Text == BL2C1.Text && BL2C1.Text == BL3C1.Text || //COluna 1
                    BL1C2.Text != String.Empty && BL1C2.Text == BL2C2.Text && BL2C2.Text == BL3C2.Text || //Coluna 2
                    BL1C3.Text != String.Empty && BL1C3.Text == BL2C3.Text && BL2C3.Text == BL3C3.Text || //Coluna 3

                    BL1C1.Text != String.Empty && BL1C1.Text == BL2C2.Text && BL2C2.Text == BL3C3.Text || // Diagonal\
                    BL1C3.Text != String.Empty && BL1C3.Text == BL2C2.Text && BL2C2.Text == BL3C1.Text // Diagonal\
                )
            {
                MessageBox.Show(String.Format("O ganhador é o {0}", xis ? "x" : "o"), "Temos um Vencedor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Reiniciar();
            }
            else
            {
                VerificarEmpate();
            }

        }
        private void VerificarEmpate()
        {
            bool todosDesabilitados = true;

            foreach (Control item in this.Controls)
            {
                if (item is Button && item.Enabled)
                {
                    todosDesabilitados = false;
                    break;
                }
            }

            if (todosDesabilitados)
            {
                MessageBox.Show(String.Format("Deu empate"), "Ops!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Reiniciar();
            }
        }
        private void Reiniciar()
        {
            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    item.Enabled = true;
                    item.Text = String.Empty;
                }
            }
        }
    }

}
