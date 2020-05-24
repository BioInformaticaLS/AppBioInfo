using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xceed.Wpf.Toolkit;

namespace AppBioInfo
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
            
        public static long Prima_differenza(string sensibile, string resistente)
        {
            for (int i = 0; i < Math.Min(sensibile.Length, resistente.Length); i++)
            {
                if (sensibile[i] != resistente[i])
                    return i;
            }

            return -1;
        }

        public static string Parte_Uguale(string sensibile, string resistente)
        {
            string parte_uguale = null;

            int index = 0;
            bool same = true;

            do
            {
                if (sensibile[index] == resistente[index])
                {
                    parte_uguale += sensibile[index];
                    index++;
                }
                else
                {
                    same = false;
                }

            } while (same && index < sensibile.Length && index < resistente.Length);

            return parte_uguale;
        }

        public static int numero_caratteri_differenti(string sensibile, string resistente)
        {
            int index = 0;
            int uguali = 0;
            int differenti = 0;

            do
            {
                if (sensibile[index] == resistente[index])
                {
                    uguali++;
                    index++;
                }
                else
                {
                    differenti++;
                    index++;
                }

            } while (index < sensibile.Length && index < resistente.Length);

            return differenti;
        }

        private void Calcola_Clicked(object sender, EventArgs e)
        {
            try
            {
                string sensibile = EntrySensibile.Text;
                string resistente = EntryResistente.Text;

                //string filesensibile = BioInformatica.LetturaStringa1();
                //string fileresistente = BioInformatica.LetturaStringa2();

                long lunghezzasensibile = 0;
                long lunghezzaresistente = 0;
                long differenza = 0;

                string parte_uguale = "";

                int numerocaratteridifferenti = 0;

                //CALCOLA LUNGHEZZA SENSIBILE
                lunghezzasensibile = sensibile.Length;

                //CALCOLA LUNGHEZZA RESISTENTE
                lunghezzaresistente = resistente.Length;

                //PRIMA DIFFERENZA
                differenza = Prima_differenza(sensibile, resistente);

                //PRIMA PORZIONE DI SEQUENZA IDENTICA
                parte_uguale = Parte_Uguale(sensibile, resistente);

                //NUMERO CARATTERI DIFFERENTI
                numerocaratteridifferenti = numero_caratteri_differenti(sensibile, resistente);

                //STAMPARE
                LblLunghezza1.Text = $"La prima lunghezza è: {lunghezzasensibile}";
                LblLunghezza2.Text = $"La seconda lunghezza è: {lunghezzaresistente}";
                LblDifferenza.Text = $"La prima differenza si trova nella posizione: {differenza}";
                LblParteUguale.Text = "La prima parte uguale é:" + "\n" + parte_uguale;
                LblNumeroCaratteriUguali.Text = $"Il numero dei caratteri differenti è: {numerocaratteridifferenti}";
            }
            catch(Exception)
            {
                
            }
        }
            
        private void Reset_Clicked(object sender, EventArgs e)
        {
            //RESET COMPLETO

            EntrySensibile.Text = null;
            EntryResistente.Text = null;
            LblLunghezza1.Text = null;
            LblLunghezza2.Text = null;
            LblDifferenza.Text = null;
            LblParteUguale.Text = null;
            LblNumeroCaratteriUguali.Text = null;
        }
    }
}
