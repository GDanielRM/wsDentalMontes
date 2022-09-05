using Microsoft.AspNetCore.Mvc;
using System;
using wsDentalMontes.Model;

namespace wsDentalMontes.Controllers
{
    [Route("[controller]")]
    public class PhoneNumberController : Controller
    {
        Response response = new Response();

        [HttpPut("save")]
        public Response Save([FromBody] PhoneNumberModel phoneNumber)
        {
            try
            {
                Method.PhoneNumberMethod.SavePhoneNumber(phoneNumber);
                //if (patient.id_patient == 0)
                //{

                //}
                //else
                //{
                //    db.Patient.Add(patient);
                //    db.SaveChanges();
                //}
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message + " | " + ex.InnerException;
            }

            return response;
        }

        [HttpGet("byIdPerson/{id}")]
        public Response GetPhoneNumberByIdPerson(int id)
        {
            try
            {
                var data = Method.PhoneNumberMethod.GetPhoneNumbers(0,id);

                response.Data = data;
                response.Message = "Numero de telefono obtenido correctamente";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message + " | " + ex.InnerException;
            }

            return response;
        }
    }
}
