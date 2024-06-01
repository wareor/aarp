using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class PeripheralService
    {
        private readonly IMongoCollection<Peripheral> _peripheralsCollection;

        // <snippet_ctor>
        public PeripheralService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _peripheralsCollection = mongoDatabase.GetCollection<Peripheral>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<Peripheral>> GetAsync() =>
            await _peripheralsCollection.Find(_ => true).ToListAsync();

        public async Task<Peripheral?> GetAsync(string id) =>
            await _peripheralsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Peripheral newPeripheral) =>
            await _peripheralsCollection.InsertOneAsync(newPeripheral);

        public async Task UpdateAsync(string id, Peripheral updatedPeripheral) =>
            await _peripheralsCollection.ReplaceOneAsync(x => x.Id == id, updatedPeripheral);

        public async Task RemoveAsync(string id) =>
            await _peripheralsCollection.DeleteOneAsync(x => x.Id == id);
    }
}