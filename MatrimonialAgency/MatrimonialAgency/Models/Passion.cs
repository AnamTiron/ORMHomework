using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MatrimonialAgency.Models
{
    [Table("Passion", Schema = "Agency")]
    public class Passion
    {
        [Key]
        public virtual int PassionId { get; set; }

        [Required]
        
        public virtual string Name { get; set; }

        
        public virtual decimal? YearsOfTraining { get; set; }

        //create many-to-many relationship between passion and members
        //members can have multiple passions and multiple members can share the same passion

       // [InverseProperty("MembersCluster")]
        public virtual ICollection<Member> Members { get; set; }
    }
}
