using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Idojaras
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Varos> varosok = new();
        public List<string> adat { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            P.Visibility = Visibility.Hidden;
            H.Visibility = Visibility.Hidden;
            SZ.Visibility = Visibility.Hidden;
            PL.Visibility = Visibility.Hidden;
            HL.Visibility = Visibility.Hidden;
            SZL.Visibility = Visibility.Hidden;
            telepules.Visibility = Visibility.Hidden;
            Done.Visibility = Visibility.Hidden;
            varosok.Add(new("Miskolc", 15, 45, 39));
            varosok.Add(new("Budapest", 20, 42, 32));
            varosok.Add(new("Székesfehérvár", 12, 36, 37));
            Feltolt(varosok);
        }   

        private void Varosok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Varosok.SelectedItem != null)
            {
                ListBoxItem varos = (ListBoxItem)Varosok.SelectedItem;
                bool kellAdat = true;
                foreach (var v in varosok)
                {
                    if (v._nev == varos.Content.ToString())
                    {
                        Adatok.Text = $"Páratartalom: {v._homerseklet.ToString()} g/m3 \n Hőméréklet: {v._paratartalom.ToString()} °C\n Szélsebesség: {v._szelsebesseg.ToString()} km/h";
                        kellAdat = false;
                    }
                }
                if (kellAdat)
                {
                    P.Visibility = Visibility.Visible;
                    H.Visibility = Visibility.Visible;
                    SZ.Visibility = Visibility.Visible;
                    PL.Visibility = Visibility.Visible;
                    HL.Visibility = Visibility.Visible;
                    SZL.Visibility = Visibility.Visible;
                    telepules.Visibility = Visibility.Visible;
                    Done.Visibility = Visibility.Visible;
                    telepules.Text = varos.Content.ToString();
                }
            }
        }

        private void Hozzaad(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = new();
            item.Content = Telepules.Text;
            Varosok.Items.Add(item);
            Telepules.Text = string.Empty;
        }

        private void Feltolt(List<Varos> varosok)
        {
            Varosok.Items.Clear();
            foreach (var v in varosok)
            {
                ListBoxItem varos = new();
                varos.Content = v._nev;
                Varosok.Items.Add(varos);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            varosok.Add(new(telepules.Text, int.Parse(H.Text), int.Parse(P.Text), int.Parse(SZ.Text)));
            P.Visibility = Visibility.Hidden;
            H.Visibility = Visibility.Hidden;
            SZ.Visibility = Visibility.Hidden;
            PL.Visibility = Visibility.Hidden;
            HL.Visibility = Visibility.Hidden;
            SZL.Visibility = Visibility.Hidden;
            telepules.Visibility = Visibility.Hidden;
            Done.Visibility = Visibility.Hidden;
            Feltolt(varosok);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Adatok.Text != string.Empty) Adatok.Text = string.Empty;
            ListBoxItem item = (ListBoxItem)Varosok.SelectedItem;
            int i = -1;
            foreach (var v in varosok)
            {
                if (v._nev == item.Content.ToString())
                {
                    i = varosok.IndexOf(v);
                }
            }
            if(i  > -1 )varosok.RemoveAt(i);
            Feltolt(varosok);
        }
    }
}