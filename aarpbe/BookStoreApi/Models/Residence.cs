namespace AARP_BE.Models
{
    /// <summary>
    /// Abstraction of System Entities that correspond to a Residence which manage the interaction between 
    /// RentalUnit, Address and the list of Entities assigned to a Residence to complete the concept used in Administration Residences Private
    /// </summary>
    public class Residence
    {
        /// <summary>
        /// Correspond to RentalUnit SuitNumber
        /// </summary>
        public string? ResidenceName { get; set; }
        /// <summary>
        /// Correspond to RentalUnit Holder UserName
        /// </summary>
        public string? HolderName { get; set; }
        /// <summary>
        /// Correspond to RentalUnit Status //JALEF: pregunta aquí. Para devolver al Front End es mejor manejar la cadena de texto final en BackEnd o en FrontEnd?
        /// </summary>
        public string? Status { get; set; }
        /// <summary>
        /// Correspond to the sum of Services Payment pending to pay
        /// </summary>
        public string? TotalDebt { get; set; }
        /// <summary>
        /// RenalUnit wrapped on this residence
        /// </summary>
        public RentalUnit? RentalUnit { get; set; }
        /// <summary>
        /// Address that correspond to AddressId of the RentalUnit for this Residence
        /// </summary>
        public Address? Address { get; set; }
    }
}
