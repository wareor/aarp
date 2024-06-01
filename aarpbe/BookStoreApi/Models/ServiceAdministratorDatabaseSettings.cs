namespace AARP_BE.Models
{
    public class ServiceAdministratorDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string PaymentsCollectionName { get; set; } = null!;
        public string AddressCollectionName { get; set; } = null!;
        public string RentalUnitsCollectionName { get; set; } = null!;
        public string ServicesCollectionName { get; set; } = null!;
    }
}
