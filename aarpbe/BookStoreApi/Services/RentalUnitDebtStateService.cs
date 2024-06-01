using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class RentalUnitDebtStateService
    {
        private readonly IMongoCollection<RentalUnitDebtState> _rentalUnitDebtStatesCollection;

        // <snippet_ctor>
        public RentalUnitDebtStateService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _rentalUnitDebtStatesCollection = mongoDatabase.GetCollection<RentalUnitDebtState>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<RentalUnitDebtState>> GetAsync() =>
            await _rentalUnitDebtStatesCollection.Find(_ => true).ToListAsync();

        public async Task<RentalUnitDebtState?> GetAsync(string id) =>
            await _rentalUnitDebtStatesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(RentalUnitDebtState newRentalUnitDebtState) =>
            await _rentalUnitDebtStatesCollection.InsertOneAsync(newRentalUnitDebtState);

        public async Task UpdateAsync(string id, RentalUnitDebtState updatedRentalUnitDebtState) =>
            await _rentalUnitDebtStatesCollection.ReplaceOneAsync(x => x.Id == id, updatedRentalUnitDebtState);

        public async Task RemoveAsync(string id) =>
            await _rentalUnitDebtStatesCollection.DeleteOneAsync(x => x.Id == id);
    }
}