using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wsDentalMontes.Model
{
    [Table("cat_status")]
    public class StatusEntity
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_status { get; set; }
        public string name { get; set; }

        public static string GetStatusString(int id)
        {
            string status = "";
            switch (id)
            {
                case (int)StatusEnum.Enabled: status = "ACTIVO";
                    break;
                case (int)StatusEnum.Disabled: status = "INACTIVO";
                    break;
                case (int)StatusEnum.Deleted: status = "ELIMINADO";
                    break;
            }

            return status;
        }
    }

    public enum StatusEnum
    {
        Enabled = 1,
        Disabled = 2,
        Deleted = 99
    }
}
