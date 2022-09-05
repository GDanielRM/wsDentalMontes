using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wsDentalMontes.Model
{
    [Table("cat_phone_number_type")]
    public class PhoneNumberTypeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_phone_number_type { get; set; }
        public string name { get; set; }
    }
}

public enum PhoneNumberTypeEnum
{
    Personal = 1,
    Emergency = 2
}