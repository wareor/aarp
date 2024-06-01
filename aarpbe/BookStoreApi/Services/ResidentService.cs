using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class ResidentService
    {
        private readonly IMongoCollection<Resident> _residentsCollection;

        // <snippet_ctor>
        public ResidentService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _residentsCollection = mongoDatabase.GetCollection<Resident>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<Resident>> GetAsync() =>
            await _residentsCollection.Find(_ => true).ToListAsync();

        public async Task<Resident?> GetAsync(string id) =>
            await _residentsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Resident newResident) =>
            await _residentsCollection.InsertOneAsync(newResident);

        public async Task UpdateAsync(string id, Resident updatedResident) =>
            await _residentsCollection.ReplaceOneAsync(x => x.Id == id, updatedResident);

        public async Task RemoveAsync(string id) =>
            await _residentsCollection.DeleteOneAsync(x => x.Id == id);
    }
}