using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class ClientService
    {
        private readonly IMongoCollection<Client> _clientsCollection;

        // <snippet_ctor>
        public ClientService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _clientsCollection = mongoDatabase.GetCollection<Client>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<Client>> GetAsync() =>
            await _clientsCollection.Find(_ => true).ToListAsync();

        public async Task<Client?> GetAsync(string id) =>
            await _clientsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Client newClient) =>
            await _clientsCollection.InsertOneAsync(newClient);

        public async Task UpdateAsync(string id, Client updatedClient) =>
            await _clientsCollection.ReplaceOneAsync(x => x.Id == id, updatedClient);

        public async Task RemoveAsync(string id) =>
            await _clientsCollection.DeleteOneAsync(x => x.Id == id);
    }
}