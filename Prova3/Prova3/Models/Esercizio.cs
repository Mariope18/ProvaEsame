using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prova3.Models
{
    public class Esercizio
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
    }
}
