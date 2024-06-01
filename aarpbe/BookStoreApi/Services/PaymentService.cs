using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class PaymentService
    {
        private readonly IMongoCollection<Payment> _paymentsCollection;

        // <snippet_ctor>
        public PaymentService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _paymentsCollection = mongoDatabase.GetCollection<Payment>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }

        public PaymentService(
            IOptions<ServiceAdministratorDatabaseSettings> serviceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                serviceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                serviceAdministratorDatabaseSettings.Value.DatabaseName);

            _paymentsCollection = mongoDatabase.GetCollection<Payment>(
                serviceAdministratorDatabaseSettings.Value.PaymentsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<Payment>> GetAsync() =>
            await _paymentsCollection.Find(_ => true).ToListAsync();

        public async Task<Payment?> GetAsync(string id) =>
            await _paymentsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Payment newPayment) =>
            await _paymentsCollection.InsertOneAsync(newPayment);

        public async Task UpdateAsync(string id, Payment updatedPayment) =>
            await _paymentsCollection.ReplaceOneAsync(x => x.Id == id, updatedPayment);

        public async Task RemoveAsync(string id) =>
            await _paymentsCollection.DeleteOneAsync(x => x.Id == id);
    }
}