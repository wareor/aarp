using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class OwedDetailService
    {
        private readonly IMongoCollection<OwedDetail> _owedDetailsCollection;

        // <snippet_ctor>
        public OwedDetailService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _owedDetailsCollection = mongoDatabase.GetCollection<OwedDetail>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<OwedDetail>> GetAsync() =>
            await _owedDetailsCollection.Find(_ => true).ToListAsync();

        public async Task<OwedDetail?> GetAsync(string id) =>
            await _owedDetailsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(OwedDetail newOwedDetail) =>
            await _owedDetailsCollection.InsertOneAsync(newOwedDetail);

        public async Task UpdateAsync(string id, OwedDetail updatedOwedDetail) =>
            await _owedDetailsCollection.ReplaceOneAsync(x => x.Id == id, updatedOwedDetail);

        public async Task RemoveAsync(string id) =>
            await _owedDetailsCollection.DeleteOneAsync(x => x.Id == id);
    }
}