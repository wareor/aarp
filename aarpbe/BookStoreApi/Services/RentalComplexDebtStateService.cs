using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class RentalComplexDebtStateService
    {
        private readonly IMongoCollection<RentalComplexDebtState> _rentalComplexDebtStatesCollection;

        // <snippet_ctor>
        public RentalComplexDebtStateService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _rentalComplexDebtStatesCollection = mongoDatabase.GetCollection<RentalComplexDebtState>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<RentalComplexDebtState>> GetAsync() =>
            await _rentalComplexDebtStatesCollection.Find(_ => true).ToListAsync();

        public async Task<RentalComplexDebtState?> GetAsync(string id) =>
            await _rentalComplexDebtStatesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(RentalComplexDebtState newRentalComplexDebtState) =>
            await _rentalComplexDebtStatesCollection.InsertOneAsync(newRentalComplexDebtState);

        public async Task UpdateAsync(string id, RentalComplexDebtState updatedRentalComplexDebtState) =>
            await _rentalComplexDebtStatesCollection.ReplaceOneAsync(x => x.Id == id, updatedRentalComplexDebtState);

        public async Task RemoveAsync(string id) =>
            await _rentalComplexDebtStatesCollection.DeleteOneAsync(x => x.Id == id);

        public async Task<decimal> GetRentalUnitDebtState(string id)
        {
            //return await _rentalComplexDebtStatesCollection.Find(debtState =>)
            return 0;
        }
    }
}