using wsDentalMontes.Model;

namespace wsDentalMontes.Helpers
{
    public class Tools
    {
        public static bool ValidStatus(StatusModel status)
        {
            if (!(status is null))
            {
                if (status.id_status != 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
