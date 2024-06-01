using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services
{
    public class DiscountService
    {
        private readonly IMongoCollection<Discount> _discountsCollection;

        // <snippet_ctor>
        public DiscountService(
            IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                residenceAdministratorDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                residenceAdministratorDatabaseSettings.Value.DatabaseName);

            _discountsCollection = mongoDatabase.GetCollection<Discount>(
                residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<Discount>> GetAsync() =>
            await _discountsCollection.Find(_ => true).ToListAsync();

        public async Task<Discount?> GetAsync(string id) =>
            await _discountsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Discount newDiscount) =>
            await _discountsCollection.InsertOneAsync(newDiscount);

        public async Task UpdateAsync(string id, Discount updatedDiscount) =>
            await _discountsCollection.ReplaceOneAsync(x => x.Id == id, updatedDiscount);

        public async Task RemoveAsync(string id) =>
            await _discountsCollection.DeleteOneAsync(x => x.Id == id);
    }
}