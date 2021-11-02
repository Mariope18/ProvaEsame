using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prova3.Models
{
    class Scheda
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
