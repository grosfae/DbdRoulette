using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("Difficulty")]
    public class Difficulty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Killer> Killer { get; set; }
        //public virtual ICollection<Survivor> Survivor { get; set; }
    }
}
