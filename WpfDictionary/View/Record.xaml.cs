using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfDictionary.Model;
using WpfDictionary.ViewModel;

namespace WpfDictionary.View
{
    /// <summary>
    /// Логика взаимодействия для Record.xaml
    /// </summary>
    public partial class Record : Window
    {
        public bool IsEditing { get; private set; }
        private Cars currentCar = new Cars();
        public event Action OnButtonClicked = delegate { };
        Work work = new Work();
        public Record(string title)
        {
            InitializeComponent();
            this.Title = title;
        }
        public Record(string title, Cars car) : this(title)
        {
            IsEditing = true;
            currentCar = car;
            LoadCarData(car);
        }

        private void LoadCarData(Cars car)
        {
            Txt_Make.Text = car.Make;
            Txt_Model.Text = car.Model;
            Txt_Mileage.Text = car.Mileage;
            DPick_DateOfPurchase.Text = car.DateOfPurchase;
            ChBox_IsAvailable.IsChecked = car.IsAvailable == 1;
        }
        private async void SaveDb_Click(object sender, RoutedEventArgs e)
        {
            if (Txt_Make.Text.Length != 0 && Txt_Model.Text.Length != 0 && Txt_Mileage.Text.Length != 0 && DPick_DateOfPurchase.Text.Length != 0)
            {
                Cars car = new Cars();
                car.Make = Txt_Make.Text;
                car.Model = Txt_Model.Text;
                car.Mileage = Txt_Mileage.Text;
                car.DateOfPurchase = DPick_DateOfPurchase.Text;
                car.IsAvailable = ChBox_IsAvailable.IsChecked.GetValueOrDefault() ? 1 : 0;
                if (IsEditing)
                {
                    car.Id = currentCar.Id;
                    await work.EditCars(car);
                }
                else
                {
                    await work.AddCar(car);
                }
                OnButtonClicked();
                Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
        private void Mileage_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Mileage_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
