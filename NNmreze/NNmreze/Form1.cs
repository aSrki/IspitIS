using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NNmreze
{
    public partial class Form1 : Form
    {

        private double[][] ulazi;
        private double[][] izlazi;
        private double[][] ulaziTest;
        private double[][] izlaziTest;


        public Form1()
        {
            InitializeComponent();

            //Mreza m = new Mreza(2, new int[] { 3, 2, 2 }, new string[] { "STEP", "LIN", "SIG" });

            //m.stampaj(listBoxIspis);
            //m.resetMreze();
            //m.stampaj(listBoxIspis);

            //m.izracunaj(new double[] {2.4 , 1.5} );

            //Neuron n = new Neuron(2, "STEP");

            //double[][] ulazi = new double[][] { 
            //    new double[] { 1, 2 }, 
            //    new double[] { -1, 2 },
            //    new double[] { 0, -1 }
            //};

            //double[] izlazi = new double[] { 1, 0, 0 };

            //Obuka o = new Obuka(0.5, 0.01, 500);

            //bool uspesnot = o.obuci(n, ulazi, izlazi);

            //int brIt = o.getBrIteracija();
            //double err = o.getErr();

            init();

            Mreza m = new Mreza(4, new int[] { 4, 1 }, new string[] {"SIG", "STEP" });
            m.stampaj(listBoxIspis);
            Obuka o = new Obuka(0.3, 0.09, 10000);
            bool uspesnost = o.obuci(m, ulazi, izlazi);

            m.stampaj(listBoxIspis);

            double gresak = o.getErr();
            int brIt = o.getBrIteracija();

            double tacnost = o.testMreze(m, ulaziTest, izlaziTest, 0.3);

            Console.WriteLine(tacnost);
        }

        public void init()
        {
            ulazi = new double[][]
            {
                new double[] {1, 29.44/40, 85/100, 0 },
                new double[] {1, 10.00/40, 90/100, 1 },
                new double[] {0.5, 28.33/40, 86/100, 0 },
                new double[] {0, 21.11/40, 96/100, 0 },
                new double[] {0, 20.00/40, 80/100,  0},
                new double[] {0, 18.33/40, 70/100,  1},
                new double[] {0.5, 17.78/40, 65/100, 1 },
                new double[] {1, 22.22/40, 95/100,  0},
                new double[] {1, 20.56/40, 70/100,  0},
                new double[] {0, 23.89/40, 80/100, 0 },
                new double[] {1, 23.89/40, 70/100, 1 }
            };

            izlazi = new double[][]
            {
                new double[] {0},
                new double[] {0},
                new double[] {1},
                new double[] {1},
                new double[] {1},
                new double[] {0},
                new double[] {1},
                new double[] {0},
                new double[] {1},
                new double[] {1},
                new double[] {1}
            };

            ulaziTest = new double[][]
            {
                new double[] {0.5, 22.22/40, 90/100, 1 },
                new double[] {0.5, 27.22/40, 75/100, 0 },
                new double[] {0, 21.67/40, 91/100, 1 }
            };

            izlaziTest = new double[][]
            {
                new double[] {1},
                new double[] {1},
                new double[] {0}
            };
        }

    }
}
