using System;

namespace wsDentalMontes.Model
{
    public class PatientModel
    {
        public int id_patient { get; set; }
        public PersonModel person { get; set; }
        public StatusModel status { get; set; }
        public DateTime? cancel_date { get; set; }

        public int VPerson(int person) { return (this.person.id_person == 0) ? person : this.person.id_person; }
        public int VStatus(int status) { return (this.status.id_status == 0) ? status : this.status.id_status; }
        public DateTime? VCancelDate(DateTime? cancelDate) { return (this.cancel_date is null) ? cancelDate : this.cancel_date; }
    }

}
