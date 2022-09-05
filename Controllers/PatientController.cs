using Microsoft.AspNetCore.Mvc;
using System;
using wsDentalMontes.Model;

namespace wsDentalMontes.Controllers
{
    [Route("[controller]")]
    public class PatientController : Controller
    {
        Response response = new Response();

        [HttpGet]
        public Response Get()
        {
            try
            {
                var data = Method.PatientMethod.GetPatients();

                response.Data = data;
                response.Message = "Pacientes obtenidos correctamente";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message + " | " + ex.InnerException;
            }

            return response;
        }

        [HttpGet("{id}")]
        public Response GetPatientById(int id)
        {
           try
           {
                var data = Method.PatientMethod.GetPatients(id);

                response.Data = data;
                response.Message = "Paciente obtenido correctamente";
           }
           catch (Exception ex)
           {
                response.Status = false;
                response.Message = ex.Message + " | " + ex.InnerException;
           }

            return response;
        }

        [HttpPut("save")]
        public Response Save([FromBody] PatientModel patient)
        {
            try
            {
                if (patient.person.first_name == "")
                {
                    throw new Exception("El primer nombre no puede estar vacio");
                }

                if (patient.person.last_name == "")
                {
                    throw new Exception("El apellido paterno no puede estar vacio");
                }

                if (patient.person.second_last_name == "")
                {
                    throw new Exception("El apellido materno no puede estar vacio");
                }

                if (patient.person.date_of_birth is null)
                {
                    throw new Exception("La fecha de nacimiento no puede estar vacia");
                }

                if (patient.person.city.id_city == 0)
                {
                    throw new Exception("Ciudad no definida");
                }

                if (patient.person.neighborhood.id_neighborhood == 0)
                {
                    throw new Exception("Colonia no definida");
                }

                if (patient.person.street.id_street == 0)
                {
                    throw new Exception("Calle no definida");
                }

                if (patient.person.house_number == "")
                {
                    throw new Exception("El numero de casa no puede estar vacio");
                }

                if (patient.person.email == "")
                {
                    throw new Exception("El email no puede estar vacio");
                }

                if (patient.person.phone_number_personal.phone_number == "")
                {
                    throw new Exception("El numero de telefono personal no puede estar vacio");
                }

                if (patient.person.phone_number_emergency.name == "")
                {
                    throw new Exception("El nombre del telefono de emergencia no puede estar vacio");
                }

                if (patient.person.phone_number_emergency.phone_number == "")
                {
                    throw new Exception("El numero de telefono de emergencia no puede estar vacio");
                }

                if (patient.id_patient == 0)
                {
                    Method.PatientMethod.AddPatient(patient);
                    response.Message = "Paciente creado con exito";
                }
                else
                {
                    Method.PatientMethod.SavePatient(patient);
                    response.Message = "Paciente guardado con exito";
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message + " | " + ex.InnerException;
            }

            return response;
        }

        [Route("enable")]
        [HttpPatch]
        public Response Enable(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Numero de pasiente no definido");
                }

                var data = Method.PatientMethod.GetPatients(id);
                data[0].status.id_status = (int)StatusEnum.Enabled;
                Method.PatientMethod.SavePatient(data[0]);

                response.Message = "Paciente habilitado correctamente";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message + " | " + ex.InnerException;
            }

            return response;
        }

        [Route("disable")]
        [HttpPatch]
        public Response Disable(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Numero de pasiente no definido");
                }

                var data = Method.PatientMethod.GetPatients(id);
                data[0].status.id_status = (int)StatusEnum.Disabled;
                Method.PatientMethod.SavePatient(data[0]);

                response.Message = "Paciente deshabilitado correctamente";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message + " | " + ex.InnerException;
            }

            return response;
        }

        [Route("delete")]
        [HttpPatch]
        public Response Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Numero de pasiente no definido");
                }

                var data = Method.PatientMethod.GetPatients(id);
                data[0].status.id_status = (int)StatusEnum.Deleted;
                Method.PatientMethod.SavePatient(data[0]);

                response.Message = "Paciente eliminado correctamente";
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
