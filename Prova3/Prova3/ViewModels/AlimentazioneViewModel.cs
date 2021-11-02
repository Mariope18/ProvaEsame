using MvvmHelpers;
using MvvmHelpers.Commands;
using Prova3.Models;
using Prova3.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Prova3.ViewModels
{
    class AlimentazioneViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Scheda> Schede { get; set; }
        public AsyncCommand AddScheda { get; }
        public AsyncCommand RefreshCommand { get; }

        public AlimentazioneViewModel()
        {
            Schede = new ObservableRangeCollection<Scheda>();

            AddScheda = new AsyncCommand(AddS);
            RefreshCommand = new AsyncCommand(Refresh);
        }

        async Task AddS()
        {
            var nomeScheda = await App.Current.MainPage.DisplayPromptAsync("Nome Scheda","");
            
            await SchedaService.AddSchedaDb(nomeScheda);
        }
        
        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            Schede.Clear();
            var scheda = await SchedaService.GetScheda();
            Schede.AddRange(scheda);
            IsBusy = false;
        }
    }

    
}