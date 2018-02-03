using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.DataVisualization.Charting;
namespace Proiect_tp
{
    /// <summary>
    /// Interaction logic for Oras.xaml
    /// </summary>
    /// 
    public partial class Oras : Window
    {
        public string line0 = "";
        public string line1 = "";
        public string line2 = "";
        public string line3 = "";
        public string line4 = "";
        public string line5 = "";
        public string line6 = "";
        public string line7 = "";
        public string line8 = "";
        public string line9 = "";
        public string line10 = "";
        public string line11 = "";
        public string line12 = "";
        public class Orase
        {
            public string Locatie { get; set; }
            public string Tempr { get; set; }
            public string Temps { get; set; }
            public string Ora { get; set; }

            public Orase(string locatie, string tempr, string temps, string ora)
            {
                Locatie = locatie;
                Tempr = tempr;
                Temps = temps;
                Ora = ora;
            }
        }

        public IEnumerable<Orase> ReadCSV(string fileName)
        {
            // We change file extension here to make sure it's a .csv file.
            // TODO: Error checking.
            string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv"));
            line0 = lines[0];
            line1 = lines[1];
            line2 = lines[2];
            line3 = lines[3];
            line4 = lines[4];
            line5 = lines[5];
            line6 = lines[6];
            line7 = lines[7];
            line8 = lines[8];
            line9 = lines[9];
            line10 = lines[10];
            line11 = lines[11];
            line12 = lines[12];
            // lines.Select allows me to project each line as a Person. 
            // This will give me an IEnumerable<Person> back.
            return lines.Select(line =>
            {
                string[] data = line.Split(',');
                // We return a city with the data in order.
                return new Orase(data[0], data[1], data[2], data[3]);
            });

        }

        public Oras()
        {
            InitializeComponent();
            
        }
        public void LoadLineChartData()
        {
            ReadCSV(@"C:\Users\Cataa\Desktop\experiment.csv");
            string[] data = this.line1.Split(',');
            string[] data2 = this.line2.Split(',');
            string[] data3 = this.line3.Split(',');
            string[] data4 = this.line4.Split(',');
            string[] data5 = this.line5.Split(',');
            string[] data6 = this.line6.Split(',');
            string[] data7 = this.line7.Split(',');
            string[] data8 = this.line8.Split(',');
            string[] data9 = this.line9.Split(',');
            string[] data10 = this.line10.Split(',');
            string[] data11 = this.line11.Split(',');
            string[] data12 = this.line12.Split(',');

            //int x = Int32.Parse(data2[3]);
            //textb.Text = data10[3];
            ((LineSeries)Oraschart.Series[0]).ItemsSource =
                new KeyValuePair<string, int>[]{
            new KeyValuePair<string, int>("SM", Int32.Parse(data[3])),
            new KeyValuePair<string, int>("IS", Int32.Parse(data2[3])),
            new KeyValuePair<string, int>("CJ", Int32.Parse(data3[3])),
            new KeyValuePair<string, int>("TG", Int32.Parse(data4[3])),
            new KeyValuePair<string, int>("MC", Int32.Parse(data5[3])),
            new KeyValuePair<string, int>("SB", Int32.Parse(data6[3])),
            new KeyValuePair<string, int>("BV", Int32.Parse(data7[3])),
            new KeyValuePair<string, int>("TM", Int32.Parse(data8[3])),
            new KeyValuePair<string, int>("RV", Int32.Parse(data9[3])),
            new KeyValuePair<string, int>("CV", Int32.Parse(data10[3])),
            new KeyValuePair<string, int>("B", Int32.Parse(data11[3])),
            new KeyValuePair<string, int>("CT", Int32.Parse(data12[3])) };
        }
        void ShowHideDetails(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            TempRM.Visibility = Visibility.Hidden;
            TextbRM.Visibility = Visibility.Hidden;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LoadLineChartData();
        }
    }

}
