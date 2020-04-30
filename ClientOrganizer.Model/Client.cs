using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientOrganizer.Model
{
    public class Client
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PartyId { get; set; }

        [Required]
        public int PartyCode { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        public long TaxCode { get; set; }

        [Required]
        public string CountryCode { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public string ClientType { get; set; }
    }
}
