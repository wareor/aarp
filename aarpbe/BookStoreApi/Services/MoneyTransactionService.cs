using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class MoneyTransactionService
    {
        private readonly IMongoCollection<MoneyTransaction> _moneyTransactionsCollection;

        // <snippet_ctor>
        public MoneyTransactionService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _moneyTransactionsCollection = mongoDatabase.GetCollection<MoneyTransaction>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<MoneyTransaction>> GetAsync() =>
            await _moneyTransactionsCollection.Find(_ => true).ToListAsync();

        public async Task<MoneyTransaction?> GetAsync(string id) =>
            await _moneyTransactionsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(MoneyTransaction newMoneyTransaction) =>
            await _moneyTransactionsCollection.InsertOneAsync(newMoneyTransaction);

        public async Task UpdateAsync(string id, MoneyTransaction updatedMoneyTransaction) =>
            await _moneyTransactionsCollection.ReplaceOneAsync(x => x.Id == id, updatedMoneyTransaction);

        public async Task RemoveAsync(string id) =>
            await _moneyTransactionsCollection.DeleteOneAsync(x => x.Id == id);
    }
}