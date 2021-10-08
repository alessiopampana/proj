using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Data
{
    public class cUser
    {
        [Key]
        public int ID { set; get; }
        [Required]
        public string Username { set; get; }
        [Required]
        public string Password { set; get; }
        [NotMapped]
        public bool IsLogged { get { return !string.IsNullOrEmpty(Username); } }
    }
}
