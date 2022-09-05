using Microsoft.AspNetCore.Mvc;
using System;
using wsDentalMontes.Model;

namespace wsDentalMontes.Controllers
{
    [Route("[controller]")]
    public class CityController : Controller
    {
        Response response = new Response();

        [HttpGet]
        public Response Get()
        {
            try
            {
                var data = Method.CityMethod.GetCities();

                response.Data = data;
                response.Message = "Colonias obtenidas correctamente";
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
