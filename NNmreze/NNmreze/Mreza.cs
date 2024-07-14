using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NNmreze
{
    class Mreza
    {
        Sloj[] mreza;

        //------------------------------------------------------------------------------

        #region konstruktor

        public Mreza(int brUlaza, int[] config, string[] fje)
        {
            mreza = new Sloj[config.Length];

            //prvi sloj se razlikuje od svih ostalih slojeva u mrezi po broju ulaza
            //ulazi prvog sloja su uvek spoljni ulazi
            //ulazi svih ostalih slojeva su izlazi neurona prethodnog sloja
            mreza[0] = new Sloj(brUlaza, fje[0], config[0]);

            for(int i = 1; i < mreza.Length; i++)
            {
                mreza[i] = new Sloj(config[i - 1], fje[i], config[i]);
            }

        }

        #endregion

        //------------------------------------------------------------------------------

        #region metode

        public double[] izracunaj(double[] x)
        {
            double[] y;

            y = mreza[0].izracunaj(x);

            for (int i = 1; i < mreza.Length; i++)
                y = mreza[i].izracunaj(y);

            return y;
        }

        public void resetMreze()
        {
            for (int i = 0; i < mreza.Length; i++)
                mreza[i].resetSloja();
        }

        public void stampaj(ListBox listBox)
        {
            listBox.Items.Add("===========================================================");
            for(int i = 0; i < mreza.Length; i++)
            {
                listBox.Items.Add($"SLOJ {i + 1}");
                mreza[i].stampaj(listBox);
            }
            listBox.Items.Add("===========================================================");
        }

        #endregion

        //------------------------------------------------------------------------------

        #region getSet metode

        public Sloj getSloj(int i)
        {
            return this.mreza[i];
        }

        public int getBrSlojeva()
        {
            return mreza.Length;
        }

        #endregion

        //------------------------------------------------------------------------------



    }
}
