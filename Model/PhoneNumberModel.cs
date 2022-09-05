using System;

namespace wsDentalMontes.Model
{
    public class PhoneNumberModel
    {
        public int id_phone_number { get; set; }
        public PhoneNumberTypeModel type {get;set; }
        public string name { get; set; }
        public string phone_number { get; set; }
        public StatusModel status { get; set; }
        public DateTime? cancel_date { get; set; }

        public int VType(int type) { return (this.type is null || this.type.id_phone_number_type == 0) ? type : this.type.id_phone_number_type; }
        public string VName(string name) { return (this.name is null || this.name == "") ? name : this.name; }
        public string VPhoneNumber(string phoenNumber) { return (this.phone_number is null || this.phone_number == "") ? phoenNumber : this.phone_number; }
        public int VStatus(int status) { return (this.status is null || this.status.id_status == 0) ? status : this.status.id_status; }
        public DateTime? VCancelDate(DateTime? cancelDate) { return (this.cancel_date is null) ? cancelDate : this.cancel_date; }
    }
}
