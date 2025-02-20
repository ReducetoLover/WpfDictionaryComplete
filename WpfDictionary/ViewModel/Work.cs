using Microsoft.VisualBasic;
using SQLite;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfDictionary.Model;

namespace WpfDictionary.ViewModel
{
    public class Work
    {
        string db = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DB.db");
        public Work()
        {
            
            database = new SQLiteAsyncConnection(db);
            database.CreateTableAsync<Cars>().Wait();
        }
        public SQLiteAsyncConnection database { get; set; }
        StringBuilder message = new StringBuilder();
        private string LogPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\LogCommandWPF.json";
        public List<Cars> ListCars { get; set; } = new List<Cars>();
        public async Task<List<Cars>> Working()
        {
            ListCars = await LoadCars();
            return ListCars;
        }
        public async Task<List<Cars>> LoadCars()
        {

                List<Cars> test = await database.QueryAsync<Cars>(@"SELECT * FROM Cars WHERE IsAvailable != 0");
           // await database.ExecuteAsync();
            return test;
        }
        //public async Task<List<Employees>> LoadEmployees(int value)
        //{
        //    ListEmloyees = await database.Table<Employees>().Where(x => x.OrgId == value).ToListAsync();
        //    return ListEmloyees;
        //}
        //public List<Employees> LoadEmployees(string value)
        //{
        //    List<Employees> ListChangedEmployees = ListEmloyees.Where(p => p.Surname.ToLower().Contains(value) || p.Name.ToLower().Contains(value) || p.Middlename.ToLower().Contains(value) || p.Position.ToLower().Contains(value)).ToList();
        //    return ListChangedEmployees;
        //}
        public void SaveLogInnerData(StringBuilder Msg)
        {
            string TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                StreamWriter LogFile = File.AppendText(LogPath);
                LogFile.WriteLine("Дата события: " + TimeStamp + Environment.NewLine + Environment.NewLine + Msg);
                LogFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public async void EditCars(Cars row)
        {
            await database.UpdateAsync(row);
            message.Clear();
            message.Append($"ИЗМЕНЕНА ОРГАНИЗАЦИЯ {row.Make}");
            SaveLogInnerData(message);
        }
        //public async void EditEmpl(Employees row)
        //{
        //    await database.UpdateAsync(row);
        //    message.Clear();
        //    message.Append($"ИЗМЕНЁН СОТРУДНИК {row.Surname} {row.Name} {row.Middlename}. Должность {row.Position}");
        //    SaveLogInnerData(message);
        //}
        public Task<int> DelCars(string value)
        {
            //await database.DeleteAsync(value);
            return database.DropTableAsync<Cars>();
           
        }
        //public async void DelEmpl(Employees value)
        //{
        //    await database.DeleteAsync(value);
        //    message.Clear();
        //    message.Append($"УДАЛЁН СОТРУДНИК {value.Surname} {value.Name} {value.Middlename}. Должность {value.Position}");
        //    SaveLogInnerData(message);
        //}
        public async void AddCars(Cars employees)
        {
            await database.InsertAsync(employees);
            message.Clear();
            message.Append($"ДОБАВЛЕН СОТРУДНИК");
            SaveLogInnerData(message);
        }
        //public async void AddOrg()
        //{
        //    if (database != null)
        //    {
        //        Organization organization = new Organization() { };
        //        await database.InsertAsync(organization);
        //        message.Clear();
        //        message.Append($"ДОБАВЛЕНА ОРГАНИЗАЦИЯ {organization.Name}");
        //        SaveLogInnerData(message);

        //    }
        //}
    }
}
