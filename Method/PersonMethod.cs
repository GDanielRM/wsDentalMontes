using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wsDentalMontes.Contexts;
using wsDentalMontes.Model;

namespace wsDentalMontes.Method
{
    public class PersonMethod
    {
        public static void SavePerson(PersonModel person)
        {
            using (DBDataContext db = new DBDataContext())
            {
                var data = (from A in db.Person where A.id_person == person.id_person select A).FirstOrDefault();
                data.first_name = person.VFirstName(data.first_name);
                data.middle_name = person.VMiddleName(data.middle_name);
                data.last_name = person.VLastName(data.last_name);
                data.second_last_name = person.VSecondLastName(data.second_last_name);
                data.date_of_birth = person.VDateOfBirth(data.date_of_birth);
                data.email = person.VEmail(data.email);
                data.id_city = person.VCity(data.id_city);
                data.id_neighborhood = person.VNeighborhood(data.id_neighborhood);
                data.id_street = person.VStreet(data.id_street);
                data.house_number = person.VHouseNumber(data.house_number);
                data.id_phone_number_personal = person.VPhoneNumberPersonal(data.id_phone_number_personal);
                data.id_phone_number_emergency = person.VPhoneNumberEmergency(data.id_phone_number_emergency);
                data.id_status = person.VStatus(data.id_status);

                person.phone_number_personal.id_phone_number = data.id_phone_number_personal;
                PhoneNumberMethod.SavePhoneNumber(person.phone_number_personal);

                person.phone_number_emergency.id_phone_number = data.id_phone_number_emergency;
                PhoneNumberMethod.SavePhoneNumber(person.phone_number_emergency);

                bool validStatus = Helpers.Tools.ValidStatus(person.status);
                if (validStatus) data.id_status = person.status.id_status;
                db.SaveChanges();
            }
        }

        public static int AddPerson(PersonModel person)
        {
            using (DBDataContext db = new DBDataContext())
            {
                person.phone_number_personal.type.id_phone_number_type = (int)PhoneNumberTypeEnum.Personal;
                int newPersonalPhoenNumberId = PhoneNumberMethod.AddPhoneNumber(person.phone_number_personal);
                person.phone_number_emergency.type.id_phone_number_type = (int)PhoneNumberTypeEnum.Emergency;
                int newEmergencyPhoenNumberId = PhoneNumberMethod.AddPhoneNumber(person.phone_number_emergency);

                PersonEntity newPerson = new PersonEntity();
                newPerson.first_name = person.first_name;
                newPerson.middle_name = person.middle_name;
                newPerson.last_name = person.last_name;
                newPerson.second_last_name = person.second_last_name;
                newPerson.date_of_birth = person.date_of_birth;
                newPerson.email = person.email;
                newPerson.id_city = person.city.id_city;
                newPerson.id_neighborhood = person.neighborhood.id_neighborhood;
                newPerson.id_street = person.street.id_street;
                newPerson.house_number = person.house_number;
                newPerson.id_phone_number_personal = newPersonalPhoenNumberId;
                newPerson.id_phone_number_emergency = newEmergencyPhoenNumberId;
                newPerson.id_status = (int)StatusEnum.Enabled;
                newPerson.creation_date = DateTime.Now;

                db.Person.Add(newPerson);
                db.SaveChanges();

                return newPerson.id_person;
            }
        }
    }
}
