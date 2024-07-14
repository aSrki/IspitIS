using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AI.Fuzzy.Library;

namespace FuzzyLogic
{
    public partial class Form1 : Form
    {

        MamdaniFuzzySystem fsBudzet;
        FuzzyVariable fvTrziste;
        FuzzyVariable fvKonkurencija;
        FuzzyVariable fvBudzet;

        SugenoFuzzySystem fsBaksis;
        FuzzyVariable fvUsluga;
        FuzzyVariable fvHrana;
        SugenoVariable svBaksis;


        public Form1()
        {
            InitializeComponent();

            definisiMamdaniSistem();
            double budzet1 = racunajMamdani(110000, 9);
            double budzet2 = racunajMamdani(45000, 11);

            definisiSugenoSistem();
            double baksis1 = racunajSugeno(7, 4);

        }

        public void definisiMamdaniSistem()
        {
            fsBudzet = new MamdaniFuzzySystem();

            fvTrziste = new FuzzyVariable("trziste", 0, 200000);
            fvTrziste.Terms.Add(new FuzzyTerm("malo", new TrapezoidMembershipFunction(0, 0, 10000, 50000)));
            fvTrziste.Terms.Add(new FuzzyTerm("srednje", new TrapezoidMembershipFunction(30000, 60000, 100000, 150000)));
            fvTrziste.Terms.Add(new FuzzyTerm("veliko", new TrapezoidMembershipFunction(100000, 150000, 200000, 200000)));
            fsBudzet.Input.Add(fvTrziste);

            fvKonkurencija = new FuzzyVariable("konkurencija", 0, 20);
            fvKonkurencija.Terms.Add(new FuzzyTerm("niska", new TrapezoidMembershipFunction(0, 0, 5, 10)));
            fvKonkurencija.Terms.Add(new FuzzyTerm("visoka", new TrapezoidMembershipFunction(5, 12, 20, 20)));
            fsBudzet.Input.Add(fvKonkurencija);

            fvBudzet = new FuzzyVariable("budzet", 0, 400000);
            fvBudzet.Terms.Add(new FuzzyTerm("mali", new TrapezoidMembershipFunction(0, 0, 20000, 50000)));
            fvBudzet.Terms.Add(new FuzzyTerm("srednji", new TrapezoidMembershipFunction(20000, 50000, 100000, 300000)));
            fvBudzet.Terms.Add(new FuzzyTerm("veliki", new TrapezoidMembershipFunction(150000, 300000, 400000, 400000)));
            fsBudzet.Output.Add(fvBudzet);

            try
            {
                MamdaniFuzzyRule pravilo1 = fsBudzet.ParseRule("if (trziste is malo) and (konkurencija is niska) then (budzet is mali)");
                MamdaniFuzzyRule pravilo2 = fsBudzet.ParseRule("if (trziste is srednje) or (konkurencija is visoka) then (budzet is srednji)");
                MamdaniFuzzyRule pravilo3 = fsBudzet.ParseRule("if (trziste is veliko) then (budzet is veliki)");

                fsBudzet.Rules.Add(pravilo1);
                fsBudzet.Rules.Add(pravilo2);
                fsBudzet.Rules.Add(pravilo3);

            }
            catch(Exception ex)
            {

            }
        }

        public double racunajMamdani(double trziste, double konkurencija)
        {
            Dictionary<FuzzyVariable, double> ulazneVrednosti = new Dictionary<FuzzyVariable, double>();
            ulazneVrednosti.Add(fvTrziste, trziste);
            ulazneVrednosti.Add(fvKonkurencija, konkurencija);

            Dictionary<FuzzyVariable, double> rezultat = fsBudzet.Calculate(ulazneVrednosti);

            return rezultat[fvBudzet];
        }

        public void definisiSugenoSistem()
        {
            fsBaksis = new SugenoFuzzySystem();

            fvUsluga = new FuzzyVariable("usluga", 0, 10);
            fvUsluga.Terms.Add(new FuzzyTerm("losa", new TrapezoidMembershipFunction(0, 0, 1, 4)));
            fvUsluga.Terms.Add(new FuzzyTerm("dobra", new TriangularMembershipFunction(1, 5, 9)));
            fvUsluga.Terms.Add(new FuzzyTerm("odlicna", new TrapezoidMembershipFunction(6, 9, 10, 10)));
            fsBaksis.Input.Add(fvUsluga);

            fvHrana = new FuzzyVariable("hrana", 0, 10);
            fvHrana.Terms.Add(new FuzzyTerm("ocajna", new TrapezoidMembershipFunction(0, 0, 2, 9)));
            fvHrana.Terms.Add(new FuzzyTerm("ukusna", new TrapezoidMembershipFunction(1, 8, 10, 10)));
            fsBaksis.Input.Add(fvHrana);

            svBaksis = new SugenoVariable("baksis");
            svBaksis.Functions.Add(fsBaksis.CreateSugenoFunction("mali", new double[] { 0, 0, 1 }));
            svBaksis.Functions.Add(fsBaksis.CreateSugenoFunction("prosecan", new double[] { 0, 0, 5 }));
            svBaksis.Functions.Add(fsBaksis.CreateSugenoFunction("velik", new double[] { 0, 0, 9 }));
            fsBaksis.Output.Add(svBaksis);


            try
            {
                SugenoFuzzyRule pravilo1 = fsBaksis.ParseRule("if (usluga is losa) or (hrana is ocajna) then (baksis is mali)");
                SugenoFuzzyRule pravilo2 = fsBaksis.ParseRule("if (usluga is dobra) then (baksis is prosecan)");
                SugenoFuzzyRule pravilo3 = fsBaksis.ParseRule("if (usluga is odlicna) or (hrana is ukusna) then (baksis is velik)");

                fsBaksis.Rules.Add(pravilo1);
                fsBaksis.Rules.Add(pravilo2);
                fsBaksis.Rules.Add(pravilo3);

            }
            catch(Exception ex)
            {

            }
        }

        public double racunajSugeno(double usluga, double hrana)
        {
            Dictionary<FuzzyVariable, double> ulazneVrednosti = new Dictionary<FuzzyVariable, double>();
            ulazneVrednosti.Add(fvUsluga, usluga);
            ulazneVrednosti.Add(fvHrana, hrana);

            Dictionary<SugenoVariable, double> rezultat = fsBaksis.Calculate(ulazneVrednosti);

            return rezultat[svBaksis];
        }
        
    }
}
