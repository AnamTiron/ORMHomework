using MatrimonialAgency.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MatrimonialAgency.Models
{
    [Table("Members", Schema = "Agency")]
   public class Member
    {
        [Key]
        public virtual long MemberId { get; set; }

        public virtual string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public virtual DateTime DateOfBirth { get; set; }

        
        public virtual int? GenderId { get; set; }
        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }



        public virtual string InterestedIn { get; set; }

        public virtual int? LocationId { get; set; }
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        //create many-to-many relationship between passion and members
        //members can have multiple passions and multiple members can share the same passion

        //[InverseProperty("PassionCluster")]
        /*The InversePropertyAttribute on property 'Passions' on type 'MatrimonialAgency.Models.Member' is not valid.
         *  The property 'PassionCluster' is not a valid navigation property on the related type 'MatrimonialAgency.Models.Passion'.
         *   Ensure that the property exists and is a valid reference or collection navigation property.
         *   
         *   Nu am reusit sa rezolv aceasta eroare.
         */
        public virtual ICollection<Passion> Passions { get; set; }


        [Required]
        [MaxLength(25)]
        [Index("UX_Email", IsUnique = true)]
        public virtual string Email { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual DateTime? DateOfJoining { get; set; }

        //M. Crearea unei proprietati intr-una din clasele atasate la context, 
        //care sa nu ajunga in tabela corespunzatoare 
        [NotMapped]
        public string FullName { get { return FirstName + ' ' + LastName; } }

    }
}
