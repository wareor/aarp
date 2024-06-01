using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class AccountService
    {
        private readonly IMongoCollection<Account> _accountsCollection;

        // <snippet_ctor>
        public AccountService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _accountsCollection = mongoDatabase.GetCollection<Account>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<Account>> GetAsync() =>  
            await _accountsCollection.Find(_ => true).ToListAsync();

        public async Task<Account?> GetAsync(string id) =>
            await _accountsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Account newAccount) =>
            await _accountsCollection.InsertOneAsync(newAccount);

        public async Task UpdateAsync(string id, Account updatedAccount) =>
            await _accountsCollection.ReplaceOneAsync(x => x.Id == id, updatedAccount);

        public async Task RemoveAsync(string id) =>
            await _accountsCollection.DeleteOneAsync(x => x.Id == id);
    }
}

