using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wsDentalMontes.Model
{
    [Table("phone_number")]
    public class PhoneNumberEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_phone_number { get; set; }
        public int id_type { get; set; }
        public string name { get; set; }
        public string phone_number { get; set; }
        public int id_status { get; set; }
        public DateTime? cancel_date { get; set; }
    }
}
