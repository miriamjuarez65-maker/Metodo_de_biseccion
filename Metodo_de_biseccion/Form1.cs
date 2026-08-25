using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metodo_de_biseccion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtA_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {

            double a = double.Parse(txtA.Text);
            double b = double.Parse(txtB.Text);
            double error = double.Parse(txtError.Text);

            double fa = Funcion(a);
            double fb = Funcion(b);

            if (fa * fb > 0)
            {
                MessageBox.Show("El intervalo no contiene un cambio de signo.");
                return;
            }

            lstResultados.Items.Clear();

            lstResultados.Items.Add(
                "Iter.      a          b          xr        f(xr)       Error %");

            lstResultados.Items.Add(
                "----------------------------------------------------------------");

            double xr = 0;
            double xrAnterior = 0;
            double errorAproximado = 100;
            int iteracion = 0;

            while (errorAproximado > error)
            {
                iteracion++;

                xr = (a + b) / 2;

                double fxr = Funcion(xr);

                if (iteracion > 1)
                {
                    errorAproximado =
                        Math.Abs((xr - xrAnterior) / xr) * 100;
                }

                lstResultados.Items.Add(
                    iteracion.ToString().PadRight(10) +
                    a.ToString("F6").PadRight(11) +
                    b.ToString("F6").PadRight(11) +
                    xr.ToString("F6").PadRight(11) +
                    fxr.ToString("F6").PadRight(13) +
                    errorAproximado.ToString("F6") + "%"
                );

                if (fa * fxr < 0)
                {
                    b = xr;
                    fb = fxr;
                }
                else
                {
                    a = xr;
                    fa = fxr;
                }

                xrAnterior = xr;
            }

            lblRaiz.Text = "Raíz aproximada: " + xr.ToString("F6");
        }
        private double Funcion(double x)
        {
            return 5 * Math.Pow(x, 3) - 5 * Math.Pow(x, 2) + 6 * x - 2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
