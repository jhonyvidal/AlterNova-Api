using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlternovaData.Entities
{
    public class TestEntitie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Nombre { get; set; }
        [Required]
        public required string Apellido { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Genero { get; set; }
    }
}
