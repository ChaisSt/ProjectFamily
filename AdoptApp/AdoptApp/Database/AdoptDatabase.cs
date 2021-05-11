using AdoptApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptApp.Database
{
    public class AdoptDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        private SQLiteConnection _sqlconnection;
        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public AdoptDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Login).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Login)).ConfigureAwait(false);
                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(CaseWorker).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(CaseWorker)).ConfigureAwait(false);
                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Case).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Case)).ConfigureAwait(false);
                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Family).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Family)).ConfigureAwait(false);
                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Home).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Home)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public Task<List<Login>> GetLogins()
        {
            return Database.Table<Login>().ToListAsync();
        }

        public async Task<Login> GetLogin(string userName)
        {
            return await Database.Table<Login>().FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public Task<int> SaveLogin(Login login)
        {
            if (login.LoginId == 0)
                return Database.InsertAsync(login);
            else
                return Database.UpdateAsync(login);
        }

        public Home GetHome(string userName)
        {
            return _sqlconnection.Table<Home>().FirstOrDefault(t => t.UserName == userName);
        }

        public Task<int> SaveHome(Home home)
        {
            if (home.HomeId == 0)
                return Database.InsertAsync(home);
            else
                return Database.UpdateAsync(home);
        }

        public Family GetFamily(string userName)
        {
            return _sqlconnection.Table<Family>().FirstOrDefault(t => t.UserName == userName);
        }

        public Task<List<Family>> GetFamilies()
        {
            return Database.Table<Family>().ToListAsync();
        }

        public Task<int> SaveFamily(Family family)
        {
            if (family.FamilyId == 0)
                return Database.InsertAsync(family);
            else
                return Database.UpdateAsync(family);
        }

        public CaseWorker GetCaseWorker(string userName)
        {
            return _sqlconnection.Table<CaseWorker>().FirstOrDefault(t => t.UserName == userName);
        }

        public Task<List<CaseWorker>> GetCaseWorkers()
        {
            return Database.Table<CaseWorker>().ToListAsync();
        }

        public Task<int> SaveCaseWorker(CaseWorker worker)
        {
            if (worker.WorkerId == 0)
                return Database.InsertAsync(worker);
            else
                return Database.UpdateAsync(worker);
        }

        public Task<int> SaveCase(Case child)
        {
            if (child.CaseId == 0)
                return Database.InsertAsync(child);
            else
                return Database.UpdateAsync(child);
        }

        public Task<List<Case>> GetWorkerCases(string workerId)
        {
            return Database.Table<Case>().Where(t => t.CaseWorkerId == workerId).ToListAsync();
        }
        
        public async Task<Case> GetCase(int id)
        {
            return await Database.Table<Case>().FirstOrDefaultAsync(x => x.CaseId == id); 
        }

        public Task<List<Case>> GetCases()
        {
            return Database.Table<Case>().ToListAsync();
        }

        

        public Task<int> DeleteCase(Case child)
        {
            return Database.DeleteAsync(child);
        }
    }
}
