using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace atletikaVB_WPF
{
    public partial class MainWindow : Window
    {
        List<Ermek> eredmenyek = new List<Ermek>();

        public MainWindow()
        {
            InitializeComponent();

            StreamReader sr = new StreamReader("atletikaVB2017.csv");

            while (!sr.EndOfStream)
            {
                eredmenyek.Add(new Ermek(sr.ReadLine()));
            }

            sr.Close();

            tabla.ItemsSource = eredmenyek;
        }
        #region Beolvasés
        private void Beolvasas_Click(object sender, RoutedEventArgs e)
        {
            eredmenyek.Clear();

            StreamReader sr = new StreamReader("atletikaVB2017.csv");

            string fejlec = sr.ReadLine();

            while (!sr.EndOfStream)
            {
                eredmenyek.Add(new Ermek(sr.ReadLine()));
            }

            sr.Close();

            tabla.Items.Refresh();

            MessageBox.Show("Sikeres beolvasás!");
        }
        #endregion
        #region Hozzadas
        private void Hozzaadas_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtHelyezes.Text, out int helyezes))
            {
                MessageBox.Show("A helyezésnek számnak kell lennie");
                return;
            }
            string verseny = txtVerseny.Text;
            string nem = txtNem.Text;
            string orszag = txtOrszag.Text;
            string nev = txtNev.Text;
            string eredmeny = txtEredmeny.Text;
            string rekord = txtRekord.Text;

            eredmenyek.Add(new Ermek(verseny, nem, orszag, nev, eredmeny, rekord, helyezes));

            tabla.Items.Refresh();

            MessageBox.Show("Sikeres bevitel!");
        }
        #endregion
        #region Torles
        private void Torles_Click(object sender, RoutedEventArgs e)
        {
            int index = tabla.SelectedIndex;

            if (index >= 0)
            {
                eredmenyek.RemoveAt(index);

                tabla.Items.Refresh();

                MessageBox.Show("Sikeres törlés!");
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem!");
            }
        }
        #endregion
        #region Mentes
        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("atletikaVB2017.csv");

            sw.WriteLine("Verseny;Nem;Orszag;Nev;Eredmeny;Rekord;Helyezes");

            foreach (var item in eredmenyek)
            {
                sw.WriteLine(item.ToString());
            }

            sw.Close();

            MessageBox.Show("Sikeres mentés!");
        }
        #endregion
        #region Modositas
        private void Modositas_Click(object sender, RoutedEventArgs e)
        {
            int index = tabla.SelectedIndex;

            if (index >= 0)
            {
                if (!int.TryParse(txtHelyezes.Text, out int helyezes))
                {
                    MessageBox.Show("A helyezésnek számnak kell lennie");
                    return;
                }

                eredmenyek[index].Verseny = txtVerseny.Text;
                eredmenyek[index].Nem = txtNem.Text;
                eredmenyek[index].Orszag = txtOrszag.Text;
                eredmenyek[index].Nev = txtNev.Text;
                eredmenyek[index].Eredmeny = txtEredmeny.Text;
                eredmenyek[index].Rekord = txtRekord.Text;
                eredmenyek[index].Helyezes = helyezes;

                tabla.Items.Refresh();

                MessageBox.Show("Sikeres módosítás!");
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem!");
            }
            #endregion
        }
    }
}