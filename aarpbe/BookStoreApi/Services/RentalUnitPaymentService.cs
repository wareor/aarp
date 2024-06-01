using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class RentalUnitPaymentService
    {
        private readonly IMongoCollection<RentalUnitPayment> _rentalUnitPaymentsCollection;

        // <snippet_ctor>
        public RentalUnitPaymentService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _rentalUnitPaymentsCollection = mongoDatabase.GetCollection<RentalUnitPayment>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<RentalUnitPayment>> GetAsync() =>
            await _rentalUnitPaymentsCollection.Find(_ => true).ToListAsync();

        public async Task<RentalUnitPayment?> GetAsync(string id) =>
            await _rentalUnitPaymentsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(RentalUnitPayment newRentalUnitPayment) =>
            await _rentalUnitPaymentsCollection.InsertOneAsync(newRentalUnitPayment);

        public async Task UpdateAsync(string id, RentalUnitPayment updatedRentalUnitPayment) =>
            await _rentalUnitPaymentsCollection.ReplaceOneAsync(x => x.Id == id, updatedRentalUnitPayment);

        public async Task RemoveAsync(string id) =>
            await _rentalUnitPaymentsCollection.DeleteOneAsync(x => x.Id == id);
    }
}