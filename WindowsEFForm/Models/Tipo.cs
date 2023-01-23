using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEFForm.Models
{
    [Table("Tipo")]
    public class Tipo
    {
        [Key]
        public int IDTipo { get; set; }

        public string Nombre { get; set; }

    }
}
