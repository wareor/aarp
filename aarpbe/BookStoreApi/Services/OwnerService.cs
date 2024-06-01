using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class OwnerService
    {
        private readonly IMongoCollection<Owner> _ownersCollection;

        // <snippet_ctor>
        public OwnerService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _ownersCollection = mongoDatabase.GetCollection<Owner>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<Owner>> GetAsync() =>
            await _ownersCollection.Find(_ => true).ToListAsync();

        public async Task<Owner?> GetAsync(string id) =>
            await _ownersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Owner newOwner) =>
            await _ownersCollection.InsertOneAsync(newOwner);

        public async Task UpdateAsync(string id, Owner updatedOwner) =>
            await _ownersCollection.ReplaceOneAsync(x => x.Id == id, updatedOwner);

        public async Task RemoveAsync(string id) =>
            await _ownersCollection.DeleteOneAsync(x => x.Id == id);
    }
}