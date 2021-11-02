using MvvmHelpers;
using Prova3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Prova3.ViewModels
{
    public class AllenamentoViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Esercizio> Esercizio { get; set; }
        public ObservableRangeCollection<Grouping<string, Esercizio>> GruppiEsercizio { get; set; }
        
        public AllenamentoViewModel()
        {
            Esercizio = new ObservableRangeCollection<Esercizio>();
            GruppiEsercizio = new ObservableRangeCollection<Grouping<string, Esercizio>>();

            Esercizio.Add(new Esercizio { Name = "Squat", Group = "Gambe" });
            Esercizio.Add(new Esercizio { Name = "Stacco", Group = "Gambe" });
            Esercizio.Add(new Esercizio { Name = "Stacco rumeno", Group = "Gambe" });
            Esercizio.Add(new Esercizio { Name = "Affondi", Group = "Gambe" });
            Esercizio.Add(new Esercizio { Name = "Squat Bulgaro", Group = "Gambe" });
            Esercizio.Add(new Esercizio { Name = "Squat pistol", Group = "Gambe" });
            Esercizio.Add(new Esercizio { Name = "Leg extension", Group = "Gambe" });
            Esercizio.Add(new Esercizio { Name = "Leg curl", Group = "Gambe" });
            Esercizio.Add(new Esercizio { Name = "Pressa", Group = "Gambe" });





            GruppiEsercizio.Add(new Grouping<string, Esercizio>("Gambe", Esercizio));
            GruppiEsercizio.Add(new Grouping<string, Esercizio>("Gambe", Esercizio));



        }
    }
}
