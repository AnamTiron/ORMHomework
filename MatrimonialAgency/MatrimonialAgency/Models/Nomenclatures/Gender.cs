using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MatrimonialAgency.Models.Nomenclatures
{
    [Table("Gender", Schema = "Nom")]
    public class Gender
        //
    {
        [Key]
        public virtual int GenderId { get; set; }

        public virtual string Name { get; set; }

    }
}
