using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Data
{
    public class cIngrediant
    {
        [Key]
        public int ID { set; get; }
        [ForeignKey("SweetID")]
        public int SweetID { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public double Amount { set; get; }
        [Required]
        public string UnitOfMeasure { set; get; }
    }
}
