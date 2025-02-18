using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfDictionary.Model
{
    public class Employees
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int OrgId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Middlename { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public byte[]? Image { get; set; }
    }
}
