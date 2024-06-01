using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class PermissionService
    {
        private readonly IMongoCollection<Permission> _permissionsCollection;

        // <snippet_ctor>
        public PermissionService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _permissionsCollection = mongoDatabase.GetCollection<Permission>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<Permission>> GetAsync() =>
            await _permissionsCollection.Find(_ => true).ToListAsync();

        public async Task<Permission?> GetAsync(string id) =>
            await _permissionsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Permission newPermission) =>
            await _permissionsCollection.InsertOneAsync(newPermission);

        public async Task UpdateAsync(string id, Permission updatedPermission) =>
            await _permissionsCollection.ReplaceOneAsync(x => x.Id == id, updatedPermission);

        public async Task RemoveAsync(string id) =>
            await _permissionsCollection.DeleteOneAsync(x => x.Id == id);
    }
}