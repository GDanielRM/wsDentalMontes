using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wsDentalMontes.Model
{
    [Table("cat_cities")]
    public class CityEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_city { get; set; }
        public string name { get; set; }
        public int id_status { get; set; }
        public DateTime? creation_date { get; set; }
        public DateTime? cancel_date { get; set; }
    }
}
