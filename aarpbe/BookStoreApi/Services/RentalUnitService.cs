// <snippet_File>
using AARP_BE.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AARP_BE.Services;

public class RentalUnitService
{
    private readonly IMongoCollection<RentalUnit> _rentalUnitsCollection;

    // <snippet_ctor>
    public RentalUnitService(
        IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            residenceAdministratorDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            residenceAdministratorDatabaseSettings.Value.DatabaseName);

        _rentalUnitsCollection = mongoDatabase.GetCollection<RentalUnit>(
            residenceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
    }
    // </snippet_ctor>

    public RentalUnitService(
        IOptions<ServiceAdministratorDatabaseSettings> serviceAdministratorDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            serviceAdministratorDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            serviceAdministratorDatabaseSettings.Value.DatabaseName);

        _rentalUnitsCollection = mongoDatabase.GetCollection<RentalUnit>(
            serviceAdministratorDatabaseSettings.Value.RentalUnitsCollectionName);
    }

    public async Task<List<RentalUnit>> GetAsync() =>
        await _rentalUnitsCollection.Find(_ => true).ToListAsync();

    public async Task<RentalUnit?> GetAsync(string id) =>
        await _rentalUnitsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<RentalUnit> CreateAsync(RentalUnit newRentalUnit)
    {
        await _rentalUnitsCollection.InsertOneAsync(newRentalUnit);
        return newRentalUnit;
    }

    public async Task UpdateAsync(string id, RentalUnit updatedResidence) =>
        await _rentalUnitsCollection.ReplaceOneAsync(x => x.Id == id, updatedResidence);

    public async Task RemoveAsync(string id) =>
        await _rentalUnitsCollection.DeleteOneAsync(x => x.Id == id);
}
// </snippet_File>
