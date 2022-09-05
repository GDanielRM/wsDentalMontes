using Microsoft.AspNetCore.Mvc;
using wsDentalMontes.Model;
using System;

namespace wsDentalMontes.Controllers
{
    [Route("[controller]")]
    public class NeighborhoodController : Controller
    {
        Response response = new Response();

        [HttpGet]
        public Response Get()
        {
            try
            {
                var data = Method.Neightborhood.GetNeightborhoods();

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
