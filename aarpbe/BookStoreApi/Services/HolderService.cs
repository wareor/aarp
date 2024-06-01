using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class HolderService
    {
        private readonly IMongoCollection<Holder> _holdersCollection;

        // <snippet_ctor>
        public HolderService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _holdersCollection = mongoDatabase.GetCollection<Holder>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<Holder>> GetAsync() =>
            await _holdersCollection.Find(_ => true).ToListAsync();

        public async Task<Holder?> GetAsync(string id) =>
            await _holdersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Holder newHolder) =>
            await _holdersCollection.InsertOneAsync(newHolder);

        public async Task UpdateAsync(string id, Holder updatedHolder) =>
            await _holdersCollection.ReplaceOneAsync(x => x.Id == id, updatedHolder);

        public async Task RemoveAsync(string id) =>
            await _holdersCollection.DeleteOneAsync(x => x.Id == id);
    }
}