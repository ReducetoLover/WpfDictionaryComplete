using System.Windows;
using System.Windows.Controls;
using WpfDictionary.Model;
using WpfDictionary.View;
using WpfDictionary.ViewModel;

namespace WpfDictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Work work = new Work();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnLoadTables_Click(object sender, RoutedEventArgs e)
        {
            Cars.ItemsSource = await work.Working();
        }

        private async void TxtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = TxtBoxSearch.Text.ToLower();
            Cars.ItemsSource = await work.Working(searchText);
        }
        private void BtnAddCar_Click(object sender, RoutedEventArgs e)
        {
            Record recordWindow = new Record("Добавление автомобиля");
            recordWindow.OnButtonClicked += UpdateTable;
            recordWindow.Show();
        }

        private async void UpdateTable()
        {
            Cars.ItemsSource = await work.Working();
        }

        private void BtnEditCar_Click(object sender, RoutedEventArgs e)
        {
            if (Cars.SelectedIndex >= 0)
            {
                Cars selectedCar = (Cars)Cars.SelectedItem;
                Record recordWindow = new Record("Редактирование автомобиля", selectedCar);
                recordWindow.OnButtonClicked += UpdateTable;
                recordWindow.Show();
            }
        }
        private async void BtnDeleteCar_Click(object sender, RoutedEventArgs e)
        {
            if (Cars.SelectedIndex >= 0)
            {
                var selectedOrg = (Cars)Cars.SelectedItem;
                await work.DelCar(selectedOrg);
                Cars.ItemsSource = await work.Working();
            }
        }
        private async void BtnDeleteTables_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить все данные?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                await work.DelCars("Cars");
                Cars.ItemsSource = await work.Working();
            }
        }
    }
}