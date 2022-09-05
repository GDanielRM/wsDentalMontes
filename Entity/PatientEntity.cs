using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wsDentalMontes.Model
{
    [Table("patients")]
    public class PatientEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_patient { get; set; }
        public int id_person{ get; set; }
        public int id_status { get; set; }
        public DateTime? canceled_date { get; set; }
    }
}
