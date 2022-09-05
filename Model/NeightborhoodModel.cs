using System;

namespace wsDentalMontes.Model
{
    public class NeighborhoodViewModel
    {
            public int id_neighborhood { get; set; }
            public string name { get; set; }
            public StatusModel status { get; set; }
            public DateTime? creation_date { get; set; }
            public DateTime? cancel_date { get; set; }
    }
}
