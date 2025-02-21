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
        Work work = new Work();
        List<Cars> listCars = new List<Cars>();
        public Record(string title)
        {
            InitializeComponent();
            this.Title = title;
            //this.listCars = listCars;
        }


        private async void SaveDb_Click(object sender, RoutedEventArgs e)
        {
            Cars car = new Cars();
            car.Make = Txt_Make.Text;
            car.Model = Txt_Model.Text;
            car.Mileage = Txt_Mileage.Text;
            car.DateOfPurchase = DPick_DateOfPurchase.Text;
            car.IsAvailable = ChBox_IsAvailable.IsChecked.GetValueOrDefault() ? 1 : 0;
            await work.AddCar(car);
            //var selectedOrgId = ((Organization)Org.SelectedItem).Id;
            //Employees employees = new Employees() { OrgId = selectedOrgId };
            //work.AddEmpl(employees);
            //Emp.ItemsSource = await work.LoadEmployees(selectedOrgId);
            //Org.ItemsSource = await work.Working();
            Close();
        }
        private void Model_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Используем регулярное выражение для проверки ввода
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Model_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Блокируем ввод недопустимых клавиш
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
