using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class PettyCashService
    {
        private readonly IMongoCollection<PettyCash> _pettyCashCollection;

        // <snippet_ctor>
        public PettyCashService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _pettyCashCollection = mongoDatabase.GetCollection<PettyCash>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<PettyCash>> GetAsync() =>
            await _pettyCashCollection.Find(_ => true).ToListAsync();

        public async Task<PettyCash?> GetAsync(string id) =>
            await _pettyCashCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(PettyCash newPettyCash) =>
            await _pettyCashCollection.InsertOneAsync(newPettyCash);

        public async Task UpdateAsync(string id, PettyCash updatedPettyCash) =>
            await _pettyCashCollection.ReplaceOneAsync(x => x.Id == id, updatedPettyCash);

        public async Task RemoveAsync(string id) =>
            await _pettyCashCollection.DeleteOneAsync(x => x.Id == id);
    }
}