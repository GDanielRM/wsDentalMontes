using System.Collections.Generic;
using System.Linq;
using wsDentalMontes.Contexts;
using wsDentalMontes.Model;

namespace wsDentalMontes.Method
{
    public class PhoneNumberMethod
    {
        public static List<PhoneNumberModel> GetPhoneNumbers(int idPhoneNumber = 0, int idPerson = 0)
        {
            using (DBDataContext db = new DBDataContext())
            {
                var data = from A in db.PhoneNumber
                           join B in db.PhoneNumberType on A.id_type equals B.id_phone_number_type
                           join C in db.Status on A.id_status equals C.id_status
                           select new PhoneNumberModel()
                           {
                               id_phone_number = A.id_phone_number,
                               type = new PhoneNumberTypeModel()
                               {
                                   id_phone_number_type = B.id_phone_number_type,
                                   name = B.name
                               },
                               name = A.name,
                               phone_number = A.phone_number,
                               status = new StatusModel()
                               {
                                   id_status = C.id_status,
                                   name = C.name
                               },
                               cancel_date = A.cancel_date
                           };

                if (idPhoneNumber != 0)
                {
                    data = data.Where(x => x.id_phone_number == idPhoneNumber);
                }

                return data.ToList();
            }
        }

        public static void SavePhoneNumber(PhoneNumberModel phoneNumber)
        {
            using (DBDataContext db = new DBDataContext())
            {
                var data = (from A in db.PhoneNumber where A.id_phone_number == phoneNumber.id_phone_number select A).FirstOrDefault();
                data.id_type = phoneNumber.VType(data.id_type);
                data.name = phoneNumber.VName(data.name);
                data.phone_number = phoneNumber.VPhoneNumber(data.phone_number);
                data.id_status = phoneNumber.VStatus(data.id_status);
                data.cancel_date = phoneNumber.VCancelDate(data.cancel_date);
                data.id_status = phoneNumber.VStatus(data.id_status);
                db.SaveChanges();
            }
        }

        public static int AddPhoneNumber(PhoneNumberModel phoneNumber)
        {
            using (DBDataContext db = new DBDataContext())
            {
                PhoneNumberEntity newPhoneNumber = new PhoneNumberEntity();
                newPhoneNumber.id_type = phoneNumber.type.id_phone_number_type;
                newPhoneNumber.name = phoneNumber.name;
                newPhoneNumber.phone_number = phoneNumber.phone_number;
                newPhoneNumber.id_status = (int)StatusEnum.Enabled;
                newPhoneNumber.cancel_date = phoneNumber.cancel_date;

                db.PhoneNumber.Add(newPhoneNumber);
                db.SaveChanges();

                return newPhoneNumber.id_phone_number;
            }
        }
    }
}
