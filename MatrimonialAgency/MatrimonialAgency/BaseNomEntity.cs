using System.ComponentModel.DataAnnotations;

namespace MatrimonialAgency
{
    public class BaseNomEntity
    {
        [Key]
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }
    }
}
