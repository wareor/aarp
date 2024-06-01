using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class ServiceTypeService
    {
        private readonly IMongoCollection<ServiceType> _serviceTypesCollection;

        // <snippet_ctor>
        public ServiceTypeService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _serviceTypesCollection = mongoDatabase.GetCollection<ServiceType>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<ServiceType>> GetAsync() =>
            await _serviceTypesCollection.Find(_ => true).ToListAsync();

        public async Task<ServiceType?> GetAsync(string id) =>
            await _serviceTypesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ServiceType newServiceType) =>
            await _serviceTypesCollection.InsertOneAsync(newServiceType);

        public async Task UpdateAsync(string id, ServiceType updatedServiceType) =>
            await _serviceTypesCollection.ReplaceOneAsync(x => x.Id == id, updatedServiceType);

        public async Task RemoveAsync(string id) =>
            await _serviceTypesCollection.DeleteOneAsync(x => x.Id == id);
    }
}