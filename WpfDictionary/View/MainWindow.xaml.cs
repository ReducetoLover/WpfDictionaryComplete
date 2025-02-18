using SQLite;
using System.Windows;
using System.Windows.Controls;
using WpfDictionary.Model;
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
        private async void UpdateTables(object sender, RoutedEventArgs e)
        {
           // Org.ItemsSource = await work.Working();
            //BitmapImage bmp;
            //foreach (var item in test)
            //{
            //    if (item.Image != null)
            //        using (MemoryStream str = new MemoryStream(item.Image))
            //        {
            //            BitmapImage image2 = new BitmapImage(new Uri(@"C:\icons8-человек-50.png"));
            //            BitmapImage image = new BitmapImage();
            //            image.BeginInit();
            //            image.StreamSource = str;
            //            image.CacheOption = BitmapCacheOption.OnLoad;
            //            image.EndInit();
            //            image.Freeze();
            //           // ListTest.Add(new Employees2 { Surname = "ТЕст", Name = "sdlkfj", Image = image });
            //        }
            //    Date.ItemsSource = ListEmloyees;
        }
        private async void LoadTables(object sender, RoutedEventArgs e)
        {
            Cars.ItemsSource = await work.Working();
        }
        private void DeteleTables(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить все данные?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Emp.ItemsSource = null;
               // Org.ItemsSource = null;
            }
        }

        private void TxtBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = TxtBoxSearch.Text.ToLower();
            //Emp.ItemsSource = work.LoadEmployees(searchText);
        }
        private async void Org_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TxtBoxSearch.Text = string.Empty;
            //if (Org.SelectedIndex >= 0)
            //{
            //    //var selectedOrgId = ((Organization)Org.SelectedItem).Id;
            //    //Emp.ItemsSource = await work.LoadEmployees(selectedOrgId);
            //}
        }



        private void Org_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            //Organization row = (Organization)e.Row.Item;
            //work.EditCars(row);
        }

        private async void BtnDeleteOrg_Click(object sender, RoutedEventArgs e)
        {
            //if (Org.SelectedIndex >= 0)
            //{
            //    //var selectedOrg = (Organization)Org.SelectedItem;
            //    //work.DelCars(selectedOrg);
            //    //Org.ItemsSource = await work.Working();
            //}

        }

        private async void BtnAddEmpl_Click(object sender, RoutedEventArgs e)
        {
            //if (Org.SelectedIndex >= 0)
            //{
            //    //var selectedOrgId = ((Organization)Org.SelectedItem).Id;
            //    //Employees employees = new Employees() { OrgId = selectedOrgId };
            //    //work.AddEmpl(employees);
            //    //Emp.ItemsSource = await work.LoadEmployees(selectedOrgId);
            //    //Org.ItemsSource = await work.Working();
            //}
        }
        private async void BtnAddOrg_Click(object sender, RoutedEventArgs e)
        {
            //work.AddOrg();
            //Org.ItemsSource = await work.Working();
        }


        private async void BtnDeleteEmpl_Click(object sender, RoutedEventArgs e)
        {
            //if (Emp.SelectedIndex >= 0 && Org.SelectedIndex >=0)
            //{
            //    //var selectedEmpl = ((Employees)Emp.SelectedItem);
            //    //var selectedOrg = ((Organization)Org.SelectedItem);
            //    //work.DelEmpl(selectedEmpl);
            //    //Org.ItemsSource = await work.Working();
            //    //Emp.ItemsSource = await work.LoadEmployees(selectedOrg.Id);
            //}
        }
        private void Emp_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            //var value = (Employees)Emp.SelectedItem;
            //Employees row = (Employees)e.Row.Item;
            //work.EditEmpl(row);
        }
    }
}