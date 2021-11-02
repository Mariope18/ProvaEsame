using Prova3.Models;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Prova3.Services
{
    public static class Prova3Service
    {
        static SQLiteAsyncConnection db;
        public static async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Esercizio>();
        }
        public static async Task AddEsercizio(string name, string group)
        {
            await Init();
            var esercizio = new Esercizio
            {
                Name = name,
                Group = group,
            };

            var id = await db.InsertAsync(esercizio);
        }
        public static async Task RemoveEsercizio(int id)
        {
            await Init();

            await db.DeleteAsync<Esercizio>(id);
        }
        public static async Task<IEnumerable<Esercizio>> GetEsercizio()
        {
            await Init();

            var esercizio = await db.Table<Esercizio>().ToListAsync();
            return esercizio;
        }

        public static Task<Esercizio> GetEsercizioAsync()
        {
            return db.Table<Esercizio>().FirstOrDefaultAsync();
        }

        

        //public static Task<int> SaveEsercizio(Esercizio esercizio)
        //{
        //    return db.InsertAsync(esercizio);
        //}

        //public static Task<Esercizio> GetEsercizioAsync()
        //{
        //    return db.Table<Esercizio>().ToListAsync();
        //} 
    }
}
