using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using IronPython.Hosting;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Threading;
using System.ComponentModel;
namespace Proiect_tp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int ok = 1;
        private readonly BackgroundWorker worker = new BackgroundWorker();
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // run all background tasks here
            var py = Python.CreateEngine();
            if (ok == 1)
            {
                py.ExecuteFile("script.py");
                MessageBox.Show("Datele din trecut au fost scrise in fisier");
            }
            if (ok == 2)
            {
                py.ExecuteFile("script2.py");
                MessageBox.Show("Datele live au fost scrise in fisier");
            }
            if (ok == 3)
            {
                py.ExecuteFile("script3.py");
                MessageBox.Show("Temperatura pentru Ramnicu Valcea a fost calculata");
            }
        }

        private void worker_RunWorkerCompleted(object sender,
                                               RunWorkerCompletedEventArgs e)
        {
            //update ui once worker complete his work
            
        }
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
            // lines.Select allows me to project each line as a Person. 
            // This will give me an IEnumerable<Person> back.
            return lines.Select(line =>
            {
                string[] data = line.Split(',');
                // We return a person with the data in order.
                return new Orase(data[0], data[1], data[2], data[3]);
            });

        }

        public class DataObject
        {
            public string A { get; set; }
            public string B { get; set; }
            public string C { get; set; }
            public string D { get; set; }
            public string E { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }
        
        Oras oras = new Oras();
        Window1 w1 = new Window1();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Ramnicu Valcea
            oras.Show();
            oras.img.Source = new BitmapImage(new Uri("images/RamnicuValcea.jpg", UriKind.Relative));
            oras.Localitate.Text = "Ramnicu Valcea";
            oras.dataGrid1.ItemsSource = ReadCSV(@"C:\Users\Cataa\Desktop\experiment.csv");
            var list = new List<DataObject>(); //ObservableCollection<DataObject>();
            string[] data2 = oras.line9.Split(',');
            list.Add(new DataObject() { A = data2[0], B = data2[1], C = data2[2], D = data2[3],E=data2[4] });
            oras.dataGrid1.ItemsSource = list;
            string [] linii=File.ReadAllLines(@"C: \Users\Cataa\Desktop\Testul.csv",Encoding.UTF8);
            oras.TextbRM.Text = linii[0];
            oras.TextbRM.Visibility = Visibility.Visible;
            oras.TempRM.Visibility = Visibility.Visible;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Brasov;
            oras.Show();
            oras.img.Source = new BitmapImage(new Uri("images/Brasov.jpg", UriKind.Relative));
            oras.Localitate.Text = "Brasov";
            oras.dataGrid1.ItemsSource = ReadCSV(@"C:\Users\Cataa\Desktop\experiment.csv");
            var list = new List<DataObject>(); //ObservableCollection<DataObject>();
            string[] data2 = oras.line7.Split(',');
            list.Add(new DataObject() { A = data2[0], B = data2[1], C = data2[2], D = data2[3], E=data2[4] });
            oras.dataGrid1.ItemsSource = list;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Miercurea Ciuc
            oras.Show();
            oras.img.Source = new BitmapImage(new Uri("images/MiercureaCiuc.jpg", UriKind.Relative));
            oras.Localitate.Text = "Miercurea Ciuc";
            oras.dataGrid1.ItemsSource = ReadCSV(@"C:\Users\Cataa\Desktop\experiment.csv");
            var list = new List<DataObject>(); //ObservableCollection<DataObject>();
            string[] data2 = oras.line5.Split(',');
            list.Add(new DataObject() { A = data2[0], B = data2[1], C = data2[2], D = data2[3], E = data2[4] });
            oras.dataGrid1.ItemsSource = list;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Sibiu
            oras.Show();
            oras.img.Source = new BitmapImage(new Uri("images/Sibiu.jpg", UriKind.Relative));
            oras.Localitate.Text = "Sibiu";
            oras.dataGrid1.ItemsSource = ReadCSV(@"C:\Users\Cataa\Desktop\experiment.csv");
            var list = new List<DataObject>(); //ObservableCollection<DataObject>();
            string[] data2 = oras.line6.Split(',');
            list.Add(new DataObject() { A = data2[0], B = data2[1], C = data2[2], D = data2[3], E = data2[4] });
            oras.dataGrid1.ItemsSource = list;
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            // Timisoara
            oras.Show();
            oras.img.Source = new BitmapImage(new Uri("images/Timisoara.jpg", UriKind.Relative));
            oras.Localitate.Text = "Timisoara";
            oras.dataGrid1.ItemsSource = ReadCSV(@"C:\Users\Cataa\Desktop\experiment.csv");
            var list = new List<DataObject>(); //ObservableCollection<DataObject>();
            string[] data2 = oras.line8.Split(',');
            list.Add(new DataObject() { A = data2[0], B = data2[1], C = data2[2], D = data2[3], E = data2[4] });
            oras.dataGrid1.ItemsSource = list;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            // Constanta
            oras.Show();
            oras.img.Source = new BitmapImage(new Uri("images/Constanta.jpg", UriKind.Relative));
            oras.Localitate.Text = "Constanta";
            oras.dataGrid1.ItemsSource = ReadCSV(@"C:\Users\Cataa\Desktop\experiment.csv");
            var list = new List<DataObject>(); //ObservableCollection<DataObject>();
            string[] data2 = oras.line12.Split(',');
            list.Add(new DataObject() { A = data2[0], B = data2[1], C = data2[2], D = data2[3], E = data2[4] });
            oras.dataGrid1.ItemsSource = list;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
         
            //Cluj
            oras.Show();
            oras.img.Source = new BitmapImage(new Uri("images/Cluj.jpg", UriKind.Relative));
            oras.Localitate.Text = "Cluj";
            oras.dataGrid1.ItemsSource = ReadCSV(@"C:\Users\Cataa\Desktop\experiment.csv");
            var list = new List<DataObject>(); //ObservableCollection<DataObject>();
            string[] data2 = oras.line3.Split(',');
            list.Add(new DataObject() { A = data2[0], B = data2[1], C = data2[2], D = data2[3], E = data2[4] });
            oras.dataGrid1.ItemsSource = list;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            // Satu Mare
            oras.Show();
            oras.img.Source = new BitmapImage(new Uri("images/SatuMare.jpg", UriKind.Relative));
            oras.Localitate.Text = "Satu Mare";
            oras.dataGrid1.ItemsSource = ReadCSV(@"C:\Users\Cataa\Desktop\experiment.csv");
            var list = new List<DataObject>(); //ObservableCollection<DataObject>();
            string[] data2 = oras.line1.Split(',');
            list.Add(new DataObject() { A = data2[0], B = data2[1], C = data2[2], D = data2[3], E = data2[4] });
            oras.dataGrid1.ItemsSource = list;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            //Bucuresti
            oras.Show();
            oras.img.Source = new BitmapImage(new Uri("images/Bucuresti.jpg", UriKind.Relative));
            oras.Localitate.Text = "Bucuresti";
            oras.dataGrid1.ItemsSource = ReadCSV(@"C:\Users\Cataa\Desktop\experiment.csv");
            var list = new List<DataObject>(); //ObservableCollection<DataObject>();
            string[] data2 = oras.line11.Split(',');
            list.Add(new DataObject() { A = data2[0], B = data2[1], C = data2[2], D = data2[3], E=data2[4] });
            oras.dataGrid1.ItemsSource = list;
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            // Craiova
            oras.Show();
            oras.img.Source = new BitmapImage(new Uri("images/Craiova.jpg", UriKind.Relative));
            oras.Localitate.Text = "Craiova";
            oras.dataGrid1.ItemsSource = ReadCSV(@"C:\Users\Cataa\Desktop\experiment.csv");
            var list = new List<DataObject>(); //ObservableCollection<DataObject>();
            string[] data2 = oras.line10.Split(',');
            list.Add(new DataObject() { A = data2[0], B = data2[1], C = data2[2], D = data2[3], E = data2[4] });
            oras.dataGrid1.ItemsSource = list;
        }
      
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            //Iasi
            oras.Show();
            oras.img.Source = new BitmapImage(new Uri("images/Iasi.jpg", UriKind.Relative));
            oras.Localitate.Text = "Iasi";
            oras.dataGrid1.ItemsSource = ReadCSV(@"C:\Users\Cataa\Desktop\experiment.csv");
            var list = new List<DataObject>(); //ObservableCollection<DataObject>();
            string[] data2 = oras.line2.Split(',');
            list.Add(new DataObject() { A = data2[0], B = data2[1], C = data2[2], D = data2[3], E = data2[4] });
            oras.dataGrid1.ItemsSource = list;
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            //Targu Mures
            oras.Show();
            oras.img.Source = new BitmapImage(new Uri("images/TarguMures.jpg", UriKind.Relative));
            oras.Localitate.Text = "Targu Mures";
            oras.dataGrid1.ItemsSource = ReadCSV(@"C:\Users\Cataa\Desktop\experiment.csv");
            var list = new List<DataObject>(); //ObservableCollection<DataObject>();
            string[] data2 = oras.line4.Split(',');
            list.Add(new DataObject() { A = data2[0], B = data2[1], C = data2[2], D = data2[3], E = data2[4] });
            oras.dataGrid1.ItemsSource = list;
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            string s = Cautare.Text;
            if (s == "Brasov")
                Button_Click_1(sender, e);
            else
                if (s == "Miercurea Ciuc")
                Button_Click_2(sender, e);
            else
                if (s == "Sibiu")
                Button_Click_3(sender, e);
            else
                if (s == "Timisoara")
                Button_Click_4(sender, e);
            else
                if (s == "Constanta")
                Button_Click_5(sender, e);
            else
                if (s == "Cluj")
                Button_Click_7(sender, e);
            else
                if (s == "Satu Mare")
                Button_Click_8(sender, e);
            else
                if (s == "Bucuresti")
                Button_Click_9(sender, e);
            else
                if (s == "Craiova")
                Button_Click_10(sender, e);
            else
                if (s == "Iasi")
                Button_Click_11(sender, e);
            else
                if (s == "Targu Mures")
                Button_Click_12(sender, e);
            else
                Cautare.Text = "Cautare invalida";
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            oras.Show();
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            //w1.Show();
            oras.LoadLineChartData();
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            ok = 1;
            // var py = Python.CreateEngine();
            // py.ExecuteFile("script.py");
            //MessageBox.Show("Datele din trecut au fost scrise in fisier");
            worker.RunWorkerAsync();
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            ok = 2;
            worker.RunWorkerAsync();

        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            ok = 3;
            //var py = Python.CreateEngine();
            //py.ExecuteFile("script3.py");
            worker.RunWorkerAsync();
        }

    }
}
