using System.Collections.Generic;
using wsDentalMontes.Contexts;
using System.Linq;
using wsDentalMontes.Model;

namespace wsDentalMontes.Method
{
    public class CityMethod
    {
        public static List<CityModel> GetCities()
        {
            using (DBDataContext db = new DBDataContext())
            {
                var data = from A in db.City
                           join B in db.Status on A.id_status equals B.id_status
                           select new CityModel()
                           {
                               id_city = A.id_city,
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

        public static void SaveCity(CityModel city)
        {
            using (DBDataContext db = new DBDataContext())
            {
                var data = (from A in db.City where A.id_city == city.id_city select A).FirstOrDefault();
                data.name = city.name;
                data.id_status = city.status.id_status;
                data.creation_date = city.creation_date;
                data.cancel_date = city.cancel_date;
                db.SaveChanges();
            }
        }
    }
}
