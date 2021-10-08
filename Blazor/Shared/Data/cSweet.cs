using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Data
{
    public class cSweet
    {
        [Key]
        public int ID { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public double Price { set; get; }
        [Required]
        public int Availability { set; get; }
        public DateTime Date { set; get; }
        [NotMapped]
        public List<cIngrediant> Ingrediants { set; get; }
        public cSweet()
        {
            Ingrediants = new List<cIngrediant>();
            Date = DateTime.Now;
        }
    }
}
