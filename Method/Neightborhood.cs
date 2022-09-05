using System.Collections.Generic;
using System.Linq;
using wsDentalMontes.Contexts;
using wsDentalMontes.Model;

namespace wsDentalMontes.Method
{
    public class Neightborhood
    {
        public static List<NeighborhoodViewModel> GetNeightborhoods()
        {
            using (DBDataContext db = new DBDataContext())
            {
                var data = from A in db.Neighborhood
                           join B in db.Status on A.id_status equals B.id_status
                           select new NeighborhoodViewModel()
                           {
                               id_neighborhood = A.id_neighborhood,
                               name = A.name,
                               status = new StatusModel()
                               {
                                   id_status = B.id_status,
                                   name = B.name
                               },
                               creation_date = A.creation_date,
                               cancel_date = A.cancel_date
                           };
                
                return data.ToList();
            }
        }
    }
}
