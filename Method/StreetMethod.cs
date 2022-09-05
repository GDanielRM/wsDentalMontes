using System.Collections.Generic;
using wsDentalMontes.Contexts;
using wsDentalMontes.Model;
using System.Linq;

namespace wsDentalMontes.Method
{
    public class StreetMethod
    {
        public static List<StreetModel> GetStreets(int id = 0)
        {
            using (DBDataContext db = new DBDataContext())
            {
                var data = from A in db.Street
                           join B in db.Status on A.id_status equals B.id_status
                           select new StreetModel()
                           {
                               id_street = A.id_street,
                               name = A.name,
                               status = new StatusModel()
                               {
                                   id_status = B.id_status,
                                   name = B.name
                               },
                               creation_date = A.creation_date,
                               cancel_date = A.cancel_date
                           };

                if (id != 0)
                {
                    data = data.Where(x => x.id_street == id);
                }

                return data.ToList();
            }
        }
    }
}
