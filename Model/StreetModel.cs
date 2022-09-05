using System;

namespace wsDentalMontes.Model
{
    public class StreetModel
    {
        public int id_street { get; set; }
        public string name { get; set; }
        public StatusModel status { get; set; }
        public DateTime? creation_date { get; set; }
        public DateTime? cancel_date { get; set; }
    }
}
