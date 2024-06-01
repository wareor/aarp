using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class LogService
    {
        private readonly IMongoCollection<Log> _logsCollection;

        // <snippet_ctor>
        public LogService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _logsCollection = mongoDatabase.GetCollection<Log>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<Log>> GetAsync() =>
            await _logsCollection.Find(_ => true).ToListAsync();

        public async Task<Log?> GetAsync(string id) =>
            await _logsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Log newLog) =>
            await _logsCollection.InsertOneAsync(newLog);

        public async Task UpdateAsync(string id, Log updatedLog) =>
            await _logsCollection.ReplaceOneAsync(x => x.Id == id, updatedLog);

        public async Task RemoveAsync(string id) =>
            await _logsCollection.DeleteOneAsync(x => x.Id == id);
    }
}