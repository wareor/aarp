using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class AddressService
    {
        private readonly IMongoCollection<Address> _addressCollection;

        // <snippet_ctor>
        public AddressService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _addressCollection = mongoDatabase.GetCollection<Address>(
                residenceAdministratorDatabaseSettings.Value.AddressCollectionName);
        }
        // </snippet_ctor>

        public AddressService(
            IOptions<ServiceAdministratorDatabaseSettings> serviceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                serviceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                serviceAdministratorDatabaseSettings.Value.DatabaseName);

            _addressCollection = mongoDatabase.GetCollection<Address>(
                serviceAdministratorDatabaseSettings.Value.AddressCollectionName);
        }

        public async Task<List<Address>> GetAsync() =>
            await _addressCollection.Find(_ => true).ToListAsync();

        public async Task<Address?> GetAsync(string id) =>
            await _addressCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<Address> CreateAsync(Address newAddress)
        {
            await _addressCollection.InsertOneAsync(newAddress);
            return newAddress;
        }

        public async Task UpdateAsync(string id, Address updatedAddress) =>
            await _addressCollection.ReplaceOneAsync(x => x.Id == id, updatedAddress);

        public async Task RemoveAsync(string id) =>
            await _addressCollection.DeleteOneAsync(x => x.Id == id);
    }
}

