using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class RecordService
    {
        private readonly IMongoCollection<Record> _recordsCollection;

        // <snippet_ctor>
        public RecordService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _recordsCollection = mongoDatabase.GetCollection<Record>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<Record>> GetAsync() =>
            await _recordsCollection.Find(_ => true).ToListAsync();

        public async Task<Record?> GetAsync(string id) =>
            await _recordsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Record newRecord) =>
            await _recordsCollection.InsertOneAsync(newRecord);

        public async Task UpdateAsync(string id, Record updatedRecord) =>
            await _recordsCollection.ReplaceOneAsync(x => x.Id == id, updatedRecord);

        public async Task RemoveAsync(string id) =>
            await _recordsCollection.DeleteOneAsync(x => x.Id == id);
    }
}