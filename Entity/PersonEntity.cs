using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wsDentalMontes.Model
{
    [Table("person")]
    public class PersonEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_person { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string second_last_name { get; set; }
        public DateTime? date_of_birth { get; set; }
        public string email { get; set; }
        public int id_city { get; set; }
        public int id_neighborhood { get; set; }
        public int id_street { get; set; }
        public string house_number { get; set; }
        public int id_phone_number_personal { get; set; }
        public int id_phone_number_emergency { get; set; }
        public int id_status { get; set; }
        public DateTime? creation_date { get; set; }
        public DateTime? cancel_date { get; set; }
    }
}
