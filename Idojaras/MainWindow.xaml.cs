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
        public MainWindow()
        {
            InitializeComponent();
            List<Varos> varosok = new();
            varosok.Add(new("Miskolc", 15, 45, 39));
            varosok.Add(new("Budapest", 20, 42, 32));
            varosok.Add(new("Székesfehérvár", 12, 36, 37));
            foreach (var v in varosok) ltbVarosok.Items.Add(v._nev);
        }

        private void button_Click(object sender, EventArgs e, List<Varos> varosok)
        {
            Button varos = (Button)sender;
            string nev = varos.Content.ToString();
            foreach (var v in varosok)
            {
                if (v._nev == nev)
                {
                    Adatok.Text = v._paratartalom + "\n" + v._homerseklet + "\n" + v._szelsebesseg;
                }
            }
        }
    }
}