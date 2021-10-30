using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Models
{
    [Table("Rent-a-car")]
    public class RentACar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentCarID { get; set; }

        [Required]
        public string RentName { get; set; }

        public int? Rating { get; set; }

        [NotMapped]
        public virtual ICollection<Car> Cars { get; set; }

        public RentACar()
        {
            Cars = new HashSet<Car>();
        }
    }
}
