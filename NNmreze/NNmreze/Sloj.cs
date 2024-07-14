using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NNmreze
{
    class Sloj
    {
        Neuron[] sloj;

        //------------------------------------------------------------------------------

        #region konstruktor

        public Sloj(int brUlaza, string fja, int brNeurona)
        {
            //inicijalizacija niza sloj, prvo moramo da napravimo niz
            this.sloj = new Neuron[brNeurona];

            //posto su elemneti niza objekti klase Neuron,
            //da bi ih mogli koristiti moramo da ih napravimo
            for (int i = 0; i < sloj.Length; i++)
                this.sloj[i] = new Neuron(brUlaza, fja);
        }

        #endregion

        //------------------------------------------------------------------------------

        #region metode

        public int getBrNeurona()
        {
            return this.sloj.Length;
        }

        public double[] izracunaj(double[] x)
        {
            double[] y = new double[sloj.Length];

            for(int i = 0; i < sloj.Length; i++)
            {
                y[i] = this.sloj[i].izracunaj(x);
            }

            return y;

        }

        public void stampaj(ListBox listBox)
        {
            listBox.Items.Add("**********************************************************");
            for(int i = 0; i < sloj.Length; i++)
            {
                listBox.Items.Add($"NEURON {i + 1}:");
                sloj[i].stampaj(listBox);
            }
            listBox.Items.Add("**********************************************************");
        }

        public void resetSloja()
        {
            for (int i = 0; i < sloj.Length; i++)
                sloj[i].resetNeuron();
        }

        #endregion


        //------------------------------------------------------------------------------

        #region getSet medote

        public Neuron getNeuron(int i)
        {
            return this.sloj[i];
        }

        #endregion

        //------------------------------------------------------------------------------

    }
}
