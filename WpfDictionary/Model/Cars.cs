using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDictionary.Model
{
    [Table("Cars")]
    public class Cars
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        [Column("Make")]
        [AllowNull]
        public  string Make { get; set; }
        [Column("Model")]
        public string? Model { get; set; }
        [Column("Mileage")]
        public string? Mileage { get; set; }
        [Column("DateOfPurchase")]
        public string? DateOfPurchase { get; set; }
        [Column("IsAvailable")]
        public int? IsAvailable { get; set; }
    }
}
