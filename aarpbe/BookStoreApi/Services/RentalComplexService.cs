using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class RentalComplexService
    {
        private readonly IMongoCollection<RentalComplex> _rentalComplexsCollection;

        // <snippet_ctor>
        public RentalComplexService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _rentalComplexsCollection = mongoDatabase.GetCollection<RentalComplex>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<RentalComplex>> GetAsync() =>
            await _rentalComplexsCollection.Find(_ => true).ToListAsync();

        public async Task<RentalComplex?> GetAsync(string id) =>
            await _rentalComplexsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(RentalComplex newRentalComplex) =>
            await _rentalComplexsCollection.InsertOneAsync(newRentalComplex);

        public async Task UpdateAsync(string id, RentalComplex updatedRentalComplex) =>
            await _rentalComplexsCollection.ReplaceOneAsync(x => x.Id == id, updatedRentalComplex);

        public async Task RemoveAsync(string id) =>
            await _rentalComplexsCollection.DeleteOneAsync(x => x.Id == id);
    }
}