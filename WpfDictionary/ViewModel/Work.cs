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
        }
        public SQLiteAsyncConnection database { get; set; }
        public List<Cars> ListCars { get; set; } = new List<Cars>();
        public async Task<List<Cars>> Working()
        {
            ListCars = await LoadCars();
            return ListCars;
        }
        public async Task<List<Cars>> Working(string text)
        {
            ListCars = await LoadCars();
            return ListCars.Where(x=> x.Make.ToLower().Contains(text.ToLower())).ToList();
        }
        private async Task<List<Cars>> LoadCars()
        {
           List<Cars> test = await database.QueryAsync<Cars>(@"SELECT * FROM Cars WHERE IsAvailable != 0");
            return test;
        }
        public async Task<bool> EditCars(Cars row)
        {
            await database.UpdateAsync(row);
            await LoadCars();
            return true;
        }
        public async Task<int> DelCars(string value)
        {
            return await database.ExecuteAsync(@"DELETE FROM Cars");
        }
        public async Task<bool> DelCar(Cars car)
        {
            await database.DeleteAsync(car);
            return true;

        }
        public async Task<bool> AddCar(Cars car)
        {
            await database.InsertAsync(car);
            await LoadCars();
            return true;
        }
    }
}
