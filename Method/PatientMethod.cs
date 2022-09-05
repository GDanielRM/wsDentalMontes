using System.Collections.Generic;
using wsDentalMontes.Contexts;
using wsDentalMontes.Model;
using System.Linq;

namespace wsDentalMontes.Method
{
    public class PatientMethod
    {
        public static List<PatientModel> GetPatients(int id = 0)
        {
            using (DBDataContext db = new DBDataContext())
            {
                var data = from A in db.Patient
                           join B in db.Person on A.id_person equals B.id_person into R1
                           from item1 in R1
                           join C in db.City on item1.id_city equals C.id_city
                           join D in db.Neighborhood on item1.id_neighborhood equals D.id_neighborhood
                           join E in db.Street on item1.id_street equals E.id_street
                           join F in db.Status on A.id_status equals F.id_status
                           join G in db.PhoneNumber on item1.id_phone_number_personal equals G.id_phone_number
                           join H in db.PhoneNumber on item1.id_phone_number_emergency equals H.id_phone_number
                           select new PatientModel()
                           {
                               id_patient = A.id_patient,
                               status = new StatusModel()
                               {
                                   id_status = F.id_status,
                                   name = F.name
                               },
                               person = new PersonModel()
                               {
                                   id_person = item1.id_person,
                                   first_name = item1.first_name,
                                   middle_name = item1.middle_name,
                                   last_name = item1.last_name,
                                   second_last_name = item1.second_last_name,
                                   date_of_birth = item1.date_of_birth,
                                   email = item1.email,
                                   house_number = item1.house_number,
                                   phone_number_personal = new PhoneNumberModel()
                                   {
                                       id_phone_number = G.id_phone_number,
                                       name = G.name,
                                       phone_number = G.phone_number
                                   },
                                   phone_number_emergency = new PhoneNumberModel()
                                   {
                                       id_phone_number = H.id_phone_number,
                                       name = H.name,
                                       phone_number = H.phone_number
                                   },
                                   city = new CityModel()
                                   {
                                       id_city = C.id_city,
                                       name = C.name
                                   },
                                   neighborhood = new NeighborhoodViewModel()
                                   {
                                       id_neighborhood = D.id_neighborhood,
                                       name = D.name
                                   },
                                   street = new StreetModel()
                                   {
                                       id_street = E.id_street,
                                       name = E.name
                                   }
                               },
                           };

                if (id != 0)
                {
                    data = data.Where(x => x.id_patient == id);
                }

                return data.ToList();
            }
        }

        public static int AddPatient(PatientModel patient)
        {
            using (DBDataContext db = new DBDataContext())
            {
                int newPersonId = PersonMethod.AddPerson(patient.person);

                PatientEntity newPatient = new PatientEntity();
                newPatient.id_person = newPersonId;
                newPatient.id_status = (int)StatusEnum.Enabled;

                db.Patient.Add(newPatient);
                db.SaveChanges();

                return newPatient.id_patient;
            }
        }

        public static void SavePatient(PatientModel patient)
        {
            using (DBDataContext db = new DBDataContext())
            {
                var data = (from A in db.Patient where A.id_patient == patient.id_patient select A).FirstOrDefault();
                data.id_person = patient.VPerson(data.id_person);
                data.id_status = patient.VStatus(data.id_status);
                data.canceled_date = patient.VCancelDate(data.canceled_date);
                db.SaveChanges();

                patient.person.id_person = data.id_person;
                PersonMethod.SavePerson(patient.person);
            }
        }
    }
}
