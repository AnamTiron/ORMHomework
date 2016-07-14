
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MatrimonialAgency.Models
{
    [Table("Location", Schema = "Agency")]
    public  class Location
    {
        [Key]
        public virtual int LocationId { get; set; }

        [Required]
        [MaxLength(30)]
        [Index("UX_CityAndPostalCode", 1, IsUnique = true)]
        public virtual string City { get; set; }

        [Index("UX_CityAndPostalCode", 2, IsUnique = true)]
        [MaxLength(30)]
        public virtual string PostalCode { get; set; }

        public virtual string StateProvince { get; set; }
    }
}
