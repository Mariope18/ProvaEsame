using Prova3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Prova3.Services
{
    class SchedaService
    {
        static SQLiteAsyncConnection dbS;
        public static async Task Init()
        {
            if (dbS != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            dbS = new SQLiteAsyncConnection(databasePath);

            await dbS.CreateTableAsync<Scheda>();
        }
        public static async Task AddSchedaDb(string nomeScheda)
        {
            await Init();

            var scheda = new Scheda
            {
                Name = nomeScheda,
            };
            var id = await dbS.InsertAsync(scheda);
        }

        public static async Task<IEnumerable<Scheda>> GetScheda()
        {
            await Init();

            var scheda = await dbS.Table<Scheda>().ToListAsync();
            return scheda;
        }
    }

}
