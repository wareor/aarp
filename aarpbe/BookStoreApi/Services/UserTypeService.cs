using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class UserTypeService
    {
        private readonly IMongoCollection<UserType> _userTypesCollection;

        // <snippet_ctor>
        public UserTypeService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _userTypesCollection = mongoDatabase.GetCollection<UserType>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<UserType>> GetAsync() =>
            await _userTypesCollection.Find(_ => true).ToListAsync();

        public async Task<UserType?> GetAsync(string id) =>
            await _userTypesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(UserType newUserType) =>
            await _userTypesCollection.InsertOneAsync(newUserType);

        public async Task UpdateAsync(string id, UserType updatedUserType) =>
            await _userTypesCollection.ReplaceOneAsync(x => x.Id == id, updatedUserType);

        public async Task RemoveAsync(string id) =>
            await _userTypesCollection.DeleteOneAsync(x => x.Id == id);
    }
}