using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class AppPaymentService
    {
        private readonly IMongoCollection<AppPayment> _appPaymentsCollection;

        // <snippet_ctor>
        public AppPaymentService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _appPaymentsCollection = mongoDatabase.GetCollection<AppPayment>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<AppPayment>> GetAsync() =>
            await _appPaymentsCollection.Find(_ => true).ToListAsync();

        public async Task<AppPayment?> GetAsync(string id) =>
            await _appPaymentsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(AppPayment newAppPayment) =>
            await _appPaymentsCollection.InsertOneAsync(newAppPayment);

        public async Task UpdateAsync(string id, AppPayment updatedAppPayment) =>
            await _appPaymentsCollection.ReplaceOneAsync(x => x.Id == id, updatedAppPayment);

        public async Task RemoveAsync(string id) =>
            await _appPaymentsCollection.DeleteOneAsync(x => x.Id == id);
    }
}