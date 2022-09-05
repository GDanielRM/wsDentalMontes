using System;

namespace wsDentalMontes.Model
{
    public class CityModel
    {
        public int id_city { get; set; }
        public string name { get; set; }
        public StatusModel status { get; set; }
        public DateTime? creation_date { get; set; }
        public DateTime? cancel_date { get; set; }
    }
}
