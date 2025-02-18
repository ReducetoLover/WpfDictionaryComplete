using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDictionary.Model
{
    public class Cars
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Mileage { get; set; }
        public string? DateOfPurchase { get; set; }
        public int IsAvailable { get; set; }
    }
}
