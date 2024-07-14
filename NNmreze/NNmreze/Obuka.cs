using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNmreze
{
    class Obuka
    {
        private double ni;
        private double maxErr;
        private int maxIt;

        private double sumErr;
        private int it;

        public Obuka(double ni, double maxErr, int maxIt)
        {
            this.ni = ni;
            this.maxErr = maxErr;
            this.maxIt = maxIt;
        }

        public bool obuci(Neuron n, double[][] ulazi, double[] izlazi)
        {
            sumErr = 0;
            it = 0;

            n.resetNeuron();

            do
            {
                it++;
                sumErr = 0;

                for(int i = 0; i < ulazi.Length; i++)
                {
                    double[] x = ulazi[i];
                    double yZel = izlazi[i];

                    //1. racunanje izlaza Neurona
                    n.izracunaj(x);

                    //2. racunanje greske

                    double err = yZel - n.getLastY();
                    double delta = err * n.YPrim();
                    n.setDelta(delta);
                    sumErr += (err * err) / 2;

                    //3. podesavanje tezina i bijasa
                    double noviB = n.getB() + ni * n.getDelta() * 1;
                    n.setB(noviB);

                    for (int j = 0; j < n.getBrUlaza(); j++)
                        n.setW(j, n.getW(j) + ni * n.getDelta() * x[j]);

                }


            } while (sumErr > maxErr && it < maxIt);


            //vracamo uspesnost, da li sam uspeo da obucim neuron, tj. da li je greska zadovoljena
            return sumErr <= maxErr;
        }

        public bool obuci(Mreza m, double[][] ulazi, double[][] izlazi)
        {
            sumErr = 0;
            it = 0;

            m.resetMreze();

            do
            {
                it++;
                sumErr = 0;

                for(int i = 0; i < ulazi.Length; i++)
                {
                    double[] x = ulazi[i];

                    //1. racunjanje izlaza mreze
                    m.izracunaj(x);

                    //2. racunanje delte i greske
                    for(int s = (m.getBrSlojeva()-1); s >= 0; s--)
                    {
                        Sloj sloj = m.getSloj(s);

                        if (s == m.getBrSlojeva() - 1)
                        {
                            //izlazni sloj
                            for(int n = 0; n < sloj.getBrNeurona(); n++)
                            {
                                Neuron neuron = sloj.getNeuron(n);

                                double yZel = izlazi[i][n];
                                double err = yZel - neuron.getLastY();
                                //double err = yZel - m.getSloj(s).getNeuron(n).getLastY();
                                double delta = err * neuron.YPrim();
                                neuron.setDelta(delta);
                                sumErr += (err * err) / 2;
                            }
                        }
                        else
                        {
                            //neki drugi sloj, nije izlazni

                            //za prolaz kroz neurone tog sloja
                            for(int n = 0; n < sloj.getBrNeurona(); n++)
                            {
                                Neuron neuron = sloj.getNeuron(n);

                                Sloj slojIspred = m.getSloj(s + 1);

                                double sumDelta = 0;

                                for (int t = 0; t < slojIspred.getBrNeurona(); t++)
                                {
                                    Neuron neuronIspred = slojIspred.getNeuron(t);

                                    sumDelta += neuronIspred.getW(n) * neuronIspred.getDelta();
                                }

                                double delta = sumDelta * neuron.YPrim();
                                neuron.setDelta(delta);
                            }
                        }
                    }

                    //3. podesavanje tezina i bijasa
                    for(int s = 0; s < m.getBrSlojeva(); s++)
                    {
                        Sloj sloj = m.getSloj(s);

                        if (s == 0)
                        {
                            for(int n = 0; n < sloj.getBrNeurona(); n++)
                            {
                                Neuron neuron = sloj.getNeuron(n);

                                double noviB = neuron.getB() + this.ni * neuron.getDelta() * 1;
                                neuron.setB(noviB);
                                //double noviB = m.getSloj(s).getNeuron(n).getB() + this.ni * m.getSloj(s).getNeuron(n).getDelta() * 1;

                                for(int t = 0; t < neuron.getBrUlaza(); t++)
                                {
                                    double novaW = neuron.getW(t) + this.ni * neuron.getDelta() * x[t];
                                    neuron.setW(t, novaW);
                                }
                            }
                        }
                        else
                        {
                            for(int n = 0; n < sloj.getBrNeurona(); n++)
                            {
                                Neuron neuron = sloj.getNeuron(n);

                                double noviB = neuron.getB() + this.ni * neuron.getDelta() * 1;
                                neuron.setB(noviB);

                                Sloj slojIza = m.getSloj(s - 1);

                                for(int t = 0; t < neuron.getBrUlaza(); t++)
                                {
                                    double novaW = neuron.getW(t) + this.ni * neuron.getDelta() * slojIza.getNeuron(t).getLastY();
                                    neuron.setW(t, novaW);
                                }
                            }
                        }
                    }
                }

            } while (sumErr > maxErr && it < maxIt);

            
            return (sumErr <= maxErr);
        }


        public double testMreze(Mreza m, double[][] ulaziTest, double[][] izlaziTest, double odstupanje)
        {
            double brojPogodaka = 0;
            double brojUzoraka = 0;

            for(int i = 0; i < ulaziTest.Length; i++)
            {
                double[] dobijeniIzlazi = m.izracunaj(ulaziTest[i]);
                double[] zeljeniIzlazi = izlaziTest[i];

                for(int j = 0; j < dobijeniIzlazi.Length; j++)
                {
                    brojUzoraka++;
                    if (dobijeniIzlazi[j] >= (zeljeniIzlazi[j] - odstupanje) && dobijeniIzlazi[j] <= (zeljeniIzlazi[j] + odstupanje))
                        brojPogodaka++;
                }

            }

            return brojPogodaka / brojUzoraka * 100;
        }


        public int getBrIteracija()
        {
            return this.it;
        }

        public double getErr()
        {
            return this.sumErr;
        }

    }
}
