using System.Net.Http;
using System.Text;

namespace wsDentalMontes.Tools
{
    public class Tools
    {
        internal static void SetResponseContent(ref HttpResponseMessage Response, string JsonString)
        {
            Response.Content = new StringContent(
                JsonString,
                Encoding.UTF8,
                "application/json"
            );
        }
    }

    //public static DataTable CommandStringToDataTable(string CommandString)
    //{
    //    DBConectionModels connection = new DBConectionModels();

    //    SqlCommand Command = new SqlCommand();
    //    Command.CommandText = CommandString;
    //    SqlConnection cn = new SqlConnection(connection.conection.ConnectionString);
    //    Command.CommandType = CommandType.Text;
    //    Command.Connection = cn;
    //    Command.CommandTimeout = 0;
    //    SqlDataAdapter adp = new SqlDataAdapter(Command);
    //    DataTable Resultado = new DataTable();
    //    adp.Fill(Resultado);
    //    return Resultado;
    //}
}
