using System;

namespace wsDentalMontes.Model
{
    public class PersonModel
    {
        public int id_person { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string second_last_name { get; set; }
        public DateTime? date_of_birth { get; set; }
        public string email { get; set; }
        public CityModel city { get; set; }
        public NeighborhoodViewModel neighborhood { get; set; }
        public StreetModel street { get; set; }
        public string house_number { get; set; }
        public PhoneNumberModel phone_number_personal { get; set; }
        public PhoneNumberModel phone_number_emergency { get; set; }
        public StatusModel status { get; set; }

        public string VFirstName(string firstName) { return (this.first_name is null || this.first_name == "") ? firstName : this.first_name; }
        public string VMiddleName(string middleName) { return (this.middle_name is null || this.middle_name == "") ? middleName : this.middle_name; }
        public string VLastName(string lastName) { return (this.last_name is null || this.last_name == "") ? lastName : this.last_name; }
        public string VSecondLastName(string secondLastName) { return (this.second_last_name is null || this.second_last_name == "") ? secondLastName : this.second_last_name; }
        public DateTime? VDateOfBirth(DateTime? dateOfBirth) { return (this.date_of_birth is null) ? dateOfBirth : this.date_of_birth; }
        public string VEmail(string email) { return (this.email is null || this.email == "") ? email : this.email; }
        public int VCity(int city) { return (this.city.id_city == 0) ? city : this.city.id_city; }
        public int VNeighborhood(int neighborhood) { return (this.neighborhood.id_neighborhood == 0) ? neighborhood : this.neighborhood.id_neighborhood; }
        public int VStreet(int street) { return (this.street.id_street == 0) ? street : this.street.id_street; }
        public string VHouseNumber(string houseNumber) { return (this.house_number is null || this.house_number == "") ? houseNumber : this.house_number; }
        public int VPhoneNumberPersonal(int phoneNumberPersonal) { return (this.phone_number_personal.id_phone_number == 0) ? phoneNumberPersonal : this.phone_number_personal.id_phone_number; }
        public int VPhoneNumberEmergency(int phoneNumberEmergency) { return (this.phone_number_emergency.id_phone_number == 0) ? phoneNumberEmergency : this.phone_number_emergency.id_phone_number; }
        public int VStatus(int status) { return (this.status is null || this.status.id_status == 0) ? status : this.status.id_status; }
    }
}
