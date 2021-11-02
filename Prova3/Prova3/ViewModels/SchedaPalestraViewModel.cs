using MvvmHelpers;
using MvvmHelpers.Commands;
using Prova3.Models;
using Prova3.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prova3.ViewModels
{
    public class SchedaPalestraViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Esercizio> Esercizio { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Esercizio> RemoveCommand { get; }



        public SchedaPalestraViewModel()
        {
            Esercizio = new ObservableRangeCollection<Esercizio>();

            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Esercizio>(Remove);
        }

        async Task Add()
        {

            var name = await App.Current.MainPage.DisplayActionSheet("Name of Coffee", "Cancel", "Delete", "OK");
            var group = await App.Current.MainPage.DisplayActionSheet("Name of Group", "Cancel", "Delete", "OK");
            await Prova3Service.AddEsercizio(name, group);
            await Refresh();

        }

        async Task Add2()
        {
    
            var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Nome Esercizio", "Ok", "Cancella");
            var group = await App.Current.MainPage.DisplayPromptAsync("Group", "Nome Gruppo", "Ok", "Cancella");
            await Prova3Service.AddEsercizio(name, group);
            await Refresh();
            
        }



        //async Task Add2()
        //{
        //    var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Nome Esercizio", "Ok", "Cancella");
        //    var group = await App.Current.MainPage.DisplayPromptAsync("Group", "Nome Gruppo", "Ok", "Cancella");
        //    if(name != string.Empty && group != string.Empty)
        //    {
        //        await Prova3Service.SaveEsercizio(new Esercizio
        //        {
        //            Name = name,
        //            Group = group
        //        });
        //    }
        //    else
        //    {
        //        return;
        //    }

        //    await Refresh();
        //}

        async Task Remove(Esercizio esercizio)
        {
            await Prova3Service.RemoveEsercizio(esercizio.Id);
            await Refresh();
        }

        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            Esercizio.Clear();
            var esercizi = await Prova3Service.GetEsercizio();
            Esercizio.AddRange(esercizi);
            IsBusy = false;
        }
    }
}
