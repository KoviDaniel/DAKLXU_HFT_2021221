using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAKLXU_HFT_2021221.Models
{
    [Table("Cars")]
    public class Car
    {
        //car ID property
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarID { get; set; }

        public int BrandId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Brand Brand { get; set; }

        public int RentCarID { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual RentACar RentACar { get; set; }

        [MaxLength(150)]
        [Required]
        public string Model { get; set; }

        public int RentPrice { get; set; }

        public string Colour { get; set; }

        public bool CarInsurance { get; set; }

        public int? RunnedKM { get; set; }

        public override string ToString()
        {
            return $"{this.Model}, {this.RentPrice}, {Colour}, {CarInsurance}, {RunnedKM}";
        }

    }
}
