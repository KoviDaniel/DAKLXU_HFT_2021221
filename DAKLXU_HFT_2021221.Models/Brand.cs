using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Models
{
    [Table("Brands")]
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandID { get; set; }

        [MaxLength(50)]
        [Required]
        public string BrandName { get; set; }

        [NotMapped]
        public virtual ICollection<Car> Cars { get; set; }

        public Brand() {
            Cars = new HashSet<Car>();
        }
    }
}
