using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AI.Fuzzy.Library;

namespace FuzzyLogic
{
    public partial class Form1 : Form
    {
        SugenoFuzzySystem fsKran;
        FuzzyVariable fvRazdaljina;
        FuzzyVariable fvUgao;
        SugenoVariable svSnaga;


        public Form1()
        {
            InitializeComponent();

            napraviFuzzySistem();
            
            
        }

        public void napraviFuzzySistem()
        {
            fsKran = new SugenoFuzzySystem();

            fvRazdaljina = new FuzzyVariable("Razdaljina", -10, 30);
            fvRazdaljina.Terms.Add(new FuzzyTerm("predaleko", new TrapezoidMembershipFunction(-10, -10, -5, 0)));
            fvRazdaljina.Terms.Add(new FuzzyTerm("nula", new TriangularMembershipFunction(-5, 0, 5)));
            fvRazdaljina.Terms.Add(new FuzzyTerm("blizu", new TriangularMembershipFunction(0, 5, 10)));
            fvRazdaljina.Terms.Add(new FuzzyTerm("srednje", new TriangularMembershipFunction(5, 10, 23)));
            fvRazdaljina.Terms.Add(new FuzzyTerm("daleko", new TrapezoidMembershipFunction(10, 23, 30, 30)));
            fsKran.Input.Add(fvRazdaljina);

            fvUgao = new FuzzyVariable("Ugao", -90, 90);
            fvUgao.Terms.Add(new FuzzyTerm("neg_velik", new TrapezoidMembershipFunction(-90, -90, -50, -10)));
            fvUgao.Terms.Add(new FuzzyTerm("neg_mali", new TriangularMembershipFunction(-50, -10, 0)));
            fvUgao.Terms.Add(new FuzzyTerm("nula", new TriangularMembershipFunction(-10, 0, 10)));
            fvUgao.Terms.Add(new FuzzyTerm("poz_mali", new TriangularMembershipFunction(0, 10, 50)));
            fvUgao.Terms.Add(new FuzzyTerm("poz_veliki", new TrapezoidMembershipFunction(10, 50, 90, 90)));
            fsKran.Input.Add(fvUgao);

            svSnaga = new SugenoVariable("Snaga");
            svSnaga.Functions.Add(fsKran.CreateSugenoFunction("neg_velika", new double[] { 0, 0, -25 }));
            svSnaga.Functions.Add(fsKran.CreateSugenoFunction("neg_srednja", new double[] { 0, 0, -10 }));
            svSnaga.Functions.Add(fsKran.CreateSugenoFunction("nula", new double[] { 0, 0, 0 }));
            svSnaga.Functions.Add(fsKran.CreateSugenoFunction("poz_srednja", new double[] { 0, 0, 10 }));
            svSnaga.Functions.Add(fsKran.CreateSugenoFunction("poz_velika", new double[] { 0, 0, 25 }));
            fsKran.Output.Add(svSnaga);

            try
            {
                SugenoFuzzyRule pravilo1 = fsKran.ParseRule("if (Razdaljina is daleko) and (Ugao is nula) then (Snaga is poz_srednja)");
                SugenoFuzzyRule pravilo2 = fsKran.ParseRule("if (Razdaljina is daleko) and (Ugao is neg_mali) then (Snaga is poz_velika)");
                SugenoFuzzyRule pravilo3 = fsKran.ParseRule("if (Razdaljina is daleko) and (Ugao is neg_velik) then (Snaga is poz_srednja)");
                SugenoFuzzyRule pravilo4 = fsKran.ParseRule("if (Razdaljina is srednje) and (Ugao is neg_mali) then (Snaga is neg_srednja)");
                SugenoFuzzyRule pravilo5 = fsKran.ParseRule("if (Razdaljina is blizu) and (Ugao is poz_mali) then (Snaga is poz_srednja)");
                SugenoFuzzyRule pravilo6 = fsKran.ParseRule("if (Razdaljina is nula) and (Ugao is nula) then (Snaga is nula)");
                SugenoFuzzyRule pravilo7 = fsKran.ParseRule("if (Razdaljina is predaleko) or (Ugao is neg_velik) then (Snaga is neg_velika)");

                fsKran.Rules.Add(pravilo1);
                fsKran.Rules.Add(pravilo2);
                fsKran.Rules.Add(pravilo3);
                fsKran.Rules.Add(pravilo4);
                fsKran.Rules.Add(pravilo5);
                fsKran.Rules.Add(pravilo6);
                fsKran.Rules.Add(pravilo7);
            }
            catch (Exception ex)
            {

            }
        }


        public double racunajIzlaz(double razdaljina, double ugao)
        {
            Dictionary<FuzzyVariable, double> ulazneVrednosti = new Dictionary<FuzzyVariable, double>();
            ulazneVrednosti.Add(fvRazdaljina, razdaljina);
            ulazneVrednosti.Add(fvUgao, ugao);

            Dictionary<SugenoVariable, double> rezultat = fsKran.Calculate(ulazneVrednosti);


            return rezultat[svSnaga];
        }

        private void btnRazunaj_Click(object sender, EventArgs e)
        {
            try
            {
                double rez = racunajIzlaz(Convert.ToDouble(txtRazdaljina.Text), Convert.ToDouble(txtUgao.Text));

                lblRezultat.Text = $"Rezultat je: {rez}";
            }
            catch(Exception ex)
            {
                lblGreska.Text = $"Greska: {ex.Message}";
            }

        }
    }
}
