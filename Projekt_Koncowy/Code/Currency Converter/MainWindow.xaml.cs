using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Data;
using System.Text.RegularExpressions;
using System.Net.Http;
using Newtonsoft.Json;

namespace Currency_Converter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Root val = new Root();
        public class Root
        {
            public Rate rates { get; set; }
            public long timestamp;
            public string license;
        }

        public class Rate
        {
            public double INR { get; set; }
            public double JPY { get; set; }
            public double USD { get; set; }
            public double NZD { get; set; }
            public double EUR { get; set; }
            public double CAD { get; set; }
            public double ISK { get; set; }
            public double PHP { get; set; }
            public double DKK { get; set; }
            public double CZK { get; set; }
            public double PLN { get; set; }
        }
        //Podpięcie API 
        private async void GetValue()
        {
            val = await GetData<Root>("https://openexchangerates.org/api/latest.json?app_id=a7b1c7546e6f4b37901ccd7d6adafdf1");
            BindCurrency();
        }

        public static async Task<Root> GetData<T>(string url)
        {
            var myRoot = new Root();
            try
            {
                using (var client = new HttpClient())
                {
                    //Asynchroniczne podpięcie API. Czekaj na odpowiedź albo wywal błąd
                    client.Timeout = TimeSpan.FromMinutes(1);
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var ResponceString = await response.Content.ReadAsStringAsync();
                        var ResponceObject = JsonConvert.DeserializeObject<Root>(ResponceString);
                        return ResponceObject;
                    }
                    return myRoot;
                }
            }
            catch
            {
                return myRoot;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            GetValue();
           
        }

        private void BindCurrency()
            //Wyciągnięcie z API rekordów
        {
            DataTable dtCurrency = new DataTable();
            dtCurrency.Columns.Add("Text");
            dtCurrency.Columns.Add("Value");

            dtCurrency.Rows.Add("--SELECT--", 0);
            dtCurrency.Rows.Add("INR", val.rates.INR);
            dtCurrency.Rows.Add("USD", val.rates.USD);
            dtCurrency.Rows.Add("NZD", val.rates.NZD);
            dtCurrency.Rows.Add("JPY", val.rates.JPY);
            dtCurrency.Rows.Add("EUR", val.rates.EUR);
            dtCurrency.Rows.Add("CAD", val.rates.CAD);
            dtCurrency.Rows.Add("ISK", val.rates.ISK);
            dtCurrency.Rows.Add("PHP", val.rates.PHP);
            dtCurrency.Rows.Add("DKK", val.rates.DKK);
            dtCurrency.Rows.Add("CZK", val.rates.CZK);
            dtCurrency.Rows.Add("PLN", val.rates.PLN);

            cmbFromCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbFromCurrency.DisplayMemberPath = "Text";
            cmbFromCurrency.SelectedValuePath = "Value";
            cmbFromCurrency.SelectedIndex = 0;

            cmbToCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbToCurrency.DisplayMemberPath = "Text";
            cmbToCurrency.SelectedValuePath = "Value";
            cmbToCurrency.SelectedIndex = 0;
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            //Tworzenie zmiennej dla przekonwertowanej waluty
            double ConvertedValue;

            //Sprawdzenie czy wpisana wartość nie jest nullem albo pusta
            if (txtCurrency.Text == null || txtCurrency.Text.Trim() == "")
            {
                //Jeśli tak wyrzuć błąd   
                MessageBox.Show("Please Enter Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                //Jeśli nie - git
                txtCurrency.Focus();
                return;
            }
            //Jeśli waluta nie jest zadeklarowana albo została domyślna 
            else if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0)
            {
                //Wyrzuć błąd
                MessageBox.Show("Please Select Currency From", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                //Jeśli nie - git
                cmbFromCurrency.Focus();
                return;
            }
            //Jeśli waluta nie została wybrana albo jest nullem
            else if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedIndex == 0)
            {
                //Pokaż wiadomość 
                MessageBox.Show("Please Select Currency To", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                //Jeśli nie to git 
                cmbToCurrency.Focus();
                return;
            }
            //Jeśli są takie same
            if (cmbFromCurrency.Text == cmbToCurrency.Text)
            {
                //Wartość pola tekstowego kwoty ustawiona w ConvertedValue.
                //double.parse służy do konwersji typu danych String na Double.
                //Tekst w polu tekstowym ma ciąg znaków, a ConvertedValue to double
                ConvertedValue = double.Parse(txtCurrency.Text);

                //Pokaż w etykiecie przeliczoną walutę i przekonwertowaną nazwę waluty.
                // i ToString("N3") służy do umieszczania 000 po (.)
                lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
            }
            else
            {

                //Calculation for currency converter is From Currency value multiply(*) 
                // with amount textbox value and then the total is divided(/) with To Currency value
                ConvertedValue = (double.Parse(cmbToCurrency.SelectedValue.ToString()) * double.Parse(txtCurrency.Text)) / double.Parse(cmbFromCurrency.SelectedValue.ToString());

                //Show in label converted currency and converted currency name.
                lblCurrency.Content = cmbToCurrency.Text + " " + ConvertedValue.ToString("N3");
            }
        }
        //Walidacja - nie da się wpisać wartości po za tymi od 0-9 
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        //Opcja czyszczenia
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearControls();
        }
        private void ClearControls()
        {
            txtCurrency.Text = string.Empty;
            if (cmbFromCurrency.Items.Count > 0)
                cmbFromCurrency.SelectedIndex = 0;
            if (cmbToCurrency.Items.Count > 0)
                cmbToCurrency.SelectedIndex = 0;
            lblCurrency.Content = "";
            txtCurrency.Focus();
        }
    }
}
