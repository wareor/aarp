using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class PeripheralsTypeService
    {
        private readonly IMongoCollection<PeripheralsType> _peripheralsTypesCollection;

        // <snippet_ctor>
        public PeripheralsTypeService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _peripheralsTypesCollection = mongoDatabase.GetCollection<PeripheralsType>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<PeripheralsType>> GetAsync() =>
            await _peripheralsTypesCollection.Find(_ => true).ToListAsync();

        public async Task<PeripheralsType?> GetAsync(string id) =>
            await _peripheralsTypesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(PeripheralsType newPeripheralsType) =>
            await _peripheralsTypesCollection.InsertOneAsync(newPeripheralsType);

        public async Task UpdateAsync(string id, PeripheralsType updatedPeripheralsType) =>
            await _peripheralsTypesCollection.ReplaceOneAsync(x => x.Id == id, updatedPeripheralsType);

        public async Task RemoveAsync(string id) =>
            await _peripheralsTypesCollection.DeleteOneAsync(x => x.Id == id);
    }
}