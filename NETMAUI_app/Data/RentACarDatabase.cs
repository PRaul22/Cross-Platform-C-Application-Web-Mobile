using Proiect_Nonu_Stefania_Popa_Raul_.NETMAUI.Models;
using SQLite;

namespace Proiect_Nonu_Stefania_Popa_Raul_.NETMAUI.Data
{
    public class RentCarDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public RentCarDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Masina>().Wait();
            _database.CreateTableAsync<Inchiriere>().Wait();
        }

        // --- CRUD MASINA ---
        public Task<List<Masina>> GetMasiniAsync()
        {
            return _database.Table<Masina>().ToListAsync();
        }

        public Task<int> SaveMasinaAsync(Masina masina)
        {
            if (masina.ID != 0)
                return _database.UpdateAsync(masina);
            else
                return _database.InsertAsync(masina);
        }

        public Task<int> DeleteMasinaAsync(Masina masina)
        {
            return _database.DeleteAsync(masina);
        }

        // --- CRUD INCHIRIERE ---
        public Task<List<Inchiriere>> GetInchirieriAsync()
        {
            return _database.Table<Inchiriere>().ToListAsync();
        }

        // Luăm închirierile pentru o mașină specifică
        public Task<List<Inchiriere>> GetInchirieriByMasinaAsync(int masinaId)
        {
            return _database.Table<Inchiriere>()
                            .Where(i => i.MasinaID == masinaId)
                            .ToListAsync();
        }

        public Task<int> SaveInchiriereAsync(Inchiriere inchiriere)
        {
            if (inchiriere.ID != 0)
                return _database.UpdateAsync(inchiriere);
            else
                return _database.InsertAsync(inchiriere);
        }

        public Task<int> DeleteInchiriereAsync(Inchiriere inchiriere)
        {
            return _database.DeleteAsync(inchiriere);
        }
    }
}