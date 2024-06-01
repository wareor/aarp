using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class ServiceService
    {
        private readonly IMongoCollection<Account> _servicesCollection;

        // <snippet_ctor>
        public ServiceService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _servicesCollection = mongoDatabase.GetCollection<Account>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<Account>> GetAsync() =>
            await _servicesCollection.Find(_ => true).ToListAsync();

        public async Task<Account?> GetAsync(string id) =>
            await _servicesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Account newService) =>
            await _servicesCollection.InsertOneAsync(newService);

        public async Task UpdateAsync(string id, Account updatedService) =>
            await _servicesCollection.ReplaceOneAsync(x => x.Id == id, updatedService);

        public async Task RemoveAsync(string id) =>
            await _servicesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
