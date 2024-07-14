using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NNmreze
{
    class Neuron
    {
        private double[] w;
        private double b;
        private string fja; //STEP, LIN, SIG
        private double y;
        private double delta;

        //------------------------------------------------------------------------------

        #region konstruktor

        public Neuron()
        {

        }

        public Neuron(int brojUlaza, string fja)
        {
            w = new double[brojUlaza];
            b = 0;
            this.fja = fja;
        }

        #endregion

        //------------------------------------------------------------------------------

        #region metode

        public double izracunaj(double[] x)
        {
            double suma = 0;

            for(int i = 0; i < x.Length; i++)
            {
                suma += this.w[i] * x[i];
            }

            suma = suma + b;

            if(this.fja == "STEP")
            {
                if (suma >= 0)
                    y = 1;
                else
                    y = 0;
            }
            else if (this.fja == "LIN")
            {
                y = suma;
            }
            else if (this.fja == "SIG")
            {
                y = 1 / (1 + Math.Exp(-suma));
            }

            return y;
        }

        public double YPrim()
        {
            double yPrim = 0;

            switch(this.fja)
            {
                case "STEP":
                case "LIN":
                    yPrim = 1;
                    break;
                case "SIG":
                    yPrim = this.y * (1 - this.y);
                    break;
            }

            return yPrim;
        }

        public void resetNeuron(double min, double max)
        {
            Random rnd = new Random();

            b = min + rnd.NextDouble() * (max - min);

            for(int i = 0; i < w.Length; i++)
            {
                w[i] = min + rnd.NextDouble() * (max - min);
            }
        }

        public void resetNeuron()
        {
            //min = -1, max = 1;
            resetNeuron(-1, 1);
        }

        public void stampaj(ListBox listBox)
        {
            listBox.Items.Add("-----------------------------------------------------");
            for(int i = 0; i < w.Length; i++)
                listBox.Items.Add($"w{i + 1} = {w[i]}");
            listBox.Items.Add($"b = {b}");
            listBox.Items.Add($"Fja aktivacije je {fja}");
            listBox.Items.Add("-----------------------------------------------------");
        }

        #endregion

        //------------------------------------------------------------------------------

        #region getSet metode

        public double getLastY()
        {
            return this.y;
        }

        public void setDelta(double novaDelta)
        {
            this.delta = novaDelta;
        }

        public double getDelta()
        {
            return this.delta;
        }

        public void setW(int i, double novaW)
        {
            this.w[i] = novaW;
        }

        public double getW(int i)
        {
            return this.w[i];
        }

        public void setB(double noviB)
        {
            this.b = noviB;
        }

        public double getB()
        {
            return this.b;
        }

        public void setFja(string novaFja)
        {
            this.fja = novaFja;
        }

        public string getFja()
        {
            return this.fja;
        }

        public int getBrUlaza()
        {
            return this.w.Length;
        }

        #endregion

        //------------------------------------------------------------------------------
    }
}
